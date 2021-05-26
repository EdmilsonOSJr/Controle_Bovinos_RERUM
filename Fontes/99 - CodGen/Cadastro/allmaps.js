{
  "lib": "Cadastro",
  "types": [
    {
      "name": "Bovino",
      "model": "Bovino",
      "persistent": true,
      "skip": false,
      "skipgui": true,
      "converter": {
        "cs": {
          "useBos": false
        }
      }
    }
  ],
  "trns": [
    {
      "name": "Bovino",
      "skip": false,
      "skipgui": true
    }
  ],
  "evts": [
    {
      "name": "ConsultarBovinos",
      "skip": false,
      "skipgui": true
    },
    {
      "name": "ManterBovino",
      "skip": false,
      "skipgui": true
    },
    {
      "name": "RecuperarBovinoPorId",
      "skip": false,
      "skipgui": true
    }
  ],
  "doms": [],
  "tads": []
}