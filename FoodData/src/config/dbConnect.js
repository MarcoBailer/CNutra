import mongoose, {mongo} from "mongoose";

async function dbConnect(){
    
    mongoose.connect(process.env.DB_CONNECTION_STRING);

    return mongoose.connection;
}

export default dbConnect;

// mongodb+srv://marcowcandido:<password>@fooddata.9teuhh5.mongodb.net/?retryWrites=true&w=majority
