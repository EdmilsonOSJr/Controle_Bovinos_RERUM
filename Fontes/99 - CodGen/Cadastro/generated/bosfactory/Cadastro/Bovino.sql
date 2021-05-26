-- ----------------------------------------------------------------------------------------------------
DELETE FROM bosfactory
WHERE  heranca = 'Bovino.RPOObject';

INSERT INTO bosfactory
            (clid,
             clname,
             bos,
             col,
             heranca)
VALUES      (0,
             'Bovino',
             'Cadastro::application.bos.Bovino',
             'Cadastro::application.col.ColBovino',
             'Bovino.RPOObject'); 
-- ----------------------------------------------------------------------------------------------------