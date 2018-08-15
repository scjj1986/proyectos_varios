CREATE TABLE alumno (
  id int(11) NOT NULL auto_increment,
  ve varchar(2) collate utf8_spanish_ci NOT NULL,
  cedula varchar(50) collate utf8_spanish_ci NOT NULL,
  nombre varchar(100) collate utf8_spanish_ci NOT NULL,
  apellido varchar(100) collate utf8_spanish_ci NOT NULL,
  semestre varchar(100) collate utf8_spanish_ci NOT NULL,
  PRIMARY KEY  (id)
) ENGINE=MyISAM AUTO_INCREMENT=15 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;
INSERT INTO alumno (id, ve, cedula, nombre, apellido, semestre) VALUES (5,'V-','18000000','SANDRA','MATA','6'),(4,'V-','17000000','JUAN','CASTRO','5'),(6,'V-','22000000','DAVID','FERRER','2'),(7,'V-','19000000','MILEIDYS','ARANGO','6'),(8,'V-','21500000','MIGUEL','SILVA','5'),(9,'V-','21000000','JULIO','RODRIGUEZ','3'),(10,'V-','21000001','KARINA','MATA','4'),(11,'V-','21000002','ANDRES','GOMEZ','3'),(12,'V-','22100000','LUZ','CAMPOS','6'),(13,'V-','22200000','PEDRO','LOVERA','5'),(14,'V-','22300000','KELVIN','ARIAS','7');
CREATE TABLE carrera (
  nombre varchar(100) collate utf8_spanish_ci NOT NULL,
  id int(11) NOT NULL auto_increment,
  PRIMARY KEY  (id)
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;
INSERT INTO carrera (nombre, id) VALUES ('ING SISTEMAS',1),('ENFERMERIA',2),('TURISMO',3),('ADMINISTRACION',4),('CONTADURIA PUBLICA',5);
CREATE TABLE cuo (
  `year` varchar(10) collate utf8_spanish_ci NOT NULL,
  semestre varchar(2) collate utf8_spanish_ci NOT NULL,
  PRIMARY KEY  (`year`,semestre)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;
INSERT INTO cuo (year, semestre) VALUES ('2011','I'),('2014','I');
CREATE TABLE proyecto (
  id int(11) NOT NULL auto_increment,
  ncuo varchar(10) collate utf8_spanish_ci NOT NULL,
  nombre varchar(200) collate utf8_spanish_ci NOT NULL,
  cedtutoracademico varchar(40) collate utf8_spanish_ci NOT NULL,
  cedtutorcomunitario varchar(100) collate utf8_spanish_ci NOT NULL,
  estado varchar(20) collate utf8_spanish_ci NOT NULL,
  carrera varchar(100) collate utf8_spanish_ci NOT NULL,
  tipo varchar(60) collate utf8_spanish_ci NOT NULL,
  fechainicio varchar(20) collate utf8_spanish_ci NOT NULL,
  fechafin varchar(20) collate utf8_spanish_ci NOT NULL,
  PRIMARY KEY  (id)
) ENGINE=MyISAM AUTO_INCREMENT=11 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;
INSERT INTO proyecto (id, ncuo, nombre, cedtutoracademico, cedtutorcomunitario, estado, carrera, tipo, fechainicio, fechafin) VALUES (7,'2014-I','ESTO ES UN PROYECTO DE PRUEBA','V-10000000','V-11000000','APROBADO','ING SISTEMAS','UNEFA VA A LA ESCUELA','06/05/2014','23/10/2015'),(8,'2014-I','APOYO AL HOSPITAL DE JUAN GRIEGO','V-10000000','V-12000000','ESPERA','ENFERMERIA','UNEFA VA A LA COMUNIDAD','04/06/2015','POR DEFINIR'),(9,'2014-I','APOYO ADMINISTRATIVO A LA ALCALDIA DEL MUNICIPIO TAL','V-10000000','V-9000001','REPROBADO','ADMINISTRACION','UNEFA VA A LA COMUNIDAD','13/01/2014','26/09/2014'),(10,'2014-I','CURSOS DE HERRAMIENTAS OFIMATICAS A LA ESCUELA TAL','V-10000000','V-11100000','ESPERA','ING SISTEMAS','UNEFA VA A LA ESCUELA','09/05/2014','POR DEFINIR');
CREATE TABLE realiza (
  nombreproyecto varchar(200) collate utf8_spanish_ci NOT NULL,
  cedalumno varchar(30) collate utf8_spanish_ci NOT NULL,
  PRIMARY KEY  (nombreproyecto,cedalumno)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;
INSERT INTO realiza (nombreproyecto, cedalumno) VALUES ('APOYO ADMINISTRATIVO A LA ALCALDIA DEL MUNICIPIO TAL','V-21000000'),('APOYO ADMINISTRATIVO A LA ALCALDIA DEL MUNICIPIO TAL','V-21000001'),('APOYO ADMINISTRATIVO A LA ALCALDIA DEL MUNICIPIO TAL','V-21000002'),('APOYO AL HOSPITAL DE JUAN GRIEGO','V-19000000'),('APOYO AL HOSPITAL DE JUAN GRIEGO','V-21500000'),('CURSOS DE HERRAMIENTAS OFIMATICAS A LA ESCUELA TAL','V-22100000'),('CURSOS DE HERRAMIENTAS OFIMATICAS A LA ESCUELA TAL','V-22200000'),('CURSOS DE HERRAMIENTAS OFIMATICAS A LA ESCUELA TAL','V-22300000'),('ESTO ES UN PROYECTO DE PRUEBA','V-17000000'),('ESTO ES UN PROYECTO DE PRUEBA','V-18000000'),('ESTO ES UN PROYECTO DE PRUEBA','V-22000000');
CREATE TABLE tutor (
  id int(11) NOT NULL auto_increment,
  ve varchar(2) collate utf8_spanish_ci NOT NULL,
  cedula varchar(20) collate utf8_spanish_ci NOT NULL,
  nombre varchar(60) collate utf8_spanish_ci NOT NULL,
  apellido varchar(60) collate utf8_spanish_ci NOT NULL,
  telefono varchar(30) collate utf8_spanish_ci NOT NULL,
  tipo varchar(15) collate utf8_spanish_ci NOT NULL,
  PRIMARY KEY  (id)
) ENGINE=MyISAM AUTO_INCREMENT=10 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;
INSERT INTO tutor (id, ve, cedula, nombre, apellido, telefono, tipo) VALUES (1,'V-','10000000','LEONEL','RAMIREZ','04269807354','ACADEMICO'),(4,'V-','11000000','JOSE','MORILLO','1234567','COMUNITARIO'),(6,'V-','12000000','CLARA','MILLAN','02952539987','COMUNITARIO'),(7,'V-','9000001','JORGE','PALACIOS','4536789','COMUNITARIO'),(9,'V-','11100000','CARLOS','COSTA','445566778','COMUNITARIO');
CREATE TABLE usuario (
  nick varchar(30) collate utf8_spanish_ci NOT NULL,
  contrasena varchar(30) collate utf8_spanish_ci NOT NULL,
  PRIMARY KEY  (nick,contrasena)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;
INSERT INTO usuario (nick, contrasena) VALUES ('kluna','654321');

