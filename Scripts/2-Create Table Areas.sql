CREATE TABLE `areas` (
  `idArea` int(11) NOT NULL AUTO_INCREMENT,
  `descArea` varchar(45) NOT NULL,
  `dataCriacao` datetime DEFAULT NULL,
  `idEmpresa` int(11) DEFAULT NULL,
  PRIMARY KEY (`idArea`),
  KEY `FK_Area_Empresa_idx` (`idEmpresa`),
  CONSTRAINT `FK_Area_Empresa` FOREIGN KEY (`idEmpresa`) REFERENCES `empresas` (`idEmpresa`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;
