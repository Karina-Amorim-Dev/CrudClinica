CREATE DATABASE IF NOT EXISTS crudClinica;

USE crudClinica;

-- =====================================================
-- TABELA: ESPECIALIDADE
-- =====================================================

CREATE TABLE IF NOT EXISTS Especialidade (
    idEspecialidade INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(50) NOT NULL
);

-- =====================================================
-- TABELA: MEDICO
-- =====================================================

CREATE TABLE IF NOT EXISTS Medico (
    idMedico INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    crm VARCHAR(20) NOT NULL UNIQUE,
    idEspecialidade INT NOT NULL,
    FOREIGN KEY (idEspecialidade)
        REFERENCES Especialidade(idEspecialidade)
);

-- =====================================================
-- TABELA: PACIENTE
-- =====================================================

CREATE TABLE IF NOT EXISTS Paciente (
    idPaciente INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    cpf VARCHAR(14) NOT NULL UNIQUE,
    telefone VARCHAR(15),
    dataNasc DATE
);

-- =====================================================
-- TABELA: CONSULTA
-- =====================================================

CREATE TABLE IF NOT EXISTS Consulta (
    idConsulta INT AUTO_INCREMENT PRIMARY KEY,
    idMedico INT NOT NULL,
    idPaciente INT NOT NULL,
    dataHora DATETIME NOT NULL,
    FOREIGN KEY (idMedico)
        REFERENCES Medico(idMedico),
    FOREIGN KEY (idPaciente)
        REFERENCES Paciente(idPaciente)
);

-- =====================================================
-- DADOS INICIAIS
-- =====================================================

INSERT INTO Especialidade (nome) VALUES
('Ortopedia'),
('Ginecologia');

INSERT INTO Medico (nome, crm, idEspecialidade) VALUES
('Dr. Felipe Costa', 'CRM-SP 45678', 1),
('Dra. Juliana Alves', 'CRM-SP 56789', 2),
('Dr. Ricardo Nunes', 'CRM-SP 67890', 1);

INSERT INTO Paciente (nome, cpf, telefone, dataNasc) VALUES
('Ana Beatriz Lima', '444.555.666-77', '(11) 94444-4444', '1998-02-14'),
('Carlos Eduardo', '555.666.777-88', '(11) 95555-5555', '1975-07-30'),
('Fernanda Rocha', '666.777.888-99', '(11) 96666-6666', '2002-12-01'),
('Gabriel Martins', '777.888.999-00', '(11) 97777-7777', '2018-09-19'),
('Helena Barros', '888.999.000-11', '(11) 98888-8888', '1965-04-05');

INSERT INTO Consulta (idMedico, idPaciente, dataHora) VALUES
(1, 4, '2026-08-06 09:00:00'),
(3, 5, '2026-08-06 11:00:00'),
(1, 1, '2026-08-07 15:30:00'),
(2, 2, '2026-08-07 16:00:00'),
(2, 1, '2026-08-08 08:00:00'),
(3, 3, '2026-08-08 09:30:00'),
(1, 2, '2026-08-10 10:00:00'),
(1, 3, '2026-08-11 14:30:00'),
(3, 5, '2026-08-12 13:00:00'),
(2, 4, '2026-08-13 17:00:00');

-- =====================================================
-- PROCEDURES: PACIENTE
-- =====================================================

DROP PROCEDURE IF EXISTS sp_paciente_criar;
DROP PROCEDURE IF EXISTS sp_paciente_listar;
DROP PROCEDURE IF EXISTS sp_paciente_obter;
DROP PROCEDURE IF EXISTS sp_paciente_editar;
DROP PROCEDURE IF EXISTS sp_paciente_excluir;

DELIMITER $$

CREATE PROCEDURE sp_paciente_criar (
    IN p_nome VARCHAR(100),
    IN p_cpf VARCHAR(14),
    IN p_telefone VARCHAR(15),
    IN p_dataNasc DATE
)
BEGIN
    INSERT INTO Paciente (
        nome,
        cpf,
        telefone,
        dataNasc
    )
    VALUES (
        p_nome,
        p_cpf,
        p_telefone,
        p_dataNasc
    );
END $$

CREATE PROCEDURE sp_paciente_listar()
BEGIN
    SELECT
        idPaciente,
        nome,
        cpf,
        telefone,
        dataNasc
    FROM Paciente
    ORDER BY nome;
END $$

CREATE PROCEDURE sp_paciente_obter (
    IN p_idPaciente INT
)
BEGIN
    SELECT
        idPaciente,
        nome,
        cpf,
        telefone,
        dataNasc
    FROM Paciente
    WHERE idPaciente = p_idPaciente;
END $$

CREATE PROCEDURE sp_paciente_editar (
    IN p_idPaciente INT,
    IN p_nome VARCHAR(100),
    IN p_cpf VARCHAR(14),
    IN p_telefone VARCHAR(15),
    IN p_dataNasc DATE
)
BEGIN
    UPDATE Paciente
    SET
        nome = p_nome,
        cpf = p_cpf,
        telefone = p_telefone,
        dataNasc = p_dataNasc
    WHERE idPaciente = p_idPaciente;
END $$

CREATE PROCEDURE sp_paciente_excluir (
    IN p_idPaciente INT
)
BEGIN
    IF EXISTS (
        SELECT 1
        FROM Consulta
        WHERE idPaciente = p_idPaciente
    ) THEN

        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT =
        'Não é possível excluir este paciente porque existem consultas cadastradas.';

    ELSE

        DELETE FROM Paciente
        WHERE idPaciente = p_idPaciente;

    END IF;
END $$

DELIMITER ;

-- =====================================================
-- PROCEDURES: MEDICO
-- =====================================================

DROP PROCEDURE IF EXISTS sp_medico_criar;
DROP PROCEDURE IF EXISTS sp_medico_listar;
DROP PROCEDURE IF EXISTS sp_medico_obter;
DROP PROCEDURE IF EXISTS sp_medico_editar;
DROP PROCEDURE IF EXISTS sp_medico_excluir;

DELIMITER $$

CREATE PROCEDURE sp_medico_criar (
    IN p_nome VARCHAR(100),
    IN p_crm VARCHAR(20),
    IN p_idEspecialidade INT
)
BEGIN
    INSERT INTO Medico (
        nome,
        crm,
        idEspecialidade
    )
    VALUES (
        p_nome,
        p_crm,
        p_idEspecialidade
    );
END $$

CREATE PROCEDURE sp_medico_listar()
BEGIN
    SELECT
        m.idMedico,
        m.nome,
        m.crm,
        m.idEspecialidade,
        e.nome AS especialidade
    FROM Medico m
    INNER JOIN Especialidade e
        ON m.idEspecialidade = e.idEspecialidade
    ORDER BY m.idMedico ASC;
END $$

CREATE PROCEDURE sp_medico_obter (
    IN p_idMedico INT
)
BEGIN
    SELECT
        m.idMedico,
        m.nome,
        m.crm,
        m.idEspecialidade,
        e.nome AS especialidade
    FROM Medico m
    INNER JOIN Especialidade e
        ON m.idEspecialidade = e.idEspecialidade
    WHERE m.idMedico = p_idMedico;
END $$

CREATE PROCEDURE sp_medico_editar (
    IN p_idMedico INT,
    IN p_nome VARCHAR(100),
    IN p_crm VARCHAR(20),
    IN p_idEspecialidade INT
)
BEGIN
    UPDATE Medico
    SET
        nome = p_nome,
        crm = p_crm,
        idEspecialidade = p_idEspecialidade
    WHERE idMedico = p_idMedico;
END $$

CREATE PROCEDURE sp_medico_excluir (
    IN p_idMedico INT
)
BEGIN
    IF EXISTS (
        SELECT 1
        FROM Consulta
        WHERE idMedico = p_idMedico
    ) THEN

        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT =
        'Não é possível excluir este médico porque existem consultas cadastradas.';

    ELSE

        DELETE FROM Medico
        WHERE idMedico = p_idMedico;

    END IF;
END $$

DELIMITER ;

-- =====================================================
-- PROCEDURES: ESPECIALIDADE
-- =====================================================

DROP PROCEDURE IF EXISTS sp_especialidade_criar;
DROP PROCEDURE IF EXISTS sp_especialidade_listar;
DROP PROCEDURE IF EXISTS sp_especialidade_obter;
DROP PROCEDURE IF EXISTS sp_especialidade_editar;
DROP PROCEDURE IF EXISTS sp_especialidade_excluir;

DELIMITER $$

CREATE PROCEDURE sp_especialidade_criar (
    IN p_nome VARCHAR(50)
)
BEGIN
    INSERT INTO Especialidade (nome)
    VALUES (p_nome);
END $$

CREATE PROCEDURE sp_especialidade_listar()
BEGIN
    SELECT
        idEspecialidade,
        nome
    FROM Especialidade
    ORDER BY idEspecialidade ASC;
END $$

CREATE PROCEDURE sp_especialidade_obter (
    IN p_idEspecialidade INT
)
BEGIN
    SELECT
        idEspecialidade,
        nome
    FROM Especialidade
    WHERE idEspecialidade = p_idEspecialidade;
END $$

CREATE PROCEDURE sp_especialidade_editar (
    IN p_idEspecialidade INT,
    IN p_nome VARCHAR(50)
)
BEGIN
    UPDATE Especialidade
    SET nome = p_nome
    WHERE idEspecialidade = p_idEspecialidade;
END $$

CREATE PROCEDURE sp_especialidade_excluir (
    IN p_idEspecialidade INT
)
BEGIN
    IF EXISTS (
        SELECT 1
        FROM Medico
        WHERE idEspecialidade = p_idEspecialidade
    ) THEN

        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT =
        'Não é possível excluir esta especialidade porque existem médicos cadastrados nela.';

    ELSE

        DELETE FROM Especialidade
        WHERE idEspecialidade = p_idEspecialidade;

    END IF;
END $$

DELIMITER ;

-- =====================================================
-- PROCEDURES: CONSULTA
-- =====================================================

DROP PROCEDURE IF EXISTS sp_consulta_criar;
DROP PROCEDURE IF EXISTS sp_consulta_listar;
DROP PROCEDURE IF EXISTS sp_consulta_obter;
DROP PROCEDURE IF EXISTS sp_consulta_editar;
DROP PROCEDURE IF EXISTS sp_consulta_excluir;

DELIMITER $$

CREATE PROCEDURE sp_consulta_criar (
    IN p_idMedico INT,
    IN p_idPaciente INT,
    IN p_dataHora DATETIME
)
BEGIN
    INSERT INTO Consulta (
        idMedico,
        idPaciente,
        dataHora
    )
    VALUES (
        p_idMedico,
        p_idPaciente,
        p_dataHora
    );
END $$

CREATE PROCEDURE sp_consulta_listar()
BEGIN
    SELECT
        c.idConsulta,
        c.idMedico,
        m.nome AS medico,
        c.idPaciente,
        p.nome AS paciente,
        c.dataHora
    FROM Consulta c
    INNER JOIN Medico m
        ON c.idMedico = m.idMedico
    INNER JOIN Paciente p
        ON c.idPaciente = p.idPaciente
    ORDER BY c.idConsulta ASC;
END $$

CREATE PROCEDURE sp_consulta_obter (
    IN p_idConsulta INT
)
BEGIN
    SELECT
        c.idConsulta,
        c.idMedico,
        m.nome AS medico,
        c.idPaciente,
        p.nome AS paciente,
        c.dataHora
    FROM Consulta c
    INNER JOIN Medico m
        ON c.idMedico = m.idMedico
    INNER JOIN Paciente p
        ON c.idPaciente = p.idPaciente
    WHERE c.idConsulta = p_idConsulta;
END $$

CREATE PROCEDURE sp_consulta_editar (
    IN p_idConsulta INT,
    IN p_idMedico INT,
    IN p_idPaciente INT,
    IN p_dataHora DATETIME
)
BEGIN
    UPDATE Consulta
    SET
        idMedico = p_idMedico,
        idPaciente = p_idPaciente,
        dataHora = p_dataHora
    WHERE idConsulta = p_idConsulta;
END $$

CREATE PROCEDURE sp_consulta_excluir (
    IN p_idConsulta INT
)
BEGIN
    DELETE FROM Consulta
    WHERE idConsulta = p_idConsulta;
END $$

DELIMITER ;

-- =====================================================
-- CONSULTAS DE TESTE OPCIONAIS
-- =====================================================

-- SELECT * FROM Especialidade;
-- SELECT * FROM Medico;
-- SELECT * FROM Paciente;
-- SELECT * FROM Consulta;

-- CALL sp_especialidade_listar();
-- CALL sp_medico_listar();
-- CALL sp_paciente_listar();
-- CALL sp_consulta_listar();
