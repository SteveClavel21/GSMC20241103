Create database GSMC20241103DB

CREATE TABLE Computadoras (
    Id INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(100) NOT NULL,
    Marca NVARCHAR(50),
    Modelo NVARCHAR(50),
    Precio DECIMAL(10, 2)
);

-- Crear tabla para los componentes de las computadoras
CREATE TABLE Componentes (
    Id INT PRIMARY KEY IDENTITY,
    ComputadoraId INT FOREIGN KEY REFERENCES Computadoras(Id),
    Nombre NVARCHAR(100) NOT NULL,
    Tipo NVARCHAR(50),
    Marca NVARCHAR(50),
    Precio DECIMAL(10, 2)
);