import mongoose, { version } from "mongoose";

const AlimentoSchema = new mongoose.Schema({
    id:{
        type: mongoose.Schema.Types.ObjectId,
    },
    categoria:{
        type: String,
        required: true,
    },
    nome:{
        type: String,
        required: true,
    },
    carboidratos:{
        type: Number,
        required: true,
    },
    proteinas:{
        type: Number,
        required: true,
    },
    lipidios:{
        type: Number,
        required: true,
    },
    calorias:{
        type: Number,
        required: true,
    },
    vitaminas:{
        type: Object,
        required: true,
    },
},{versionKey: false});

const Alimento = mongoose.model("Alimento", AlimentoSchema);

export default Alimento;

// {
//     "nome": "Uva",
//     "carboidratos": 16.8,
//     "proteinas": 0.6,
//     "lipidios": 0.1,
//     "calorias": 69.1,
//     "vitaminas": {
//       "A": 66,
//       "C": 3.2,
//       "B1": 0.07
//     }
//   },