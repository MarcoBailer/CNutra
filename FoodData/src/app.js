import express from "express";
import dbConnect from "./config/dbConnect.js";
import alimentos from "./models/Alimento.js";

const connection = await dbConnect();

connection.on("error", (error) => console.log("Erro de conexao",error));

connection.once("open", () => console.log("Conectamos no MongoDB"));

const app = express();
app.use(express.json());

app.get("/", (req, res) => {
  res.status(200).send("Hello World!");
});

app.get("/alimentos", async (req, res) => {
  const listaAlimentos = await alimentos.find({});
  res.status(200).json(listaAlimentos);
});

app.get("/alimentos/:id", (req, res) => {
  const index = buscaAlimento(req.params.id);
  res.status(200).json(alimentos[index]);
})

app.post("/alimentos", (req, res) => {
  alimentos.push(req.body);
  res.status(201).send("aliemento cadastrado com sucesso");
});

app.put("/alimentos/:id", (req, res) => {
  const index = buscaAlimento(req.params.id);
  alimentos[index].titulo = req.body.titulo;
  res.status(200).json(alimentos);
});

app.delete("/alimentos/:id", (req, res) => {
  const index = buscaAlimento(req.params.id);
  alimentos.splice(index, 1);
  res.status(200).send("alimento removido com sucesso");
});


export default app;