-- phpMyAdmin SQL Dump
-- version 4.1.14
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Nov 22, 2016 at 06:48 PM
-- Server version: 5.6.17
-- PHP Version: 5.5.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `medical_store`
--

-- --------------------------------------------------------

--
-- Table structure for table `accounts`
--

CREATE TABLE IF NOT EXISTS `accounts` (
  `UsrId` varchar(50) NOT NULL,
  `Name` varchar(50) NOT NULL,
  `Address` varchar(100) NOT NULL,
  `CellPhone` varchar(50) NOT NULL,
  `Password` varchar(50) NOT NULL,
  `IsAdmin` varchar(10) NOT NULL,
  `MedStrName` varchar(50) NOT NULL,
  `IsBlocked` varchar(10) NOT NULL,
  PRIMARY KEY (`UsrId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `accounts`
--

INSERT INTO `accounts` (`UsrId`, `Name`, `Address`, `CellPhone`, `Password`, `IsAdmin`, `MedStrName`, `IsBlocked`) VALUES
('AD11', 'Saad Afzaal', 'House # 2 Street # 20 Aamir Town Harbanspura Lahore Pakistan', '03234521048', '123', 'Yes', 'Al-Saad-Medical Store', 'No'),
('US11', 'Amjad Afzaal', 'House # 2 Street # 20 Aamir Town Harbanspura Lahore Pakistan', '03224307843', '03224307843', 'No', 'Al-Saad-Medical Store', 'No'),
('US22', 'Ali Nawaz', 'House # 20 Street # 5 Bilal Town Dharhampura Lahore Pakistan', '03217894523', '1234', 'No', 'Al-Saad-Medical Store', 'No'),
('US23', 'Hassan Raza', 'House # 25 Street # 15 Galiz Town FatehGrah Lahore Pakistan', '03217894523', '0321', 'No', 'Al-Saad-Medical Store', 'No');

-- --------------------------------------------------------

--
-- Table structure for table `audittrail`
--

CREATE TABLE IF NOT EXISTS `audittrail` (
  `AudTrlId` bigint(50) NOT NULL AUTO_INCREMENT,
  `MedCde` varchar(50) NOT NULL,
  `Type` varchar(50) NOT NULL,
  `Name` varchar(50) NOT NULL,
  `UsrId` varchar(50) NOT NULL,
  `IsPur` varchar(10) NOT NULL,
  `IsSld` varchar(10) NOT NULL,
  `Qty` int(11) NOT NULL,
  `PurUntPrice` double NOT NULL,
  `SldUntPrice` double NOT NULL,
  `Date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`AudTrlId`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=123 ;

--
-- Dumping data for table `audittrail`
--

INSERT INTO `audittrail` (`AudTrlId`, `MedCde`, `Type`, `Name`, `UsrId`, `IsPur`, `IsSld`, `Qty`, `PurUntPrice`, `SldUntPrice`, `Date`) VALUES
(1, 'IFN0002', 'Tablet', 'Disparen', 'AD11', 'No', 'Yes', 10, 5, 10, '2016-05-08 00:00:00'),
(2, 'IFN0001', 'Tablet', 'Panadol', 'AD11', 'No', 'Yes', 10, 10, 15, '2016-05-08 00:00:00'),
(3, 'IFN0002', 'Tablet', 'Disparen', 'US11', 'No', 'Yes', 10, 5, 10, '2016-05-08 00:00:00'),
(4, 'IFN0001', 'Tablet', 'Panadol', 'US11', 'No', 'Yes', 5, 10, 15, '2016-05-08 00:00:00'),
(5, 'IFN0002', 'Tablet', 'Disparen', 'US23', 'No', 'Yes', 5, 5, 10, '2016-05-08 00:00:00'),
(6, 'IFN0001', 'Tablet', 'Panadol', 'US23', 'No', 'Yes', 5, 10, 15, '2016-05-08 00:00:00'),
(7, 'IFN0002', 'Tablet', 'Disparen', 'AD11', 'Yes', 'No', 5, 5, 10, '2016-05-08 00:00:00'),
(8, 'IFN0001', 'Tablet', 'Panadol', 'AD11', 'Yes', 'No', 5, 10, 15, '2016-05-08 00:00:00'),
(9, 'IFN0002', 'Tablet', 'Disparen', 'AD11', 'Yes', 'No', 10, 5, 10, '2016-05-08 00:00:00'),
(10, 'IFN0001', 'Tablet', 'Panadol', 'AD11', 'Yes', 'No', 10, 10, 15, '2016-05-08 00:00:00'),
(11, 'IFN0002', 'Tablet', 'Disparen', 'AD11', 'No', 'Yes', 10, 5, 10, '2016-05-08 00:00:00'),
(12, 'IFN0001', 'Tablet', 'Panadol', 'AD11', 'No', 'Yes', 10, 10, 15, '2016-05-08 00:00:00'),
(13, 'IFN0002', 'Tablet', 'Disparen', 'AD11', 'Yes', 'No', 5, 5, 10, '2016-05-08 00:00:00'),
(14, 'IFN0001', 'Tablet', 'Panadol', 'AD11', 'Yes', 'No', 5, 10, 15, '2016-05-08 00:00:00'),
(15, 'IFN0002', 'Tablet', 'Disparen', 'AD11', 'No', 'Yes', 5, 5, 10, '2016-05-08 00:00:00'),
(16, 'IFN0001', 'Tablet', 'Panadol', 'AD11', 'No', 'Yes', 5, 10, 15, '2016-05-08 00:00:00'),
(17, 'IFN0002', 'Tablet', 'Disparen', 'AD11', 'No', 'Yes', 5, 5, 10, '2016-05-08 00:00:00'),
(18, 'IFN0001', 'Tablet', 'Panadol', 'AD11', 'No', 'Yes', 5, 10, 15, '2016-05-08 00:00:00'),
(19, 'IFN0002', 'Tablet', 'Disparen', 'US11', 'No', 'Yes', 12, 5, 10, '2016-05-08 00:00:00'),
(20, 'IFN0001', 'Tablet', 'Panadol', 'US11', 'No', 'Yes', 12, 10, 15, '2016-05-08 00:00:00'),
(21, 'IFN0002', 'Tablet', 'Disparen', 'AD11', 'Yes', 'No', 20, 5, 10, '2016-05-08 00:00:00'),
(22, 'IFN0001', 'Tablet', 'Panadol', 'AD11', 'Yes', 'No', 20, 10, 15, '2016-05-08 00:00:00'),
(23, 'IFN0003', 'Cerup', 'Cola', 'AD11', 'Yes', 'No', 5, 5, 10, '2016-05-15 00:00:00'),
(24, 'IFN0002', 'Tablet', 'Disparen', 'AD11', 'Yes', 'No', 5, 5, 10, '2016-05-15 00:00:00'),
(25, 'IFN0003', 'Cerup', 'Cola', 'AD11', 'Yes', 'No', 5, 5, 10, '2016-05-15 00:00:00'),
(26, 'IFN0003', 'Cerup', 'Cola', 'AD11', 'Yes', 'No', 5, 5, 10, '2016-05-15 00:00:00'),
(27, 'IFN0001', 'Tablet', 'Panadol', 'AD11', 'Yes', 'No', 5, 10, 15, '2016-05-15 00:00:00'),
(28, 'IFN0003', 'Cerup', 'Cola', 'AD11', 'No', 'Yes', 5, 5, 10, '2016-05-15 00:00:00'),
(29, 'IFN0002', 'Tablet', 'Disparen', 'AD11', 'No', 'Yes', 5, 5, 10, '2016-05-15 00:00:00'),
(30, 'IFN0003', 'Cerup', 'Cola', 'AD11', 'No', 'Yes', 5, 5, 10, '2016-05-15 00:00:00'),
(31, 'IFN0001', 'Tablet', 'Panadol', 'AD11', 'No', 'Yes', 5, 10, 15, '2016-05-15 00:00:00'),
(32, 'IFN0003', 'Cerup', 'Cola', 'AD11', 'No', 'Yes', 5, 5, 10, '2016-05-16 00:00:00'),
(33, 'IFN0003', 'Cerup', 'Cola', 'AD11', 'Yes', 'No', 5, 5, 10, '2016-05-21 00:00:00'),
(34, 'IFN0003', 'Cerup', 'Cola', 'AD11', 'Yes', 'No', 5, 5, 10, '2016-05-21 00:00:00'),
(35, 'IFN0003', 'Cerup', 'Cola', 'AD11', 'No', 'Yes', 5, 5, 5, '2016-05-21 00:00:00'),
(36, 'IFN0003', 'Cerup', 'Cola', 'AD11', 'Yes', 'No', 10, 5, 10, '2016-05-21 00:00:00'),
(37, 'IFN0003', 'Cerup', 'Cola', 'AD11', 'Yes', 'No', 5, 5, 5, '2016-05-22 00:00:00'),
(38, 'IFN0003', 'Cerup', 'Cola', 'AD11', 'Yes', 'No', 30, 10, 10, '2016-05-22 00:00:00'),
(39, 'IFN0003', 'Cerup', 'Cola', 'AD11', 'Yes', 'No', 55, 10, 10, '2016-05-22 00:00:00'),
(40, 'IFN0003', 'Cerup', 'Cola', 'AD11', 'Yes', 'No', 30, 10, 10, '2016-05-22 00:00:00'),
(41, 'IFN0003', 'Cerup', 'Cola', 'AD11', 'Yes', 'No', 50, 10, 10, '2016-05-22 00:00:00'),
(42, 'IFN0002', 'Tablet', 'Disparen', 'AD11', 'No', 'Yes', 5, 5, 5, '2016-05-22 00:00:00'),
(43, 'IFN0002', 'Tablet', 'Disparen', 'AD11', 'Yes', 'No', 5, 5, 10, '2016-05-22 00:00:00'),
(44, 'IFN0003', 'Cerup', 'Cola', 'AD11', 'No', 'Yes', 50, 5, 10, '2016-05-22 00:00:00'),
(45, 'IFN0003', 'Cerup', 'Cola', 'AD11', 'Yes', 'No', 40, 10, 10, '2016-05-22 00:00:00'),
(46, 'IFN0004', 'Cerup', 'Complex', 'AD11', 'Yes', 'No', 20, 30, 50, '2016-05-22 00:00:00'),
(47, 'IFN0004', 'Cerup', 'Complex', 'AD11', 'No', 'Yes', 10, 30, 50, '2016-05-22 00:00:00'),
(48, 'IFN0004', 'Cerup', 'Complex', 'AD11', 'No', 'Yes', 5, 30, 50, '2016-05-22 00:00:00'),
(49, 'IFN0004', 'Cerup', 'Complex', 'AD11', 'No', 'Yes', 3, 30, 50, '2016-05-22 00:00:00'),
(50, 'IFN0003', 'Cerup', 'Cola', 'US11', 'Yes', 'No', 20, 10, 10, '2016-06-17 00:00:00'),
(51, 'IFN0003', 'Cerup', 'Cola', 'AD11', 'Yes', 'No', 10, 10, 10, '2016-06-17 00:00:00'),
(52, 'IFN0003', 'Cerup', 'Cola', 'AD11', 'No', 'Yes', 10, 5, 5, '2016-06-17 00:00:00'),
(53, 'IFN0003', 'Cerup', 'Cola', 'AD11', 'Yes', 'No', 10, 5, 10, '2016-06-17 00:00:00'),
(54, 'IFN0003', 'Cerup', 'Cola', 'AD11', 'Yes', 'No', 10, 5, 10, '2016-06-17 00:00:00'),
(55, 'IFN0003', 'Cerup', 'Cola', 'AD11', 'Yes', 'No', 10, 5, 10, '2016-06-17 00:00:00'),
(56, 'IFN0003', 'Cerup', 'Cola', 'AD11', 'Yes', 'No', 10, 5, 10, '2016-06-17 00:00:00'),
(57, 'IFN0003', 'Cerup', 'Cola', 'AD11', 'No', 'Yes', 10, 5, 5, '2016-06-17 00:00:00'),
(58, 'IFN0003', 'Cerup', 'Cola', 'AD11', 'No', 'Yes', 10, 5, 5, '2016-06-17 00:00:00'),
(59, 'IFN0004', 'Cerup', 'Complex', 'AD11', 'Yes', 'No', 2, 30, 50, '2016-06-17 00:00:00'),
(60, 'IFN0003', 'Cerup', 'Cola', 'AD11', 'No', 'Yes', 20, 5, 10, '2016-06-17 00:00:00'),
(61, 'IFN0003', 'Cerup', 'Cola', 'AD11', 'Yes', 'No', 20, 10, 10, '2016-06-17 00:00:00'),
(62, 'IFN0003', 'Cerup', 'Cola', 'AD11', 'No', 'Yes', 10, 5, 10, '2016-06-17 00:00:00'),
(63, 'IFN0003', 'Cerup', 'Cola', 'AD11', 'Yes', 'No', 10, 10, 10, '2016-06-17 00:00:00'),
(64, 'IFN0004', 'Cerup', 'Complex', 'AD11', 'Yes', 'No', 6, 30, 50, '2016-06-19 00:00:00'),
(65, 'IFN0004', 'Cerup', 'Complex', 'AD11', 'Yes', 'No', 10, 30, 50, '2016-06-20 00:00:00'),
(66, 'IFN0004', 'Cerup', 'Complex', 'AD11', 'Yes', 'No', 10, 30, 50, '2016-06-20 00:00:00'),
(67, 'IFN0004', 'Cerup', 'Complex', 'AD11', 'No', 'Yes', 10, 30, 30, '2016-06-20 00:00:00'),
(68, 'IFN0001', 'Tablet', 'Panadol', 'AD11', 'No', 'Yes', 3, 10, 15, '2016-06-20 00:00:00'),
(70, 'IFN0002', 'Tablet', 'Disparen', 'AD11', 'No', 'Yes', 9, 5, 10, '2016-06-23 00:00:00'),
(71, 'IFN0002', 'Tablet', 'Disparen', 'AD11', 'Yes', 'No', 6, 10, 10, '2016-06-23 00:00:00'),
(72, 'IFN0005', 'Tab', 'augmented', 'AD11', 'Yes', 'No', 35, 6, 12, '2016-07-07 00:00:00'),
(73, 'IFN0003', 'Cerup', 'Cola', 'AD11', 'Yes', 'No', 20, 5, 10, '2016-07-07 00:00:00'),
(74, 'IFN0004', 'Cerup', 'Complex', 'AD11', 'Yes', 'No', 5, 30, 50, '2016-07-07 00:00:00'),
(75, 'IFN0005', 'Tab', 'augmented', 'AD11', 'No', 'Yes', 10, 6, 12, '2016-07-07 00:00:00'),
(76, 'IFN0005', 'Tab', 'augmented', 'AD11', 'No', 'Yes', 30, 6, 12, '2016-07-07 00:00:00'),
(77, 'IFN0005', 'Tab', 'augmented', 'AD11', 'No', 'Yes', 10, 6, 12, '2016-07-07 00:00:00'),
(78, 'IFN0005', 'Tab', 'augmented', 'AD11', 'No', 'Yes', 10, 6, 12, '2016-08-10 00:00:00'),
(79, 'IFN0003', 'Cerup', 'Cola', 'AD11', 'Yes', 'No', 10, 10, 10, '2016-08-10 00:00:00'),
(80, 'IFN0005', 'Tab', 'augmented', 'AD11', 'No', 'Yes', 5, 6, 12, '2016-08-10 00:00:00'),
(81, 'IFN0003', 'Cerup', 'Cola', 'AD11', 'Yes', 'No', 5, 10, 10, '2016-08-10 00:00:00'),
(82, 'IFN0003', 'Cerup', 'Cola', 'AD11', 'No', 'Yes', 20, 5, 10, '2016-08-10 00:00:00'),
(83, 'IFN0005', 'Tab', 'augmented', 'AD11', 'Yes', 'No', 5, 6, 12, '2016-08-12 00:00:00'),
(84, 'IFN0005', 'Tab', 'augmented', 'AD11', 'Yes', 'No', 5, 8, 12, '2016-08-12 00:00:00'),
(85, 'IFN0005', 'Tab', 'augmented', 'AD11', 'Yes', 'No', 5, 6, 12, '2016-08-12 00:00:00'),
(86, 'IFN0005', 'Tab', 'augmented', 'AD11', 'Yes', 'No', 5, 8, 8, '2016-08-12 00:00:00'),
(87, 'IFN0005', 'Tab', 'augmented', 'AD11', 'Yes', 'No', 5, 8, 8, '2016-08-12 00:00:00'),
(88, 'IFN0005', 'Tab', 'augmented', 'AD11', 'No', 'Yes', 5, 6, 6, '2016-08-12 00:00:00'),
(89, 'IFN0005', 'Tab', 'augmented', 'AD11', 'Yes', 'No', 5, 6, 12, '2016-08-12 00:00:00'),
(90, 'IFN0005', 'Tab', 'augmented', 'AD11', 'No', 'Yes', 5, 6, 6, '2016-08-12 00:00:00'),
(91, 'IFN0005', 'Tab', 'augmented', 'AD11', 'Yes', 'No', 5, 6, 12, '2016-08-12 00:00:00'),
(92, 'IFN0005', 'Tab', 'augmented', 'AD11', 'No', 'Yes', 5, 6, 6, '2016-08-12 00:00:00'),
(93, 'IFN0005', 'Tab', 'augmented', 'AD11', 'No', 'Yes', 10, 8, 8, '2016-08-12 00:00:00'),
(94, 'IFN0005', 'Tab', 'augmented', 'AD11', 'No', 'Yes', 3, 6, 12, '2016-08-12 00:00:00'),
(95, 'IFN0005', 'Tab', 'augmented', 'AD11', 'No', 'Yes', 5, 8, 12, '2016-08-12 00:00:00'),
(96, 'IFN0005', 'Tab', 'augmented', 'AD11', 'Yes', 'No', 1, 12, 12, '2016-08-12 00:00:00'),
(97, 'IFN0005', 'Tab', 'augmented', 'AD11', 'Yes', 'No', 2, 12, 12, '2016-08-12 00:00:00'),
(98, 'IFN0005', 'Tab', 'augmented', 'AD11', 'No', 'Yes', 1, 6, 12, '2016-08-12 00:00:00'),
(99, 'IFN0005', 'Tab', 'augmented', 'AD11', 'No', 'Yes', 2, 8, 12, '2016-08-12 00:00:00'),
(100, 'IFN0005', 'Tab', 'augmented', 'AD11', 'Yes', 'No', 3, 6.55, 12.55, '2016-11-22 00:00:00'),
(101, 'IFN0003', 'Cerup', 'Cola', 'AD11', 'Yes', 'No', 5, 12.55, 12.55, '2016-11-22 00:00:00'),
(102, 'IFN0005', 'Tab', 'augmented', 'AD11', 'Yes', 'No', 3, 6.55, 12.55, '2016-11-22 00:00:00'),
(103, 'IFN0003', 'Cerup', 'Cola', 'AD11', 'Yes', 'No', 5, 12.55, 12.55, '2016-11-22 00:00:00'),
(104, 'IFN0005', 'Tab', 'augmented', 'AD11', 'Yes', 'No', 3, 6.55, 12.55, '2016-11-22 00:00:00'),
(105, 'IFN0003', 'Cerup', 'Cola', 'AD11', 'Yes', 'No', 5, 12.55, 12.55, '2016-11-22 00:00:00'),
(106, 'IFN0005', 'Tab', 'augmented', 'AD11', 'Yes', 'No', 3, 6.55, 12.55, '2016-11-22 00:00:00'),
(107, 'IFN0003', 'Cerup', 'Cola', 'AD11', 'Yes', 'No', 5, 12.55, 12.55, '2016-11-22 00:00:00'),
(108, 'IFN0005', 'Tab', 'augmented', 'AD11', 'Yes', 'No', 3, 6.55, 12.55, '2016-11-22 00:00:00'),
(109, 'IFN0003', 'Cerup', 'Cola', 'AD11', 'Yes', 'No', 5, 12.55, 12.55, '2016-11-22 00:00:00'),
(110, 'IFN0005', 'Tab', 'augmented', 'AD11', 'Yes', 'No', 3, 6.55, 12.55, '2016-11-22 00:00:00'),
(111, 'IFN0003', 'Cerup', 'Cola', 'AD11', 'Yes', 'No', 5, 12.55, 12.55, '2016-11-22 00:00:00'),
(112, 'IFN0005', 'Tab', 'augmented', 'AD11', 'No', 'Yes', 5, 6.55, 6.55, '2016-11-22 00:00:00'),
(113, 'IFN0003', 'Cerup', 'Cola', 'AD11', 'No', 'Yes', 10, 12.55, 12.55, '2016-11-22 00:00:00'),
(114, 'IFN0005', 'Tab', 'augmented', 'AD11', 'No', 'Yes', 5, 6.55, 12.55, '2016-11-22 00:00:00'),
(115, 'IFN0003', 'Cerup', 'Cola', 'AD11', 'No', 'Yes', 5, 5.55, 10.55, '2016-11-22 00:00:00'),
(116, 'IFN0005', 'Tab', 'augmented', 'AD11', 'Yes', 'No', 5, 8.55, 8.55, '2016-11-22 00:00:00'),
(117, 'IFN0003', 'Cerup', 'Cola', 'AD11', 'No', 'Yes', 10, 5.55, 10.55, '2016-11-22 00:00:00'),
(118, 'IFN0005', 'Tab', 'augmented', 'AD11', 'No', 'Yes', 5, 6.55, 12.55, '2016-11-22 00:00:00'),
(119, 'IFN0003', 'Cerup', 'Cola', 'AD11', 'No', 'Yes', 20, 5.55, 10.55, '2016-11-22 00:00:00'),
(120, 'IFN0005', 'Tab', 'augmented', 'AD11', 'Yes', 'No', 5, 12.55, 12.55, '2016-11-22 00:00:00'),
(121, 'IFN0003', 'Cerup', 'Cola', 'AD11', 'Yes', 'No', 5, 5.55, 10.55, '2016-11-22 00:00:00'),
(122, 'IFN0005', 'Tab', 'augmented', 'AD11', 'Yes', 'No', 5, 6.55, 12.55, '2016-11-22 00:00:00');

-- --------------------------------------------------------

--
-- Table structure for table `cart`
--

CREATE TABLE IF NOT EXISTS `cart` (
  `Name` varchar(50) NOT NULL,
  `Quantity` int(11) NOT NULL,
  `Individual_Price` double NOT NULL,
  `Total_Price` double NOT NULL,
  `Discount` varchar(11) NOT NULL,
  `Net_Price` double NOT NULL,
  `Stock_Type` varchar(11) NOT NULL,
  `IsReturn` varchar(10) NOT NULL,
  PRIMARY KEY (`Name`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `counter`
--

CREATE TABLE IF NOT EXISTS `counter` (
  `Count` int(11) NOT NULL,
  PRIMARY KEY (`Count`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `counter`
--

INSERT INTO `counter` (`Count`) VALUES
(7);

-- --------------------------------------------------------

--
-- Table structure for table `expense`
--

CREATE TABLE IF NOT EXISTS `expense` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Expense` varchar(50) NOT NULL,
  `Price` double NOT NULL,
  `Date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=15 ;

--
-- Dumping data for table `expense`
--

INSERT INTO `expense` (`id`, `Expense`, `Price`, `Date`) VALUES
(7, 'Salaries', 30000.99, '2016-05-03 00:00:00'),
(8, 'Dividents', 15000.33, '2016-05-03 00:00:00'),
(9, 'Utility Bills', 8000.54, '2016-05-03 00:00:00'),
(10, 'Interset', 8080.66, '2016-05-05 00:00:00'),
(11, 'discout on tables augenlasah', 90.33, '2016-07-07 00:00:00'),
(14, 'Loan', 2000.99, '2016-11-21 00:00:00');

-- --------------------------------------------------------

--
-- Table structure for table `medicine`
--

CREATE TABLE IF NOT EXISTS `medicine` (
  `MedCde` varchar(50) NOT NULL,
  `Type` varchar(50) NOT NULL,
  `Name` varchar(50) NOT NULL,
  `Stock` int(11) NOT NULL,
  `Sold` int(11) NOT NULL,
  `PurUntPrice` double NOT NULL,
  `SldUntPrice` double NOT NULL,
  `ThhVal` int(11) NOT NULL,
  `Discount` double NOT NULL,
  `NewStock` int(11) NOT NULL,
  `NewPurUntPrice` double NOT NULL,
  `LastPurDate` datetime DEFAULT NULL,
  `LastSldDate` datetime DEFAULT NULL,
  PRIMARY KEY (`Name`),
  UNIQUE KEY `MedCde` (`MedCde`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `medicine`
--

INSERT INTO `medicine` (`MedCde`, `Type`, `Name`, `Stock`, `Sold`, `PurUntPrice`, `SldUntPrice`, `ThhVal`, `Discount`, `NewStock`, `NewPurUntPrice`, `LastPurDate`, `LastSldDate`) VALUES
('IFN0005', 'Tab', 'augmented', 10, 78, 6.55, 12.55, 10, 10, 15, 8.55, '2016-11-22 00:00:00', '2016-11-22 00:00:00'),
('IFN0003', 'Cerup', 'Cola', 105, 55, 5.55, 10.55, 5, 10, 20, 12.55, '2016-11-22 00:00:00', '2016-11-22 00:00:00'),
('IFN0004', 'Cerup', 'Complex', 25, 18, 30, 50, 5, 10, 0, 0, '2016-07-07 00:00:00', '2016-06-20 00:00:00'),
('IFN0002', 'Tablet', 'Disparen', 26, 9, 5, 10, 5, 10, 0, 0, '2016-06-23 00:00:00', '2016-06-23 00:00:00'),
('IFN0007', 'Tablet', 'Loprene', 0, 0, 25, 30, 10, 10, 0, 0, NULL, NULL),
('IFN0001', 'Tablet', 'Panadol', 20, 15, 10, 15, 5, 10, 0, 0, '2016-05-15 00:00:00', '2016-06-20 00:00:00'),
('IFN0006', 'Tablet', 'Xavor', 0, 0, 40, 50, 10, 10, 0, 0, NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `purchase_bill`
--

CREATE TABLE IF NOT EXISTS `purchase_bill` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Bill` int(11) NOT NULL,
  `Date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=48 ;

--
-- Dumping data for table `purchase_bill`
--

INSERT INTO `purchase_bill` (`id`, `Bill`, `Date`) VALUES
(1, 75, '2016-05-08 00:00:00'),
(2, 150, '2016-05-08 00:00:00'),
(3, 0, '2016-05-08 00:00:00'),
(4, 0, '2016-05-08 00:00:00'),
(5, 0, '2016-05-08 00:00:00'),
(6, 0, '2016-05-08 00:00:00'),
(7, 0, '2016-05-08 00:00:00'),
(8, 0, '2016-05-08 00:00:00'),
(9, 75, '2016-05-08 00:00:00'),
(10, 300, '2016-05-08 00:00:00'),
(11, 100, '2016-05-15 00:00:00'),
(12, 75, '2016-05-15 00:00:00'),
(13, 75, '2016-05-15 00:00:00'),
(14, 50, '2016-05-15 00:00:00'),
(15, 100, '2016-05-15 00:00:00'),
(16, 25, '2016-05-21 00:00:00'),
(17, 25, '2016-05-21 00:00:00'),
(18, 25, '2016-05-21 00:00:00'),
(19, 50, '2016-05-21 00:00:00'),
(20, 25, '2016-05-22 00:00:00'),
(21, 25, '2016-05-22 00:00:00'),
(22, 600, '2016-05-22 00:00:00'),
(23, 50, '2016-06-17 00:00:00'),
(24, 50, '2016-06-17 00:00:00'),
(25, 60, '2016-06-17 00:00:00'),
(26, 200, '2016-06-17 00:00:00'),
(27, 100, '2016-06-17 00:00:00'),
(28, 180, '2016-06-19 00:00:00'),
(29, 300, '2016-06-20 00:00:00'),
(30, 300, '2016-06-20 00:00:00'),
(31, 60, '2016-06-20 00:00:00'),
(32, 60, '2016-06-23 00:00:00'),
(33, 530, '2016-07-07 00:00:00'),
(34, 90, '2016-08-10 00:00:00'),
(35, 45, '2016-08-10 00:00:00'),
(36, 30, '2016-08-12 00:00:00'),
(37, 40, '2016-08-12 00:00:00'),
(38, 30, '2016-08-12 00:00:00'),
(39, 40, '2016-08-12 00:00:00'),
(40, 40, '2016-08-12 00:00:00'),
(41, 11, '2016-08-12 00:00:00'),
(42, 22, '2016-08-12 00:00:00'),
(43, 82, '2016-11-22 00:00:00'),
(44, 43, '2016-11-22 00:00:00'),
(45, 56, '2016-11-22 00:00:00'),
(46, 28, '2016-11-22 00:00:00'),
(47, 33, '2016-11-22 00:00:00');

-- --------------------------------------------------------

--
-- Table structure for table `report`
--

CREATE TABLE IF NOT EXISTS `report` (
  `ReportID` bigint(100) NOT NULL AUTO_INCREMENT,
  `MedCde` varchar(50) NOT NULL,
  `Type` varchar(50) NOT NULL,
  `Name` varchar(50) NOT NULL,
  `Total_Sold_Quantity` int(20) NOT NULL,
  `Total_Purchased_Cost` double NOT NULL,
  `Total_Sold_Cost` double NOT NULL,
  `Sold_per_Unit_Price` double NOT NULL,
  `Purchased_Per_Unit_Price` double NOT NULL,
  `Discount` varchar(11) NOT NULL,
  `Profit` double NOT NULL,
  PRIMARY KEY (`ReportID`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=62 ;

-- --------------------------------------------------------

--
-- Table structure for table `sold_bill`
--

CREATE TABLE IF NOT EXISTS `sold_bill` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Bill` int(11) NOT NULL,
  `Date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=68 ;

--
-- Dumping data for table `sold_bill`
--

INSERT INTO `sold_bill` (`id`, `Bill`, `Date`) VALUES
(1, 300, '2016-05-06 00:00:00'),
(2, 325, '2016-05-06 00:00:00'),
(3, 300, '2016-05-06 00:00:00'),
(4, 125, '2016-05-06 00:00:00'),
(5, 50, '2016-05-06 00:00:00'),
(6, 125, '2016-05-06 00:00:00'),
(7, 195, '2016-05-06 00:00:00'),
(8, 130, '2016-05-06 00:00:00'),
(9, 130, '2016-05-06 00:00:00'),
(10, 130, '2016-05-06 00:00:00'),
(11, 125, '2016-05-07 00:00:00'),
(12, 125, '2016-05-07 00:00:00'),
(13, 125, '2016-05-07 00:00:00'),
(14, 150, '2016-05-07 00:00:00'),
(15, 50, '2016-05-07 00:00:00'),
(16, 375, '2016-05-07 00:00:00'),
(17, 0, '2016-05-07 00:00:00'),
(18, 50, '2016-05-07 00:00:00'),
(19, 250, '2016-05-07 00:00:00'),
(20, 250, '2016-05-07 00:00:00'),
(21, 250, '2016-05-08 00:00:00'),
(22, 175, '2016-05-08 00:00:00'),
(23, 125, '2016-05-08 00:00:00'),
(24, 250, '2016-05-08 00:00:00'),
(25, 0, '2016-05-08 00:00:00'),
(26, 125, '2016-05-08 00:00:00'),
(27, 125, '2016-05-08 00:00:00'),
(28, 300, '2016-05-08 00:00:00'),
(29, 75, '2016-05-15 00:00:00'),
(30, 100, '2016-05-15 00:00:00'),
(31, 50, '2016-05-16 00:00:00'),
(32, 50, '2016-05-22 00:00:00'),
(33, 300, '2016-05-22 00:00:00'),
(34, 550, '2016-05-22 00:00:00'),
(35, 300, '2016-05-22 00:00:00'),
(36, 500, '2016-05-22 00:00:00'),
(37, 500, '2016-05-22 00:00:00'),
(38, 400, '2016-05-22 00:00:00'),
(39, 500, '2016-05-22 00:00:00'),
(40, 250, '2016-05-22 00:00:00'),
(41, 150, '2016-05-22 00:00:00'),
(42, 200, '2016-06-17 00:00:00'),
(43, 100, '2016-06-17 00:00:00'),
(44, 50, '2016-06-17 00:00:00'),
(45, 200, '2016-06-17 00:00:00'),
(46, 100, '2016-06-17 00:00:00'),
(47, 300, '2016-06-20 00:00:00'),
(48, 45, '2016-06-20 00:00:00'),
(49, 90, '2016-06-23 00:00:00'),
(50, 150, '2016-07-07 00:00:00'),
(51, 360, '2016-07-07 00:00:00'),
(52, 150, '2016-07-07 00:00:00'),
(53, 108, '2016-08-10 00:00:00'),
(54, 54, '2016-08-10 00:00:00'),
(55, 180, '2016-08-10 00:00:00'),
(56, 30, '2016-08-12 00:00:00'),
(57, 30, '2016-08-12 00:00:00'),
(58, 30, '2016-08-12 00:00:00'),
(59, 80, '2016-08-12 00:00:00'),
(60, 33, '2016-08-12 00:00:00'),
(61, 54, '2016-08-12 00:00:00'),
(62, 11, '2016-08-12 00:00:00'),
(63, 22, '2016-08-12 00:00:00'),
(64, 158, '2016-11-22 00:00:00'),
(65, 104, '2016-11-22 00:00:00'),
(66, 95, '2016-11-22 00:00:00'),
(67, 246, '2016-11-22 00:00:00');

-- --------------------------------------------------------

--
-- Table structure for table `stock`
--

CREATE TABLE IF NOT EXISTS `stock` (
  `Name` varchar(50) NOT NULL,
  `Quantity` int(11) NOT NULL,
  `Individual_Price` double NOT NULL,
  `Total_Price` double NOT NULL,
  `Stock_Type` varchar(11) NOT NULL,
  `IsReturn` varchar(10) NOT NULL,
  PRIMARY KEY (`Name`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
