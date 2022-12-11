-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Dec 11, 2022 at 07:35 PM
-- Server version: 10.4.25-MariaDB
-- PHP Version: 8.1.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `monsterdatabase`
--

-- --------------------------------------------------------

--
-- Table structure for table `abilities`
--

CREATE TABLE `abilities` (
  `ID` int(11) NOT NULL,
  `Name` varchar(32) NOT NULL,
  `AbilityRange` int(11) NOT NULL,
  `Special` text NOT NULL,
  `HitModifier` int(11) DEFAULT NULL,
  `DamageModifier` int(11) DEFAULT NULL,
  `DamageRange_ID` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `attacks`
--

CREATE TABLE `attacks` (
  `ID` int(11) NOT NULL,
  `Name` varchar(32) NOT NULL,
  `AttackRange` int(11) NOT NULL,
  `Special` text NOT NULL,
  `HitModifier` int(11) DEFAULT NULL,
  `DamageModifier` int(11) DEFAULT NULL,
  `DamageRange_ID` int(11) DEFAULT NULL,
  `Weapon_ID` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `damageranges`
--

CREATE TABLE `damageranges` (
  `ID` int(11) NOT NULL,
  `DamageRange` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `monsterabilities`
--

CREATE TABLE `monsterabilities` (
  `Monster_ID` int(11) NOT NULL,
  `Ability_ID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `monsterattacks`
--

CREATE TABLE `monsterattacks` (
  `Monster_ID` int(11) NOT NULL,
  `Attack_ID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `monsters`
--

CREATE TABLE `monsters` (
  `ID` int(11) NOT NULL,
  `Name` varchar(32) NOT NULL,
  `ChallengeRating` float NOT NULL,
  `ArmorClass` int(11) NOT NULL,
  `HitPoints` int(11) NOT NULL,
  `Resistances` text NOT NULL,
  `Vulnerabilities` text NOT NULL,
  `Immunities` text NOT NULL,
  `Speed` int(11) NOT NULL,
  `Size` varchar(32) NOT NULL,
  `HitModifier` int(11) DEFAULT NULL,
  `DamageModifier` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `monsterweapons`
--

CREATE TABLE `monsterweapons` (
  `Monster_ID` int(11) NOT NULL,
  `Weapon_ID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `weapons`
--

CREATE TABLE `weapons` (
  `ID` int(11) NOT NULL,
  `Name` varchar(32) NOT NULL,
  `Weight` float NOT NULL,
  `Durability` int(11) NOT NULL,
  `GoldValue` int(11) NOT NULL,
  `Special` text NOT NULL,
  `HitModifier` int(11) DEFAULT NULL,
  `DamageModifier` int(11) DEFAULT NULL,
  `DamageRange_ID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `abilities`
--
ALTER TABLE `abilities`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `Damage_ID` (`DamageRange_ID`);

--
-- Indexes for table `attacks`
--
ALTER TABLE `attacks`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `Damage_ID` (`DamageRange_ID`,`Weapon_ID`),
  ADD KEY `Weapon_ID` (`Weapon_ID`);

--
-- Indexes for table `damageranges`
--
ALTER TABLE `damageranges`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `monsterabilities`
--
ALTER TABLE `monsterabilities`
  ADD KEY `Monster_ID` (`Monster_ID`,`Ability_ID`),
  ADD KEY `Ability_ID` (`Ability_ID`);

--
-- Indexes for table `monsterattacks`
--
ALTER TABLE `monsterattacks`
  ADD KEY `Monster_ID` (`Monster_ID`,`Attack_ID`),
  ADD KEY `Attack_ID` (`Attack_ID`);

--
-- Indexes for table `monsters`
--
ALTER TABLE `monsters`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `monsterweapons`
--
ALTER TABLE `monsterweapons`
  ADD KEY `Monster_ID` (`Monster_ID`,`Weapon_ID`),
  ADD KEY `Weapon_ID` (`Weapon_ID`);

--
-- Indexes for table `weapons`
--
ALTER TABLE `weapons`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `Damage_ID` (`DamageRange_ID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `abilities`
--
ALTER TABLE `abilities`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `attacks`
--
ALTER TABLE `attacks`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `damageranges`
--
ALTER TABLE `damageranges`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `monsters`
--
ALTER TABLE `monsters`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `weapons`
--
ALTER TABLE `weapons`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
