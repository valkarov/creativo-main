use creativoDB


-- Insert records into the table Admins (Administrators of the Creative Club)
INSERT INTO Admins (IdAdmin, Username, Password, FirstName, LastName)
VALUES
    (2378954,'admin1', '1234', 'Alejandro', 'G�mez'),
    (2374573,'admin2', '1234', 'Mar�a', 'Mart�nez'),
    (2390847,'admin3', '1234', 'Carlos', 'S�nchez'),
    (1234234,'admin4', '1234', 'Laura', 'P�rez'),
    (5647343,'admin5', '1234', 'Javier', 'L�pez');

-- Insert first and second delivery persons
INSERT INTO Delivery_Person (IdDeliveryPerson, Username, Password, Firstname, Lastname, State, Province, Canton, District, Phone, Email
) VALUES 
(1, 'd1', '1234', 'John', 'Doe', 'State1', 'Province1', 'Canton1', 'District1', '123-456-7890', 'john.doe@example.com'),
(2, 'd2', '1234', 'Jane', 'Smith', 'State2', 'Province2', 'Canton2', 'District2', '098-765-4321', 'jane.smith@example.com');



-- Insert records into the table Question (Frequently Asked Questions of the Creative Club)
INSERT INTO Questions(QuestionText, Answer)
VALUES
    ('¿Cómo puedo participar en las ferias del Club Creativo?', 'Para participar, regístrate como emprendedor en nuestro sitio web y envía tu propuesta creativa.'),
    ('¿Cuándo son las próximas ferias de arte?', 'Consulta nuestro calendario en línea para conocer las fechas de nuestras próximas ferias.'),
    ('¿Hay algún costo asociado a la participación en las ferias?', 'Sí, hay una tarifa de participación que varía según el tipo de emprendimiento y el espacio solicitado.'),
    ('¿Puedo participar como artista individual?', '¡Claro! Aceptamos participantes individuales y grupos creativos.'),
    ('¿Cómo puedo contactar al equipo del Club Creativo?', 'Puedes contactarnos a través de nuestro correo electrónico info@clubcreativo.com o llamando al 8759-0323.');

-- Insert into ENTREPRENEURSHIP
INSERT INTO ENTREPRENEURSHIP (IdEntrepreneurship, Username, Type, Name, Email, Sinpe, Phone, Province, Canton, District, State, IdType, Description, Reason)
VALUES
    (8293401, 'e7', 'Arte', 'Galer�a Creativa', 'galeria@example.com', '87649076', '87650938', 'San Jos�', 'Escaz�', 'Distrito1', 'Pendiente', 'Fisica', 'Prueba', ''),
    (2342355, 'e2', 'Cocina', 'Sabores Innovadores', 'sabores@example.com', '289648375', '89765903', 'Heredia', 'Bel�n', 'Distrito2', 'Pendiente', 'Fisica', 'Prueba', ''),
    (2346236, 'e3', 'Manualidades', 'Hecho a Mano', 'hechoamano@example.com', '70986345', '72348593', 'Cartago', 'Cartago', 'Distrito3', 'Pendiente', 'Fisica', 'Prueba', ''),
    (2356346, 'e4', 'Moda', 'Estilo Creativo', 'estilo@example.com', '88769504', '70987345', 'Alajuela', 'Alajuela', 'Distrito4', 'Pendiente', 'Fisica', 'Prueba', ''),
    (3452323, 'e5', 'Fotograf�a', 'Capturas Creativas', 'capturas@example.com', '61897658', '89764903', 'Puntarenas', 'Puntarenas', 'Distrito5', 'Pendiente', 'Fisica', 'Prueba', '');

-- Insertar todos los tipos de redes sociales y p�gina web en un solo comando
INSERT INTO Social_Type(type)
VALUES 
    ('Facebook'),
    ('Tiktok'),
    ('Instagram'),
    ('Twitter'),
    ('WebPage');

-- Insertar informaci�n de redes sociales para cada emprendimiento
INSERT INTO Social (Username, Type, Link)
VALUES
    ('e7', 'Facebook', 'https://www.facebook.com/galeriacreativa'),
    ('e7', 'Instagram', 'https://www.instagram.com/galeriacreativa'),
    ('e2', 'Facebook', 'https://www.facebook.com/saboresinnovadores'),
    ('e2', 'Twitter', 'https://twitter.com/saboresinnovadores'),
    ('e3', 'Instagram', 'https://www.instagram.com/hechoamano'),
    ('e3', 'Tiktok', 'https://www.tiktok.com/@hechoamano'),
    ('e4', 'Facebook', 'https://www.facebook.com/estilocreativo'),
    ('e4', 'Instagram', 'https://www.instagram.com/estilocreativo'),
    ('e5', 'Instagram', 'https://www.instagram.com/capturascreativas'),
    ('e5', 'WebPage', 'https://www.capturascreativas.com');

-- Ingreso de tipo de emprendimientos
INSERT INTO Entrepreneurship_Type (type) VALUES 
    ('Comida'),
    ('Collares'),
    ('Dibujo'),
    ('Arte'),
    ('Ropa'),
    ('Decoraci�n'),
    ('Joyer�a'),
    ('Tecnolog�a'),
    ('Fotograf�a'),
    ('Manualidades'),
    ('Otros');


-- Insertar usuario 1
INSERT INTO Client (IdClient, Username, Password, Email, FirstName, LastName, Phone, Province, Canton, District)
VALUES 
	(1234, 'u1', '1234', 'example1@gmail.com',  'Nombre1', 'Apellido1', '123456789', 'San Jos�', 'San Jos�', 'San Jos�'),
	(4321, 'u2', '1234', 'example2@gmail.com', 'Nombre2', 'Apellido2', '987654321', 'Heredia', 'Heredia', 'Heredia');

-- Insertar una fila en Entrepreneurship_Admins
INSERT INTO Entrepreneurship_Admins (IdEntrepreneurship, IdClient, state)
VALUES 
	('e5', 'u1', 'Aceptado'),
	('e2', 'u1', 'Pendiente'),
	('e3', 'u1', 'Aceptado'),
	('e7', 'u1', 'Aceptado'),
	('e2', 'u2', 'Aceptado'),
	('e4', 'u2', 'Aceptado'),
	('e5', 'u2', 'Pendiente');




-- Insertar datos en la tabla Province
INSERT INTO Province (Name) VALUES 
('San Jos�');

-- Insertar datos en la tabla Province
INSERT INTO Province (Name) VALUES 
('Heredia');

-- Insertar datos en la tabla Canton
INSERT INTO Canton (Name, Province) VALUES
('Heredia', 'Heredia'),
('Barva', 'Heredia'),
('Santo Domingo', 'Heredia'),
('Santa B�rbara', 'Heredia'),
('San Rafael', 'Heredia');


-- Insertar datos en la tabla District
INSERT INTO Distric (Name, Canton) VALUES
('Heredia', 'Heredia'),
('Mercedes', 'Heredia'),
('San Francisco', 'Heredia'),
('Ulloa', 'Heredia'),
('Varablanca', 'Heredia'),
('Barva', 'Barva'),
('San Pedro', 'Barva'),
('San Pablo', 'Barva'),
('San Roque', 'Barva'),
('Santa Luc�a', 'Barva'),
('San Jos� de la Monta�a', 'Barva'),
('Santo Domingo', 'Santo Domingo'),
('San Vicente', 'Santo Domingo'),
('San Miguel', 'Santo Domingo'),
('Paracito', 'Santo Domingo'),
('Santo Tom�s', 'Santo Domingo'),
('Santa Rosa', 'Santo Domingo'),
('Santa B�rbara', 'Santa B�rbara'),
('San Juan', 'Santa B�rbara'),
('Jes�s', 'Santa B�rbara'),
('Purab�', 'Santa B�rbara'),
('San Rafael', 'San Rafael'),
('San Josecito', 'San Rafael'),
('Santiago', 'San Rafael'),
('�ngeles', 'San Rafael'),
('Concepci�n', 'San Rafael'),
('San Isidro', 'San Rafael');


-- Insertar datos en la tabla Canton
INSERT INTO Canton (Name, Province) VALUES
('San Jos�', 'San Jos�'),
('Escaz�', 'San Jos�'),
('Desamparados', 'San Jos�'),
('Puriscal', 'San Jos�'),
('Tarraz�', 'San Jos�'),
('Aserr�', 'San Jos�'),
('Mora', 'San Jos�'),
('Goicoechea', 'San Jos�'),
('Santa Ana', 'San Jos�'),
('Alajuelita', 'San Jos�'),
('V�zquez de Coronado', 'San Jos�'),
('Acosta', 'San Jos�'),
('Tib�s', 'San Jos�'),
('Moravia', 'San Jos�'),
('Montes de Oca', 'San Jos�'),
('Turrubares', 'San Jos�'),
('Dota', 'San Jos�'),
('Curridabat', 'San Jos�'),
('P�rez Zeled�n', 'San Jos�'),
('Le�n Cort�s Castro', 'San Jos�');


-- Insertar datos en la tabla District
INSERT INTO Distric (Name, Canton) VALUES
('San Jos�', 'San Jos�'),
('Escaz�', 'Escaz�'),
('Desamparados', 'Desamparados'),
('Santiago', 'Desamparados'),
('San Rafael Arriba', 'Desamparados'),
('San Antonio', 'Desamparados'),
('San Crist�bal', 'Desamparados'),
('Rosario', 'Desamparados'),
('Damas', 'Desamparados'),
('San Juan de Dios', 'Desamparados'),
('Gravilias', 'Desamparados'),
('Los Guido', 'Desamparados'),
('S�nchez', 'Desamparados'),
('San Miguel', 'Desamparados'),
('San Juan', 'Desamparados'),
('San Rafael Abajo', 'Desamparados'),
('Col�n', 'Puriscal'),
('Puriscal', 'Puriscal'),
('Santiago', 'Puriscal'),
('Mercedes Sur', 'Puriscal'),
('Barbacoas', 'Puriscal'),
('Grifo Alto', 'Puriscal'),
('San Rafael', 'Puriscal'),
('Candelarita', 'Puriscal'),
('Desamparaditos', 'Puriscal'),
('San Antonio', 'Puriscal'),
('Chires', 'Puriscal'),
('Aserr�', 'Aserr�'),
('Tarbaca', 'Aserr�'),
('Vuelta de Jorco', 'Aserr�'),
('San Gabriel', 'Aserr�'),
('Legua', 'Aserr�'),
('Monterrey', 'Aserr�'),
('Salitrillos', 'Aserr�'),
('San Isidro', 'Mora'),
('Col�n', 'Mora'),
('Guayabo', 'Mora'),
('Tabarcia', 'Mora'),
('Piedras Negras', 'Mora'),
('Jaris', 'Mora'),
('Quitirris�', 'Mora'),
('Ip�s', 'Goicoechea'),
('Rancho Redondo', 'Goicoechea'),
('Purral', 'Goicoechea'),
('Sabanilla', 'Goicoechea'),
('Uruca', 'Goicoechea'),
('Mata Redonda', 'Goicoechea'),
('Pavas', 'Goicoechea'),
('Anselmo Llorente', 'Santa Ana'),
('Santa Ana', 'Santa Ana'),
('Salitral', 'Santa Ana'),
('Piedades', 'Santa Ana'),
('Brasil', 'Santa Ana'),
('Alajuelita', 'Alajuelita'),
('San Josecito', 'Alajuelita'),
('San Antonio', 'Alajuelita'),
('Concepci�n', 'V�zquez de Coronado'),
('San Isidro', 'V�zquez de Coronado'),
('San Rafael', 'V�zquez de Coronado'),
('Dulce Nombre de Jes�s', 'V�zquez de Coronado'),
('Patalillo', 'V�zquez de Coronado'),
('Cascajal', 'V�zquez de Coronado'),
('San Juan', 'Acosta'),
('San Ignacio', 'Acosta'),
('Guaitil', 'Acosta'),
('Palmichal', 'Acosta'),
('Cipreses', 'Acosta'),
('San Jos�', 'Tib�s'),
('Cinco Esquinas', 'Tib�s'),
('Anselmo Llorente', 'Tib�s'),
('Le�n XIII', 'Tib�s'),
('Colima', 'Tib�s'),
('San Juan', 'Moravia'),
('La Trinidad', 'Moravia'),
('San Vicente', 'Moravia'),
('San Jer�nimo', 'Moravia'),
('San Diego', 'Moravia'),
('San Rafael', 'Moravia'),
('San Luis', 'Moravia'),
('San Pedro', 'Montes de Oca'),
('Sabanilla', 'Montes de Oca'),
('Mercedes', 'Montes de Oca'),
('San Rafael', 'Montes de Oca'),
('San Antonio', 'Montes de Oca'),
('Concepci�n', 'Montes de Oca'),
('San Juan de Mata', 'Turrubares'),
('San Luis', 'Turrubares'),
('Carara', 'Turrubares'),
('Copey', 'Turrubares'),
('Jard�n', 'Turrubares'),
('Dota', 'Dota'),
('Santa Mar�a', 'Dota'),
('Jard�n', 'Dota'),
('Copey', 'Dota'),
('San Francisco de Dos R�os', 'Curridabat'),
('Cipreses', 'Curridabat'),
('Curridabat', 'Curridabat'),
('Granadilla', 'Curridabat'),
('S�nchez', 'Curridabat'),
('Tirrases', 'Curridabat'),
('R�o Nuevo', 'P�rez Zeled�n'),
('P�ramo', 'P�rez Zeled�n'),
('La Palma', 'P�rez Zeled�n'),
('Rivas', 'P�rez Zeled�n'),
('San Isidro de El General', 'P�rez Zeled�n'),
('Pejibaye', 'P�rez Zeled�n'),
('La Amistad', 'P�rez Zeled�n'),
('Platanares', 'P�rez Zeled�n'),
('Bar�', 'P�rez Zeled�n'),
('Caj�n', 'P�rez Zeled�n'),
('La Colonia', 'Le�n Cort�s Castro'),
('San Antonio', 'Le�n Cort�s Castro'),
('San Isidro', 'Le�n Cort�s Castro');



-- Insertar datos en la tabla Province
INSERT INTO Province (Name) VALUES 
('Cartago');

-- Insertar datos en la tabla Canton
INSERT INTO Canton (Name, Province) VALUES
('Cartago', 'Cartago'),
('Para�so', 'Cartago'),
('La Uni�n', 'Cartago'),
('Jim�nez', 'Cartago'),
('Turrialba', 'Cartago');


-- Insertar datos en la tabla District
INSERT INTO Distric (Name, Canton) VALUES
('Oriental', 'Cartago'),
('Occidental', 'Cartago'),
('Carmen', 'Cartago'),
('San Nicol�s', 'Cartago'),
('Agua Caliente', 'Cartago'),
('Guadalupe', 'Para�so'),
('Santa Luc�a', 'Para�so'),
('Corralillo', 'Para�so'),
('Tierra Blanca', 'Para�so'),
('Cot', 'La Uni�n'),
('Cipreses', 'La Uni�n'),
('Santa Rosa', 'La Uni�n'),
('Zurqu�', 'La Uni�n'),
('Pejibaye', 'Jim�nez'),
('Juan Vi�as', 'Jim�nez'),
('Tucurrique', 'Jim�nez'),
('Turrialba', 'Turrialba'),
('La Suiza', 'Turrialba'),
('Peralta', 'Turrialba'),
('Santa Cruz', 'Turrialba'),
('Santa Teresita', 'Turrialba');



-- Insertar datos en la tabla Province
INSERT INTO Province (Name) VALUES 
('Alajuela');

-- Insertar datos en la tabla Canton
INSERT INTO Canton (Name, Province) VALUES
('Alajuela', 'Alajuela'),
('San Ram�n', 'Alajuela'),
('Grecia', 'Alajuela'),
('San Mateo', 'Alajuela'),
('Atenas', 'Alajuela'),
('Naranjo', 'Alajuela'),
('Palmares', 'Alajuela'),
('Po�s', 'Alajuela'),
('Orotina', 'Alajuela'),
('San Carlos', 'Alajuela'),
('Zarcero', 'Alajuela'),
('Valverde Vega', 'Alajuela'),
('Upala', 'Alajuela'),
('Los Chiles', 'Alajuela'),
('Guatuso', 'Alajuela');

-- Insertar datos en la tabla District
INSERT INTO Distric (Name, Canton) VALUES
('Alajuela', 'Alajuela'),
('San Jos�', 'Alajuela'),
('Carrizal', 'Alajuela'),
('San Antonio', 'Alajuela'),
('Gu�cima', 'Alajuela'),
('San Isidro', 'Alajuela'),
('Sabanilla', 'Alajuela'),
('San Rafael', 'Alajuela'),
('R�o Segundo', 'Alajuela'),
('Desamparados', 'Alajuela'),
('Turrucares', 'Alajuela'),
('Tambor', 'Alajuela'),
('Garita', 'Alajuela'),
('Sarapiqu�', 'Alajuela'),
('Alegr�a', 'San Ram�n'),
('San Juan', 'San Ram�n'),
('San Rafael', 'San Ram�n'),
('San Isidro', 'San Ram�n'),
('�ngeles', 'San Ram�n'),
('Alfaro', 'Grecia'),
('Puente de Piedra', 'Grecia'),
('San Jos�', 'Grecia'),
('San Roque', 'Grecia'),
('Tacares', 'Grecia'),
('Monserrat', 'San Mateo'),
('Coyolar', 'San Mateo'),
('Desmonte', 'San Mateo'),
('San Mateo', 'San Mateo'),
('Concepci�n', 'Atenas'),
('San Jos�', 'Atenas'),
('Jes�s', 'Atenas'),
('Mercedes', 'Atenas'),
('San Isidro', 'Atenas'),
('San Juan', 'Naranjo'),
('San Jos�', 'Naranjo'),
('Cirr� Sur', 'Naranjo'),
('Rosario', 'Naranjo'),
('Palmares', 'Palmares'),
('Zaragoza', 'Palmares'),
('Buenos Aires', 'Palmares'),
('Santiago', 'Palmares'),
('San Pedro', 'Po�s'),
('San Juan', 'Po�s'),
('San Rafael', 'Po�s'),
('Carrillos', 'Po�s'),
('Mastate', 'Orotina'),
('Coyolar', 'Orotina'),
('Hacienda Vieja', 'Orotina'),
('La Ceiba', 'Orotina'),
('Pital', 'San Carlos'),
('La Fortuna', 'San Carlos'),
('La Tigra', 'San Carlos'),
('La Palmera', 'San Carlos'),
('Venado', 'San Carlos'),
('San Carlos', 'San Carlos'),
('Zarcero', 'Zarcero'),
('Laguna', 'Zarcero'),
('Tapezco', 'Zarcero'),
('Guadalupe', 'Valverde Vega'),
('Palmira', 'Valverde Vega'),
('Buenavista', 'Valverde Vega'),
('Sarch� Norte', 'Valverde Vega'),
('Delicias', 'Valverde Vega'),
('San Jos�', 'Upala'),
('Upala', 'Upala'),
('Aguas Claras', 'Upala'),
('San Jos�', 'Los Chiles'),
('Ca�o Negro', 'Los Chiles'),
('El Amparo', 'Los Chiles'),
('San Jorge', 'Los Chiles'),
('San Rafael', 'Los Chiles'),
('Katira', 'Guatuso'),
('San Jos�', 'Guatuso'),
('San Antonio', 'Guatuso'),
('San Lorenzo', 'Guatuso'),
('Santa Rita', 'Guatuso');


-- Insertar datos en la tabla Province
INSERT INTO Province (Name) VALUES 
('Puntarenas');

-- Insertar datos en la tabla Canton
INSERT INTO Canton (Name, Province) VALUES
('Puntarenas', 'Puntarenas'),
('Esparza', 'Puntarenas'),
('Buenos Aires', 'Puntarenas'),
('Montes de Oro', 'Puntarenas'),
('Osa', 'Puntarenas'),
('Aguirre', 'Puntarenas'),
('Golfito', 'Puntarenas'),
('Coto Brus', 'Puntarenas'),
('Parrita', 'Puntarenas'),
('Corredores', 'Puntarenas');

-- Insertar datos en la tabla District
INSERT INTO Distric (Name, Canton) VALUES
('Puntarenas', 'Puntarenas'),
('Chomes', 'Puntarenas'),
('Lepanto', 'Puntarenas'),
('Paquera', 'Puntarenas'),
('Manzanillo', 'Puntarenas'),
('Guacimal', 'Puntarenas'),
('Barranca', 'Puntarenas'),
('Monteverde', 'Puntarenas'),
('Isla del Coco', 'Puntarenas'),
('C�bano', 'Puntarenas'),
('Esp�ritu Santo', 'Esparza'),
('San Juan Grande', 'Esparza'),
('Macacona', 'Esparza'),
('San Rafael', 'Esparza'),
('San Jer�nimo', 'Esparza'),
('Boruca', 'Buenos Aires'),
('Buenos Aires', 'Buenos Aires'),
('Volc�n', 'Buenos Aires'),
('Potrero Grande', 'Buenos Aires'),
('Bijagual', 'Montes de Oro'),
('Miramar', 'Montes de Oro'),
('La Uni�n', 'Montes de Oro'),
('Aguabuena', 'Montes de Oro'),
('Ciudad Cort�s', 'Osa'),
('Palmar', 'Osa'),
('Sierpe', 'Osa'),
('Bah�a Ballena', 'Osa'),
('Pav�n', 'Osa'),
('Puerto Cort�s', 'Aguirre'),
('Palmar Norte', 'Aguirre'),
('Sierpe', 'Aguirre'),
('Golfito', 'Golfito'),
('Puerto Jim�nez', 'Golfito'),
('Guaycar�', 'Golfito'),
('Pav�n', 'Golfito'),
('San Vito', 'Coto Brus'),
('Sabalito', 'Coto Brus'),
('Agua Buena', 'Coto Brus'),
('Limoncito', 'Coto Brus'),
('Parrita', 'Parrita'),
('Damitas', 'Parrita'),
('Juntas', 'Parrita'),
('Macacona', 'Parrita'),
('La Cuesta', 'Corredores'),
('Paso Canoas', 'Corredores'),
('Laurel', 'Corredores'),
('Ciudad Neily', 'Corredores');


-- Insertar datos en la tabla Province
INSERT INTO Province (Name) VALUES 
('Guanacaste');

-- Insertar datos en la tabla Canton
INSERT INTO Canton (Name, Province) VALUES
('Liberia', 'Guanacaste'),
('Nicoya', 'Guanacaste'),
('Santa Cruz', 'Guanacaste'),
('Bagaces', 'Guanacaste'),
('Carrillo', 'Guanacaste'),
('Ca�as', 'Guanacaste'),
('Abangares', 'Guanacaste'),
('Tilar�n', 'Guanacaste'),
('Nandayure', 'Guanacaste'),
('La Cruz', 'Guanacaste'),
('Hojancha', 'Guanacaste');

-- Insertar datos en la tabla District
INSERT INTO Distric (Name, Canton) VALUES
('Liberia', 'Liberia'),
('Ca�as Dulces', 'Liberia'),
('Mayorga', 'Liberia'),
('Nacascolo', 'Liberia'),
('Curuband�', 'Liberia'),
('Nicoya', 'Nicoya'),
('Mansion', 'Nicoya'),
('San Antonio', 'Nicoya'),
('Quebrada Honda', 'Nicoya'),
('S�mara', 'Nicoya'),
('Bel�n de Nosarita', 'Nicoya'),
('Santa Cruz', 'Santa Cruz'),
('Bols�n', 'Santa Cruz'),
('Veintisiete de Abril', 'Santa Cruz'),
('Tempate', 'Santa Cruz'),
('Cartagena', 'Santa Cruz'),
('Cuajiniquil', 'Santa Cruz'),
('Bagaces', 'Bagaces'),
('Fortuna', 'Bagaces'),
('Mogote', 'Bagaces'),
('R�o Naranjo', 'Bagaces'),
('La Garita', 'Bagaces'),
('Filadelfia', 'Carrillo'),
('Palmira', 'Carrillo'),
('Sardinal', 'Carrillo'),
('Bel�n', 'Carrillo'),
('Santa Rosa', 'Carrillo'),
('Liberia', 'Ca�as'),
('Ca�as', 'Ca�as'),
('Palmira', 'Ca�as'),
('San Miguel', 'Ca�as'),
('Bebedero', 'Ca�as'),
('Porozal', 'Ca�as'),
('Las Juntas', 'Abangares'),
('Sierra', 'Abangares'),
('San Juan', 'Abangares'),
('Colorado', 'Abangares'),
('Canjel', 'Abangares'),
('Tilar�n', 'Tilar�n'),
('Quebrada Grande', 'Tilar�n'),
('Tronadora', 'Tilar�n'),
('Libano', 'Tilar�n'),
('Tierras Morenas', 'Tilar�n'),
('Carmona', 'Nandayure'),
('Santa Rita', 'Nandayure'),
('Zapotillal', 'Nandayure'),
('San Pablo', 'Nandayure'),
('Porvenir', 'Nandayure'),
('La Cruz', 'La Cruz'),
('Santa Cecilia', 'La Cruz'),
('La Garita', 'La Cruz'),
('Santa Elena', 'La Cruz'),
('Cuajiniquil', 'La Cruz'),
('Hojancha', 'Hojancha'),
('Monte Romo', 'Hojancha'),
('Puerto Carrillo', 'Hojancha'),
('Huacas', 'Hojancha'),
('Matamb�', 'Hojancha');



-- Insertar datos en la tabla Province
INSERT INTO Province (Name) VALUES 
('Lim�n');

-- Insertar datos en la tabla Canton
INSERT INTO Canton (Name, Province) VALUES
('Lim�n', 'Lim�n'),
('Pococ�', 'Lim�n'),
('Siquirres', 'Lim�n'),
('Talamanca', 'Lim�n'),
('Matina', 'Lim�n');

-- Insertar datos en la tabla District
INSERT INTO Distric (Name, Canton) VALUES
('Lim�n', 'Lim�n'),
('Valle La Estrella', 'Lim�n'),
('Liverpool', 'Lim�n'),
('Matama', 'Lim�n'),
('R�o Blanco', 'Lim�n'),
('Gu�piles', 'Pococ�'),
('Jim�nez', 'Pococ�'),
('La Rita', 'Pococ�'),
('Roxana', 'Pococ�'),
('Cariari', 'Pococ�'),
('Siquirres', 'Siquirres'),
('Pacuarito', 'Siquirres'),
('Florida', 'Siquirres'),
('Alegr�a', 'Siquirres'),
('La Colonia', 'Siquirres'),
('Bratsi', 'Talamanca'),
('Sixaola', 'Talamanca'),
('Cahuita', 'Talamanca'),
('Telire', 'Talamanca'),
('Matina', 'Matina'),
('Bata�n', 'Matina'),
('Carrandi', 'Matina'),
('Gu�cimo', 'Matina'),
('Guadalupe', 'Matina'),
('Santa Rosa', 'Matina');
