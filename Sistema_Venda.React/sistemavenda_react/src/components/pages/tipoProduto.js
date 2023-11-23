import React, { useState, useEffect } from 'react'
import { AlterarTipoProduto, CadastratTipoProduto, ListarTiposProduto } from '../../services/serviceTipoProduto'
import './tipoProduto.css'

const TipoProduto = () => {
    const [listaTipoProduto, setListaTipoProduto] = useState([])
    const [descricao, setDescricao] = useState('')
    const [codigo, setCodigo] = useState(0)
    const [alterar, setAlterar] = useState(false)
    const [salvou, setSalvou] = useState(false)


    const ListarDados = () => {
        ListarTiposProduto().then(res => {
            setListaTipoProduto(res.data)
        })
    }

    const Salvar = () => {
        if (alterar) {
            let tipoProduto = {
                tipCodigo: codigo,
                tipDescricao: descricao
            }

            AlterarTipoProduto(tipoProduto).then(res => {
                alert('dados alterados com sucesso')
            }).catch((err) => {
                alert(err)
            })
        }
        else {
            let tipoProduto = {
                tipDescricao: descricao
            }
            CadastratTipoProduto(tipoProduto).then(res => {
                alert('dados salvos com sucesso')
            }).catch((err) => {
                alert(err)
            })
        }
        setSalvou(true)

    }

    const Alterar = (item) => {
        setAlterar(true)
        setDescricao(item.tipDescricao)
        setCodigo(item.tipCodigo)

    }

    useEffect(() => {
        ListarDados()
    }, [salvou])

    return (

        <>
            <label>Tipo Produto</label>
            <input className="form-control"type="text" value={descricao} onChange={(e) => setDescricao(e.target.value)}></input>
            <button className='btn btn-primary' type="button" onClick={Salvar}>Salvar</button>

            <table className='table '>
                <thead>
                    <tr>
                        <th>
                            Tipo
                        </th>
                        <th>
                            Acão
                        </th>
                    </tr>
                </thead>
                <tbody>
                    {listaTipoProduto && listaTipoProduto?.map(item => (
                        <tr key={'lin' + item.tipCodigo}>
                            <td key={item.tipCodigo}>
                                {item.tipDescricao}

                            </td>
                            <td>
                                <button className='btn btn-secondary' onClick={() => Alterar(item)} type="button">Alterar</button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>

        </>
    )
}

export default TipoProduto