/*DATABASE*/
CREATE DATABASE ConnectPlus;
GO;



/*TABELAS*/
CREATE TABLE TipoContato(
IdTipoContato UNIQUEIDENTIFIER   PRIMARY  KEY   DEFAULT ((NEWID())),
Titulo        NVARCHAR(255)      NOT      NULL                     ,
);

CREATE TABLE Contado(
IdContato     UNIQUEIDENTIFIER   PRIMARY  KEY   DEFAULT ((NEWID())), 

Nome          NVARCHAR(255)      NOT      NULL                     ,
FormaContato  NVARCHAR(255)      NOT      NULL                     ,
Imagens       NVARCHAR(255)      NOT      NULL                     ,
FromaContato  NVARCHAR(255)      NOT      NULL                     ,

IdTipoContato UNIQUEIDENTIFIER

FOREIGN KEY REFERENCES TipoContato(IdTipoContato)                  ,   


);

SELECT * FROM TipoContato
SELECT * FROM Contado


ALTER TABLE Contado
DROP COLUMN FromaContato;