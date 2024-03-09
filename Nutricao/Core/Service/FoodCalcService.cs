﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nutricao.Core.Dtos;
using Nutricao.Core.Dtos.Context;
using Nutricao.Core.Dtos.Refeicao;
using Nutricao.Core.Interfaces;
using Nutricao.Core.OtherObjects;
using Nutricao.Exceptions;
using Nutricao.Models;

namespace Nutricao.Core.Service
{
    public class FoodCalcService : IFoodCalc
    {
        private readonly RefeicaoContext _context;
        private readonly IFoodInfomation _foodInformation;

        public FoodCalcService(RefeicaoContext context, IFoodInfomation foodInformation)
        {
            _context = context;
            _foodInformation = foodInformation;
        }
        public async Task<FoodServiceResponseDto> CadastrarVariasRef([FromBody] CreateRefeicaoDto refeicaoDto)
        {
            List<FoodServiceResponseDto> informacoes = new List<FoodServiceResponseDto>();
            string[] nomesSeperados = refeicaoDto.Nome.Split(';');

            foreach (var nome in nomesSeperados)
            {
                try
                {
                    var informacao = await _foodInformation.FoodDetailSearchByName(nome);
                    var refeicao = new RefeicaoMVN
                    {
                        Nome = informacao.Food.Nome,
                        Carboidratos = informacao.Food.Carboidratos,
                        Proteinas = informacao.Food.Proteinas,
                        Lipidios = informacao.Food.Lipidios,
                        Calorias = informacao.Food.Calorias,
                        Fibra = informacao.Food.Fibra_Alimentar,
                        Dia = refeicaoDto.Dia,
                        Mes = refeicaoDto.Mes,
                        Ano = refeicaoDto.Ano,
                        IsMatinal = refeicaoDto.IsMatinal,
                        IsVespertina = refeicaoDto.IsVespertina,
                        IsNoturna = refeicaoDto.IsNoturna,
                        Posicao = refeicaoDto.Posicao
                    };

                    MainCallException.ValidarPeriodo(refeicaoDto.Dia, refeicaoDto.Mes, refeicaoDto.IsMatinal, refeicaoDto.IsVespertina, refeicaoDto.IsNoturna);

                    if (refeicao.IsMatinal || refeicao.IsVespertina || refeicao.IsNoturna)
                    {
                        _context.RefeicaoMVN.Add(refeicao);
                        await _context.SaveChangesAsync();
                        informacoes.Add(informacao);
                    }
                }
                catch (InvalidPeriodException ex)
                {
                    return new FoodServiceResponseDto
                    {
                        IsSuccess = false,
                        StatusCode = 500,
                        Message = $"Erro ao cadastrar refeição {ex.Message}"
                    };
                }
            }
            return new FoodServiceResponseDto
            {
                IsSuccess = true,
                StatusCode = 201,
                Message = "Operacao realizada com sucesso"
            };
        }
        public async Task<FoodServiceResponseDto> CalculoTotal([FromQuery] ReadRefeicaoDto refeicao)
        {
            try
            {
                var ListaDeRefeicao = await GetRefeicao(refeicao);

                var total = new CalculoDaRefeicao
                {
                    TotalCarboidratos = RefeicaoMVN.CalcularTotalCarboidratos(ListaDeRefeicao),
                    TotalProteinas = RefeicaoMVN.CalcularTotalProteinas(ListaDeRefeicao),
                    TotalGorduras = RefeicaoMVN.CalcularTotalLipidios(ListaDeRefeicao),
                    TotalCalorias = RefeicaoMVN.CalcularTotalCalorias(ListaDeRefeicao),
                    TotalFibras = RefeicaoMVN.CalcularTotalFibras(ListaDeRefeicao),
                    Dia = refeicao.Dia,
                    Mes = refeicao.Mes,
                    Ano = refeicao.Ano
                };
                _context.Refeicao.Add(total);
                await _context.SaveChangesAsync();
                return new FoodServiceResponseDto
                {
                    IsSuccess = true,
                    StatusCode = 201,
                    Message = $"Calculo nutricional feito com sucesso para o dia {refeicao.Dia}/{refeicao.Mes}/{refeicao.Ano}"
                };
            }
            catch (Exception ex)
            {
                return new FoodServiceResponseDto
                {
                    IsSuccess = false,
                    StatusCode = 500,
                    Message = $"Erro ao calcular o total da refeição: {ex.Message}"
                };
            }
        }
        public async Task<FoodServiceResponseDto> CalcularTotalRefeicaoPelaPosicao([FromQuery] ReadRefeicaoDto refeicao, int lugar)
        {
            try
            {
                var query = await GetRefeicaoByPlace(refeicao, lugar);

                var refe = new Nutrients
                {
                    Nome = $"Total refei {lugar}",
                    Carboidratos = RefeicaoMVN.CalcularTotalCarboidratos(query),
                    Proteinas = RefeicaoMVN.CalcularTotalProteinas(query),
                    Calorias = RefeicaoMVN.CalcularTotalCalorias(query),
                    Lipidios = RefeicaoMVN.CalcularTotalLipidios(query),
                    Fibra_Alimentar = RefeicaoMVN.CalcularTotalFibras(query),
                };
                return new FoodServiceResponseDto
                {
                    IsSuccess = true,
                    StatusCode = 200,
                    Message = $"Sua {lugar}° refeição somou esses nutrientes",
                    Food = refe
                };
            }
            catch (Exception ex)
            {
                return new FoodServiceResponseDto
                {
                    IsSuccess = false,
                    StatusCode = 500,
                    Message = $"Erro ao calcular o total da refeição: {ex.Message}"
                };
            }
        }
        public async Task<List<RefeicaoMVN>> GetRefeicao([FromQuery] ReadRefeicaoDto refeicao)
        {
            try
            {
                var query = await _context.RefeicaoMVN.Where(x => x.Dia == refeicao.Dia && x.Mes == refeicao.Mes && x.Ano == refeicao.Ano).ToListAsync();
            
                return query;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Erro ao buscar refeição: {ex.Message}");
                return null;
            }
        }
        public async Task<List<RefeicaoMVN>> GetRefeicaoByPlace([FromQuery] ReadRefeicaoDto refeicao, int lugar)
        {
            try
            {
                var query = await _context.RefeicaoMVN.Where(x => x.Dia == refeicao.Dia && x.Mes == refeicao.Mes && x.Ano == refeicao.Ano && x.Posicao == lugar).ToListAsync();
                return query;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Erro ao buscar refeição: {ex.Message}");
                return null;
            }
        }
        public async Task<CalculoDaRefeicao> GetCalculoRefeicao([FromQuery] ReadRefeicaoDto refeicao)
        {
            try
            {
                var query = await _context.Refeicao.Where(x => x.Dia == refeicao.Dia && x.Mes == refeicao.Mes && x.Ano == refeicao.Ano).FirstOrDefaultAsync();
                return query;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Erro ao buscar refeição: {ex.Message}");
                return null;
            }
        }
        public async Task<FoodServiceResponseDto> RemoveRefeicao([FromQuery] ReadRefeicaoDto refeicao, string nome)
        {
            try
            {
                var query = await GetRefeicao(refeicao);
                var result = query.Find(x => x.Nome == nome);

                _context.RefeicaoMVN.Remove(result);
                await _context.SaveChangesAsync();

                var calc = await GetCalculoRefeicao(refeicao);

                if(calc != null)
                {
                    _context.Refeicao.Remove(calc);
                    await _context.SaveChangesAsync();
                    await CalculoTotal(refeicao);
                }

                return new FoodServiceResponseDto
                {
                    IsSuccess = true,
                    StatusCode = 200,
                    Message = $"Refeição removida com sucesso. Recalculo dos nutrientes feito com sucesso."
                };
            }catch(Exception ex)
            {
                return new FoodServiceResponseDto
                {
                    IsSuccess = false,
                    StatusCode = 500,
                    Message = $"Erro ao remover refeição: {ex.Message}"
                };
            }
        }

        public async Task<FoodServiceResponseDto> UpdateRefeicao([FromQuery] ReadRefeicaoDto refeicao, [FromBody] UpdateRefeicaoDto updt)
        {
            try
            {
                var query = await GetRefeicao(refeicao);
                var refeicaoToUpdate = query.FirstOrDefault(x => x.Nome == updt.Nome);

                if (refeicaoToUpdate == null)
                {
                    return new FoodServiceResponseDto
                    {
                        IsSuccess = false,
                        StatusCode = 404,
                        Message = $"Refeição com nome '{updt.Nome}' não encontrada para atualização."
                    };
                }

                var updatedInfo = await _foodInformation.FoodDetailSearchByName(updt.NomeAtt);

                refeicaoToUpdate.Nome = updatedInfo.Food.Nome;
                refeicaoToUpdate.Carboidratos = updatedInfo.Food.Carboidratos;
                refeicaoToUpdate.Proteinas = updatedInfo.Food.Proteinas;
                refeicaoToUpdate.Lipidios = updatedInfo.Food.Lipidios;
                refeicaoToUpdate.Calorias = updatedInfo.Food.Calorias;
                refeicaoToUpdate.Fibra = updatedInfo.Food.Fibra_Alimentar;

                _context.RefeicaoMVN.Update(refeicaoToUpdate);
                await _context.SaveChangesAsync();

                var calc = await GetCalculoRefeicao(refeicao);
                _context.Refeicao.Remove(calc);
                await _context.SaveChangesAsync();
                var newCalc = await CalculoTotal(refeicao);

                return new FoodServiceResponseDto
                {
                    IsSuccess = true,
                    StatusCode = 200,
                    Message = $"Refeição '{updt.Nome}' atualizada para '{updt.NomeAtt}'. Recálculo dos nutrientes feito com sucesso."
                };
            }
            catch (Exception ex)
            {
                return new FoodServiceResponseDto
                {
                    IsSuccess = false,
                    StatusCode = 500,
                    Message = $"Erro ao atualizar refeição: {ex.Message}"
                };
            }
        }
        public async Task<FoodServiceResponseDto> UpdateRefeicaoDate([FromQuery] ReadRefeicaoDto refeicao, [FromBody] UpdateRefeicaoDto updt)
        {
            try
            {
                var query = await GetRefeicao(refeicao);
                var result = query.Find(x => x.Nome == updt.Nome);

                result.Dia = updt.Dia;
                result.Mes = updt.Mes;
                result.Ano = updt.Ano;

                _context.RefeicaoMVN.Update(result);
                await _context.SaveChangesAsync();

                var calc = await GetCalculoRefeicao(refeicao);
                _context.Refeicao.Remove(calc);

                await _context.SaveChangesAsync();
                var newCalc = await CalculoTotal(refeicao);

                return new FoodServiceResponseDto
                {
                    IsSuccess = true,
                    StatusCode = 200,
                    Message = $"Data da refeição atualizada com sucesso. De {refeicao.Dia} para {updt.Dia}. Faça o calculo nutricional para o dia {updt.Dia}"
                };
            }
            catch (Exception ex)
            {
                return new FoodServiceResponseDto
                {
                    IsSuccess = false,
                    StatusCode = 500,
                    Message = $"Erro ao atualizar data da refeição: {ex.Message}"
                };
            }
        }
    }
}
