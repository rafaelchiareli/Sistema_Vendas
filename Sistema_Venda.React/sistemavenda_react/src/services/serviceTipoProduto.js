import Api from "../helpers/api";

export async function ListarTiposProduto() {
    return await Api.get("/tipoproduto/listarTodos")
}

export async function CadastratTipoProduto(tipoProduto){
    return await Api.post("tipoproduto/CreateApi", tipoProduto)
}

export async function AlterarTipoProduto(tipoProduto){
    return await Api.post("/tipoproduto/EditApi", tipoProduto)
}