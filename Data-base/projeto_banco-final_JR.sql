-- MySQL dump 10.13  Distrib 8.0.42, for Win64 (x86_64)
--
-- Host: localhost    Database: calculo_salario2
-- ------------------------------------------------------
-- Server version	8.0.42

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `cargo`
--

DROP TABLE IF EXISTS `cargo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cargo` (
  `nome` varchar(100) NOT NULL,
  `salario` decimal(10,2) NOT NULL,
  PRIMARY KEY (`nome`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cargo`
--

LOCK TABLES `cargo` WRITE;
/*!40000 ALTER TABLE `cargo` DISABLE KEYS */;
INSERT INTO `cargo` VALUES ('Analista',4000.00),('Coordenador',6000.00),('Estagiário',1500.00),('Gerente',9000.00),('Técnico',2500.00);
/*!40000 ALTER TABLE `cargo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `contador_matricula`
--

DROP TABLE IF EXISTS `contador_matricula`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `contador_matricula` (
  `ano` int NOT NULL,
  `contador` int NOT NULL,
  PRIMARY KEY (`ano`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `contador_matricula`
--

LOCK TABLES `contador_matricula` WRITE;
/*!40000 ALTER TABLE `contador_matricula` DISABLE KEYS */;
INSERT INTO `contador_matricula` VALUES (2025,42);
/*!40000 ALTER TABLE `contador_matricula` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pessoa`
--

DROP TABLE IF EXISTS `pessoa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pessoa` (
  `matricula` varchar(10) NOT NULL,
  `cpf` char(11) NOT NULL,
  `nome` varchar(255) NOT NULL,
  `data_nascimento` date NOT NULL,
  `cidade` varchar(255) NOT NULL,
  `email` varchar(255) NOT NULL,
  `cep` varchar(20) NOT NULL,
  `logradouro` varchar(255) NOT NULL,
  `numero` varchar(20) NOT NULL,
  `pais` varchar(100) NOT NULL,
  `usuario` varchar(100) NOT NULL,
  `telefone` varchar(50) NOT NULL,
  `cargo_nome` varchar(100) NOT NULL,
  `ativo` tinyint(1) NOT NULL DEFAULT '1',
  PRIMARY KEY (`matricula`),
  UNIQUE KEY `email` (`email`),
  UNIQUE KEY `cpf_UNIQUE` (`cpf`),
  UNIQUE KEY `usuario_UNIQUE` (`usuario`),
  KEY `cargo_nome` (`cargo_nome`),
  CONSTRAINT `pessoa_ibfk_1` FOREIGN KEY (`cargo_nome`) REFERENCES `cargo` (`nome`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pessoa`
--

LOCK TABLES `pessoa` WRITE;
/*!40000 ALTER TABLE `pessoa` DISABLE KEYS */;
INSERT INTO `pessoa` VALUES ('2502','88732312311','Rafael','1998-02-12','Coisado','rr@gmail.com','59129000','Rua Atol','234','Brasil','uffs','(84) 99821-1242','Gerente',0),('2503','98765432122','Ana Louro','1999-09-12','Natal','ana@yahoo.com','55129000','Rua Das Quengas','99','Brasil','anap','(79) 98723-1212','Estagiario',0),('2504','67898780933','João Da Silva','1997-09-12','Fortaleza','joao@gmail.com','56789111','Praia de ','01','Brasil','joaofort','(81) 98867-6152','Gerente',1),('2505','98765488811','Joao Fontes','1995-02-02','Natal','ffo@gmail.com','45987000','Rua das Coisas','22','Brasil','ucfont','(76) 99898-3224','Coordenador',1),('2506','67801298720','Severina Pato','1985-10-22','Crato','svr@gmail.com','34222190','Rua Sem Água','555','Brasil','svrna','(83) 99921-3344','Gerente',1),('2507','56785411188','Antonio Pereira','1992-10-22','Natal','ap@gmail.com','67589000','Rua Primeira','4455','Brasil','ap44','(84) 97423-7564','Analista',1),('2508','87423399901','Karnet Mendes','1984-06-14','São Paulo','knet@gmail.com','78122098','Avenida Paulista','3','Brasil','netkr','(11) 97656-4899','Analista',0),('2509','55555555512','Melkor Primeiro','1994-10-15','Rio De Janeiro','mlkor@gmail.com','56788000','Rua','44','Brasil','mlkr','(21) 98989-6767','Analista',1),('2510','56745634533','José Abreu','1990-05-13','Natal','abreu@gmail.com','87434999','Rua Outra','77','Brasil','abreu01','(84) 99834-6789','Analista',0),('2511','12345678900','Ana Clara','1995-03-10','Natal','ana@gmail.com','59000000','Rua das Flores','100','Brasil','ana_user','(84) 98888-1111','Analista',1),('2512','98765432100','Bruno Silva','1990-06-22','Mossoró','bruno@gmail.com','59600000','Av. Central','200','Brasil','bruno_s','(84) 98888-2222','Técnico',1),('2513','11223344556','Carla Souza','1988-11-05','Parnamirim','carla@gmail.com','59140000','Rua Verde','50','Brasil','carlinha','(84) 98888-3333','Gerente',1),('2514','22334455667','Diego Lima','1993-07-18','Caicó','diego@gmail.com','59300000','Travessa Azul','120','Brasil','d_lima','(84) 98888-4444','Coordenador',1),('2515','33445566778','Eduarda Matos','1997-02-01','Currais Novos','eduarda@gmail.com','59280000','Rua do Sol','75','Brasil','dudamat','(84) 98888-5555','Estagiário',1),('2516','44556677889','Felipe Torres','1985-12-20','Apodi','felipe@gmail.com','59700000','Rua das Palmeiras','33','Brasil','f_torres','(84) 98888-6666','Técnico',1),('2517','55667788990','Gabriela Rocha','1996-08-13','Assu','gabriela@gmail.com','59650000','Av. Atlântica','98','Brasil','g_rocha','(84) 98888-7777','Analista',1),('2518','66778899001','Henrique Dantas','1991-09-09','Macau','henrique@gmail.com','59500000','Rua Rio Branco','65','Brasil','henry_d','(84) 98888-8888','Técnico',1),('2519','77889900112','Isabela Melo','1994-01-30','Touros','isabela@gmail.com','59580000','Rua Marfim','42','Brasil','isamelo','(84) 98888-9999','Gerente',1),('2520','88990011223','João Pedro','1992-10-15','Areia Branca','joa67o@gmail.com','59680000','Rua Principal','77','Brasil','joaop','(84) 98888-0000','Analista',1),('2521','99001122334','Karen Alves','1999-04-12','Serra Negra','karen@gmail.com','59570000','Rua Oeste','88','Brasil','kalves','(84) 98888-1112','Estagiário',1),('2522','10111213141','Lucas Freitas','1998-12-03','Jucurutu','lucas@gmail.com','59330000','Rua Nova','52','Brasil','l_freitas','(84) 98888-1313','Técnico',1),('2523','12131415161','Marina Cunha','1996-01-08','Pau dos Ferros','marina@gmail.com','59900000','Rua Verdejante','29','Brasil','marinac','(84) 98888-1414','Analista',1),('2524','13141516171','Nicolas Dias','1997-07-27','Canguaretama','nicolas@gmail.com','59190000','Rua Brasil','60','Brasil','n_dias','(84) 98888-1515','Coordenador',1),('2525','14151617181','Olivia Batista','1995-06-14','Santa Cruz','olivia@gmail.com','59200000','Av. Natal','110','Brasil','olibat','(84) 98888-1616','Gerente',1),('2526','15161718191','Pedro Henrique','1993-09-25','São Gonçalo','pedro@gmail.com','59290000','Rua dos Ipês','25','Brasil','pedroh','(84) 98888-1717','Analista',1),('2527','16171819201','Quezia Moura','1990-10-10','Extremoz','quezia@gmail.com','59590000','Rua Norte','45','Brasil','quezia_m','(84) 98888-1818','Estagiário',1),('2528','17181920212','Rafael Lemos','1989-05-20','Nísia Floresta','rafael.l@gmail.com','59164000','Rua das Laranjeiras','82','Brasil','rafal','(84) 98888-1919','Coordenador',1),('2529','18192021223','Sara Brito','1992-02-28','Baía Formosa','sara@gmail.com','59194000','Av. das Gaivotas','38','Brasil','s_brito','(84) 98888-2020','Gerente',1),('2530','19202122234','Thiago Monteiro','1987-11-17','Pedro Velho','thiago@gmail.com','59196000','Rua Mar Azul','90','Brasil','t_monteiro','(84) 98888-2121','Técnico',1),('2531','20212223245','Ursula Lira','1994-03-09','Ceará-Mirim','ursula@gmail.com','59570000','Rua Oeste','73','Brasil','ulira','(84) 98888-2222','Estagiário',1),('2532','21222324356','Vinicius Teixeira','1991-01-11','Goianinha','vinicius@gmail.com','59190000','Rua das Acácias','58','Brasil','vteix','(84) 98888-2323','Analista',1),('2533','22232425467','Wesley Gomes','1996-10-04','Lagoa Nova','wesley@gmail.com','59390000','Rua Lago Azul','37','Brasil','wesgom','(84) 98888-2424','Técnico',1),('2534','23242526478','Xuxa Silva','1984-08-15','São Miguel','xuxa@gmail.com','59930000','Rua dos Cedros','84','Brasil','x_silva','(84) 98888-2525','Gerente',1),('2535','24252627489','Yasmin Ramos','1993-12-22','Tangará','yasmin@gmail.com','59240000','Rua A','120','Brasil','yasramos','(84) 98888-2626','Estagiário',1),('2536','25262728490','Zeca Alves','1990-04-19','Upanema','zeca@gmail.com','59670000','Rua B','56','Brasil','zecalves','(84) 98888-2727','Analista',1),('2537','26272829401','Alan Moura','1998-09-09','Acari','alan@gmail.com','59370000','Rua Projetada','70','Brasil','alanm','(84) 98888-2828','Técnico',1),('2538','27282930412','Bia Costa','1997-02-16','Campo Redondo','bia@gmail.com','59230000','Rua das Rosas','19','Brasil','biac','(84) 98888-2929','Coordenador',1),('2539','28293031423','Caio Melo','1996-06-06','Riachuelo','caio@gmail.com','59470000','Rua do Centro','22','Brasil','caiomelo','(84) 98888-3030','Estagiário',1),('2540','29303132434','Debora Lima','1994-05-30','São Tomé','debora@gmail.com','59530000','Rua do Sol Nascente','35','Brasil','debolima','(84) 98888-3131','Gerente',1),('2541','25123008022','Dagô Do Forró','1969-10-09','Natal','meajude@vote.em.mim','25123000','Rua','322','Brasil','umrealoCD','(84) 99865-7656','Coordenador',1),('2542','00100198211','José Henrique','1998-08-07','Natal','jhaa@gmail.com','59233000','Rua AV 1','32','Brasil','henrJ','(84) 94312-9322','Analista',1);
/*!40000 ALTER TABLE `pessoa` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pessoa_salario`
--

DROP TABLE IF EXISTS `pessoa_salario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pessoa_salario` (
  `matricula` varchar(10) NOT NULL,
  `salario_base` decimal(10,2) NOT NULL,
  `bonus` decimal(10,2) DEFAULT '0.00',
  `descontos` decimal(10,2) DEFAULT '0.00',
  PRIMARY KEY (`matricula`),
  CONSTRAINT `pessoa_salario_ibfk_1` FOREIGN KEY (`matricula`) REFERENCES `pessoa` (`matricula`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pessoa_salario`
--

LOCK TABLES `pessoa_salario` WRITE;
/*!40000 ALTER TABLE `pessoa_salario` DISABLE KEYS */;
INSERT INTO `pessoa_salario` VALUES ('2504',9000.00,0.00,0.00),('2505',6000.00,0.00,0.00),('2506',9000.00,0.00,0.00),('2507',4000.00,0.00,0.00),('2509',4000.00,0.00,0.00),('2511',4000.00,0.00,0.00),('2512',2500.00,0.00,0.00),('2513',9000.00,0.00,0.00),('2514',6000.00,0.00,0.00),('2515',1500.00,0.00,0.00),('2516',2500.00,0.00,0.00),('2517',4000.00,0.00,0.00),('2518',2500.00,0.00,0.00),('2519',9000.00,0.00,0.00),('2520',4000.00,0.00,0.00),('2521',1500.00,0.00,0.00),('2522',2500.00,0.00,0.00),('2523',4000.00,0.00,0.00),('2524',6000.00,0.00,0.00),('2525',9000.00,0.00,0.00),('2526',4000.00,0.00,0.00),('2527',1500.00,0.00,0.00),('2528',6000.00,0.00,0.00),('2529',9000.00,0.00,0.00),('2530',2500.00,0.00,0.00),('2531',1500.00,0.00,0.00),('2532',4000.00,0.00,0.00),('2533',2500.00,0.00,0.00),('2534',9000.00,0.00,0.00),('2535',1500.00,0.00,0.00),('2536',4000.00,0.00,0.00),('2537',2500.00,0.00,0.00),('2538',6000.00,0.00,0.00),('2539',1500.00,0.00,0.00),('2540',9000.00,0.00,0.00),('2541',6000.00,0.00,0.00),('2542',4000.00,0.00,0.00);
/*!40000 ALTER TABLE `pessoa_salario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `vw_pessoa_salario_ativo`
--

DROP TABLE IF EXISTS `vw_pessoa_salario_ativo`;
/*!50001 DROP VIEW IF EXISTS `vw_pessoa_salario_ativo`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `vw_pessoa_salario_ativo` AS SELECT 
 1 AS `matricula`,
 1 AS `nome`,
 1 AS `email`,
 1 AS `cargo`,
 1 AS `salario_base`,
 1 AS `bonus`,
 1 AS `descontos`,
 1 AS `salario_liquido`*/;
SET character_set_client = @saved_cs_client;

--
-- Dumping routines for database 'calculo_salario2'
--
/*!50003 DROP PROCEDURE IF EXISTS `calcular_salarios` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE PROCEDURE `calcular_salarios`(
    IN p_bonus DECIMAL(10,2),
    IN p_descontos DECIMAL(10,2)
)
BEGIN
  DECLARE v_bonus DECIMAL(10,2);
  DECLARE v_descontos DECIMAL(10,2);

  SET v_bonus = IFNULL(p_bonus, 0);
  SET v_descontos = IFNULL(p_descontos, 0);

  TRUNCATE TABLE pessoa_salario;

  INSERT INTO pessoa_salario (matricula, salario_base, bonus, descontos)
  SELECT
    p.matricula,
    c.salario AS salario_base,
    c.salario * v_bonus / 100 AS bonus,
    v_descontos AS descontos
  FROM pessoa p
  INNER JOIN cargo c ON p.cargo_nome = c.nome
  WHERE p.ativo = 1;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `inserir_pessoa` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE PROCEDURE `inserir_pessoa`(
    IN p_nome VARCHAR(100),
    IN p_cidade VARCHAR(100),
    IN p_email VARCHAR(100),
    IN p_cep VARCHAR(20),
    IN p_logradouro VARCHAR(255),
    IN p_numero VARCHAR(20),
    IN p_pais VARCHAR(50),
    IN p_usuario VARCHAR(50),
    IN p_telefone VARCHAR(30),
    IN p_data_nascimento DATE,
    IN p_cargo_nome VARCHAR(100),
    IN p_cpf CHAR(11)
)
BEGIN
    DECLARE ano_atual INT;
    DECLARE contador_atual INT;
    DECLARE nova_matricula VARCHAR(10);

    SET ano_atual = YEAR(CURDATE());

    -- Se ainda não há entrada para o ano atual, criar
    INSERT INTO contador_matricula (ano, contador)
    VALUES (ano_atual, 0)
    ON DUPLICATE KEY UPDATE contador = contador;

    -- Incrementar o contador
    UPDATE contador_matricula
    SET contador = contador + 1
    WHERE ano = ano_atual;

    -- Obter valor atualizado
    SELECT contador INTO contador_atual
    FROM contador_matricula
    WHERE ano = ano_atual;

    -- Gerar a matrícula no formato YYNNN
    SET nova_matricula = CONCAT(LPAD(RIGHT(ano_atual, 2), 2, '0'), LPAD(contador_atual, 2, '0'));

    -- Inserir a pessoa com a matrícula gerada
    INSERT INTO pessoa (
        matricula, nome, cidade, email, cep, logradouro, numero, pais,
        usuario, telefone, data_nascimento, cargo_nome, cpf, ativo
    ) VALUES (
        nova_matricula, p_nome, p_cidade, p_email, p_cep, p_logradouro, p_numero, p_pais,
        p_usuario, p_telefone, p_data_nascimento, p_cargo_nome, p_cpf, 1
    );
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Final view structure for view `vw_pessoa_salario_ativo`
--

/*!50001 DROP VIEW IF EXISTS `vw_pessoa_salario_ativo`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */

/*!50001 VIEW `vw_pessoa_salario_ativo` AS select `p`.`matricula` AS `matricula`,`p`.`nome` AS `nome`,`p`.`email` AS `email`,`p`.`cargo_nome` AS `cargo`,`ps`.`salario_base` AS `salario_base`,`ps`.`bonus` AS `bonus`,`ps`.`descontos` AS `descontos`,((`ps`.`salario_base` + `ps`.`bonus`) - `ps`.`descontos`) AS `salario_liquido` from (`pessoa` `p` join `pessoa_salario` `ps` on((`p`.`matricula` = `ps`.`matricula`))) where (`p`.`ativo` = 1) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-07-15  1:46:21
