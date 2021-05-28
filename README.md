# ASP_FRAMEWORK_CLIMA

## Base de datos

```sql
--  CREACION DE LA TABLA
create table Clima(
	ClimaId int PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	Localidad varchar(50) NOT NULL,
	Temperatura float NOT NULL,
	Trecipitaciones float NOT NULL,
	Viento float NOT NULL,
	FechaCreacion datetime DEFAULT(getdate()) 
);


-- AGREGAR CAMPO CALCULADO PARA EL TIEMPO ATMOSFERICO
ALTER TABLE Clima
ADD TiempoAtmosf�rico as (Temperatura + Trecipitaciones + FechaCreacion);


INSERT INTO [dbo].[Clima]
           ([Localidad]
           ,[Temperatura]
           ,[Trecipitaciones]
           ,[Viento]
           ,[FechaCreacion])
     VALUES
           ('Bogota'
           ,16
           ,3
           ,15
           ,GETDATE()),
		   ('Medellin'
           ,16
           ,3
           ,15
           ,GETDATE()),
		   ('Manizales'
           ,16
           ,3
           ,15
           ,GETDATE()),
		   ('Cali'
           ,16
           ,3
           ,15
           ,GETDATE())

```

## login

![imagen](img/login.png)

## login validaciones

![imagen](img/2.png)

## registro

![imagen](img/registro.png)

## listar

![imagen](img/listar.png)

## crear

![imagen](img/creacionclima.png)

## modificar 

![imagen](img/modificacion.png)

## eliminar

![imagen](img/eliminar.png)

# NOTA

No pude terminar todas las validaciones de los inputs pero se como implementarlas. 
