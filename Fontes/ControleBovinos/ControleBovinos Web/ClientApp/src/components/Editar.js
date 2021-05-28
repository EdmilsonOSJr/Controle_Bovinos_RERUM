import React, { Component } from 'react';
import api from '../api';
export class Editar extends Component {
    displayName = Editar.name
    constructor(props) {
        super(props);
        this.onChangeNome = this.onChangeNome.bind(this);
        this.onChangeBrinco = this.onChangeBrinco.bind(this);
        this.onChangeBrincoPai = this.onChangeBrincoPai.bind(this);
        this.onChangeBrincoMae = this.onChangeBrincoMae.bind(this);
        this.onChangeSexo = this.onChangeSexo.bind(this);
        this.onChangeSituacao = this.onChangeSituacao.bind(this);
        this.onChangeRaca = this.onChangeRaca.bind(this);
        this.onSubmit = this.onSubmit.bind(this);
        this.state = {
            nome: '',
            brinco: '',
            brincoPai: '',
            brincoMae: '',
            sexo: '',
            situacao: '',
            raca: '',

            showSuccessBlock: false
        }
    }
    componentDidMount() {
        api.get('Crud/' + this.props.match.params.id)
            .then(response => {
                this.setState({
                    nome: response.data.nome,
                    brinco: response.data.brinco,
                    brincoPai: response.data.brincoPai,
                    brincoMae: response.data.brincoMae,
                    sexo: response.data.sexo,
                    situacao: response.data.situacao,
                    raca: response.data.raca,
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
        };
        api.put('Crud/' + this.props.match.params.id, obj).then(response => {
            this.setState({ showSuccessBlock: true })
        }).catch(err => { console.log(err) })
   
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
                        <label>Brinco: </label>
                        <input
                            style={{ textTransform: 'capitalize' }}
                            type="text"
                            className="form-control"
                            value={this.state.brinco}
                            onChange={this.onChangeBrinco}
                            required
                            readonly="readonly"
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