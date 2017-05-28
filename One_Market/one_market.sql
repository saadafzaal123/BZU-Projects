-- phpMyAdmin SQL Dump
-- version 4.1.14
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Apr 30, 2017 at 08:10 PM
-- Server version: 5.6.17
-- PHP Version: 5.5.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `one_market`
--

-- --------------------------------------------------------

--
-- Table structure for table `admin_logins`
--

CREATE TABLE IF NOT EXISTS `admin_logins` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `username` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `password` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `email` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci AUTO_INCREMENT=3 ;

--
-- Dumping data for table `admin_logins`
--

INSERT INTO `admin_logins` (`id`, `username`, `password`, `email`, `created_at`, `updated_at`) VALUES
(1, 'Amjad Afzaal', '123', 'amjad.afzaal@gmail.com', NULL, NULL),
(2, 'Saad Afzaal', '$2y$10$yj8o3XYdb/V4W6Q4WewCouGlHWCX8Mu4sLK7Hu5upTPfCT0SVlscK', 'saad.afzaal777@gmail.com', NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `brands`
--

CREATE TABLE IF NOT EXISTS `brands` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci AUTO_INCREMENT=7 ;

--
-- Dumping data for table `brands`
--

INSERT INTO `brands` (`id`, `name`, `created_at`, `updated_at`) VALUES
(1, 'HP', '2016-07-31 10:03:15', '2016-07-31 10:03:15'),
(2, 'Sony', '2016-07-31 10:03:48', '2016-07-31 10:03:48'),
(4, 'Nokia', '2016-07-31 13:37:58', '2016-07-31 13:37:58'),
(5, 'Q-Mobile', '2016-08-06 14:33:58', '2016-08-06 14:33:58'),
(6, 'SamSung', '2016-08-17 13:23:11', '2016-08-17 13:23:11');

-- --------------------------------------------------------

--
-- Table structure for table `carts`
--

CREATE TABLE IF NOT EXISTS `carts` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `p_id` int(11) NOT NULL,
  `customer_id` int(11) NOT NULL,
  `quantity` int(11) NOT NULL,
  `price` int(11) NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `categories`
--

CREATE TABLE IF NOT EXISTS `categories` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci AUTO_INCREMENT=6 ;

--
-- Dumping data for table `categories`
--

INSERT INTO `categories` (`id`, `name`, `created_at`, `updated_at`) VALUES
(1, 'Computers', '2016-07-31 09:56:31', '2016-07-31 09:56:31'),
(2, 'Camera', '2016-07-31 09:57:20', '2016-07-31 09:57:20'),
(4, 'Laptops', '2016-07-31 13:36:54', '2016-07-31 13:36:54'),
(5, 'Mobiles', '2016-08-06 14:33:29', '2016-08-06 14:33:29');

-- --------------------------------------------------------

--
-- Table structure for table `cities`
--

CREATE TABLE IF NOT EXISTS `cities` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `image1` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `image2` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `image3` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `description` longtext COLLATE utf8_unicode_ci NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci AUTO_INCREMENT=14 ;

--
-- Dumping data for table `cities`
--

INSERT INTO `cities` (`id`, `name`, `image1`, `image2`, `image3`, `description`, `created_at`, `updated_at`) VALUES
(10, 'Lahore', '88007.jpg', '66558.jpg', '99438.jpg', 'Lahore is the capital city of the province of Punjab, the second-largest metropolitan area in Pakistan and with a population of 10,052,000 people, it is the 15th-most-populous city in the world.', '2016-08-01 15:01:46', '2016-08-01 15:01:46'),
(11, 'Karachi', '59781.jpg', '52492.jpg', '23274.jpg', 'Karachi is the largest and most populous city in Pakistan and 7th most populous urban city in the world.', '2016-08-01 15:06:42', '2016-08-01 15:06:42'),
(12, 'Islamabad', '75990.jpg', '42800.jpg', '95971.jpg', 'Islamabad is the capital and beautiful city of Pakistan.', '2016-08-01 15:09:25', '2016-08-01 15:09:25'),
(13, 'Multan', '62695.jpeg', '56165.jpg', '76405.jpg', 'Multan is the city in south panjab has an area of 133 kilometer square.', '2016-08-01 15:13:59', '2016-08-01 15:13:59');

-- --------------------------------------------------------

--
-- Table structure for table `customers`
--

CREATE TABLE IF NOT EXISTS `customers` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `username` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `password` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `email` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `creditcartNo` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `phoneNo` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `home_address` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `image` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci AUTO_INCREMENT=4 ;

--
-- Dumping data for table `customers`
--

INSERT INTO `customers` (`id`, `username`, `password`, `email`, `creditcartNo`, `phoneNo`, `home_address`, `image`, `created_at`, `updated_at`) VALUES
(1, 'Saad Afzaal', 'eyJpdiI6IlJSS0Y2VDQwalMrQk1Xc0dPQjJEVFE9PSIsInZhbHVlIjoiS05tcHlZYzB1RThkb2dmbDRGdVwvUUE9PSIsIm1hYyI6Ijk1N2QzYTdiZmZhMzM1NDAxZDk3NGM0YTAyMzA0ZjBjY2RlNjJkMDcwY2Q4YmY1OThjZTg1MGQzMGU3NWUzOGMifQ==', 'saad.afzaal777@gmail.com', '425591HGUKL087', '03234521048', 'H.# 2 st # 20 amir town harbanspura lahore ', '21530.jpg', '2016-08-24 15:06:29', '2016-08-25 08:10:10'),
(3, 'Zawar Shahid', 'eyJpdiI6ImxIWDR0NlhqRlwvVUdVVFUxVFlIOFBRPT0iLCJ2YWx1ZSI6IkVqVitHQWlZd0NZbDFEb296VEZuT1E9PSIsIm1hYyI6ImFjZmU3NDQ3YTY0YzY0MmMyYjBmMzc1N2Q5YjY4ZGUxMTYzNjI5NGM4MWIwNGUzMzE3MDE3MjgzNWVmOWRhNGMifQ==', 'zawars245@gmail.com', '444744TRST365', '03244663758', 'H.# 8 st # 6 Faiz Bhag near UET Lahore ', '19745.jpg', '2016-08-25 09:22:43', '2016-08-25 09:22:43');

-- --------------------------------------------------------

--
-- Table structure for table `markets`
--

CREATE TABLE IF NOT EXISTS `markets` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `city_id` int(11) NOT NULL,
  `image1` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `image2` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `image3` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `area` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `description` longtext COLLATE utf8_unicode_ci NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci AUTO_INCREMENT=13 ;

--
-- Dumping data for table `markets`
--

INSERT INTO `markets` (`id`, `name`, `city_id`, `image1`, `image2`, `image3`, `area`, `description`, `created_at`, `updated_at`) VALUES
(5, 'HyperStar', 10, '14922.jpg', '30864.jpg', '17195.jpg', 'Lahore Fottress Stadiyam', '<p>Hyperstar located in Lahore Fottress Stadiyam Lahore cantt.</p>', '2016-08-02 05:02:02', '2016-08-02 05:02:02'),
(6, 'Khadda Market', 11, '54725.jpg', '45787.jpg', '59016.jpg', 'Tariq Road Defense Clifton', '<p>Tariq Road Defense Clifton</p>', '2016-08-02 05:10:32', '2016-08-02 05:10:32'),
(7, 'Jinah Super Market', 12, '71888.jpg', '95730.jpg', '98640.jpg', 'College Rd, Islamabad', '<p>One of the oldest and best markets of Islamabad where you can find almost everything.</p>', '2016-08-02 05:17:37', '2016-08-02 10:47:25'),
(8, 'Hafeez Center', 10, '34559.jpg', '61580.jpg', '72140.jpg', 'Ghalib Road Gulberg', 'Hafeez center lahore pakistan, buy, sell, gadgets, Iphone 5s gold factory unlock complete box in very good condition.', '2016-08-06 10:01:08', '2016-08-06 10:01:08'),
(9, 'Kohsar Market', 12, '52107.jpg', '22954.jpg', '49432.jpg', 'Street 10, Islamabad 44000', 'One of the ''posh'' places and home to some really good restaurants. But if you''re hungry just grab a cup of coffee and enjoy the calm.', '2016-08-06 10:11:27', '2016-08-06 10:11:27'),
(10, 'Bara Mobile', 11, '13281.jpg', '58921.jpg', '32372.jpg', 'Shahrah-e-Usman, Sector 5C-2, North Karachi, Karachi, Sindh', '<p>It''s a Mobile Market.. also knows as 5C/4, Bus Stop</p>', '2016-08-06 10:19:01', '2016-08-06 10:21:58'),
(11, 'Timber Market', 13, '76038.jpg', '45344.jpg', '70543.jpg', 'Multan', 'You will get great furniture here', '2016-08-06 10:28:42', '2016-08-06 10:28:42'),
(12, 'Hussain Agahi', 13, '15738.jpg', '68475.JPG', '26540.jpg', 'Multan', 'One of old bazar of multan. All types of living accessories are available. Like house hold, electronics, dresses , food item also available.', '2016-08-06 10:36:07', '2016-08-06 10:36:07');

-- --------------------------------------------------------

--
-- Table structure for table `migrations`
--

CREATE TABLE IF NOT EXISTS `migrations` (
  `migration` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `batch` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `migrations`
--

INSERT INTO `migrations` (`migration`, `batch`) VALUES
('2014_10_12_000000_create_users_table', 1),
('2014_10_12_100000_create_password_resets_table', 1),
('2016_05_19_050856_login', 1),
('2016_05_19_052209_create_zawar', 1),
('2016_05_19_052553_create_admin_table', 1),
('2016_07_31_135730_product_table_migration', 2),
('2016_07_31_135958_category_table_migration', 2),
('2016_07_31_140127_brand_table_migration', 2),
('2016_07_31_183159_update_category', 3),
('2016_07_31_183234_update_product', 3),
('2016_07_31_183254_update_brand', 3),
('2016_07_31_190354_admin_login_table_migration', 4),
('2016_07_31_191117_city_table_migration', 5),
('2016_07_31_191151_market_table_migration', 5),
('2016_08_01_171005_update_brand1', 6),
('2016_08_01_171110_update_product1', 7),
('2016_08_01_174934_update_category1', 8),
('2016_08_02_120958_shop_table_migration', 9),
('2016_08_02_145816_update_shop', 10),
('2016_08_03_154041_rent_table_migration', 10),
('2016_08_03_160736_update_rent', 11),
('2016_08_03_165925_update_rent1', 12),
('2016_08_04_181440_customer_table_migration', 13),
('2016_08_04_181509_order_table_migration', 13),
('2016_08_04_181532_payment_table_migration', 13),
('2016_08_05_122001_users_table_updated', 14),
('2016_08_15_213915_update_admin_login', 14),
('2016_08_19_172409_update_user', 15),
('2016_08_25_145313_cart_table_migration', 16),
('2016_08_30_121403_update_customer', 17),
('2016_08_31_174751_update_order', 18);

-- --------------------------------------------------------

--
-- Table structure for table `orders`
--

CREATE TABLE IF NOT EXISTS `orders` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `product_id` int(11) NOT NULL,
  `customer_id` int(11) NOT NULL,
  `quantity` int(11) NOT NULL,
  `amount` int(11) NOT NULL,
  `order_date` datetime NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci AUTO_INCREMENT=19 ;

--
-- Dumping data for table `orders`
--

INSERT INTO `orders` (`id`, `product_id`, `customer_id`, `quantity`, `amount`, `order_date`, `created_at`, `updated_at`) VALUES
(7, 5, 3, 2, 40000, '2016-08-30 17:11:34', '2016-08-30 12:11:34', '2016-08-30 12:11:34'),
(8, 8, 3, 1, 28000, '2016-08-30 17:11:34', '2016-08-30 12:11:34', '2016-08-30 12:11:34'),
(9, 4, 3, 2, 30000, '2016-08-31 12:11:32', '2016-08-31 07:11:32', '2016-08-31 07:11:32'),
(10, 5, 3, 1, 20000, '2016-08-31 12:11:32', '2016-08-31 07:11:32', '2016-08-31 07:11:32'),
(11, 4, 1, 2, 30000, '2016-08-31 19:46:55', '2016-08-31 14:46:55', '2016-08-31 14:46:55'),
(12, 5, 1, 2, 40000, '2016-08-31 19:46:55', '2016-08-31 14:46:55', '2016-08-31 14:46:55'),
(13, 6, 1, 2, 50000, '2016-08-31 19:46:55', '2016-08-31 14:46:55', '2016-08-31 14:46:55'),
(14, 8, 1, 2, 56000, '2016-08-31 19:46:55', '2016-08-31 14:46:55', '2016-08-31 14:46:55'),
(15, 7, 1, 2, 38000, '2016-08-31 19:46:55', '2016-08-31 14:46:55', '2016-08-31 14:46:55'),
(16, 6, 1, 1, 25000, '2016-08-31 19:57:20', '2016-08-31 14:57:20', '2016-08-31 14:57:20'),
(17, 8, 1, 1, 28000, '2016-08-31 19:57:20', '2016-08-31 14:57:20', '2016-08-31 14:57:20'),
(18, 5, 1, 2, 40000, '2016-09-03 10:53:32', '2016-09-03 05:53:32', '2016-09-03 05:53:32');

-- --------------------------------------------------------

--
-- Table structure for table `password_resets`
--

CREATE TABLE IF NOT EXISTS `password_resets` (
  `email` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `token` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `created_at` timestamp NOT NULL,
  KEY `password_resets_email_index` (`email`),
  KEY `password_resets_token_index` (`token`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `payments`
--

CREATE TABLE IF NOT EXISTS `payments` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `customer_id` int(11) NOT NULL,
  `product_id` int(11) NOT NULL,
  `amount` int(11) NOT NULL,
  `trx_id` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `currency` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `payment_date` datetime NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci AUTO_INCREMENT=12 ;

--
-- Dumping data for table `payments`
--

INSERT INTO `payments` (`id`, `customer_id`, `product_id`, `amount`, `trx_id`, `currency`, `payment_date`, `created_at`, `updated_at`) VALUES
(1, 3, 4, 30000, '1143362711', 'USD', '2016-08-31 12:11:32', '2016-08-31 07:11:32', '2016-08-31 07:11:32'),
(2, 3, 5, 20000, '1198537832', 'USD', '2016-08-31 12:11:32', '2016-08-31 07:11:33', '2016-08-31 07:11:33'),
(4, 1, 4, 30000, '1260508166', 'USD', '2016-08-31 19:46:55', '2016-08-31 14:46:55', '2016-08-31 14:46:55'),
(5, 1, 5, 40000, '1402732084', 'USD', '2016-08-31 19:46:55', '2016-08-31 14:46:55', '2016-08-31 14:46:55'),
(6, 1, 6, 50000, '1136842811', 'USD', '2016-08-31 19:46:55', '2016-08-31 14:46:55', '2016-08-31 14:46:55'),
(7, 1, 8, 56000, '1109374135', 'USD', '2016-08-31 19:46:55', '2016-08-31 14:46:55', '2016-08-31 14:46:55'),
(8, 1, 7, 38000, '1158742666', 'USD', '2016-08-31 19:46:55', '2016-08-31 14:46:55', '2016-08-31 14:46:55'),
(9, 1, 6, 25000, '1272584372', 'USD', '2016-08-31 19:57:20', '2016-08-31 14:57:20', '2016-08-31 14:57:20'),
(10, 1, 8, 28000, '1097998724', 'USD', '2016-08-31 19:57:20', '2016-08-31 14:57:20', '2016-08-31 14:57:20'),
(11, 1, 5, 40000, '1294396628', 'USD', '2016-09-03 10:53:32', '2016-09-03 05:53:32', '2016-09-03 05:53:32');

-- --------------------------------------------------------

--
-- Table structure for table `products`
--

CREATE TABLE IF NOT EXISTS `products` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `vendor_id` int(11) NOT NULL,
  `cat_id` int(11) NOT NULL,
  `brand_id` int(11) NOT NULL,
  `image1` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `image2` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `image3` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `price` double NOT NULL,
  `description` longtext COLLATE utf8_unicode_ci NOT NULL,
  `keywords` text COLLATE utf8_unicode_ci NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci AUTO_INCREMENT=9 ;

--
-- Dumping data for table `products`
--

INSERT INTO `products` (`id`, `name`, `vendor_id`, `cat_id`, `brand_id`, `image1`, `image2`, `image3`, `price`, `description`, `keywords`, `created_at`, `updated_at`) VALUES
(4, 'HP Computer Core i5', 1, 1, 1, '70312.jpg', '97550.jpg', '20654.jpg', 15000, '<p>Fast and High qualities Computers...</p>', 'HP Computer Core i5', '2016-08-02 05:43:22', '2016-09-02 13:13:00'),
(5, 'Sony Video Camera', 1, 2, 2, '21755.jpg', '65964.jpg', '83295.jpg', 20000, '<p>An innovative Product of Sony...</p>', 'Sony Video Camera', '2016-08-02 06:15:43', '2016-08-02 06:33:57'),
(6, 'HP Laptop core i7', 1, 4, 1, '75130.jpg', '22680.jpg', '59846.jpg', 25000, '<p>Very high qualities fast laptops with variety of functionality.</p>', 'HP Laptop core i7', '2016-08-02 06:20:42', '2016-08-02 06:20:42'),
(7, 'Q-Mobile E950', 1, 5, 5, '53794.jpg', '31868.jpg', '79375.jpg', 19000, '<p>A very highly good product with low price.</p>', 'Q-Mobile E950', '2016-08-06 14:37:02', '2016-09-02 13:15:40'),
(8, 'SamSung Galaxcy S5', 1, 5, 6, '65869.jpg', '43779.jpg', '23545.jpg', 28000, '<p>A very good and Handsome Mobile of Samsung with dual sims also have very good functionalities.</p>', 'SamSung Galaxcy S5', '2016-08-17 14:26:53', '2016-08-17 15:12:35');

-- --------------------------------------------------------

--
-- Table structure for table `rents`
--

CREATE TABLE IF NOT EXISTS `rents` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Vendor_Name` int(11) NOT NULL,
  `Shop_Name` int(11) NOT NULL,
  `Shop_Rent` int(11) NOT NULL,
  `Paid_Date` datetime NOT NULL,
  `IsPaid` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci AUTO_INCREMENT=5 ;

--
-- Dumping data for table `rents`
--

INSERT INTO `rents` (`id`, `Vendor_Name`, `Shop_Name`, `Shop_Rent`, `Paid_Date`, `IsPaid`, `created_at`, `updated_at`) VALUES
(1, 1, 1, 500, '2016-08-03 08:59:00', 'Yes', NULL, NULL),
(2, 2, 2, 500, '2016-08-03 08:59:00', 'Yes', NULL, NULL),
(3, 3, 3, 500, '2016-08-03 08:59:00', 'Yes', NULL, NULL),
(4, 1, 1, 500, '2016-08-19 11:06:43', 'Yes', '2016-08-19 06:06:43', '2016-08-19 06:06:43');

-- --------------------------------------------------------

--
-- Table structure for table `shops`
--

CREATE TABLE IF NOT EXISTS `shops` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `username` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `password` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `email` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `phoneNo` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `address` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `creditcartNo` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `shop_name` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `market_id` int(11) NOT NULL,
  `shop_image` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci AUTO_INCREMENT=5 ;

--
-- Dumping data for table `shops`
--

INSERT INTO `shops` (`id`, `username`, `password`, `email`, `phoneNo`, `address`, `creditcartNo`, `shop_name`, `market_id`, `shop_image`, `created_at`, `updated_at`) VALUES
(1, 'Saad Afzaal', 'eyJpdiI6InVtZng3cmJQeHNDZFdHamJqN0ptOGc9PSIsInZhbHVlIjoiZTd3N2FjUmlQc0JkSVNXcjR4UkFDUT09IiwibWFjIjoiOTllMTM4ZThlYTU1Y2U4ZTY4ZmMzZWI3NzU1Mzk3MzdiYzg5NjJjYTI0YzJjZDYyOTE3OTE1OTQ0MTYzYTQ2ZCJ9', 'saad.afzaal777@gmail.com', '03234521048', 'H.# 2 st # 20 amir town harbanspura lahore ', '98745678bvcx7', 'Croma Electronics', 5, '53358.jpg', '2016-08-02 10:32:30', '2016-08-24 10:59:18'),
(2, 'Amjad Afzaal', 'eyJpdiI6IkhidWdJY0JUZjlvXC9rVjJjQ001akh3PT0iLCJ2YWx1ZSI6IndLSXVxRjF3RFdUV0ZkTVJkQk1HVWc9PSIsIm1hYyI6ImQ3NGU2MzUxZDJmZTA5YzY2ZTYzZDQzMzExZTIwMmE4YTgyNTE5ZDQ3MmM4MTY2ZmQ0ZTQxNWViNTliOTE2NGIifQ==', 'amjad.afzaal@gmail.com', '03224307843', 'H.# 2 st # 20 amir town harbanspura lahore ', '98745678nb9hc', 'Amjad Electronics', 7, '65386.jpg', '2016-08-02 10:59:36', '2016-08-02 10:59:36'),
(3, 'Usama Shahid', 'eyJpdiI6IkhidWdJY0JUZjlvXC9rVjJjQ001akh3PT0iLCJ2YWx1ZSI6IndLSXVxRjF3RFdUV0ZkTVJkQk1HVWc9PSIsIm1hYyI6ImQ3NGU2MzUxZDJmZTA5YzY2ZTYzZDQzMzExZTIwMmE4YTgyNTE5ZDQ3MmM4MTY2ZmQ0ZTQxNWViNTliOTE2NGIifQ==', 'usama.shahid@gmail.com', '03456789234', 'H.# 2 st # 20 aziz town mughalpura lahore ', '345678uijd45', 'Usama Comet', 6, '38370.jpg', '2016-08-02 11:10:13', '2016-08-02 14:25:49'),
(4, 'Bilal Shah', 'eyJpdiI6IkhidWdJY0JUZjlvXC9rVjJjQ001akh3PT0iLCJ2YWx1ZSI6IndLSXVxRjF3RFdUV0ZkTVJkQk1HVWc9PSIsIm1hYyI6ImQ3NGU2MzUxZDJmZTA5YzY2ZTYzZDQzMzExZTIwMmE4YTgyNTE5ZDQ3MmM4MTY2ZmQ0ZTQxNWViNTliOTE2NGIifQ==', 'bilal.shah@gmail.com', '03334478044', 'H.# 12 st # 5 bhagwanpura uet lahore ', '587858kg87uj', 'Bilal Inventory', 5, '89518.JPG', '2016-08-17 10:54:32', '2016-08-19 05:46:50');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE IF NOT EXISTS `users` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `email` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `password` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `cypher_password` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `remember_token` varchar(100) COLLATE utf8_unicode_ci DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `users_email_unique` (`email`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci AUTO_INCREMENT=2 ;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `name`, `email`, `password`, `cypher_password`, `remember_token`, `created_at`, `updated_at`) VALUES
(1, 'Saad Afzaal', 'saad.afzaal777@gmail.com', '$2y$10$s9EhCjXWWA1SEml/7Mlo/uGLe/PEpxUwchGX0JoIu4KOpxyczuvSS', 'eyJpdiI6IkozUUtcL0Q1bHdWY3FzTkdXbWJYbHNRPT0iLCJ2YWx1ZSI6Ikt2dUZjc2ZMT2pSOElGMW1oQ2VyM3c9PSIsIm1hYyI6IjFhZjA1YTc4ZjNmYWZiY2UwMjRiZjIwMmQxMmI4YTI2MWIzMDNlODNlMTRkMTZmM2FkNzRmMzZjMzY2N2U5MzIifQ==', 'XEYznZlMyEgqgxr1QTakkJ76MwYAkDsqRyq6cAqhyBK5msWE9MKEH2SPpDOE', '2016-08-15 10:35:56', '2017-04-03 11:29:20');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
