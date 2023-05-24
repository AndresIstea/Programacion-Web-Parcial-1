USE [Parcial1]
GO

DROP TABLE IF EXISTS Ventas
GO

DROP TABLE IF EXISTS Productos
GO

CREATE TABLE Productos(
    Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Tipo varchar(50) NOT NULL,
    Descripcion varchar(50) NOT NULL,
    Precio float NULL,
)
GO

INSERT INTO Productos
           (Tipo,
            Descripcion,
            Precio)
     VALUES
           ('Cafe','Expresso', 800),
           ('Cafe','Cappuccino', 1200),
           ('Cafe','Latte', 1400),
           ('Nevado','Chococaramelo', 1800),
           ('Cafe en Grano','Colina 454gr', 8500.99 ),
           ('Cafe en Grano','Volcan 454gr', 8525.99 ),
           ('Cafe Molido','Cumbre Descafeinado 340gr', 5995.99),
           ('Cafetera','Moka Pedrini Infinity 3 Tazas', 21450),
           ('Cafetera','Bodum Chambord cobre 8 pocillos', 63800),
           ('Vaso','Vaso Térmico Juan Valdez', 4500),
           ('Vaso','Botella Juan Valdez', 4500)
GO

CREATE TABLE Ventas(
    Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
    NombreCliente varchar(100) NOT NULL,
    ProductoId int NOT NULL FOREIGN KEY REFERENCES Productos(Id),
    Cantidad int NULL,
)
GO

INSERT INTO Ventas
           (NombreCliente,
            ProductoId,
            Cantidad)
     VALUES
           ('Andrés Serrano', 5, 2),
           ('Andrés Serrano', 8, 1),
           ('Ariel Mercado', 5, 1),
           ('Ariel Mercado', 1, 1),
           ('Andrés Serrano', 2, 1),
           ('Natalia Cerdá', 2, 1),
           ('Natalia Cerdá', 10, 1),
           ('Rocío Ríos', 4, 1 )
GO
