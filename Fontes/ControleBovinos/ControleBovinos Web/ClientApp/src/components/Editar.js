import React, { Component } from 'react';
import api from '../api';
export class Editar extends Component {
    displayName = Editar.name
    constructor(props) {
        super(props);
        this.onChangeNome = this.onChangeNome.bind(this);
        this.onChangeCPF = this.onChangeCPF.bind(this);
        this.onChangeRG = this.onChangeRG.bind(this);
        this.onSubmit = this.onSubmit.bind(this);
        this.state = {
            nome: '',
            CPF: '',
            RG: '',
            showSuccessBlock: false
        }
    }
    componentDidMount() {
        api.get('Crud/' + this.props.match.params.id)
            .then(response => {
                this.setState({
                    nome: response.data.nome,
                    CPF: response.data.cpf,
                    RG: response.data.rg
                });
                console.log(response.data);
            })
            .catch(function (error) {
                console.log(error);
            })
    }
    onChangeNome(e) {
        this.setState({
            nome: e.target.value
        });
    }
    onChangeCPF(e) {
        this.setState({
            CPF: e.target.value
        })
    }
    onChangeRG(e) {
        this.setState({
            RG: e.target.value
        })
    }

    onSubmit(e) {
        e.preventDefault();
        const obj = {
            nome: this.state.nome,
            CPF: this.state.CPF,
            RG: this.state.RG,
        };
        api.put('Crud/' + this.props.match.params.id, obj)
        // .then(response => console.log(response.data))
        this.setState({
            nome: '',
            RG: '',
            CPF: '',
        });
        this.setState({
            showSuccessBlock: true
        });
    }
    render() {
        return !this.state.showSuccessBlock ?
            <div style={{
                marginTop: 20, display: 'flex', justifyContent: 'center', flexDirection: 'column',
                alignItems: 'center'
            }}>
                <h3 style={{ textAlign: 'center', marginBottom: 40 }}>Editar Usuário</h3>
                <form style={{ width: '50%' }} onSubmit={this.onSubmit}>
                    <div className="form-group">
                        <label>Nome: </label>
                        <input
                            style={{ textTransform: 'capitalize' }}
                            type="text"
                            className="form-control"
                            value={this.state.nome}
                            onChange={this.onChangeNome}
                            required
                        />
                    </div>
                    <div className="form-group">
                        <label>CPF: </label>
                        <input
                            style={{ textTransform: 'capitalize' }}
                            type="text"
                            className="form-control"
                            value={this.state.CPF}
                            onChange={this.onChangeCPF}
                            required
                        />
                    </div>
                    <div className="form-group">
                        <label>RG: </label>
                        <input
                            style={{ textTransform: 'capitalize' }}
                            type="text"
                            className="form-control"
                            value={this.state.RG}
                            onChange={this.onChangeRG}
                            required
                        />
                    </div>
                    <div style={{
                        display: 'flex', justifyContent: 'center', flexDirection: 'column', alignItems:
                            'center'
                    }} className="form-group" >
                        <input type="submit" value="Editar" className="btn btn-primary" />
                    </div>
                </form>
            </div>
            :
            <div style={{
                marginTop: 20, display: 'flex', justifyContent: 'center', flexDirection: 'column',
                alignItems: 'center'
            }} >
                <h3 style={{
                    backgroundColor: '#60d17e', color: '#fff', padding: 30, borderRadius: 10
                }}>Editado com sucesso!</h3>
                <button
                    onClick={() => (
                        this.setState({
                            showSuccessBlock: false
                        }),
                        this.props.history.push('/listagem')
                    )}
                    className="btn"
                >
                    Voltar
 </button>
            </ div>
    }
}