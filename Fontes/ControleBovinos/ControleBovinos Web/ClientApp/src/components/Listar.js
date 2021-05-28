import React, { Component } from 'react';
import { MdEdit, MdDelete } from 'react-icons/md';
import { Link } from 'react-router-dom';
import api from '../api';
export class Listar extends Component {
    displayName = Listar.name
    constructor(props) {
        super(props);
        this.state = { bovinos: [], loading: true }

        api.get('Crud/'+this.props.match.params.tipo+'/'+this.props.match.params.valor)
            .then(response => {
                this.setState({ bovinos: response.data, loading: false });
            });
    }
    static renderBovinosTable(bovinos) {
        return (
            <table className='table'>
                <thead>
                    <tr>
                        <th>Identificador</th>
                        <th>Nome</th>
                        <th>Brinco</th>
                        <th>Brinco Pai</th>
                        <th>Brinco Mãe</th>
                        <th>Sexo</th>
                        <th>Situação</th>
                        <th>Raça</th>
                        <th>Data de Nascimento</th>
                        <th>Data de Prenches</th>
                        <th>Data Último Parto</th>
                        <th>Editar</th>
                        <th>Deletar</th>
                    </tr>
                </thead>
                <tbody>
                    {bovinos.map(bovino =>
                        <tr key={bovino.cod_objeto}>
                            <td>{bovino.cod_objeto}</td>
                            <td>{bovino.nome}</td>
                            <td>{bovino.brinco}</td>
                            <td>{bovino.brincoPai}</td>
                            <td>{bovino.brincoMae}</td>
                            <td>{bovino.sexo}</td>
                            <td>{bovino.situacao}</td>
                            <td>{bovino.raca}</td>
                            <td>{bovino.dataNascimento}</td>
                            <td>{bovino.dataPrenches}</td>
                            <td>{bovino.dataUltimoParto}</td>
                            <td style={{ paddingLeft: 12 }}>
                                <button>
                                    <Link to={"/editar/" + bovino.cod_objeto}>
                                        <MdEdit style={{ fontSize: 20, color: 'black' }} />
                                    </Link>
                                </button>
                            </td>
                            <td style={{ paddingLeft: 12 }}>
                                <button onClick={() => (
                                    (api.delete('Crud/' + bovino.cod_objeto)
                                        .then(window.location.reload(true))
                                        .catch(err => console.log(err))
                                    ))
                                }>
                                    <MdDelete style={{ fontSize: 20, color: 'black' }} />
                                </button>
                            </td>
                        </tr>
                    )}
                </tbody>
            </table>

        );
    }
    render() {
        
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Listar.renderBovinosTable(this.state.bovinos);
        return (
            <div>
                <h1>Listagem </h1>
                <p>Listagem </p>
                {contents}
            </div>
        );
    }
}