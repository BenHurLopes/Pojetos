
    if exists (select * from dbo.sysobjects where id = object_id(N'PESSOA') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table PESSOA

    if exists (select * from dbo.sysobjects where id = object_id(N'PRODUTO') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table PRODUTO

    create table PESSOA (
        ID INT IDENTITY NOT NULL,
       NOME NVARCHAR(255) not null,
       DATANASCIMENTO DATETIME2 not null,
       primary key (ID)
    )

    create table PRODUTO (
        ID INT IDENTITY NOT NULL,
       CODIGO NVARCHAR(255) not null,
       NOME NVARCHAR(255) not null,
       PRECOUNITARIO FLOAT(53) not null,
       primary key (ID)
    )
