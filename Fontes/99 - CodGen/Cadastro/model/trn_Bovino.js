{
  "name": "Bovino",
  "base": "RPOTransaction",
  "tableName": "",
  "transactionName": "",
  "javaimport": [],
  "callBaseWithFalse": true,
  "javapkg": "Cadastro",
  "cspkg": "Cadastro",
  "csimport": [],
  "author": "Rerum",
  "created": "2021-05-26T13:47:08-03:00",
  "modified": "2021-05-26T13:53:15-03:00",
  "attributes": [
    {
      "isDom": false,
      "field": "brinco",
      "column": "brinco",
      "type": "TString",
      "stype": "object",
      "rpotype": "TString",
      "doc": "NA"
    },
    {
      "isDom": false,
      "field": "nome",
      "column": "nome",
      "type": "TString",
      "stype": "object",
      "rpotype": "TString",
      "doc": "NA"
    },
    {
      "isDom": false,
      "field": "retornoConsulta",
      "column": "retornoConsulta",
      "type": "RTTList",
      "stype": "object",
      "rpotype": "RTTList",
      "doc": "NA"
    },
    {
      "isDom": false,
      "field": "idBovino",
      "column": "idBovino",
      "type": "TObjectId",
      "stype": "object",
      "rpotype": "TObjectId",
      "doc": "NA"
    },
    {
      "isDom": false,
      "field": "bovino",
      "column": "bovino",
      "type": "Bovino",
      "stype": "object",
      "rpotype": "Bovino",
      "doc": "NA"
    }
  ],
  "associations": [],
  "aggregations": [],
  "transitions": [
    {
      "from": "Inicial",
      "to": "BovinoMantido",
      "event": "ManterBovino"
    },
    {
      "from": "Inicial",
      "to": "BovinoRecuperado",
      "event": "RecuperarBovinoPorId"
    },
    {
      "from": "Inicial",
      "to": "BovinosRecuperados",
      "event": "ConsultarBovinos"
    }
  ],
  "events": [
    {
      "name": "ManterBovino"
    },
    {
      "name": "RecuperarBovinoPorId"
    },
    {
      "name": "ConsultarBovinos"
    }
  ],
  "states": [
    {
      "name": "Inicial"
    },
    {
      "name": "BovinoMantido"
    },
    {
      "name": "BovinoRecuperado"
    },
    {
      "name": "BovinosRecuperados"
    }
  ],
  "estereotipo": "transaction"
}