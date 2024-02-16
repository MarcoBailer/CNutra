﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nutricao.Core.Dtos;
using Nutricao.Core.Dtos.Context;
using Nutricao.Core.Dtos.Refeicao;
using Nutricao.Core.Interfaces;
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

        public async Task<FoodServiceResponseSimplifiedDto> AdicionaRefeicao([FromBody] CreateRefeicaoDto refeicao, string foodName)
        {
            try
            {
                var result = await _foodInformation.FoodDetailSearchByName(foodName);

                var refe = new RefeicaoMVN
                {
                    Nome = result.Food.Nome,
                    Calorias = result.Food.Calorias,
                    Carboidratos = result.Food.Carboidratos,
                    Proteinas = result.Food.Proteinas,
                    Lipidios = result.Food.Lipidios,
                    IsMatinal = refeicao.IsMatinal,
                    IsVespertina = refeicao.IsVespertina,
                    IsNoturna = refeicao.IsNoturna,
                    Dia = refeicao.Dia,
                    Mes = refeicao.Mes,
                    Ano = refeicao.Ano,
                };
                if(refe.IsMatinal == true)
                {
                    _context.RefeicaoMVN.Add(refe);
                    await _context.SaveChangesAsync();
                    return new FoodServiceResponseSimplifiedDto
                    {
                        StatusCode = 200,
                        IsSuccess = true,
                        Message = $"Refeição matinal adicionada com sucesso."
                    };
                }
                else if(refe.IsVespertina == true)
                {
                    _context.RefeicaoMVN.Add(refe);
                    await _context.SaveChangesAsync();
                    return new FoodServiceResponseSimplifiedDto
                    {
                        StatusCode = 200,
                        IsSuccess = true,
                        Message = $"Refeição vespertina adicionada com sucesso."
                    };
                }
                else if(refe.IsNoturna == true)
                {
                    _context.RefeicaoMVN.Add(refe);
                    await _context.SaveChangesAsync();
                    return new FoodServiceResponseSimplifiedDto
                    {
                        StatusCode = 200,
                        IsSuccess = true,
                        Message = $"Refeição noturna adicionada com sucesso."
                    };
                }
                else
                {
                    return new FoodServiceResponseSimplifiedDto
                    {
                        StatusCode = 500,
                        IsSuccess = false,
                        Message = $"Erro ao adicionar refeição."
                    };
                }
            }
            catch (Exception ex)
            {
                return new FoodServiceResponseSimplifiedDto
                {
                    StatusCode = 500,
                    IsSuccess = false,
                    Message = $"Erro ao adicionar refeição: {ex}."
                };
            }
        }
        public async Task<List<FoodServiceResponseDto>> CadastrarVariasRef([FromBody] CreateRefeicaoDto refeicaoDto, string nomes)
        {
            List<FoodServiceResponseDto> informacoes = new List<FoodServiceResponseDto>();
            string[] nomesSeperados = nomes.Split(';');

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
                        Dia = refeicaoDto.Dia,
                        Mes = refeicaoDto.Mes,
                        Ano = refeicaoDto.Ano,
                        IsMatinal = refeicaoDto.IsMatinal,
                        IsVespertina = refeicaoDto.IsVespertina,
                        IsNoturna = refeicaoDto.IsNoturna,
                    };
                    if (refeicao.IsMatinal == true)
                    {
                        _context.RefeicaoMVN.Add(refeicao);
                        await _context.SaveChangesAsync();
                        informacoes.Add(informacao);
                    }
                    else if (refeicao.IsVespertina == true)
                    {
                        _context.RefeicaoMVN.Add(refeicao);
                        await _context.SaveChangesAsync();
                        informacoes.Add(informacao);
                    }
                    else if (refeicao.IsNoturna == true)
                    {
                        _context.RefeicaoMVN.Add(refeicao);
                        await _context.SaveChangesAsync();
                        informacoes.Add(informacao);
                    }
                }
                catch (Exception ex)
                {
                    informacoes.Add(new FoodServiceResponseDto
                    {
                        IsSuccess = false,
                        Message = $"Nao foi possivel realizar operacao: {ex}",
                    });
                }
            }
            return informacoes;
        }
        public async Task<List<RefeicaoMVN>> GetRefeicao([FromQuery] ReadRefeicaoDto refeicao)
        {
            var query = await _context.RefeicaoMVN.Where(x => x.Dia == refeicao.Dia && x.Mes == refeicao.Mes && x.Ano == refeicao.Ano).ToListAsync();

            return query;
        }
        public async Task<CalculoDaRefeicao> CalculoTotal([FromQuery] ReadRefeicaoDto refeicao)
        {
            try
            {
                var refe = await GetRefeicao(refeicao);
                if(refe != null)
                {
                    var totalCarboidratos = CalculoDaRefeicao.CalcularTotalCarboidratos(refe);
                    var totalProteinas = CalculoDaRefeicao.CalcularTotalProteinas(refe);
                    var totalGorduras = CalculoDaRefeicao.CalcularTotalGorduras(refe);
                    var totalCalorias = CalculoDaRefeicao.CalcularTotalCalorias(refe);

                    var total = new CalculoDaRefeicao
                    {
                        TotalCarboidratos = totalCarboidratos,
                        TotalProteinas = totalProteinas,
                        TotalGorduras = totalGorduras,
                        TotalCalorias = totalCalorias,
                        Dia = refeicao.Dia,
                        Mes = refeicao.Mes,
                        Ano = refeicao.Ano,
                    };
                    _context.Refeicao.Add(total);
                    await _context.SaveChangesAsync();
                    return total;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao calcular o total da refeição: {ex.Message}");
                return null;
            }
        }
    }
}
