INSERT INTO Questions (QuestionText, Answer)
VALUES
    ('¿Cómo puedo participar en las ferias del Club Creativo?', 'Para participar, regístrate como emprendedor en nuestro sitio web y envía tu propuesta creativa.'),
    ('¿Cuándo son las próximas ferias de arte?', 'Consulta nuestro calendario en línea para conocer las fechas de nuestras próximas ferias.'),
    ('¿Hay algún costo asociado a la participación en las ferias?', 'Sí, hay una tarifa de participación que varía según el tipo de emprendimiento y el espacio solicitado.'),
    ('¿Puedo participar como artista individual?', '¡Claro! Aceptamos participantes individuales y grupos creativos.'),
    ('¿Cómo puedo contactar al equipo del Club Creativo?', 'Puedes contactarnos a través de nuestro correo electrónico info@clubcreativo.com o llamando al 8759-0323.');

INSERT INTO Provinces(Name) VALUES
('San José'),
('Heredia');

DECLARE @San_Jose bigInt;
DECLARE @Heredia bigInt;

Select @San_jose = id
from Provinces where name ='San José';
Select @Heredia = id
from Provinces where name ='Heredia';
INSERT INTO Cantons(name, ProvinceId) VALUES
('Heredia', @Heredia),
('Barva', @Heredia),
('Santo Domingo', @Heredia),
('Santa Bárbara', @Heredia),
('San Rafael', @Heredia),
('San José', @San_Jose),
('Escazú', @San_Jose),
('Desamparados', @San_Jose),
('Puriscal', @San_Jose),
('Tarrazú', @San_Jose),
('Aserrí', @San_Jose),
('Mora', @San_Jose),
('Goicoechea', @San_Jose),
('Santa Ana', @San_Jose),
('Alajuelita', @San_Jose),
('Vázquez de Coronado', @San_Jose),
('Acosta', @San_Jose),
('Tibás', @San_Jose),
('Moravia', @San_Jose),
('Montes de Oca', @San_Jose),
('Turrubares', @San_Jose),
('Dota', @San_Jose),
('Curridabat', @San_Jose),
('Pérez Zeledón', @San_Jose),
('León Cortés Castro', @San_Jose);

Declare @herediacanton bigint;

select @herediacanton = id
from Cantons where name='Heredia';

INSERT INTO Districts (Name, CantonId) VALUES
('Heredia', @herediacanton),
('Mercedes', @herediacanton),
('San Francisco', @herediacanton),
('Ulloa', @herediacanton),
('Varablanca', @herediacanton);


INSERT INTO SocialTypes(Name)
VALUES 
    ('Facebook'),
    ('Tiktok'),
    ('Instagram'),
    ('Twitter'),
    ('WebPage');

Insert Into Roles(Name)
VALUES
	('CLIENTE'),
	('ADMIN'),
	('EMPRENDIMIENTO');