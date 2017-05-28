-- phpMyAdmin SQL Dump
-- version 4.1.14
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: May 28, 2017 at 01:51 PM
-- Server version: 5.6.17
-- PHP Version: 5.5.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `myshop`
--

-- --------------------------------------------------------

--
-- Table structure for table `admin_login`
--

CREATE TABLE IF NOT EXISTS `admin_login` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) NOT NULL,
  `Password` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=2 ;

--
-- Dumping data for table `admin_login`
--

INSERT INTO `admin_login` (`id`, `Name`, `Password`) VALUES
(1, 'Saad Afzaal', '46713413b6e5001c97c1f66288c7b885');

-- --------------------------------------------------------

--
-- Table structure for table `brands`
--

CREATE TABLE IF NOT EXISTS `brands` (
  `brand_id` int(11) NOT NULL AUTO_INCREMENT,
  `brand_title` text NOT NULL,
  PRIMARY KEY (`brand_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=9 ;

--
-- Dumping data for table `brands`
--

INSERT INTO `brands` (`brand_id`, `brand_title`) VALUES
(1, 'Nokia'),
(2, 'HP'),
(3, 'Q-Mobile'),
(4, 'SamSung'),
(6, 'Motorolla'),
(7, 'Sony'),
(8, 'Dell');

-- --------------------------------------------------------

--
-- Table structure for table `cart`
--

CREATE TABLE IF NOT EXISTS `cart` (
  `S.No` int(11) NOT NULL AUTO_INCREMENT,
  `p_id` int(11) NOT NULL,
  `ip_address` varchar(50) NOT NULL,
  `quantity` int(11) NOT NULL,
  `price` int(10) NOT NULL,
  PRIMARY KEY (`S.No`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=7 ;

--
-- Dumping data for table `cart`
--

INSERT INTO `cart` (`S.No`, `p_id`, `ip_address`, `quantity`, `price`) VALUES
(4, 10, '::1', 1, 300),
(5, 7, '::1', 1, 1000),
(6, 8, '::1', 1, 800);

-- --------------------------------------------------------

--
-- Table structure for table `categories`
--

CREATE TABLE IF NOT EXISTS `categories` (
  `cat_id` int(11) NOT NULL AUTO_INCREMENT,
  `cat_title` text NOT NULL,
  PRIMARY KEY (`cat_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=11 ;

--
-- Dumping data for table `categories`
--

INSERT INTO `categories` (`cat_id`, `cat_title`) VALUES
(1, 'Computers'),
(2, 'Laptops'),
(3, 'Mobiles'),
(4, 'Cameras'),
(6, 'Led_TV'),
(10, 'Tablets');

-- --------------------------------------------------------

--
-- Table structure for table `customers`
--

CREATE TABLE IF NOT EXISTS `customers` (
  `customer_id` int(11) NOT NULL AUTO_INCREMENT,
  `customer_ip` varchar(50) NOT NULL,
  `customer_name` varchar(50) NOT NULL,
  `customer_email` varchar(50) NOT NULL,
  `customer_password` varchar(50) NOT NULL,
  `customer_country` varchar(50) NOT NULL,
  `customer_city` varchar(50) NOT NULL,
  `customer_image` text NOT NULL,
  PRIMARY KEY (`customer_email`),
  UNIQUE KEY `customer_id` (`customer_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=4 ;

--
-- Dumping data for table `customers`
--

INSERT INTO `customers` (`customer_id`, `customer_ip`, `customer_name`, `customer_email`, `customer_password`, `customer_country`, `customer_city`, `customer_image`) VALUES
(1, '::1', 'Saad Afzaal', 'saad.afzaal777@gmail.com', '46713413b6e5001c97c1f66288c7b885', 'Pakistan', 'Lahore', '365.JPG'),
(3, '::1', 'Saad Afzaal', 'saad.afzaal777@yahoo.com', '46713413b6e5001c97c1f66288c7b885', 'Pakistan', 'Lahore', '365.JPG');

-- --------------------------------------------------------

--
-- Table structure for table `orders`
--

CREATE TABLE IF NOT EXISTS `orders` (
  `order_id` int(11) NOT NULL AUTO_INCREMENT,
  `p_id` int(11) NOT NULL,
  `c_id` int(11) NOT NULL,
  `quantity` int(50) NOT NULL,
  `order_date` timestamp NOT NULL,
  PRIMARY KEY (`order_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=20 ;

--
-- Dumping data for table `orders`
--

INSERT INTO `orders` (`order_id`, `p_id`, `c_id`, `quantity`, `order_date`) VALUES
(9, 8, 1, 1, '2016-02-10 21:46:44'),
(10, 9, 1, 1, '2016-02-10 21:46:44'),
(12, 12, 1, 2, '2016-02-10 22:25:00'),
(13, 6, 1, 1, '2016-02-22 19:29:25'),
(14, 9, 1, 1, '2016-02-22 19:29:25'),
(15, 10, 1, 1, '2016-02-22 19:29:25'),
(16, 10, 1, 1, '2016-02-23 18:58:51'),
(17, 12, 1, 1, '2016-02-23 18:58:52'),
(18, 7, 1, 1, '2016-02-23 18:58:52'),
(19, 6, 1, 1, '2016-02-23 18:58:52');

-- --------------------------------------------------------

--
-- Table structure for table `payments`
--

CREATE TABLE IF NOT EXISTS `payments` (
  `payment_id` int(11) NOT NULL AUTO_INCREMENT,
  `amount` int(50) NOT NULL,
  `customer_id` int(11) NOT NULL,
  `product_id` int(11) NOT NULL,
  `trx_id` varchar(250) NOT NULL,
  `currency` text NOT NULL,
  `payment_date` date NOT NULL,
  PRIMARY KEY (`payment_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=20 ;

--
-- Dumping data for table `payments`
--

INSERT INTO `payments` (`payment_id`, `amount`, `customer_id`, `product_id`, `trx_id`, `currency`, `payment_date`) VALUES
(13, 500, 1, 6, '1188764239', ' USD', '2016-02-22'),
(14, 200, 1, 9, '1188764239', ' USD', '2016-02-22'),
(15, 300, 1, 10, '1188764239', ' USD', '2016-02-22'),
(16, 300, 1, 10, '1149632326', ' USD', '2016-02-23'),
(17, 200, 1, 12, '1149632326', ' USD', '2016-02-23'),
(18, 1000, 1, 7, '1149632326', ' USD', '2016-02-23'),
(19, 500, 1, 6, '1149632326', ' USD', '2016-02-23');

-- --------------------------------------------------------

--
-- Table structure for table `products`
--

CREATE TABLE IF NOT EXISTS `products` (
  `product_id` int(11) NOT NULL AUTO_INCREMENT,
  `cat_id` int(11) NOT NULL,
  `brand_id` int(11) NOT NULL,
  `date` timestamp NOT NULL,
  `product_title` text NOT NULL,
  `product_img1` text NOT NULL,
  `product_img2` text NOT NULL,
  `product_img3` text NOT NULL,
  `product_price` int(10) NOT NULL,
  `product_description` text NOT NULL,
  `product_keywords` text NOT NULL,
  `status` text NOT NULL,
  PRIMARY KEY (`product_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=13 ;

--
-- Dumping data for table `products`
--

INSERT INTO `products` (`product_id`, `cat_id`, `brand_id`, `date`, `product_title`, `product_img1`, `product_img2`, `product_img3`, `product_price`, `product_description`, `product_keywords`, `status`) VALUES
(6, 2, 2, '2016-01-25 21:21:57', 'HP Pro Book Laptop ', 'images.jpg', 'images 2.jpg', 'images 1.jpg', 500, 'This is very Beautiful Laptop which I like most', 'HP Laptop', 'on'),
(7, 4, 7, '2016-01-25 21:22:44', 'Video Camera By Sony', 'Video Camera.jpg', 'Video Camera 1.jpg', 'Video Camera 2.jpg', 1000, 'Video Cameras with very high qualities.', 'Sony Video Camera ', 'on'),
(8, 4, 4, '2016-01-25 21:22:59', 'SamSung Camera', 'Samsung Camera.jpg', 'Samsung Camera 1.jpg', 'Samsung Camera 2.jpg', 800, 'Samsung Digital Camera on low Price are available.', 'SamSung Camera', 'on'),
(9, 3, 3, '2016-01-25 21:23:12', 'Q-Mobile E-950', 'Q-Mobile.jpg', 'Q-Mobile 1.jpg', 'Q-Mobile 2.jpg', 200, 'Q-Mobile very popular Smart Mobile.I like it very much. ', 'Q-Mobile E-950', 'on'),
(10, 3, 4, '2016-01-25 21:23:22', 'SamSung Galaxy S4', 'SamSung Glaxy s4.jpg', 'SamSung Glaxy s4 1.jpg', 'SamSung Glaxy s4 2.jpg', 300, 'SamSung Galaxy S4 a very handsome and smart mobile phone. ', 'SamSung Galaxy S4', 'on'),
(11, 6, 4, '2016-01-25 21:23:35', 'SamSung Led_TV', 'Samsung Led-Tv.jpg', 'Samsung Led-Tv 1.jpg', 'Samsung Led-Tv 2.jpg', 600, 'SamSung Led_TV now available is on our website.', 'SamSung Led_TV', 'on'),
(12, 1, 2, '2016-01-29 22:28:09', 'HP Core-i5', 'HP-Core-i5.jpg', 'HP-Core-i5 1.jpg', 'HP-Core-i5 2.jpg', 200, '<p>This is very nice and branded Computer at very low price.</p>', 'HP Core-i5', 'on');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
