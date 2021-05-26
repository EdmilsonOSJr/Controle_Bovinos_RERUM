--Cria a tabela bovino
CREATE TABLE bovino (
cod_objeto varchar(36) NOT NULL,
brinco varchar(8) NOT NULL,
nome varchar(20) NOT NULL,
situacao varchar(15) NULL,
sexo varchar(9) NULL,
brincoMae varchar(8) NULL,
brincoPai varchar(8) NULL,
raca varchar(15) NULL,
dataNascimento timestamp NULL, 
dataPrenches timestamp NULL,
dataUltimoParto timestamp NULL
);