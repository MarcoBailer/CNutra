using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nutricao.Core.Dtos;
using Nutricao.Core.Dtos.Context;
using Nutricao.Core.Dtos.Refeicao;
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
        public async Task<FoodServiceResponseDto> CadastrarVariasRef([FromBody] CreateRefeicaoDto refeicaoDto, string nomes)
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
                        Fibra = informacao.Food.Fibra_Alimentar,
                        Dia = refeicaoDto.Dia,
                        Mes = refeicaoDto.Mes,
                        Ano = refeicaoDto.Ano,
                        IsMatinal = refeicaoDto.IsMatinal,
                        IsVespertina = refeicaoDto.IsVespertina,
                        IsNoturna = refeicaoDto.IsNoturna,
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
                        Message = $"Erro ao cadastrar refeição {ex.Message}"
                    };
                }
            }
            return new FoodServiceResponseDto
            {
                IsSuccess = true,
                Message = "Operacao realizada com sucesso"
            };
        }
        public async Task<List<RefeicaoMVN>> GetRefeicao([FromQuery] ReadRefeicaoDto refeicao)
        {
            var query = await _context.RefeicaoMVN.Where(x => x.Dia == refeicao.Dia && x.Mes == refeicao.Mes && x.Ano == refeicao.Ano).ToListAsync();
            
            return query;
        }
        public async Task<CalculoDaRefeicao> GetCalculoRefeicao([FromQuery] ReadRefeicaoDto refeicao)
        {
            var query = await _context.Refeicao.Where(x => x.Dia == refeicao.Dia && x.Mes == refeicao.Mes && x.Ano == refeicao.Ano).FirstOrDefaultAsync();
            return query;
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
                _context.Refeicao.Remove(calc)
                    ;
                await _context.SaveChangesAsync();
                var newCalc = await CalculoTotal(refeicao);

                return new FoodServiceResponseDto
                {
                    IsSuccess = true,
                    Message = $"Refeição removida com sucesso. Recalculo dos nutrientes feito com sucesso."
                };
            }catch(Exception ex)
            {
                Console.WriteLine($"Erro ao remover refeição: {ex.Message}");
                return null;
            }
        }
        public async Task<FoodServiceResponseDto> UpdateRefeicao([FromQuery] ReadRefeicaoDto refeicao, [FromBody] UpdateRefeicaoDto updt)
        {
            try
            {
                var query = await GetRefeicao(refeicao);
                var result = query.Find(x => x.Nome == updt.Nome);
                var resultAtt = await _foodInformation.FoodDetailSearchByName(updt.NomeAtt);

                result.Nome = resultAtt.Food.Nome;
                result.Carboidratos = resultAtt.Food.Carboidratos;
                result.Proteinas = resultAtt.Food.Proteinas;
                result.Lipidios = resultAtt.Food.Lipidios;
                result.Calorias = resultAtt.Food.Calorias;
                result.Fibra = resultAtt.Food.Fibra_Alimentar;

                _context.RefeicaoMVN.Update(result);
                await _context.SaveChangesAsync();

                var calc = await GetCalculoRefeicao(refeicao);
                _context.Refeicao.Remove(calc);

                await _context.SaveChangesAsync();
                var newCalc = await CalculoTotal(refeicao);

                return new FoodServiceResponseDto
                {
                    IsSuccess = true,
                    Message = $"Refeição atualizada com sucesso. {updt.Nome} atualizado para {updt.NomeAtt}. Recalculo dos nutrientes feito com sucesso."
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar refeição: {ex.Message}");
                return null;
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
                    Message = $"Data da refeição atualizada com sucesso. De {refeicao.Dia} para {updt.Dia}. Faça o calculo nutricional para o dia {updt.Dia}"
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar refeição: {ex.Message}");
                return null;
            }
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
                    var totalFibras = CalculoDaRefeicao.CalcularTotalFibras(refe);

                    var total = new CalculoDaRefeicao
                    {
                        TotalCarboidratos = totalCarboidratos,
                        TotalProteinas = totalProteinas,
                        TotalGorduras = totalGorduras,
                        TotalCalorias = totalCalorias,
                        TotalFibras = totalFibras,
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
