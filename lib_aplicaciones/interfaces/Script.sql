/*CREATE DATABASE ExFit;
GO
USE ExFit;
GO

CREATE TABLE Gym (
    Id INT PRIMARY KEY IDENTITY(1,1),
    direccion VARCHAR(150) NOT NULL,
    horario VARCHAR(50) NOT NULL,
    telefono VARCHAR(20),
    fecha DATE
);

INSERT INTO Gym (direccion, horario, telefono, fecha) VALUES
('Cl. 10 #43-12', '05:00 - 22:00', '6044440001', '2026-01-15'),
('Cr. 43A #1-50', '06:00 - 21:00', '6044440002', '2026-02-01'),
('Av. El Poblado #15-20', '05:00 - 23:00', '6044440003', '2026-03-10'),
('Tv. Inferior #10-35', '06:00 - 20:00', '6044440004', '2026-04-05'),
('Cll. 50 #50-20', '05:00 - 22:00', '6044440005', '2026-05-12');



CREATE TABLE Trabajadores (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100) NOT NULL,
    C_c VARCHAR(20) NOT NULL,
    Cargo VARCHAR(100) NOT NULL,
    Salario DECIMAL(12,2) NOT NULL,
    Edad INT
);

INSERT INTO Trabajadores
(Nombre, C_c, Cargo, Salario, Edad) VALUES
('Carlos Gómez', '1017123456', 'Entrenador', 2500000, 28),
('Ana Martínez', '1020654321', 'Recepcionista', 1400000, 24),
('Luis Hernández', '987654321', 'Aseo', 1300000, 35),
('Sofia Ruiz', '1035987654', 'Nutricionista', 3000000, 30),
('Mateo Toro', '1015432189', 'Administrador', 3500000, 32);



CREATE TABLE Cargos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Trabajador INT NOT NULL,
    Mozo VARCHAR(20),
    Crush VARCHAR(20),
    Petalo VARCHAR(20),
    Oficial VARCHAR(20),
    FOREIGN KEY (Trabajador) REFERENCES Trabajadores(Id)
);

INSERT INTO Cargos
(Trabajador, Mozo, Crush, Petalo, Oficial) VALUES
(1, 'No', 'Si', 'No', 'Si'),
(2, 'Si', 'No', 'Si', 'No'),
(3, 'No', 'No', 'No', 'Si'),
(4, 'No', 'Si', 'Si', 'Si'),
(5, 'No', 'No', 'No', 'Si');



CREATE TABLE Asistencia_Trabajadores (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Id_Trabajador INT NOT NULL,
    Fecha DATETIME NOT NULL,
    Hora_Entrada DATETIME NOT NULL,
    Hora_Salida DATETIME,
    FOREIGN KEY (Id_Trabajador) REFERENCES Trabajadores(Id)
);

INSERT INTO Asistencia_Trabajadores
(Id_Trabajador, Fecha, Hora_Entrada, Hora_Salida) VALUES
(1, '2026-08-25', '05:00:00', '13:00:00'),
(2, '2026-08-25', '06:00:00', '14:00:00'),
(3, '2026-08-25', '13:00:00', '21:00:00'),
(4, '2026-08-25', '08:00:00', '16:00:00'),
(5, '2026-08-25', '07:30:00', '17:30:00');



CREATE TABLE Mantenimiento_Equipos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre_equipo VARCHAR(100) NOT NULL,
    Fecha_Mantenimiento DATE NOT NULL,
    Costo_Servicio DECIMAL(12,2) NOT NULL,
    Estado_Actual VARCHAR(50) NOT NULL
);

INSERT INTO Mantenimiento_Equipos
(Nombre_equipo, Fecha_Mantenimiento, Costo_Servicio, Estado_Actual) VALUES
('Caminadora 01', '2026-08-10', 250000, 'Operativo'),
('Elíptica 03', '2026-08-12', 180000, 'Operativo'),
('Prensa 45°', '2026-08-15', 120000, 'En Reparación'),
('Bicicleta Estática 05', '2026-08-18', 90000, 'Operativo'),
('Abductor', '2026-08-03', 100000, 'En Reparación');



CREATE TABLE Ejercicios (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre_Ejercicio VARCHAR(100) NOT NULL,
    Grupo_Muscular VARCHAR(100) NOT NULL,
    Equipo_Requerido VARCHAR(100),
    Nivel_Dificualtad VARCHAR(50)
);

INSERT INTO Ejercicios
(Nombre_Ejercicio, Grupo_Muscular, Equipo_Requerido, Nivel_Dificualtad) VALUES
('Sentadilla Libre', 'Cuádriceps / Glúteos', 'Barra y Discos', 'Intermedio'),
('Press de Banca', 'Pecho', 'Banco Horizontal', 'Avanzado'),
('Dominadas', 'Espalda', 'Barra Fija', 'Avanzado'),
('Cuerda Naval', 'Cardio / Hombros', 'Cuerda', 'Principiante'),
('Desplante con Mancuerna', 'Piernas', 'Mancuernas', 'Intermedio');



CREATE TABLE Clientes (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100) NOT NULL,
    C_c VARCHAR(20) NOT NULL,
    Membresia INT NOT NULL,
    Edad INT,
    Huella VARCHAR(100)
);

INSERT INTO Clientes
(Nombre, C_c, Membresia, Edad, Huella) VALUES
('Mariana López', '1036456789', 301, 22, 'HUELLA_201.DAT'),
('Camilo Ortiz', '1018987654', 302, 26, 'HUELLA_202.DAT'),
('Valeria Ríos', '1025345678', 303, 20, 'HUELLA_203.DAT'),
('Daniel Cano', '1040123987', 404, 29, 'HUELLA_204.DAT'),
('Andrea Morales', '1019876123', 505, 24, 'HUELLA_205.DAT');



CREATE TABLE Membresias (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Cliente INT NOT NULL,
    TusaFit BIT,
    SuperaFit BIT,
    SanandoFit BIT,
    NomasExs BIT,
    FOREIGN KEY (Cliente) REFERENCES Clientes(Id)
);

INSERT INTO Membresias
(Cliente, TusaFit, SuperaFit, SanandoFit, NomasExs) VALUES
(1, 1, 0, 0, 0),
(2, 0, 1, 0, 0),
(3, 0, 0, 1, 0),
(4, 0, 0, 0, 1),
(5, 1, 0, 0, 0);



CREATE TABLE Valoraciones_Medicas (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Id_Cliente INT NOT NULL,
    Peso DECIMAL(6,2),
    Estatura DECIMAL(4,2) ,
    IMC DECIMAL(5,2),
    Fecha_Evaluacion DATE,
    FOREIGN KEY (Id_Cliente) REFERENCES Clientes(Id)
);


INSERT INTO Valoraciones_Medicas
(Id_Cliente, Peso, Estatura, IMC, Fecha_Evaluacion) VALUES
(1, 62.5, 1.68, 22.1, '11-12-26'),
(2, 78, 1.75, 25.4, '12-09-25'),
(3, 55, 1.60, 21.4, '01-09-23'),
(4, 85.2, 1.80, 26.3, '09-07-26'),
(5, 60, 1.65, 22.0, '03-11-26');


CREATE TABLE Rutinas_Personalizadas (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Id_Cliente INT NOT NULL,
    Nombre_Rutina VARCHAR(150) NOT NULL,
    Fecha_Inicio DATE NOT NULL,
    Objetivo VARCHAR(150),
    FOREIGN KEY (Id_Cliente) REFERENCES Clientes(Id)
);

INSERT INTO Rutinas_Personalizadas
(Id_Cliente, Nombre_Rutina, Fecha_Inicio, Objetivo) VALUES
(1, 'Hipertrofia Glúteo', '2026-08-02', 'Aumento de masa'),
(2, 'Pérdida de Grasa', '2026-08-04', 'Recomposición'),
(3, 'Fuerza General', '2026-08-05', 'Ganancia de fuerza'),
(4, 'Funcional HIIT', '2026-08-06', 'Resistencia cardiovascular'),
(5, 'Tonificación General', '2026-08-07', 'Definición');



CREATE TABLE Dias_Ingreso (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Huella VARCHAR(100) NOT NULL,
    Tipo_Membresia VARCHAR(50) NOT NULL,
    Id_Cliente INT NOT NULL,
    Hora_ingreso DATETIME NOT NULL,
    Hora_Salida DATETIME,
    FOREIGN KEY (Id_Cliente) REFERENCES Clientes(Id)
);

INSERT INTO Dias_Ingreso
(Huella, Tipo_Membresia, Id_Cliente, Hora_ingreso, Hora_Salida) VALUES
('HUELLA_201.DAT', 'TusaFit', 1, '06:15:00', '07:45:00'),
('HUELLA_202.DAT', 'SuperaFit', 2, '07:00:00', '08:30:00'),
('HUELLA_203.DAT', 'SanandoFit', 3, '17:30:00', '19:00:00'),
('HUELLA_204.DAT', 'NomasExs', 4, '18:00:00', '19:45:00'),
('HUELLA_205.DAT', 'TusaFit', 5, '05:30:00', '07:00:00');



CREATE TABLE Casilleros (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Id_Casillero INT NOT NULL,
    Numero_Casillero INT NOT NULL,
    Id_Cliente INT,
    Estado VARCHAR(50) NOT NULL,
    FOREIGN KEY (Id_Cliente) REFERENCES Clientes(Id)
);

INSERT INTO Casilleros
(Id_Casillero, Numero_Casillero, Id_Cliente, Estado) VALUES
(1, 1, 1, 'Ocupado'),
(2, 2, 2, 'Ocupado'),
(3, 3, 3, 'Disponible'),
(4, 4, 4, 'Ocupado'),
(5, 5, 5, 'En Mantenimiento');


CREATE TABLE Pagos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Id_Membresia INT NOT NULL,
    Valor_a_pagar DECIMAL(12,2) NOT NULL,
    Fecha_Pago DATE NOT NULL,
    Metodo_Pago VARCHAR(100) NOT NULL,
    FOREIGN KEY (Id_Membresia) REFERENCES Membresias(Id)
);

INSERT INTO Pagos
(Id_Membresia, Valor_a_pagar, Fecha_Pago, Metodo_Pago) VALUES
(1, 120000, '20260801', 'Tarjeta de Crédito'),
(2, 150000, '20260803', 'Transferencia / Nequi'),
(3, 180000, '20260805', 'Efectivo'),
(4, 200000, '20260810', 'Tarjeta de Débito'),
(5, 120000, '20260815', 'Transferencia / Nequi');


CREATE TABLE Tipo_Clases (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Baile_con_el_petalo BIT,
    samba_con_el_mozo BIT,
    Ex_plotamos BIT,
    Huyendo BIT
);

INSERT INTO Tipo_Clases
(Baile_con_el_petalo, samba_con_el_mozo, Ex_plotamos, Huyendo) VALUES
(1, 0, 0, 0),
(0, 1, 0, 0),
(0, 0, 1, 0),
(0, 0, 0, 1),
(1, 1, 0, 0);


CREATE TABLE Clases (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre_Clase VARCHAR(100) NOT NULL,
    Tipo_Clase INT NOT NULL,
    Fecha DATETIME NOT NULL,
    Horario DATETIME NOT NULL,
    FOREIGN KEY (Tipo_Clase) REFERENCES Tipo_Clases(Id)
);

INSERT INTO Clases
(Nombre_Clase, Tipo_Clase, Fecha, Horario) VALUES
('Baile_con_el_petalo', 1, '2026-08-27', '07:00'),
('samba_con_el_mozo', 2, '2026-08-27', '18:00'),
('Ex_plotamos,', 3, '2026-08-28', '06:00'),
('Huyendo', 4, '2026-08-28', '19:00')


CREATE TABLE Reservas_Clases (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Id_Clase INT NOT NULL,
    Id_Cliente INT NOT NULL,
    Tipo_Membresia VARCHAR(50) NOT NULL,
    Fecha_Reserva DATE NOT NULL,
    Asistencia bit NOT NULL,
    FOREIGN KEY (Id_Clase) REFERENCES Clases(Id),
    FOREIGN KEY (Id_Cliente) REFERENCES Clientes(Id)
);

INSERT INTO Reservas_Clases
(Id_Clase, Id_Cliente, Tipo_Membresia, Fecha_Reserva, Asistencia) VALUES
(1, 1, 'TusaFit', '2026-08-26', 1),
(2, 2, 'SuperaFit', '2026-08-26', 0),
(3, 3, 'SanandoFit', '2026-08-27', 0),
(4, 4, 'NomasExs', '2026-08-27', 0)


CREATE TABLE Tienda (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Id_Producto INT NOT NULL,
    Precio DECIMAL(12,2) NOT NULL,
    Cantidad_Disponible INT NOT NULL,
    Cantidad_Productos INT NOT NULL,
    Id_Provedor INT NOT NULL
);

INSERT INTO Tienda
(Id_Producto, Precio, Cantidad_Disponible, Cantidad_Productos, Id_Provedor) VALUES
(1, 150000, 25, 30, 501),
(2, 12000, 40, 50, 502),
(3, 80000, 15, 20, 503),
(4, 45000, 30, 40, 501);


CREATE TABLE Productos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Id_Cliente INT NOT NULL,
    Id_Vendedor INT NOT NULL,
    Nombre_Producto VARCHAR(150) NOT NULL,
    Fecha_Venta DATE NOT NULL,
    Total DECIMAL(12,2) NOT NULL,
    FOREIGN KEY (Id_Cliente) REFERENCES Clientes(Id),
    FOREIGN KEY (Id_Vendedor) REFERENCES Trabajadores(Id)
);

INSERT INTO Productos
(Id_Cliente, Id_Vendedor, Nombre_Producto, Fecha_Venta, Total) VALUES
(1, 2, 'Proteína Whey 2lb', '2026-08-20', 150000),
(2, 2, 'BCAA Aminoácidos', '2026-08-21', 80000),
(3, 2, 'Botilito ExFit', '2026-08-22', 45000),
(4, 2, 'Barra Proteica', '2026-08-23', 12000),
(5, 2, 'Agregado Energizante', '2026-08-24', 5000);



CREATE TABLE Detalle_Producto (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Id_Venta INT NOT NULL,
    Id_Producto INT NOT NULL,
    Cantidad INT NOT NULL,
    Subtotal DECIMAL(12,2) NOT NULL,
    FOREIGN KEY (Id_Venta) REFERENCES Productos(Id)
);

INSERT INTO Detalle_Producto
(Id_Venta, Id_Producto, Cantidad, Subtotal) VALUES
(1, 1, 1, 150000),
(2, 2, 1, 80000),
(3, 3, 1, 45000),
(4, 4, 1, 12000);



CREATE TABLE Proveedores (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Id_Tienda INT NOT NULL,
    Nombre_Empresa VARCHAR(150) NOT NULL,
    Tipo_producto VARCHAR(150),
    Direccion VARCHAR(150)
);

INSERT INTO Proveedores
(Id_Tienda, Nombre_Empresa,Tipo_producto, Direccion) VALUES
(1, 'Suplementos Fit Colombia', 
 'Proteínas / Creatinas', 'Calle 100 #15-30'),

(1, 'Snacking Healthy S.A.S.',
 'Barras de Proteína', 'Carrera 50 #34-12'),

(1, 'Accesorios Deportivos REX', 
 'Botilitos y Guantes', 'Av. Industrial #12-40'),

(1, 'Bebidas Hidratantes S.A.',
 'Energizantes / Agua', 'Cll. 80 #68-15');

*/