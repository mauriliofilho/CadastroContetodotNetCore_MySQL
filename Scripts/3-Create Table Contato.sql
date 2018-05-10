CREATE TABLE `contato` (
  `idContato` int(11) NOT NULL AUTO_INCREMENT,
  `nomeContato` varchar(45) NOT NULL,
  `codCPF` varchar(45) NOT NULL,
  `telResidencial` varchar(45) DEFAULT NULL,
  `telCelular` varchar(45) DEFAULT NULL,
  `email` varchar(45) DEFAULT NULL,
  `idArea` int(11) DEFAULT NULL,
  PRIMARY KEY (`idContato`),
  KEY `IDX_Area` (`idContato`),
  KEY `FG_Contato_Area_idx` (`idArea`),
  CONSTRAINT `FG_Contato_Area` FOREIGN KEY (`idArea`) REFERENCES `areas` (`idArea`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;
