-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: comunidades
-- ------------------------------------------------------
-- Server version	8.0.35

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
-- Table structure for table `comunidades`
--

DROP TABLE IF EXISTS `comunidades`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `comunidades` (
  `ComunidadID` int NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(100) NOT NULL,
  `Direccion` varchar(255) NOT NULL,
  `FechaCreacion` date NOT NULL,
  `MetrosCuadrados` int DEFAULT NULL,
  `TienePiscina` tinyint(1) DEFAULT NULL,
  `PisoPortero` tinyint(1) DEFAULT NULL,
  `DuchasBano` tinyint(1) DEFAULT NULL,
  `ParqueInfantil` tinyint(1) DEFAULT NULL,
  `MaquinasEjercicio` tinyint(1) DEFAULT NULL,
  `SalaReuniones` tinyint(1) DEFAULT NULL,
  `PistaTenis` tinyint(1) DEFAULT NULL,
  `PistaPadel` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`ComunidadID`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `comunidades`
--

LOCK TABLES `comunidades` WRITE;
/*!40000 ALTER TABLE `comunidades` DISABLE KEYS */;
INSERT INTO `comunidades` VALUES (1,'Contuvernio','hola mundo','2024-02-16',21,0,1,1,1,0,0,1,0),(2,'Ciudad real','Azunea','2024-02-15',2311,0,0,1,0,1,0,0,0),(3,'Hola','hola','2024-02-09',2131,0,0,1,0,1,0,0,0),(4,'Caca','asdf','2024-02-15',21,0,0,1,0,1,0,1,1),(5,'Kevin Tieso','asdfa','0001-01-01',211,0,1,0,0,0,1,1,0),(6,'Josevi','qerwer','2024-02-08',2131,0,1,0,0,1,1,0,0),(7,'wewe','eweqwe','0001-01-01',123,0,0,1,0,1,0,0,0),(8,'e234','3243','2024-02-07',123,0,0,0,0,0,0,0,0);
/*!40000 ALTER TABLE `comunidades` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-02-07 17:17:50
