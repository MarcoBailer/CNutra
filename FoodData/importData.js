const sqlite3 = require('sqlite3').verbose();
const fs = require('fs');

// Carregue os dados do arquivo JSON
const rawData = fs.readFileSync('./arquivo_base/alimentos.json');
const alimentosFormatados = JSON.parse(rawData);

// Abra uma conexão com o banco de dados SQLite (certifique-se de ter um arquivo de banco de dados SQLite criado)
const db = new sqlite3.Database('database.sqlite');

// Crie uma tabela no banco de dados (se ainda não existir)
db.run(`CREATE TABLE IF NOT EXISTS alimentos (
  id INTEGER PRIMARY KEY,
  categoria_id INTEGER,
  grupo TEXT,
  nome TEXT,
  carboidratos REAL,
  proteinas REAL,
  lipidios REAL,
  calorias REAL,
  vitaminas TEXT
  minerais TEXT
  createdAt TEXT,
  updatedAt TEXT
)`);

// Insira os dados na tabela
const stmt = db.prepare('INSERT INTO alimentos (categoria_id, nome, grupo, carboidratos, proteinas, lipidios, calorias, vitaminas, minerais, createdAt, updatedAt) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)');

alimentosFormatados.forEach((alimento) => {
  stmt.run(alimento.categoria_id, alimento.nome, alimento.grupo, alimento.carboidratos, alimento.proteinas, alimento.lipidios, alimento.calorias, alimento.vitaminas, alimento.minerais, alimento.createdAt, alimento.updatedAt);
});

// Finalize o comando de inserção
stmt.finalize();

// Feche a conexão com o banco de dados
db.close();
