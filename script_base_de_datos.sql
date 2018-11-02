CREATE TABLE Usuario (
  username varchar(15) PRIMARY KEY,
  password varchar(15) NOT NULL,
  email varchar(25) NOT NULL UNIQUE,
  fecha_alta_sistema datetime,
);

CREATE TABLE Administrador (
  id INT PRIMARY KEY NOT NULL IDentity,
  id_sistema varchar(15) NOT NULL UNIQUE,
  usuario VARCHAR(15) FOREIGN KEY REFERENCES Usuario(username)
);

CREATE TABLE Zona_Geografica 
(
  id INT PRIMARY KEY NOT NULL IDentity,
  radio int NOT NULL,
  nombre_zona varchar(15) NOT NULL
);

CREATE TABLE Transformador (
  id INT PRIMARY KEY NOT NULL IDentity,
  nombre varchar(15) NOT NULL,
  activo bit NOT NULL,
  energia_suministrada float NOT NULL,
  latitud float NOT NULL,
  longitud float NOT NULL,
  zona_id INT FOREIGN KEY REFERENCES Zona_Geografica(id)
);

CREATE TABLE Categoria (
  id INT PRIMARY KEY NOT NULL IDentity,
  nombre varchar(25) NOT NULL,
  consumo_minimo float,
  consumo_maximo float,
  cargo_fijo float NOT NULL,
  cargo_variable float NOT NULL,
);

CREATE TABLE Cliente (
  id INT PRIMARY KEY NOT NULL IDentity,
  nombre varchar(25) NOT NULL ,
  apellido varchar(25) NOT NULL ,
  tipo_doc varchar(15) NOT NULL ,
  nro_doc int NOT NULL ,
  domicilio varchar(30),
  puntos int,
  telefono int,
  longitud numeric(18,2),
  latitud numeric(18,2),
  zona_id INT FOREIGN KEY REFERENCES Zona_Geografica(id),
  categoria_id INT FOREIGN KEY REFERENCES Categoria(id),
  usuario VARCHAR(15) FOREIGN KEY REFERENCES Usuario(username)
);


CREATE TABLE Dispositivo (
  id INT PRIMARY KEY NOT NULL IDentity,
  cliente_id INT FOREIGN KEY REFERENCES Cliente(id),
  nombre_generico varchar(15) NOT NULL,
  consumo_hora int NOT NULL,
  encendido bit NOT NULL,
  modo_ahorro_energia bit,
  consumo int NOT NULL,
  uso_mensual_max int,
  uso_mensual_min int,
  inteligente bit,
  tipo_dispositivo varchar(15),
  uso_estimado int
);


CREATE TABLE Template_Dispositivo
(
  id INT PRIMARY KEY NOT NULL,
  nombre_generico varchar(30) NOT NULL,
  consumo_hora numeric(18,0),
  encendido bit,
  inteligente bit
);

CREATE TABLE Actuador
(
  id INT PRIMARY KEY NOT NULL IDentity,
  accion varchar(255) NOT NULL,
  dispositivo_id INT FOREIGN KEY REFERENCES Dispositivo(id)
);

CREATE TABLE Regla
(
  id INT PRIMARY KEY IDentity,
  regla_cumplida bit,
  condicion NVARCHAR(250)
);

CREATE TABLE Actuador_Regla
(
  actuador_id int,
  regla_id int,
  CONSTRAINT actuador_regla_pk PRIMARY KEY (actuador_id, regla_id),
  CONSTRAINT FK_Actuador
      FOREIGN KEY (actuador_id) REFERENCES Actuador (id),
  CONSTRAINT FK_Regla
      FOREIGN KEY (regla_id) REFERENCES Regla (id),
);

CREATE TABLE Sensor
(
  id INT PRIMARY KEY NOT NULL IDentity,
  magnitud varchar(15) NOT NULL,
  regla_id INT FOREIGN KEY REFERENCES Regla(id)
);

-- Dispositivos editables




-- Inserts 

-- Zonas
INSERT INTO Zona_Geografica(radio,nombre_zona) VALUES (20500,'Noroeste');
INSERT INTO Zona_Geografica(radio,nombre_zona) VALUES (35000,'CentroNorte');
INSERT INTO Zona_Geografica(radio,nombre_zona) VALUES (14500,'CentroSur');
INSERT INTO Zona_Geografica(radio,nombre_zona) VALUES (15900,'Noreste');
INSERT INTO Zona_Geografica(radio,nombre_zona) VALUES (17900,'Suroeste');
INSERT INTO Zona_Geografica(radio,nombre_zona) VALUES (18300,'Sureste');

-- Transformadores
INSERT INTO Transformador(nombre,activo,energia_suministrada, latitud, longitud, zona_id)
 VALUES 
 ('T1',1,402685, -34.5550886,-58.4879849, (SELECT id FROM Zona_Geografica WHERE (nombre_zona = 'Noroeste')));

INSERT INTO Transformador(nombre,activo,energia_suministrada, latitud, longitud, zona_id)
 VALUES 
 ('T2',1,266445, -34.5808077,-58.5022721, (SELECT id FROM Zona_Geografica WHERE (nombre_zona = 'CentroNorte')));
 
INSERT INTO Transformador(nombre,activo,energia_suministrada, latitud, longitud, zona_id)
 VALUES 
 ('T3',1,345976, -34.5550886,-58.4249762, (SELECT id FROM Zona_Geografica WHERE (nombre_zona = 'CentroNorte')));
 
INSERT INTO Transformador(nombre,activo,energia_suministrada, latitud, longitud, zona_id)
 VALUES 
 ('T4',1,254633, -34.5889185,-58.4879849, (SELECT id FROM Zona_Geografica WHERE (nombre_zona = 'CentroNorte')));
 
INSERT INTO Transformador(nombre,activo,energia_suministrada, latitud, longitud, zona_id)
 VALUES 
 ('T5',1,158453.67, -34.6055194,-58.4922945, (SELECT id FROM Zona_Geografica WHERE (nombre_zona = 'CentroSur')));
 
INSERT INTO Transformador(nombre,activo,energia_suministrada, latitud, longitud, zona_id)
 VALUES 
 ('T6',1,160771.43, -34.6066519,-58.4483067, (SELECT id FROM Zona_Geografica WHERE (nombre_zona = 'CentroSur')));
 
INSERT INTO Transformador(nombre,activo,energia_suministrada, latitud, longitud, zona_id)
 VALUES 
 ('T7',1,171203.98, -34.5596464,-58.4273453, (SELECT id FROM Zona_Geografica WHERE (nombre_zona = 'Noreste')));

 INSERT INTO Transformador(nombre,activo,energia_suministrada, latitud, longitud, zona_id)
 VALUES 
 ('T8',1,198321, -34.5744547,-58.4082164, (SELECT id FROM Zona_Geografica WHERE (nombre_zona = 'Noreste')));

 INSERT INTO Transformador(nombre,activo,energia_suministrada, latitud, longitud, zona_id)
 VALUES 
 ('T9',1,387344, -34.6183406,-58.5075724, (SELECT id FROM Zona_Geografica WHERE (nombre_zona = 'Suroeste')));

 INSERT INTO Transformador(nombre,activo,energia_suministrada, latitud, longitud, zona_id)
 VALUES 
 ('T10',1,399639, -34.6097578,-58.4076118, (SELECT id FROM Zona_Geografica WHERE (nombre_zona = 'Sureste')));

-- Categoria
INSERT INTO Categoria (nombre,consumo_minimo,consumo_maximo,cargo_fijo, cargo_variable)
 VALUES 
 ('R1',null,150,18.76,0.644);
 
INSERT INTO Categoria (nombre,consumo_minimo,consumo_maximo,cargo_fijo, cargo_variable)
 VALUES 
 ('R2',150,325,35.32,0.644);
 
INSERT INTO Categoria (nombre,consumo_minimo,consumo_maximo,cargo_fijo, cargo_variable)
 VALUES 
 ('R3',325,400,60.71,0.681);

INSERT INTO Categoria (nombre,consumo_minimo,consumo_maximo,cargo_fijo, cargo_variable)
 VALUES 
 ('R4',400,450,71.74,0.738);
 
INSERT INTO Categoria (nombre,consumo_minimo,consumo_maximo,cargo_fijo, cargo_variable)
 VALUES 
 ('R5',450,500,110.38,0.794);
 
INSERT INTO Categoria (nombre,consumo_minimo,consumo_maximo,cargo_fijo, cargo_variable)
 VALUES 
 ('R6',500,600,220.75,0.832);
 
INSERT INTO Categoria (nombre,consumo_minimo,consumo_maximo,cargo_fijo, cargo_variable)
 VALUES 
 ('R7',600,700,443.59,0.851);
 
INSERT INTO Categoria (nombre,consumo_minimo,consumo_maximo,cargo_fijo, cargo_variable)
 VALUES 
 ('R8',700,1400,545.96,0.851);
 
INSERT INTO Categoria (nombre,consumo_minimo,consumo_maximo,cargo_fijo, cargo_variable)
 VALUES 
 ('R9',1400,null,887.19,0.851);

-- Usuarios

INSERT INTO Usuario (username,password,email,fecha_alta_sistema) VALUES ('admin1','admin1','admin1@gentlemen.com',getdate());
INSERT INTO Usuario (username,password,email,fecha_alta_sistema) VALUES ('cliente1','cliente1','cliente1@gentlemen.com',getdate());

INSERT INTO Cliente (nombre,apellido,tipo_doc,nro_doc,domicilio,puntos,telefono,zona_id,categoria_id,usuario)
 VALUES 
 ('Juan','Gonzalez','DNI','10101010','Calle falsa 123',20,1123933666,
 (SELECT id FROM Zona_Geografica WHERE (nombre_zona = 'Sureste')),
 (SELECT id FROM Categoria WHERE (nombre = 'R1')),
 (SELECT username FROM Usuario WHERE (email = 'cliente1@gentlemen.com')));

INSERT INTO Administrador (id_sistema,usuario) VALUES ('Admin1-2018',(SELECT username FROM Usuario WHERE (email = 'admin1@gentlemen.com')));






