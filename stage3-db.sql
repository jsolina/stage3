/*
SQLyog Ultimate v12.4.1 (64 bit)
MySQL - 10.4.14-MariaDB : Database - todo
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`todo` /*!40100 DEFAULT CHARACTER SET utf8mb4 */;

USE `todo`;

/*Table structure for table `itemlist` */

DROP TABLE IF EXISTS `itemlist`;

CREATE TABLE `itemlist` (
  `idItem` int(45) NOT NULL AUTO_INCREMENT,
  `idTask` int(45) DEFAULT NULL,
  `itemName` varchar(65) DEFAULT NULL,
  `itemDetails` varchar(65) DEFAULT NULL,
  `itemStatus` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idItem`),
  KEY `idTask` (`idTask`),
  CONSTRAINT `itemlist_ibfk_1` FOREIGN KEY (`idTask`) REFERENCES `tasklist` (`idTask`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4;

/*Data for the table `itemlist` */

insert  into `itemlist`(`idItem`,`idTask`,`itemName`,`itemDetails`,`itemStatus`) values 
(1,1,'item1','123',NULL),
(2,1,'item2','321',NULL),
(3,2,'czczz','czz',NULL);

/*Table structure for table `tasklist` */

DROP TABLE IF EXISTS `tasklist`;

CREATE TABLE `tasklist` (
  `idTask` int(45) NOT NULL AUTO_INCREMENT,
  `taskName` varchar(65) DEFAULT NULL,
  `taskDetails` varchar(65) DEFAULT NULL,
  PRIMARY KEY (`idTask`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4;

/*Data for the table `tasklist` */

insert  into `tasklist`(`idTask`,`taskName`,`taskDetails`) values 
(1,'task1','taskDetails3'),
(2,'task2','taskDetails2'),
(3,'task3','taskDetails3'),
(10,'task4.','taskDeails4...'),
(11,'22222','222222'),
(12,'ew','awe'),
(13,'111','11111'),
(14,'14aa','14124'),
(15,'hhhh','hh'),
(16,'jajaja','jujujuj');

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
