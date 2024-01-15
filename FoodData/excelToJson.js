const XLSX = require('xlsx');
const fs = require('fs');
const categorias = require('./categoria');

// Ler o arquivo Excel
const workbook = XLSX.readFile('./arquivo_base/tabela.xlsx');

// Selecionar a primeira planilha
const sheet_name = workbook.SheetNames[0];
const sheet = workbook.Sheets[sheet_name];

// Converter a planilha para JSON
const json_data = XLSX.utils.sheet_to_json(sheet);

// Exibir o JSON
// console.log(json_data);

// Exemplo: Acessar informações específicas do JSON
const alimentosFormatados = [];

for (let i = 0; i < json_data.length; i++) {
  const dados = json_data[i];

  const alimentoFormatado = {
    grupo: dados['Grupo'],
    categoria_id: categorias[dados['Grupo']],
    nome: dados['Descrição do Alimento'],
    carboidratos: dados['Carboidrato(g)'],
    proteinas: dados['Proteína(g)'],
    lipidios: dados['Lipídeos(g)'],
    calorias: dados['Energia(kcal)'],
    fibbras: dados['Fibra(g)'],
    vitaminas: `Vitamina A: ${dados['Retinol(mcg)'] || 'NA'}, Vitamina C: ${dados['VitaminaC(mg)'] || 'NA'} , Vitamina B1: ${dados['Tiamina(mg)'] || 'NA'}, Vitamina B2: ${dados['Riboflavina(mg)'] || 'NA'}, Vitamina B6: ${dados['Piridoxina(mg)'] || 'NA'}, Vitamina B3: ${dados['Niacina(mg)'] || 'NA'}`,
    minerais: `Cálcio: ${dados['Calcio(mg)'] || 'NA'}, Magnésio: ${dados['Magnesio(mg)'] || 'NA'}, Manganês: ${dados['Manganes(mg)'] || 'NA'}, Fósforo: ${dados['Fosforo(mg)'] || 'NA'}, Ferro: ${dados['Ferro(mg)'] || 'NA'}, Sódio: ${dados['Sodio(mg)'] || 'NA'}, Potássio: ${dados['Potassio(mg)'] || 'NA'}, Cobre: ${dados['Cobre(mcg)'] || 'NA'}, Zinco: ${dados['Zinco(mg)'] || 'NA'}, Selênio: ${dados['Selenio(mcg)'] || 'NA'}`,
    createdAt: new Date(),
    updatedAt: new Date()
  };
  alimentosFormatados.push(alimentoFormatado);
}

//criar um arquivo .JSON com os dados formatados

// fs.writeSync('./arquivo_base/alimentos.json', JSON.stringify(alimentosFormatados));

// Verificar se já existe um arquivo .JSON e se sim, verificar seus itens e adicionar os novos itens de forma que não haja repetição

let alimentosExistentes = [];

try{
  const rawData = fs.readFileSync('./arquivo_base/alimentos.json');
  alimentosExistentes = JSON.parse(rawData);
}catch(error){
  // informar que o arquivo não existe
  console.log('O arquivo não existe ou está com algum problema: ' + error);
}

const alimentoJaExiste = (alimentoNovo) => {
  return alimentosExistentes.some((alimentoExistente)=>{
    return (
      alimentoExistente.nome === alimentoNovo.nome
      );
  });
}

const adicionarAlimento = (alimentoNovo) => {
  if(!alimentoJaExiste(alimentoNovo)){
    alimentosExistentes.push(alimentoNovo);
  }
};

alimentosFormatados.forEach(alimento =>{
  adicionarAlimento(alimento);
})

fs.writeFileSync('./arquivo_base/alimentos.json', JSON.stringify(alimentosExistentes, null, 2));

// console.log(alimentosFormatados);

