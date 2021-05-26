{
  "name": "RecuperarBovinoPorId",
  "base": "RTEvent",
  "tableName": "TRNBovino",
  "transactionName": "TRNBovino",
  "javaimport": [],
  "callBaseWithFalse": true,
  "javapkg": "Cadastro",
  "cspkg": "Cadastro",
  "csimport": [],
  "author": "Rerum",
  "created": "2021-05-26T12:30:56-03:00",
  "modified": "2021-05-26T13:45:27-03:00",
  "attributes": [
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
  "transitions": [],
  "events": [],
  "states": [],
  "estereotipo": "event"
}