CREATE TABLE `empresas` (
  `idEmpresa` int(11) NOT NULL AUTO_INCREMENT,
  `nomeEmpresa` varchar(45) NOT NULL,
  `codCNPJ` varchar(19) NOT NULL,
  `dataCriacao` datetime DEFAULT NULL,
  PRIMARY KEY (`idEmpresa`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;
