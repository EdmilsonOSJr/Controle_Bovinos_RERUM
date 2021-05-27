import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { Glyphicon, Nav, Navbar, NavItem } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';
import './NavMenu.css';

export class NavMenu extends Component {
  displayName = NavMenu.name

  render() {
    return (
     <Navbar inverse fixedTop fluid collapseOnSelect>
 <Navbar.Header>
 <Navbar.Brand>
 <Link to={'/'}>Cadastro de Bovinos</Link>
 </Navbar.Brand>
 <Navbar.Toggle />
 </Navbar.Header>
 <Navbar.Collapse>
 <Nav>
 <LinkContainer to={'/'} exact>
 <NavItem>
 <Glyphicon glyph='home' /> Home
 </NavItem>
 </LinkContainer>
 <LinkContainer to={'/listagem'}>
 <NavItem>
 <Glyphicon glyph='th-list' /> Listagem de Bovinos
 </NavItem>
 </LinkContainer>
 <LinkContainer to={'/cadastro'}>
 <NavItem>
                            <Glyphicon glyph='pencil' /> Cadastro de Pessoas
                            </NavItem>
                    </LinkContainer>
                </Nav>
            </Navbar.Collapse>
        </Navbar>
    );
  }
}
