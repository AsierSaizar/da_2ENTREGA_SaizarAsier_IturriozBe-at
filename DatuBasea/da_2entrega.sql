-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
-- Host: localhost    Database: da_2entrega
-- ------------------------------------------------------
-- Server version	8.0.34

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `erabiltzailea`
--

DROP TABLE IF EXISTS `erabiltzailea`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `erabiltzailea` (
  `langilea_id` int NOT NULL,
  `erabiltzaileIzena` varchar(255) NOT NULL,
  `erabiltzailePasahitza` varchar(255) NOT NULL,
  PRIMARY KEY (`langilea_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `erabiltzailea`
--

LOCK TABLES `erabiltzailea` WRITE;
/*!40000 ALTER TABLE `erabiltzailea` DISABLE KEYS */;
INSERT INTO `erabiltzailea` VALUES (1,'agarcia','passAitor2024'),(2,'mlopez','maite1234'),(3,'imartinez','ikerSecure!'),(4,'afernandez','AmaiaFZ_90'),(5,'jgonzalez','Jon1995%'),(6,'asanchez','AneSuperPass'),(7,'ufernandez','Unai_83pass'),(8,'lperez','Leire1997#'),(9,'eruiz','Eneko_Pass!'),(10,'malonso','Mikel_AL123');
/*!40000 ALTER TABLE `erabiltzailea` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `langilea`
--

DROP TABLE IF EXISTS `langilea`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `langilea` (
  `id` int NOT NULL AUTO_INCREMENT,
  `izena` varchar(255) NOT NULL,
  `abizena` varchar(255) NOT NULL,
  `kKorrontea` char(24) NOT NULL,
  `jaiotzeData` date NOT NULL,
  `borratua` tinyint DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=49 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `langilea`
--

LOCK TABLES `langilea` WRITE;
/*!40000 ALTER TABLE `langilea` DISABLE KEYS */;
INSERT INTO `langilea` VALUES (1,'Aitor','Garcia','ES45000812828712345678','1990-05-12',NULL),(2,'Maite','Lopez','ES12004813456678901234','1985-03-22',NULL),(3,'Iker','Martinez','ES76001823456234567890','1992-07-14',NULL),(4,'Amaia','Fernandez','ES56002423456567890123','1988-11-29',NULL),(5,'Jon','Gonzalez','ES91003023234567890123','1995-12-15',NULL),(6,'Ane','Sanchez','ES44004813456789012345','1989-08-19',NULL),(7,'Unai','Iglesias','ES56005200012345678901','1983-04-02',NULL),(8,'Leire','Perez','ES30004823456789012345','1997-02-14',NULL),(9,'Eneko','Ruiz','ES83003012345678901234','1991-10-17',NULL),(10,'Mikel','Alonso','ES91004012456789012345','1990-03-26',NULL),(11,'Aritz','Hernandez','ES62005223456789012345','1994-09-11',NULL),(12,'Uxue','Castro','ES76001023456789012345','1993-06-30',NULL),(13,'Xabier','Ortega','ES02004823456789012345','1990-12-20',NULL),(14,'Lorea','Vazquez','ES84006012345678901234','1987-10-12',NULL),(15,'Ibai','Diez','ES55006512345678901234','1998-11-03',NULL),(16,'Nahia','Gutierrez','ES76007012345678901234','1986-01-25',NULL),(17,'Koldo','Ramirez','ES43007512345678901234','1990-09-29',NULL),(18,'Sara','Torres','ES33008012345678901234','1995-07-24',NULL),(19,'Ander','Navarro','ES88008512345678901234','1991-03-15',NULL),(20,'Irati','Dominguez','ES59009012345678901234','1985-08-30',NULL),(21,'Ane','Molina','ES20009512345678901234','1992-12-04',NULL),(22,'Markel','Sanz','ES12010012345678901234','1996-05-09',NULL),(23,'Maitane','Ortiz','ES74010512345678901234','1994-06-17',NULL),(24,'Aitor','Silva','ES66011012345678901234','1989-03-02',NULL),(25,'Leire','Moreno','ES33011512345678901234','1993-04-13',NULL),(26,'Asier','Cortes','ES99012012345678901234','1988-09-25',NULL),(27,'Oihana','Sierra','ES44012512345678901234','1995-02-21',NULL),(28,'Xabi','Castillo','ES88013012345678901234','1990-10-10',NULL),(29,'Miren','Agirre','ES55013512345678901234','1987-01-17',NULL),(30,'Beñat','Otero','ES30014012345678901234','1991-08-06',NULL),(31,'Lorea','Pascual','ES91014512345678901234','1986-03-27',NULL),(32,'Eneko','Santos','ES66015012345678901234','1993-11-11',NULL),(33,'Aitziber','Marti','ES78015512345678901234','1998-04-05',NULL),(34,'Gorka','Vega','ES34016012345678901234','1995-07-19',NULL),(35,'Naiara','Cano','ES17016512345678901234','1992-09-22',NULL),(36,'Lander','Rios','ES29017012345678901234','1988-06-09',NULL),(37,'Amaia','Carrasco','ES45017512345678901234','1987-12-15',NULL),(38,'Jon','Marquez','ES33018012345678901234','1991-02-20',NULL),(39,'Eider','Rey','ES90018512345678901234','1990-05-18',NULL),(40,'Irune','Soto','ES01019012345678901234','1996-08-28',NULL),(41,'Iñigo','Saez','ES22019512345678901234','1993-07-13',NULL),(42,'Maialen','Leon','ES13020012345678901234','1985-12-23',NULL),(43,'Unai','Lopez','ES05020512345678901234','1989-06-16',NULL),(44,'Aritz','Pena','ES48021012345678901234','1990-03-08',NULL),(45,'Leire','Vidal','ES91021512345678901234','1997-11-01',NULL),(46,'Mikel','Cruz','ES70022012345678901234','1988-04-16',NULL),(47,'Asier','Serrano','ES42022512345678901234','1994-06-05',NULL),(48,'Uxue','Soler','ES29023012345678901234','1985-01-19',NULL);
/*!40000 ALTER TABLE `langilea` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-10-11 17:13:41
