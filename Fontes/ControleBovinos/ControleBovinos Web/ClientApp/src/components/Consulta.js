import React, { Component } from 'react';
import { Link } from 'react-router-dom';
export class Consulta extends Component {
    displayName = Consulta.name
    constructor(props) {
        super(props);
        this.onChangeTipo = this.onChangeTipo.bind(this);
        this.onChangeValor = this.onChangeValor.bind(this);


        this.state = {
            tipo: 'nome',
            valor: '',

            showSuccessBlock: false
        }
    }

    onChangeTipo(e) {
        this.setState({
            tipo: e.target.value
        })

    }

    onChangeValor(e) {
        this.setState({
            valor: e.target.value
        })
    }

    render() {
        return <div style={{
            marginTop: 20, display: 'flex', justifyContent: 'center', flexDirection: 'column',
            alignItems: 'center'
        }}>
            <h3 style={{ textAlign: 'center', marginBottom: 40 }}>Consulta de Bovinos</h3>
            <form style={{ width: '50%' }}>

                <div className="form-group">
                    <label>Tipo: </label><br />
                    <select style={{ textTransform: 'capitalize' }}
                        className="form-control"
                        value={this.state.tipo}
                        onChange={this.onChangeTipo}>
                        <option value="nome">Nome</option>
                        <option value="brinco">Brinco</option>
                    </select>
                </div>

                <div className="form-group">
                    <label>Valor: </label>
                    <input
                        style={{ textTransform: 'capitalize' }}
                        type="text"
                        className="form-control"
                        value={this.state.valor}
                        onChange={this.onChangeValor}
                        required="required"
                    />
                </div>
               
                <td style={{ paddingLeft: 12 }}>
                   
                </td>
                
                <div style={{
                    display: 'flex', justifyContent: 'center', flexDirection: 'column', alignItems:
                        'center'
                }} className="form-group" >
                        <Link to={"/listar/" + this.state.tipo + "/" + this.state.valor}>
                            <button className="btn btn-primary">Consultar</button>
                        </Link>
                </div>
            </form>

        </div>
    }
    
}