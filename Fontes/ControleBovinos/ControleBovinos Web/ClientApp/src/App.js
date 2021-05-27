import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import { Cadastro } from './components/Cadastro';
import { ListagemBovinos } from './components/ListagemBovinos';
import { Editar } from './components/Editar';

export default class App extends Component {
  displayName = App.name

  render() {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/counter' component={Counter} />
        <Route path='/fetchdata' component={FetchData} />
        <Route path='/listagem' component={ListagemBovinos} />
        <Route path='/cadastro' component={Cadastro} />
        <Route path='/editar/:id' component={Editar} />
      </Layout>
    );
  }
}
