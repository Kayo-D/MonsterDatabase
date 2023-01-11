-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jan 11, 2023 at 02:50 AM
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

--
-- Dumping data for table `abilities`
--

INSERT INTO `abilities` (`ID`, `Name`, `AbilityRange`, `Special`, `HitModifier`, `DamageModifier`, `DamageRange_ID`) VALUES
(1, 'Dragon Fire Breath', 60, '(Recharge 5–6). The dragon exhales fire in a 60-foot cone. Each creature in that area must make a DC 21 Dexterity saving throw, taking 63 (18d6) fire damage on a failed save, or half as much damage on a successful one.', NULL, NULL, NULL),
(2, 'Dragon Acid Breath', 60, '(Recharge 5–6). The dragon exhales acid in a 60-­foot line that is 5 feet wide. Each creature in that line must make a DC 18 Dexterity saving throw, taking 54 (12d8) acid damage on a failed save, or half as much damage on a successful one.', NULL, NULL, NULL);

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

--
-- Dumping data for table `attacks`
--

INSERT INTO `attacks` (`ID`, `Name`, `AttackRange`, `Special`, `HitModifier`, `DamageModifier`, `DamageRange_ID`, `Weapon_ID`) VALUES
(1, 'Dragon Bite', 5, '', NULL, NULL, 5, NULL),
(2, 'Dragon Tail Swipe', 15, '', NULL, NULL, 4, NULL),
(3, 'Throw Dagger', 30, '', NULL, NULL, NULL, 2),
(4, 'Dagger Stab', 5, '', NULL, NULL, NULL, 2),
(5, 'Magical Sword Swing', 5, '', NULL, NULL, NULL, 4);

-- --------------------------------------------------------

--
-- Table structure for table `damageranges`
--

CREATE TABLE `damageranges` (
  `ID` int(11) NOT NULL,
  `DamageRange` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `damageranges`
--

INSERT INTO `damageranges` (`ID`, `DamageRange`) VALUES
(1, 4),
(2, 5),
(3, 6),
(4, 8),
(5, 10),
(6, 12);

-- --------------------------------------------------------

--
-- Table structure for table `monsterabilities`
--

CREATE TABLE `monsterabilities` (
  `Monster_ID` int(11) NOT NULL,
  `Ability_ID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `monsterabilities`
--

INSERT INTO `monsterabilities` (`Monster_ID`, `Ability_ID`) VALUES
(1, 1),
(2, 2);

-- --------------------------------------------------------

--
-- Table structure for table `monsterattacks`
--

CREATE TABLE `monsterattacks` (
  `Monster_ID` int(11) NOT NULL,
  `Attack_ID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `monsterattacks`
--

INSERT INTO `monsterattacks` (`Monster_ID`, `Attack_ID`) VALUES
(1, 1),
(1, 2),
(2, 1),
(2, 2),
(3, 3),
(3, 4),
(4, 5);

-- --------------------------------------------------------

--
-- Table structure for table `monsters`
--

CREATE TABLE `monsters` (
  `ID` int(11) NOT NULL,
  `Name` varchar(32) NOT NULL,
  `ChallengeRating` float NOT NULL,
  `ArmorClass` int(11) NOT NULL,
  `HitPointsMax` int(11) NOT NULL,
  `Resistances` text NOT NULL,
  `Vulnerabilities` text NOT NULL,
  `Immunities` text NOT NULL,
  `Speed` int(11) NOT NULL,
  `Size` varchar(32) NOT NULL,
  `HitModifier` int(11) DEFAULT NULL,
  `DamageModifier` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `monsters`
--

INSERT INTO `monsters` (`ID`, `Name`, `ChallengeRating`, `ArmorClass`, `HitPointsMax`, `Resistances`, `Vulnerabilities`, `Immunities`, `Speed`, `Size`, `HitModifier`, `DamageModifier`) VALUES
(1, 'Adult Red Dragon', 17, 19, 256, '', '', 'Fire', 40, 'Huge', 14, 8),
(2, 'Adult Black Dragon', 14, 19, 195, '', '', 'Acid', 40, 'Huge', 11, 6),
(3, 'Orc Assassin', 1, 13, 15, '', '', '', 30, 'Medium', 5, 3),
(4, 'Orc Chieftain', 4, 14, 25, '', '', '', 30, 'Medium', 6, 4),
(5, 'Adult Green Dragon', 15, 19, 207, '', '', 'Poison', 40, 'Huge', 11, 6),
(9, 'Adult Bronze Dragon', 15, 19, 212, '', '', 'Lightning', 40, 'Huge', 12, 7);

-- --------------------------------------------------------

--
-- Table structure for table `monsterweapons`
--

CREATE TABLE `monsterweapons` (
  `Monster_ID` int(11) NOT NULL,
  `Weapon_ID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `monsterweapons`
--

INSERT INTO `monsterweapons` (`Monster_ID`, `Weapon_ID`) VALUES
(3, 2),
(4, 4);

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
-- Dumping data for table `weapons`
--

INSERT INTO `weapons` (`ID`, `Name`, `Weight`, `Durability`, `GoldValue`, `Special`, `HitModifier`, `DamageModifier`, `DamageRange_ID`) VALUES
(2, 'Dagger', 1, 100, 2, '', NULL, NULL, 1),
(3, 'Mace', 4, 100, 5, '', NULL, NULL, 3),
(4, '+1 Longsword', 3, 100, 300, '', 1, 1, 4);

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
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `attacks`
--
ALTER TABLE `attacks`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `damageranges`
--
ALTER TABLE `damageranges`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `monsters`
--
ALTER TABLE `monsters`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `weapons`
--
ALTER TABLE `weapons`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
