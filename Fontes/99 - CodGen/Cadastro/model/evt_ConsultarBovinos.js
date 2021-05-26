{
  "name": "ConsultarBovinos",
  "base": "RTEvent",
  "tableName": "TRNBovino",
  "transactionName": "TRNBovino",
  "javaimport": [],
  "callBaseWithFalse": true,
  "javapkg": "Cadastro",
  "cspkg": "Cadastro",
  "csimport": [],
  "author": "Rerum",
  "created": "2021-05-26T12:07:53-03:00",
  "modified": "2021-05-26T13:45:27-03:00",
  "attributes": [
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
      "field": "brinco",
      "column": "brinco",
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
    }
  ],
  "associations": [],
  "aggregations": [],
  "transitions": [],
  "events": [],
  "states": [],
  "estereotipo": "event"
}