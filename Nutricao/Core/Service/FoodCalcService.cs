using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nutricao.Core.Dtos;
using Nutricao.Core.Dtos.Context;
using Nutricao.Core.Dtos.Refeicao_MVN;
using Nutricao.Core.Interfaces;
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
                            UsuarioId = refeicaoDto.UsuarioId,
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
                        return FoodServiceResponseDto.BadRequest("É necessário colocar a quantidade após o nome do alimento => /Quantidade");
                    }

                }
                catch (InvalidPeriodException ex)
                {
                    return FoodServiceResponseDto.BadRequest(ex.Message);
                }
            }
            return FoodServiceResponseDto.Created("Refeição cadastrada com sucesso.");
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

                    return FoodServiceResponseDto.Created($"Calculo nutricional feito com sucesso para o dia {refeicaoDto.Dia}/{refeicaoDto.Mes}/{refeicaoDto.Ano}");
                }
                else
                {
                    return FoodServiceResponseDto.NotFound($"Nenhuma refeição encontrada para o dia {refeicaoDto.Dia}/{refeicaoDto.Mes}/{refeicaoDto.Ano}");
                }
            }
            catch (Exception ex)
            {
                return FoodServiceResponseDto.InternalServerError($"Erro ao calcular o total da refeição: {ex.Message}");
            }
        }
        public async Task<FoodServiceResponseDto> CalcularTotalRefeicaoPelaPosicao([FromQuery] RefeicaoQuery refeicao, int lugar)
        {
            try
            {
                var query = await GetRefeicaoPorPosicao(refeicao, lugar);

                if(query != null)
                {
                    var refe = new CalculoDaRefeicaoPorPosicao
                    {
                        TotalCarboidratos = RefeicaoMVN.CalcularTotalCarboidratos(query),
                        TotalProteinas = RefeicaoMVN.CalcularTotalProteinas(query),
                        TotalCalorias = RefeicaoMVN.CalcularTotalCalorias(query),
                        TotalGorduras = RefeicaoMVN.CalcularTotalLipidios(query),
                        TotalFibras = RefeicaoMVN.CalcularTotalFibras(query),
                        Posicao = lugar,
                        Dia = refeicao.Dia,
                        Mes = refeicao.Mes,
                        Ano = refeicao.Ano
                    };

                    var calc = await GetCalculoDaRefeicaoPorPosicao(refeicao, lugar);
                    if(calc != null)
                    {
                        if(calc.TotalGorduras == refe.TotalGorduras && calc.TotalProteinas == refe.TotalProteinas && calc.TotalCarboidratos == refe.TotalCarboidratos && calc.TotalCalorias == refe.TotalCalorias && calc.TotalFibras == refe.TotalFibras)
                        {
                            return FoodServiceResponseDto.Ok("Sua refeição não foi alterada, pois o calculo já foi feito.");
                        }
                        else
                        {
                            _context.RefeicaoPosicao.Add(refe);
                            await _context.SaveChangesAsync();
                        }
                        return FoodServiceResponseDto.Created("Sua refeição foi atualizada com sucesso.");
                    }
                    else
                    {
                        _context.RefeicaoPosicao.Add(refe);
                        await _context.SaveChangesAsync();

                        return FoodServiceResponseDto.Created("Calculo nutricional feito com sucesso.");
                    }
                }
                else
                {
                    return FoodServiceResponseDto.NotFound($"Nenhuma refeição encontrada para o dia {refeicao.Dia}/{refeicao.Mes}/{refeicao.Ano}");
                }
            }
            catch (Exception ex)
            {
                return FoodServiceResponseDto.InternalServerError($"Erro ao calcular o total da refeição: {ex.Message}");
            }
        }
        public async Task<FoodServiceResponseDto> CalcularTotalRefeicaoPeloTurno([FromQuery] RefeicaoQuery refeicao, bool mat, bool vesp, bool not)
        {
            try
            {
                var query = await GetRefeicaoPorTurno(refeicao, mat, vesp, not);

                if (query != null)
                {
                    var refe = new CalculoDaRefeicaoPorTurno
                    {
                        TotalCarboidratos = RefeicaoMVN.CalcularTotalCarboidratos(query),
                        TotalProteinas = RefeicaoMVN.CalcularTotalProteinas(query),
                        TotalCalorias = RefeicaoMVN.CalcularTotalCalorias(query),
                        TotalGorduras = RefeicaoMVN.CalcularTotalLipidios(query),
                        TotalFibras = RefeicaoMVN.CalcularTotalFibras(query),
                    };

                    var calc = await GetCalculoRefeicaoPorTurno(refeicao, mat, vesp, not);

                    if(calc != null)
                    {
                        if(calc.TotalCarboidratos == refe.TotalCarboidratos && calc.TotalProteinas == refe.TotalProteinas && calc.TotalCalorias == refe.TotalCalorias && calc.TotalGorduras == refe.TotalGorduras && calc.TotalFibras == refe.TotalFibras)
                        {
                            return FoodServiceResponseDto.Ok("Sua refeição não foi alterada, pois o calculo já foi feito.");
                        }
                        else
                        {
                            _context.RefeicaoTurno.Add(refe);
                            await _context.SaveChangesAsync();
                        }
                        return FoodServiceResponseDto.Created("Sua refeição foi atualizada com sucesso.");
                    }
                    else
                    {
                        _context.RefeicaoTurno.Add(refe);
                        await _context.SaveChangesAsync();

                        return FoodServiceResponseDto.Created("Calculo nutricional feito com sucesso.");
                    }
                }
                else
                {
                    return FoodServiceResponseDto.NotFound($"Nenhuma refeição encontrada para o dia {refeicao.Dia}/{refeicao.Mes}/{refeicao.Ano}");
                }
            }
            catch (Exception ex)
            {
                return FoodServiceResponseDto.InternalServerError($"Erro ao calcular o total da refeição: {ex.Message}");
            }
        }
        public async Task<List<RefeicaoMVN>> GetRefeicao([FromQuery] RefeicaoQuery refeicaoQr)
        {
            try
            {
                var refeicao = await _context.RefeicaoMVN.Where(r => r.Dia == refeicaoQr.Dia && r.Mes == refeicaoQr.Mes && r.Ano == refeicaoQr.Ano).ToListAsync();

                return refeicao;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<List<RefeicaoMVN>> GetRefeicaoPorPosicao([FromQuery] RefeicaoQuery refeicaoQr, int lugar)
        {
            try
            {
                var query = await _context.RefeicaoMVN.Where(x => x.Dia == refeicaoQr.Dia && x.Mes == refeicaoQr.Mes && x.Ano == refeicaoQr.Ano && x.Posicao == lugar).ToListAsync();

                return query;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<List<RefeicaoMVN>> GetRefeicaoPorTurno([FromQuery] RefeicaoQuery refeicaoQr, bool isMatinal, bool isVespertina, bool isNoturna)
        {
            try
            {
                var query = await _context.RefeicaoMVN.Where(x => x.Dia == refeicaoQr.Dia && x.Mes == refeicaoQr.Mes && x.Ano == refeicaoQr.Ano && (x.IsMatinal == isMatinal || x.IsVespertina == isVespertina || x.IsNoturna == isNoturna)).ToListAsync();

                return query;
            }
            catch (Exception ex)
            {
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
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao buscar refeição: {ex.Message}");
                return null;
            }
        }
        public async Task<CalculoDaRefeicaoPorTurno> GetCalculoRefeicaoPorTurno([FromQuery] RefeicaoQuery refeicaoQr, bool mat, bool vesp, bool not)
        {
            try
            {
                var query = await _context.RefeicaoTurno.Where(x => x.Dia == refeicaoQr.Dia && x.Mes == refeicaoQr.Mes && x.Ano == refeicaoQr.Ano && (x.IsMatinal == mat || x.IsVespertina == vesp || x.IsNoturna == not)).FirstOrDefaultAsync();

                return query;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao buscar refeição: {ex.Message}");
                return null;
            }
        }
        public async Task<CalculoDaRefeicaoPorPosicao> GetCalculoDaRefeicaoPorPosicao([FromQuery] RefeicaoQuery refeicaoQr, int lugar)
        {
            try
            {
                var query = await _context.RefeicaoPosicao.Where(x => x.Dia == refeicaoQr.Dia && x.Mes == refeicaoQr.Mes && x.Ano == refeicaoQr.Ano && x.Posicao == lugar).FirstOrDefaultAsync();

                return query;
            }
            catch (Exception ex)
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

                    return FoodServiceResponseDto.Ok("Refeição removida com sucesso.");
                }
                else
                {
                    return FoodServiceResponseDto.NotFound($"Refeição com nome '{nome}' não encontrada.");
                }

            }catch(Exception ex)
            {
                return FoodServiceResponseDto.InternalServerError($"Erro ao remover refeição: {ex.Message}");
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
                        return FoodServiceResponseDto.NotFound($"Alimento com nome '{nomeUpdt}' não encontrado.");
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

                    return FoodServiceResponseDto.Ok($"Refeição atualizada com sucesso. {nome} atualizado para {nomeUpdt}. Recalculo dos nutrientes feito com sucesso.");
                }
                else
                {
                    return FoodServiceResponseDto.NotFound($"Refeição com nome '{nome}' não encontrada para atualização.");
                }
            }
            catch (Exception ex)
            {
                return FoodServiceResponseDto.InternalServerError($"Erro ao atualizar refeição: {ex.Message}");
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

                    return FoodServiceResponseDto.Ok($"Data da refeição atualizada com sucesso. De {refeicao.Dia} para {updt.Dia}. Faça o calculo nutricional para o dia {updt.Dia}");
                }
                else
                {
                    return FoodServiceResponseDto.NotFound($"Refeição com nome '{updt.Nome}' não encontrada para atualização.");
                }
            }
            catch (Exception ex)
            {
                return FoodServiceResponseDto.InternalServerError($"Erro ao atualizar refeição: {ex.Message}");
            }
        }
    }
}
