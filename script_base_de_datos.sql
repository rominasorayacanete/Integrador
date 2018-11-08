-- CREACIÓN DE TABLAS

CREATE TABLE Usuario
 (
  username VARCHAR(255) NOT NULL,
  password VARCHAR(255),
  nombre VARCHAR(255),
  apellido VARCHAR(255), 
  tipo_documento VARCHAR(5),
  nro_documento INT,
  fecha_alta_sistema DATETIME,
  domicilio VARCHAR(255),
  telefono INT
);

CREATE TABLE Administrador 
(
  id_sistema INT IDENTITY NOT NULL,
  username VARCHAR(255)
);

CREATE TABLE Cliente 
(
  clie_id INT IDENTITY NOT NULL,
  clie_puntos INT,
  clie_latitud FLOAT,
  clie_longitud FLOAT,
  clie_categoria INT,
  clie_zona INT,
  username VARCHAR(255)
);

CREATE TABLE Zona_Geografica 
(
  zona_id INT IDENTITY NOT NULL,
  zona_radio INT,
  zona_longitud FLOAT,
  zona_latitud FLOAT,
  zona_nombre VARCHAR(255)
);

CREATE TABLE Transformador (
  tran_id INT NOT NULL IDENTITY,
  tran_nombre VARCHAR(255),
  tran_activo BIT,
  tran_energia_suministrada FLOAT,
  tran_latitud FLOAT,
  tran_longitud FLOAT,
  tran_zona INT
); 

CREATE TABLE Categoria (
  cate_id INT IDENTITY NOT NULL,
  cate_nombre VARCHAR(255),
  cate_consumo_minimo FLOAT,
  cate_consumo_maximo FLOAT,
  cate_cargo_fijo FLOAT,
  cate_cargo_variable FLOAT
);

CREATE TABLE Dispositivo (
  disp_id INT IDENTITY NOT NULL,
  disp_cliente INT,
  disp_nombre_generico VARCHAR(255),
  disp_consumo_hora INT,
  disp_encendido BIT,
  disp_modo_ahorro_energia BIT,
  disp_consumo INT,
  disp_uso_mensual_max INT,
  disp_uso_mensual_min INT,
  disp_inteligente BIT,
  disp_tipo_dispositivo VARCHAR(255),
  disp_uso_estimado INT
);

CREATE TABLE Actuador
(
  actu_id INT IDENTITY NOT NULL,
  actu_accion varchar(255),
  actu_dispositivo INT
);

CREATE TABLE Regla
(
  regl_id INT IDENTITY NOT NULL,
  regl_cumplida BIT,
  regl_condicion VARCHAR(255),
  regl_sensor INT,
);

CREATE TABLE Actuador_X_Regla
(
  actuador INT NOT NULL,
  regla INT NOT NULL,
);

CREATE TABLE Sensor
(
  sens_id INT IDENTITY NOT NULL,
  sens_magnitud VARCHAR(255),
);

CREATE TABLE Template_Dispositivo
(
  temp_id INT IDENTITY NOT NULL,
  temp_nombre VARCHAR(255),
  temp_inteligente BIT,
  temp_bajo_consumo BIT,
  temp_consumo INT,
  temp_dispositivo INT
);

CREATE TABLE Operacion (
	oper_id INT IDENTITY NOT NULL,
	oper_dispositivo INT,
	oper_descripcion NVARCHAR(255),
	oper_fecha DATETIME
);


-- CREACIÓN DE PRIMARY KEYS


ALTER TABLE Usuario
ADD CONSTRAINT PK_USUARIO_USERNAME PRIMARY KEY (username)
GO

ALTER TABLE Administrador
ADD CONSTRAINT PK_ADMINISTRADOR_ID_SISTEMA PRIMARY KEY (id_sistema)
GO

ALTER TABLE Cliente
ADD CONSTRAINT PK_CLIENTE_CLIE_ID PRIMARY KEY (clie_id)
GO

ALTER TABLE Zona_Geografica
ADD CONSTRAINT PK_ZONA_GEOGRAFICA_ZONA_ID PRIMARY KEY (zona_id)
GO

ALTER TABLE Transformador
ADD CONSTRAINT PK_TRANSFORMADOR_TRAN_ID PRIMARY KEY (tran_id)
GO

ALTER TABLE Categoria
ADD CONSTRAINT PK_CATEGORIA_CATE_ID PRIMARY KEY (cate_id)
GO

ALTER TABLE Dispositivo
ADD CONSTRAINT PK_DISPOSITIVO_DISP_ID PRIMARY KEY (disp_id)
GO

ALTER TABLE Actuador
ADD CONSTRAINT PK_ACTUADOR_ACTU_ID PRIMARY KEY (actu_id)
GO

ALTER TABLE Regla
ADD CONSTRAINT PK_REGLA_REGL_ID PRIMARY KEY (regl_id)
GO

ALTER TABLE Actuador_X_Regla
ADD CONSTRAINT PK_ACTUADOR_X_REGLA_ACTUADOR_REGLA PRIMARY KEY (actuador, regla)
GO

ALTER TABLE Sensor
ADD CONSTRAINT PK_SENSOR_SENS_ID PRIMARY KEY (sens_id)
GO

ALTER TABLE Template_Dispositivo
ADD CONSTRAINT PK_TEMPLATE_DISPOSITIVO_TEMP_ID PRIMARY KEY (temp_id)
GO

ALTER TABLE Operacion
ADD CONSTRAINT PK_OPERACION_OPER_ID PRIMARY KEY (oper_id)
GO


-- CREACIÓN DE FOREIGN KEYS


ALTER TABLE Administrador
ADD CONSTRAINT FK_ADMINISTRADOR_USERNAME FOREIGN KEY (username)
REFERENCES Usuario(username)
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE Cliente
ADD CONSTRAINT FK_CLIENTE_CLIE_CATEGORIA FOREIGN KEY (clie_categoria)
REFERENCES Categoria(cate_id)
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE Cliente
ADD CONSTRAINT FK_CLIENTE_CLIE_ZONA FOREIGN KEY (clie_zona)
REFERENCES Zona_Geografica(zona_id)
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE Cliente
ADD CONSTRAINT FK_CLIENTE_USERNAME FOREIGN KEY (username)
REFERENCES Usuario(username)
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE Transformador
ADD CONSTRAINT FK_TRANSFORMADOR_TRAN_ZONA FOREIGN KEY (tran_zona)
REFERENCES Zona_Geografica(zona_id)
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE Dispositivo
ADD CONSTRAINT FK_DISPOSITIVO_DISP_CLIENTE FOREIGN KEY (disp_cliente)
REFERENCES Cliente(clie_id)
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE Actuador
ADD CONSTRAINT FK_ACTUADOR_ACTU_DISPOSITIVO FOREIGN KEY (actu_dispositivo)
REFERENCES Dispositivo(disp_id)
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE Regla
ADD CONSTRAINT FK_REGLA_REGL_SENSOR FOREIGN KEY (regl_sensor)
REFERENCES Sensor(sens_id)
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE Actuador_X_Regla
ADD CONSTRAINT FK_ACTUADOR_X_REGLA_ACTUADOR FOREIGN KEY (actuador)
REFERENCES Actuador(actu_id)
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE Actuador_X_Regla
ADD CONSTRAINT FK_ACTUADOR_X_REGLA_REGLA FOREIGN KEY (regla)
REFERENCES Regla(regl_id)
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE Operacion
ADD CONSTRAINT FK_OPERACION_DISPOSITIVO FOREIGN KEY (oper_dispositivo)
REFERENCES Dispositivo(disp_id)
ON UPDATE CASCADE
ON DELETE CASCADE
GO