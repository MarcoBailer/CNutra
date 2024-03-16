using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nutricao.Core.Dtos;
using Nutricao.Core.Dtos.Context;
using Nutricao.Core.Dtos.Refeicao_MVN;
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
        public async Task<FoodServiceResponseDto> CadastrarVariasRef([FromBody] RefeicaoMVN refeicaoDto)
        {

            string[] nomesSeperados = refeicaoDto.Nome.Split(';');

            foreach (var nome in nomesSeperados)
            {
                try
                {
                    if(nome.Contains("/"))
                    {
                        var nomeSplited = nome.Split('/')[0];

                        var informacao = await _foodInformation.FoodDetailSearchByName(nomeSplited);

                        string pesoString = nome.Split('/')[1];

                        var peso = int.Parse(pesoString);

                        var refeicao = new RefeicaoMVN
                        {
                            Nome = informacao.Food.Nome,
                            Carboidratos = RefeicaoMVN.CalcularQuantidadePeloPeso(peso, informacao.Food.Carboidratos),
                            Proteinas = RefeicaoMVN.CalcularQuantidadePeloPeso(peso, informacao.Food.Proteinas),
                            Lipidios = RefeicaoMVN.CalcularQuantidadePeloPeso(peso, informacao.Food.Lipidios),
                            Calorias = RefeicaoMVN.CalcularQuantidadePeloPeso(peso, informacao.Food.Calorias),
                            Fibra = RefeicaoMVN.CalcularQuantidadePeloPeso(peso, informacao.Food.Fibra_Alimentar),
                            Peso = peso,
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
                        }
                    }
                    else
                    {
                        return new FoodServiceResponseDto
                        {
                            IsSuccess = false,
                            StatusCode = 400,
                            Message = "A quantidade de comida ingerida deve acompanhar o nome, separado por uma barra( / )"
                        };
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
        public async Task<FoodServiceResponseDto> CalculoTotal([FromQuery] RefeicaoQuery refeicaoDto)
        {
            try
            {
                var ListaDeRefeicao = await GetRefeicao(refeicaoDto);
                
                if(ListaDeRefeicao != null)
                {
                    var total = new CalculoDaRefeicao
                    {
                        TotalCarboidratos = RefeicaoMVN.CalcularTotalCarboidratos(ListaDeRefeicao),
                        TotalProteinas = RefeicaoMVN.CalcularTotalProteinas(ListaDeRefeicao),
                        TotalGorduras = RefeicaoMVN.CalcularTotalLipidios(ListaDeRefeicao),
                        TotalCalorias = RefeicaoMVN.CalcularTotalCalorias(ListaDeRefeicao),
                        TotalFibras = RefeicaoMVN.CalcularTotalFibras(ListaDeRefeicao),
                        Dia = refeicaoDto.Dia,
                        Mes = refeicaoDto.Mes,
                        Ano = refeicaoDto.Ano
                    };
                    _context.Refeicao.Add(total);
                    await _context.SaveChangesAsync();
                    return new FoodServiceResponseDto
                    {
                        IsSuccess = true,
                        StatusCode = 201,
                        Message = $"Calculo nutricional feito com sucesso para o dia {refeicaoDto.Dia}/{refeicaoDto.Mes}/{refeicaoDto.Ano}"
                    };
                }
                else
                {
                    return new FoodServiceResponseDto
                    {
                        IsSuccess = false,
                        StatusCode = 404,
                        Message = $"Nenhuma refeição encontrada para o dia {refeicaoDto.Dia}/{refeicaoDto.Mes}/{refeicaoDto.Ano}"
                    };
                }
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
        public async Task<FoodServiceResponseDto> CalcularTotalRefeicaoPelaPosicao([FromQuery] RefeicaoQuery refeicao, int lugar)
        {
            try
            {
                var query = await GetRefeicaoByPlace(refeicao, lugar);

                if(query != null)
                {
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
                else
                {
                    return new FoodServiceResponseDto
                    {
                        IsSuccess = false,
                        StatusCode = 404,
                        Message = $"Nenhuma refeição encontrada para o lugar {lugar}, para este dia {refeicao.Dia}/{refeicao.Mes}/{refeicao.Ano}"
                    };
                }
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
        public async Task<List<RefeicaoMVN>> GetRefeicao([FromQuery] RefeicaoQuery refeicaoQr)
        {
            try
            {
                var query = await _context.RefeicaoMVN.Where(x => x.Dia == refeicaoQr.Dia && x.Mes == refeicaoQr.Mes && x.Ano == refeicaoQr.Ano).ToListAsync();

                return query;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Erro ao buscar refeição: {ex.Message}");
                return null;
            }
        }
        public async Task<List<RefeicaoMVN>> GetRefeicaoByPlace([FromQuery] RefeicaoQuery refeicaoQr, int lugar)
        {
            try
            {
                var query = await _context.RefeicaoMVN.Where(x => x.Dia == refeicaoQr.Dia && x.Mes == refeicaoQr.Mes && x.Ano == refeicaoQr.Ano && x.Posicao == lugar).ToListAsync();

                return query;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Erro ao buscar refeição: {ex.Message}");
                return null;
            }
        }
        public async Task<CalculoDaRefeicao> GetCalculoRefeicao([FromQuery] RefeicaoQuery refeicaoQr)
        {
            try
            {
                var query = await _context.Refeicao.Where(x => x.Dia == refeicaoQr.Dia && x.Mes == refeicaoQr.Mes && x.Ano == refeicaoQr.Ano).FirstOrDefaultAsync();

                return query;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Erro ao buscar refeição: {ex.Message}");
                return null;
            }
        }
        public async Task<FoodServiceResponseDto> RemoveRefeicao([FromQuery] RefeicaoQuery refeicaoQr, string nome)
        {
            try
            {
                var query = await GetRefeicao(refeicaoQr);
                var result = query.Find(x => x.Nome == nome);

                if(result != null)
                {                    
                    _context.RefeicaoMVN.Remove(result);
                    await _context.SaveChangesAsync();

                    var calc = await GetCalculoRefeicao(refeicaoQr);

                    if (calc != null)
                    {
                        _context.Refeicao.Remove(calc);
                        await _context.SaveChangesAsync();
                        await CalculoTotal(refeicaoQr);
                    }

                    return new FoodServiceResponseDto
                    {
                        IsSuccess = true,
                        StatusCode = 200,
                        Message = $"Refeição removida com sucesso. Recalculo dos nutrientes feito com sucesso."
                    };
                }
                else
                {
                    return new FoodServiceResponseDto
                    {
                        IsSuccess = false,
                        StatusCode = 404,
                        Message = $"Refeição com nome '{nome}' não encontrada para remoção."
                    };
                }

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
        public async Task<FoodServiceResponseDto> UpdateRefeicao([FromQuery] RefeicaoQuery refeicao, string nome, string nomeUpdt)
        {
            try
            {
                var query = await GetRefeicao(refeicao);
                var result = query.Find(x => x.Nome == nome);
                if (result != null)
                {
                    var resultAtt = await _foodInformation.FoodDetailSearchByName(nomeUpdt);

                    if (resultAtt == null)
                    {
                        return new FoodServiceResponseDto
                        {
                            IsSuccess = false,
                            StatusCode = 404,
                            Message = $"Alimento com nome '{nomeUpdt}' não encontrado."
                        };
                    }

                    result.Nome = resultAtt.Food.Nome;
                    result.Carboidratos = resultAtt.Food.Carboidratos;
                    result.Proteinas = resultAtt.Food.Proteinas;
                    result.Lipidios = resultAtt.Food.Lipidios;
                    result.Calorias = resultAtt.Food.Calorias;
                    result.Fibra = resultAtt.Food.Fibra_Alimentar;

                    _context.RefeicaoMVN.Update(result);
                    await _context.SaveChangesAsync();

                    var calc = await GetCalculoRefeicao(refeicao);

                    if(calc != null)
                    {
                        _context.Refeicao.Remove(calc);
                        await _context.SaveChangesAsync();
                        var newCalc = await CalculoTotal(refeicao);
                    }

                    return new FoodServiceResponseDto
                    {
                        IsSuccess = true,
                        StatusCode = 200,
                        Message = $"Refeição atualizada com sucesso. {nome} atualizado para {nomeUpdt}. Recalculo dos nutrientes feito com sucesso."
                    };
                }
                else
                {
                    return new FoodServiceResponseDto
                    {
                        IsSuccess = false,
                        StatusCode = 404,
                        Message = $"Refeição com nome '{nome}' não encontrada para atualização."
                    };
                }
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
        public async Task<FoodServiceResponseDto> UpdateRefeicaoDate([FromQuery] RefeicaoQuery refeicao, [FromBody] UpdateRefeicaoDto updt)
        {
            try
            {
                var query = await GetRefeicao(refeicao);
                var result = query.Find(x => x.Nome == updt.Nome);

                if (result != null)
                {                    
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
                else
                {
                    return new FoodServiceResponseDto
                    {
                        IsSuccess = false,
                        StatusCode = 404,
                        Message = $"Refeição com nome '{updt.Nome}' não encontrada para atualização."
                    };
                }
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
