-- Vehicle

create table Vehicle (
	Id int primary key identity(1,1),
	MarkModel nvarchar(255) not null,
	Year int not null,
	Plate nvarchar(255) not null
);

ALTER TABLE Vehicle
ADD VehicleTypeId INT;

ALTER TABLE Vehicle
ADD CONSTRAINT FK_Vehicle_VehicleType
FOREIGN KEY (VehicleTypeId) REFERENCES VehicleType(Id);

select * from Vehicle


create table VehicleType (
	Id int primary key identity(1,1),
	Name nvarchar(255) not null,
	Description nvarchar(255)
);

select * from VehicleType