-- MySQL dump 10.10
--
-- Host: localhost    Database: serviciocomunitario
-- ------------------------------------------------------
-- Server version	5.0.27-community-nt-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Current Database: `serviciocomunitario`
--

CREATE DATABASE /*!32312 IF NOT EXISTS*/ `serviciocomunitario` /*!40100 DEFAULT CHARACTER SET utf8 COLLATE utf8_spanish_ci */;

USE `serviciocomunitario`;

--
-- Table structure for table `alumno`
--

DROP TABLE IF EXISTS `alumno`;
CREATE TABLE `alumno` (
  `id` int(11) NOT NULL auto_increment,
  `ve` varchar(2) collate utf8_spanish_ci NOT NULL,
  `cedula` varchar(50) collate utf8_spanish_ci NOT NULL,
  `nombre` varchar(100) collate utf8_spanish_ci NOT NULL,
  `apellido` varchar(100) collate utf8_spanish_ci NOT NULL,
  `semestre` varchar(100) collate utf8_spanish_ci NOT NULL,
  PRIMARY KEY  (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=15 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Dumping data for table `alumno`
--

LOCK TABLES `alumno` WRITE;
/*!40000 ALTER TABLE `alumno` DISABLE KEYS */;
INSERT INTO `alumno` VALUES (5,'V-','18000000','SANDRA','MATA','6'),(4,'V-','17000000','JUAN','CASTRO','5'),(6,'V-','22000000','DAVID','FERRER','2'),(7,'V-','19000000','MILEIDYS','ARANGO','6'),(8,'V-','21500000','MIGUEL','SILVA','5'),(9,'V-','21000000','JULIO','RODRIGUEZ','3'),(10,'V-','21000001','KARINA','MATA','4'),(11,'V-','21000002','ANDRES','GOMEZ','3'),(12,'V-','22100000','LUZ','CAMPOS','6'),(13,'V-','22200000','PEDRO','LOVERA','5'),(14,'V-','22300000','KELVIN','ARIAS','7');
/*!40000 ALTER TABLE `alumno` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `carrera`
--

DROP TABLE IF EXISTS `carrera`;
CREATE TABLE `carrera` (
  `nombre` varchar(100) collate utf8_spanish_ci NOT NULL,
  `id` int(11) NOT NULL auto_increment,
  PRIMARY KEY  (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Dumping data for table `carrera`
--

LOCK TABLES `carrera` WRITE;
/*!40000 ALTER TABLE `carrera` DISABLE KEYS */;
INSERT INTO `carrera` VALUES ('ING SISTEMAS',1),('ENFERMERIA',2),('TURISMO',3),('ADMINISTRACION',4),('CONTADURIA PUBLICA',5);
/*!40000 ALTER TABLE `carrera` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cuo`
--

DROP TABLE IF EXISTS `cuo`;
CREATE TABLE `cuo` (
  `year` varchar(10) collate utf8_spanish_ci NOT NULL,
  `semestre` varchar(2) collate utf8_spanish_ci NOT NULL,
  PRIMARY KEY  (`year`,`semestre`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Dumping data for table `cuo`
--

LOCK TABLES `cuo` WRITE;
/*!40000 ALTER TABLE `cuo` DISABLE KEYS */;
INSERT INTO `cuo` VALUES ('2011','I'),('2014','I');
/*!40000 ALTER TABLE `cuo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `proyecto`
--

DROP TABLE IF EXISTS `proyecto`;
CREATE TABLE `proyecto` (
  `id` int(11) NOT NULL auto_increment,
  `ncuo` varchar(10) collate utf8_spanish_ci NOT NULL,
  `nombre` varchar(200) collate utf8_spanish_ci NOT NULL,
  `cedtutoracademico` varchar(40) collate utf8_spanish_ci NOT NULL,
  `cedtutorcomunitario` varchar(100) collate utf8_spanish_ci NOT NULL,
  `estado` varchar(20) collate utf8_spanish_ci NOT NULL,
  `carrera` varchar(100) collate utf8_spanish_ci NOT NULL,
  `tipo` varchar(60) collate utf8_spanish_ci NOT NULL,
  `fechainicio` varchar(20) collate utf8_spanish_ci NOT NULL,
  `fechafin` varchar(20) collate utf8_spanish_ci NOT NULL,
  PRIMARY KEY  (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=11 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Dumping data for table `proyecto`
--

LOCK TABLES `proyecto` WRITE;
/*!40000 ALTER TABLE `proyecto` DISABLE KEYS */;
INSERT INTO `proyecto` VALUES (7,'2014-I','ESTO ES UN PROYECTO DE PRUEBA','V-10000000','V-11000000','APROBADO','ING SISTEMAS','UNEFA VA A LA ESCUELA','06/05/2014','23/10/2015'),(8,'2014-I','APOYO AL HOSPITAL DE JUAN GRIEGO','V-10000000','V-12000000','ESPERA','ENFERMERIA','UNEFA VA A LA COMUNIDAD','04/06/2015','POR DEFINIR'),(9,'2014-I','APOYO ADMINISTRATIVO A LA ALCALDIA DEL MUNICIPIO TAL','V-10000000','V-9000001','REPROBADO','ADMINISTRACION','UNEFA VA A LA COMUNIDAD','13/01/2014','26/09/2014'),(10,'2014-I','CURSOS DE HERRAMIENTAS OFIMATICAS A LA ESCUELA TAL','V-10000000','V-11100000','ESPERA','ING SISTEMAS','UNEFA VA A LA ESCUELA','09/05/2014','POR DEFINIR');
/*!40000 ALTER TABLE `proyecto` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `realiza`
--

DROP TABLE IF EXISTS `realiza`;
CREATE TABLE `realiza` (
  `nombreproyecto` varchar(200) collate utf8_spanish_ci NOT NULL,
  `cedalumno` varchar(30) collate utf8_spanish_ci NOT NULL,
  PRIMARY KEY  (`nombreproyecto`,`cedalumno`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Dumping data for table `realiza`
--

LOCK TABLES `realiza` WRITE;
/*!40000 ALTER TABLE `realiza` DISABLE KEYS */;
INSERT INTO `realiza` VALUES ('APOYO ADMINISTRATIVO A LA ALCALDIA DEL MUNICIPIO TAL','V-21000000'),('APOYO ADMINISTRATIVO A LA ALCALDIA DEL MUNICIPIO TAL','V-21000001'),('APOYO ADMINISTRATIVO A LA ALCALDIA DEL MUNICIPIO TAL','V-21000002'),('APOYO AL HOSPITAL DE JUAN GRIEGO','V-19000000'),('APOYO AL HOSPITAL DE JUAN GRIEGO','V-21500000'),('CURSOS DE HERRAMIENTAS OFIMATICAS A LA ESCUELA TAL','V-22100000'),('CURSOS DE HERRAMIENTAS OFIMATICAS A LA ESCUELA TAL','V-22200000'),('CURSOS DE HERRAMIENTAS OFIMATICAS A LA ESCUELA TAL','V-22300000'),('ESTO ES UN PROYECTO DE PRUEBA','V-17000000'),('ESTO ES UN PROYECTO DE PRUEBA','V-18000000'),('ESTO ES UN PROYECTO DE PRUEBA','V-22000000');
/*!40000 ALTER TABLE `realiza` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tutor`
--

DROP TABLE IF EXISTS `tutor`;
CREATE TABLE `tutor` (
  `id` int(11) NOT NULL auto_increment,
  `ve` varchar(2) collate utf8_spanish_ci NOT NULL,
  `cedula` varchar(20) collate utf8_spanish_ci NOT NULL,
  `nombre` varchar(60) collate utf8_spanish_ci NOT NULL,
  `apellido` varchar(60) collate utf8_spanish_ci NOT NULL,
  `telefono` varchar(30) collate utf8_spanish_ci NOT NULL,
  `tipo` varchar(15) collate utf8_spanish_ci NOT NULL,
  PRIMARY KEY  (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=10 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Dumping data for table `tutor`
--

LOCK TABLES `tutor` WRITE;
/*!40000 ALTER TABLE `tutor` DISABLE KEYS */;
INSERT INTO `tutor` VALUES (1,'V-','10000000','LEONEL','RAMIREZ','04269807354','ACADEMICO'),(4,'V-','11000000','JOSE','MORILLO','1234567','COMUNITARIO'),(6,'V-','12000000','CLARA','MILLAN','02952539987','COMUNITARIO'),(7,'V-','9000001','JORGE','PALACIOS','4536789','COMUNITARIO'),(9,'V-','11100000','CARLOS','COSTA','445566778','COMUNITARIO');
/*!40000 ALTER TABLE `tutor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuario`
--

DROP TABLE IF EXISTS `usuario`;
CREATE TABLE `usuario` (
  `nick` varchar(30) collate utf8_spanish_ci NOT NULL,
  `contrasena` varchar(30) collate utf8_spanish_ci NOT NULL,
  PRIMARY KEY  (`nick`,`contrasena`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Dumping data for table `usuario`
--

LOCK TABLES `usuario` WRITE;
/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
INSERT INTO `usuario` VALUES ('kluna','654321');
/*!40000 ALTER TABLE `usuario` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2014-07-15  3:09:30
