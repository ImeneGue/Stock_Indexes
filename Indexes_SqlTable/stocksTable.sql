-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               8.0.30 - MySQL Community Server - GPL
-- Server OS:                    Win64
-- HeidiSQL Version:             12.1.0.6537
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Dumping database structure for stocks
CREATE DATABASE IF NOT EXISTS `stocks` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `stocks`;

-- Dumping structure for table stocks.stock
CREATE TABLE IF NOT EXISTS `stock` (
  `StockId` int NOT NULL AUTO_INCREMENT,
  `NomStock` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `IndexShortCut` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `PrixActuel` decimal(20,6) NOT NULL,
  `PrixInitial` decimal(20,6) NOT NULL,
  PRIMARY KEY (`StockId`)
) ENGINE=InnoDB AUTO_INCREMENT=50 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table stocks.stock: ~7 rows (approximately)
INSERT INTO `stock` (`StockId`, `NomStock`, `IndexShortCut`, `PrixActuel`, `PrixInitial`) VALUES
	(1, 'Euro Stoxx 50', 'STOXX50E', 3976.530000, 4000.000000),
	(2, 'S&P 500', 'S&P 500', 4004.000000, 3989.000000),
	(3, 'Bovespa', 'BVSP', 108.000000, 112.000000),
	(4, 'Dow Jones Industrial Average', 'DowJones', 33802.530000, 33852.530000),
	(5, 'Nasdaq Composite', ' Nasdaq-100', 11193.000000, 11170.000000),
	(6, 'Russell 2000', 'Russell2000', 1840.000000, 1670.000000),
	(7, 'The Boeing Company', 'BA', 172.000000, 171.000000);

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
