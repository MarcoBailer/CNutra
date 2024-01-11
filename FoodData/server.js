import "dotenv/config";
import app from "./src/app.js";

const PORT = 3000;

const rotas = {
    '/contato': 'Contato',
    '/sobre': 'Sobre',
    '/': 'Index'
}

app.listen(PORT,() =>{
    console.log('Server running at http://localhost:3000/');
})
