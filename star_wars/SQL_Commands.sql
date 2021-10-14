-- Create and change database
CREATE DATABASE EstrelaDaMorte
USE EstrelaDaMorte
GO

-- Create table Planetas
CREATE TABLE Planetas (
  IdPlaneta INT NOT NULL,
  Nome VARCHAR(50) NOT NULL,
  Rotacao FLOAT NOT NULL,
  Orbita FLOAT NOT NULL,
  Diametro FLOAT NOT NULL,
  Clima VARCHAR(50) NOT NULL,
  Populacao INT NOT NULL,
  CONSTRAINT PK_Planetas PRIMARY KEY (IdPlaneta),
)
GO

-- Create table Naves
CREATE TABLE Naves (
  IdNave INT NOT NULL,
  Nome VARCHAR(100) NOT NULL,
  Modelo VARCHAR(150) NOT NULL,
  Passageiros INT NOT NULL,
  Carga FLOAT NOT NULL,
  Classe VARCHAR(100) NOT NULL,
  CONSTRAINT PK_Naves PRIMARY KEY (IdNave),
)
GO

-- Create table Pilotos
CREATE TABLE Pilotos (
  IdPiloto INT NOT NULL,
  Nome VARCHAR(100) NOT NULL,
  AnoNascimento VARCHAR(10) NOT NULL,
  IdPlaneta INT NOT NULL,
  CONSTRAINT PK_Pilotos PRIMARY KEY (IdPiloto),
  CONSTRAINT FK_Pilotos_Planetas FOREIGN KEY (IdPlaneta) REFERENCES Planetas (IdPlaneta),
)
GO

-- Create table PilotosNaves
CREATE TABLE PilotosNaves (
  IdPiloto INT NOT NULL,
  IdNave INT NOT NULL,
  FlagAutorizado BIT NOT NULL DEFAULT 1,
  CONSTRAINT PK_PilotosNaves PRIMARY KEY (IdPiloto, IdNave),
  CONSTRAINT FK_PilotosNaves_Pilotos FOREIGN KEY (IdPiloto) REFERENCES Pilotos (IdPiloto),
  CONSTRAINT FK_PilotosNaves_Naves FOREIGN KEY (IdNave) REFERENCES Naves (IdNave),
)
GO

-- Create table HistoricoViagens
CREATE TABLE HistoricoViagens (
  IdPiloto INT NOT NULL,
  IdNave INT NOT NULL,
  DtSaida DATETIME NOT NULL,
  DtChegada DATETIME,
  CONSTRAINT FK_HistoricoViagens_PilotosNaves FOREIGN KEY (IdPiloto, IdNave) REFERENCES PilotosNaves (IdPiloto, IdNave),
)
GO
ALTER TABLE HistoricoViagens CHECK CONSTRAINT FK_HistoricoViagens_PilotosNaves
GO