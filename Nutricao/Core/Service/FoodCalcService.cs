using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nutricao.Core.Dtos;
using Nutricao.Core.Dtos.Context;
using Nutricao.Core.Dtos.Refeicao;
using Nutricao.Core.Dtos.Refeicao_Noturna;
using Nutricao.Core.Dtos.Refeicao_Vespertina;
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

        public async Task<FoodServiceResponseSimplifiedDto> AdicionaRefeicaoMatinal([FromBody] CreateRefeicaoDto refeicao, EFoodCategory foodCategory, string foodName)
        {
            try
            {
                var result = await _foodInformation.AllFoodDetails(foodCategory, foodName);

                var refeicaoMatinal = new RefeicaoMatinal
                {
                    Nome = result.Food.Nome,
                    Dia = refeicao.Dia,
                    Mes = refeicao.Mes,
                    Ano = refeicao.Ano,
                    Calorias = result.Food.Calorias,
                    Carboidratos = result.Food.Carboidratos,
                    Proteinas = result.Food.Proteinas,
                    Lipidios = result.Food.Lipidios
                };

                _context.RefeicaoMatinal.Add(refeicaoMatinal);
                await _context.SaveChangesAsync();
                return new FoodServiceResponseSimplifiedDto
                {
                    StatusCode = 200,
                    IsSuccess = true,
                    Message = $"Refeição matinal adicionada com sucesso."
                };
            }
            catch (Exception ex)
            {
                return new FoodServiceResponseSimplifiedDto
                {
                    StatusCode = 500,
                    IsSuccess = false,
                    Message = $"Erro ao adicionar refeição matinal."
                };
            }
        }
        public async Task<FoodServiceResponseSimplifiedDto> AdicionaRefeicaoVespertina([FromBody] CreateRefeicaoVespertinaDto refeicao, EFoodCategory foodCategory, string foodName)
        {
            try
            {
                var result = await _foodInformation.AllFoodDetails(foodCategory, foodName);

                var refeicaoVespertina = new RefeicaoVespertina
                {
                    Nome = result.Food.Nome,
                    Dia = refeicao.Dia,
                    Mes = refeicao.Mes,
                    Ano = refeicao.Ano,
                    Calorias = result.Food.Calorias,
                    Carboidratos = result.Food.Carboidratos,
                    Proteinas = result.Food.Proteinas,
                    Lipidios = result.Food.Lipidios
                };

                _context.RefeicaoVespertina.Add(refeicaoVespertina);
                await _context.SaveChangesAsync();
                return new FoodServiceResponseSimplifiedDto
                {
                    StatusCode = 200,
                    IsSuccess = true,
                    Message = $"Refeição vespertina adicionada com sucesso."
                };
            }
            catch (Exception ex)
            {
                return new FoodServiceResponseSimplifiedDto
                {
                    StatusCode = 500,
                    IsSuccess = false,
                    Message = $"Erro ao adicionar refeição vespertina."
                };
            }
        }
        public async Task<FoodServiceResponseSimplifiedDto> AdicionaRefeicaoNoturna([FromBody] CreateRefeicaoNoturnaDto refeicao, EFoodCategory foodCategory, string foodName)
        {
            try
            {
                var result = await _foodInformation.AllFoodDetails(foodCategory, foodName);

                var refeicaoNoturna = new RefeicaoNoturna
                {
                    Nome = result.Food.Nome,
                    Dia = refeicao.Dia,
                    Mes = refeicao.Mes,
                    Ano = refeicao.Ano,
                    Calorias = result.Food.Calorias,
                    Carboidratos = result.Food.Carboidratos,
                    Proteinas = result.Food.Proteinas,
                    Lipidios = result.Food.Lipidios
                };

                _context.RefeicaoNoturna.Add(refeicaoNoturna);
                await _context.SaveChangesAsync();
                return new FoodServiceResponseSimplifiedDto
                {
                    StatusCode = 200,
                    IsSuccess = true,
                    Message = $"Refeição noturna adicionada com sucesso."
                };
            }
            catch (Exception ex)
            {
                return new FoodServiceResponseSimplifiedDto 
                { 
                    StatusCode = 500, 
                    IsSuccess = false, 
                    Message = $"Erro ao adicionar refeição vespertina." 
                };
            }
        }
        public async Task<List<RefeicaoMatinal>> GetRefeicaoMatinal(int dia, int mes, int ano)
        {
            var result = await _context.RefeicaoMatinal.Where(x => x.Dia == dia && x.Mes == mes && x.Ano == ano)
            .ToListAsync();

            return result;
        }
        public async Task<List<RefeicaoVespertina>> GetRefeicaoVespertina(int dia, int mes, int ano)
        {
            var result = await _context.RefeicaoVespertina.Where(x => x.Dia == dia && x.Mes == mes && x.Ano == ano)
            .ToListAsync();

            return result;
        }
        public async Task<List<RefeicaoNoturna>> GetRefeicaoNoturna(int dia, int mes, int ano)
        {
            var result = await _context.RefeicaoNoturna.Where(x => x.Dia == dia && x.Mes == mes && x.Ano == ano)
            .ToListAsync();

            return result;
        }
        public async Task<CalculoDaRefeicao> CalculoTotal(int dia, int mes, int ano)
        {
            try
            {
                var matinal = await GetRefeicaoMatinal(dia, mes, ano);
                var vespertino = await GetRefeicaoVespertina(dia, mes, ano);
                var noturno = await GetRefeicaoNoturna(dia, mes, ano);

                var totalCarboidratosMatinal = matinal.Sum(x => x.Carboidratos);
                var totalProteinasMatinal = matinal.Sum(x => x.Proteinas);
                var totalGordurasMatinal = matinal.Sum(x => x.Lipidios);
                var totalCaloriasMatinal = matinal.Sum(x => x.Calorias);

                var totalCarboidratosVespertino = vespertino.Sum(x => x.Carboidratos);
                var totalProteinasVespertino = vespertino.Sum(x => x.Proteinas);
                var totalGordurasVespertino = vespertino.Sum(x => x.Lipidios);
                var totalCaloriasVespertino = vespertino.Sum(x => x.Calorias);

                var totalCarboidratosNoturno = noturno.Sum(x => x.Carboidratos);
                var totalProteinasNoturno = noturno.Sum(x => x.Proteinas);
                var totalGordurasNoturno = noturno.Sum(x => x.Lipidios);
                var totalCaloriasNoturno = noturno.Sum(x => x.Calorias);

                var totalCarboidratos = totalCarboidratosMatinal + totalCarboidratosVespertino + totalCarboidratosNoturno;
                var totalProteinas = totalProteinasMatinal + totalProteinasVespertino + totalProteinasNoturno;
                var totalGorduras = totalGordurasMatinal + totalGordurasVespertino + totalGordurasNoturno;
                var totalCalorias = totalCaloriasMatinal + totalCaloriasVespertino + totalCaloriasNoturno;

                var total = new CalculoDaRefeicao
                {
                    TotalCarboidratos = totalCarboidratos,
                    TotalProteinas = totalProteinas,
                    TotalGorduras = totalGorduras,
                    TotalCalorias = totalCalorias,
                    Dia = dia,
                    Mes = mes,
                    Ano = ano
                };
                _context.Refeicao.Add(total);
                await _context.SaveChangesAsync();
                return total;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
