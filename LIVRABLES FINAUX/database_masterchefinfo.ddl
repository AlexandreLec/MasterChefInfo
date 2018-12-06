CREATE TABLE Appareil (
  Id       int NOT NULL, 
  Nom      varchar(255) NOT NULL, 
  Quantite int NOT NULL, 
  TempsNettoyage int NULL, 
  PRIMARY KEY (Id));
CREATE TABLE Assiettes (
  id               int NOT NULL, 
  TypeAssietteid   int NOT NULL, 
  MaterielCommunid int NOT NULL, 
  PRIMARY KEY (id));
CREATE TABLE Carres (
  id      int NOT NULL, 
  Salleid int NOT NULL, 
  PRIMARY KEY (id));
CREATE TABLE Couverts (
  id               int NOT NULL, 
  TypeCouvertid    int NOT NULL, 
  MaterielCommunid int NOT NULL, 
  PRIMARY KEY (id));
CREATE TABLE Denree (
  Id             int NOT NULL, 
  TypeStockageid int NOT NULL, 
  Nom            varchar(255) NOT NULL, 
  Quantite       int NULL, 
  PRIMARY KEY (Id));
CREATE TABLE Etape (
  id          int NOT NULL, 
  Ordre       int NOT NULL, 
  Temps       float(10) NULL, 
  Recetteid   int NOT NULL, 
  Description varchar(500) NOT NULL, 
  PRIMARY KEY (id));
CREATE TABLE Etape_Appareil (
  EtapeId    int NOT NULL, 
  AppareilId int NOT NULL, 
  PRIMARY KEY (EtapeId, 
  AppareilId));
CREATE TABLE Etapes_Denrees (
  EtapeId  int NOT NULL, 
  DenreeId int NOT NULL, 
  PRIMARY KEY (EtapeId, 
  DenreeId));
CREATE TABLE Etapes_Ustensiles (
  Etapesid     int NOT NULL, 
  Ustensilesid int NOT NULL, 
  PRIMARY KEY (Etapesid, 
  Ustensilesid));
CREATE TABLE MaterielCommun (
  id       int NOT NULL, 
  Nom      varchar(255) NOT NULL, 
  Quantite int NOT NULL, 
  PRIMARY KEY (id));
CREATE TABLE Rangs (
  id       int IDENTITY NOT NULL, 
  Carresid int NOT NULL, 
  PRIMARY KEY (id));
CREATE TABLE Recette (
  id            int NOT NULL, 
  TypeRecetteid int NOT NULL,
  Nom           varchar(255) NOT NULL,
  Personnes     int NOT NULL, 
  TempsPrep     float NULL, 
  TempsCuisson  float NULL, 
  TempsPause    float NULL, 
  PRIMARY KEY (id));
CREATE TABLE Salle (
  id         int NOT NULL, 
  Chaises    int NOT NULL, 
  Corbeilles int NOT NULL, 
  PRIMARY KEY (id));
CREATE TABLE Tables (
  id       int IDENTITY NOT NULL, 
  Numero   int NULL UNIQUE, 
  Capacite int NOT NULL, 
  Rangsid  int NOT NULL, 
  PRIMARY KEY (id));
CREATE TABLE TypeAssiette (
  id   int NOT NULL, 
  Name varchar(255) NOT NULL UNIQUE, 
  PRIMARY KEY (id));
CREATE TABLE TypeCouvert (
  id   int NOT NULL, 
  Name varchar(255) NOT NULL UNIQUE, 
  PRIMARY KEY (id));
CREATE TABLE TypeRecette (
  id  int NOT NULL, 
  Nom varchar(255) NOT NULL, 
  PRIMARY KEY (id));
CREATE TABLE TypeStockage (
  Id  int NOT NULL, 
  Nom varchar(255) NULL, 
  PRIMARY KEY (Id));
CREATE TABLE TypeVerre (
  id   int NOT NULL, 
  Name varchar(255) NOT NULL UNIQUE, 
  PRIMARY KEY (id));
CREATE TABLE Ustensile (
  Id             int NOT NULL, 
  Nom            varchar(255) NOT NULL, 
  Quantite       int NOT NULL, 
  TempsNettoyage float(10) NOT NULL, 
  PRIMARY KEY (Id));
CREATE TABLE Verres (
  id               int NOT NULL, 
  TypeVerreid      int NOT NULL, 
  MaterielCommunid int NOT NULL, 
  PRIMARY KEY (id));
ALTER TABLE Rangs ADD CONSTRAINT FKRangs148318 FOREIGN KEY (Carresid) REFERENCES Carres (id);
ALTER TABLE Carres ADD CONSTRAINT FKCarres377468 FOREIGN KEY (Salleid) REFERENCES Salle (id);
ALTER TABLE Denree ADD CONSTRAINT FKDenree482004 FOREIGN KEY (TypeStockageid) REFERENCES TypeStockage (Id);
ALTER TABLE Tables ADD CONSTRAINT FKTables876332 FOREIGN KEY (Rangsid) REFERENCES Rangs (id);
ALTER TABLE Recette ADD CONSTRAINT FKRecette867280 FOREIGN KEY (TypeRecetteid) REFERENCES TypeRecette (id);
ALTER TABLE Assiettes ADD CONSTRAINT FKAssiettes214037 FOREIGN KEY (TypeAssietteid) REFERENCES TypeAssiette (id);
ALTER TABLE Couverts ADD CONSTRAINT FKCouverts516955 FOREIGN KEY (TypeCouvertid) REFERENCES TypeCouvert (id);
ALTER TABLE Verres ADD CONSTRAINT FKVerres867222 FOREIGN KEY (TypeVerreid) REFERENCES TypeVerre (id);
ALTER TABLE Etape ADD CONSTRAINT FKEtape821645 FOREIGN KEY (Recetteid) REFERENCES Recette (id);
ALTER TABLE Etapes_Denrees ADD CONSTRAINT FKEtapes_Den472296 FOREIGN KEY (EtapeId) REFERENCES Etape (id);
ALTER TABLE Etapes_Denrees ADD CONSTRAINT FKEtapes_Den395636 FOREIGN KEY (DenreeId) REFERENCES Denree (Id);
ALTER TABLE Assiettes ADD CONSTRAINT FKAssiettes359994 FOREIGN KEY (MaterielCommunid) REFERENCES MaterielCommun (id);
ALTER TABLE Couverts ADD CONSTRAINT FKCouverts20134 FOREIGN KEY (MaterielCommunid) REFERENCES MaterielCommun (id);
ALTER TABLE Verres ADD CONSTRAINT FKVerres365742 FOREIGN KEY (MaterielCommunid) REFERENCES MaterielCommun (id);
ALTER TABLE Etape_Appareil ADD CONSTRAINT FKEtape_Appa477852 FOREIGN KEY (EtapeId) REFERENCES Etape (id);
ALTER TABLE Etape_Appareil ADD CONSTRAINT FKEtape_Appa359192 FOREIGN KEY (AppareilId) REFERENCES Appareil (Id);
ALTER TABLE Etapes_Ustensiles ADD CONSTRAINT FKEtapes_Ust598866 FOREIGN KEY (Etapesid) REFERENCES Etape (id);
ALTER TABLE Etapes_Ustensiles ADD CONSTRAINT FKEtapes_Ust618614 FOREIGN KEY (Ustensilesid) REFERENCES Ustensile (Id);

