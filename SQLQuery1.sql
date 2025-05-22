
CREATE TABLE vehicle
  (
     id        INT PRIMARY KEY IDENTITY(1, 1),
     markmodel NVARCHAR(255) NOT NULL,
     year      INT NOT NULL,
     plate     NVARCHAR(255) NOT NULL
  );

ALTER TABLE vehicle
  ADD vehicletypeid INT NULL;

ALTER TABLE vehicle
  ADD CONSTRAINT fk_vehicle_vehicletype FOREIGN KEY (vehicletypeid) REFERENCES
  vehicletype(id);

SELECT *
FROM   vehicle

CREATE TABLE vehicletype
  (
     id          INT PRIMARY KEY IDENTITY(1, 1),
     NAME        NVARCHAR(255) NOT NULL,
     description NVARCHAR(255)
  );

SELECT *
FROM   vehicletype

DELETE FROM vehicletype

DELETE FROM vehicle

DROP TABLE vehicletype

DROP TABLE vehicle 
