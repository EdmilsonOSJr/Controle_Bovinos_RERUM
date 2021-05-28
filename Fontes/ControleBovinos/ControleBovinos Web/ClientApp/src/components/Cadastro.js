import React, { Component } from 'react';
import api from '../api';
export class Cadastro extends Component {
    displayName = Cadastro.name
    constructor(props) {
        super(props);
        this.onChangeNome = this.onChangeNome.bind(this);
        this.onChangeBrinco = this.onChangeBrinco.bind(this);
        this.onChangeBrincoPai = this.onChangeBrincoPai.bind(this);
        this.onChangeBrincoMae = this.onChangeBrincoMae.bind(this);
        this.onChangeSexo = this.onChangeSexo.bind(this);
        this.onChangeSituacao = this.onChangeSituacao.bind(this);
        this.onChangeRaca = this.onChangeRaca.bind(this);
        this.onChangeDataNascimento = this.onChangeDataNascimento.bind(this);
       
        this.onSubmit = this.onSubmit.bind(this);
        this.state = {
            nome: '',
            brinco: '',
            brincoPai: '',
            brincoMae: '',
            sexo: '',
            situacao: '',
            raca: '',
            dataNascimento: '',
            
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
    onChangeBrincoMae(e) {
        this.setState({
            brincoMae: e.target.value
        })
    }
    onChangeSexo(e) {
        this.setState({
            sexo: e.target.value
        })

        if (e.target.value == "macho") {
            document.getElementById("dataN").setAttribute("readonly", "readonly");
            this.state.dataNascimento = '';
        }
        else
            document.getElementById("dataN").removeAttribute("readonly");
    }
    onChangeSituacao(e) {
        this.setState({
            situacao: e.target.value
        })
    }
    onChangeRaca(e) {
        this.setState({
            raca: e.target.value
        })

    }

    onChangeDataNascimento(e) {
        this.setState({
            dataNascimento: e.target.value
        })
    }
    

    onSubmit(e) {
        e.preventDefault();
        const obj = {
            nome: this.state.nome,
            brinco: this.state.brinco,
            brincoPai: this.state.brincoPai,
            brincoMae: this.state.brincoMae,
            sexo: this.state.sexo,
            situacao: this.state.situacao,
            raca: this.state.raca,
            dataNascimento: this.state.dataNascimento,
            
        };
        api.post('Crud', obj)
            .then(response => {
                this.setState({ showSuccessBlock: true })
            })
            .catch(err => { console.log(err) })

        this.setState({
            nome: '',
            brinco: '',
            brincoPai: '',
            brincoMae: '',
            sexo: '',
            situacao: '',
            raca: '',
            dataNascimento: '',
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
                            type="text"
                            className="form-control"
                            value={this.state.brinco}
                            onChange={this.onChangeBrinco}
                            required
                        />
                    </div>
                    <div className="form-group">
                        <label>Brinco do Pai: </label>
                        <input
                            style={{ textTransform: 'capitalize' }}
                            type="text"
                            className="form-control"
                            value={this.state.brincoPai}
                            onChange={this.onChangeBrincoPai}
                        />
                    </div>
                    <div className="form-group">
                        <label>Brinco da Mãe: </label>
                        <input
                            style={{ textTransform: 'capitalize' }}
                            type="text"
                            className="form-control"
                            value={this.state.brincoMae}
                            onChange={this.onChangeBrincoMae}
                        />
                    </div>
                    <div className="form-group">
                        <label>Sexo: </label><br />
                        <select style={{ textTransform: 'capitalize' }}
                            className="form-control"
                            value={this.state.sexo}
                            onChange={this.onChangeSexo}>

                            <option value="macho">Macho</option>
                            <option value="femea">Fêmea</option>
                        </select>
                    </div>
                    <div className="form-group">
                        <label>Situação: </label>
                        <select style={{ textTransform: 'capitalize' }}
                            className="form-control"
                            value={this.state.situacao}
                            onChange={this.onChangeSituacao}>

                            <option value="Em lactação">Em lactação</option>
                            <option value="Seca">Seca</option>
                            <option value="Vendido">Vendido</option>
                            <option value="Morto">Morto</option>
                        </select>
                    </div>
                    <div className="form-group">
                        <label>Raça: </label>
                        <select style={{ textTransform: 'capitalize' }}
                            className="form-control"
                            value={this.state.raca}
                            onChange={this.onChangeRaca}>

                            <option value="Gitolando">Gitolando</option>
                            <option value="Holandes">Holandes</option>
                            <option value="Gir">Gir</option>
                            <option value="Jersey">Jersey</option>
                        </select>
                    </div>

                    <div className="form-group">
                        <label>Data de Nascimento: </label>
                        <input
                            id="dataN"
                            style={{ textTransform: 'capitalize' }}
                            type="text"
                            className="form-control"
                            value={this.state.dataNascimento}
                            onChange={this.onChangeDataNascimento}
                            readonly="readonly"
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