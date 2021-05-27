import React, { Component } from 'react';
import api from '../api';
export class Cadastro extends Component {
    displayName = Cadastro.name
    constructor(props) {
        super(props);
        this.onChangeNome = this.onChangeNome.bind(this);
        this.onChangeBrinco = this.onChangeBrinco.bind(this);
        this.onChangeBrincoPai = this.onChangeBrincoPai.bind(this);
        this.onSubmit = this.onSubmit.bind(this);
        this.state = {
            nome: '',
            brinco: '',
            brincoPai: '',
            showSuccessBlock: false
        }
    }
    onChangeNome(e) {
        this.setState({
            nome: e.target.value
        });
    }
    onChangeBrinco(e) {
        this.setState({
            brinco: e.target.value
        })
    }
    onChangeBrincoPai(e) {
        this.setState({
            brincoPai: e.target.value
        })
    }
    onSubmit(e) {
        e.preventDefault();
        const obj = {
            nome: this.state.nome,
            brinco: this.state.brinco,
            brincoPai: this.state.brincoPai,
        };
        api.post('Crud', obj)
            .then(response => console.log(response.data))

        this.setState({
            nome: '',
            brinco: '',
            brincoPai: '',
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
                <h3 style={{ textAlign: 'center', marginBottom: 40 }}>Cadastro de Bovinos</h3>
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
                        <label>Brinco: </label>
                        <input
                            style={{ textTransform: 'capitalize' }}
                            type="number"
                            className="form-control"
                            value={this.state.brinco}
                            onChange={this.onChangeBrinco}
                            required
                        />
                    </div>
                    <div className="form-group">
                        <label>Brinco pai: </label>
                        <input
                            style={{ textTransform: 'capitalize' }}
                            type="number"
                            className="form-control"
                            value={this.state.brincoPai}
                            onChange={this.onChangeBrincoPai}
                            required
                        />
                    </div>

                    <div style={{
                        display: 'flex', justifyContent: 'center', flexDirection: 'column', alignItems:
                            'center'
                    }} className="form-group" >
                        <input type="submit" value="Cadastrar" className="btn btn-primary" />
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
                }}>Cadastrado com sucesso!</h3>
                <button
                    onClick={() => (
                        this.setState({
                            showSuccessBlock: false
                        }),
                        this.props.history.push('/cadastro')
                    )}
                    className="btn"
                >
                    Voltar
 </button>
            </ div>
    }
}