--clients
insert into clients values('Random street 123',null);
insert into IndividualClients values (1,'John', 'Smith', '123456789', 'Government ID');
insert into clients values('Another street 123',1);
insert into IndividualClients values (2,'Bob', 'Nowak', '122226799', 'Government ID');
--orders
INSERT INTO Orders (DateOfConclusion, DateOfImplementation, DateOfCompletionPlanned, DateOfCompletionActual, DownPayment, Status, ClientId)
VALUES ('2024-01-20', '2024-02-01', '2024-05-01', '2024-06-01', 500.75, 'InProgress', 1);
INSERT INTO Orders (DateOfConclusion, DateOfImplementation, DateOfCompletionPlanned, DateOfCompletionActual, DownPayment, Status, ClientId)
VALUES ('2024-01-15', '2024-03-01', '2024-07-01', '2024-08-01', 300.50, 'Pending', 2);
--designers
INSERT INTO Designers (Name, Surname, PhoneNumber, Permissions)
VALUES ('John', 'Doe', '123-456-7890', 'DesignPermission');
INSERT INTO Designers (Name, Surname, PhoneNumber, Permissions)
VALUES ('Alice', 'Smith', '987-654-3210', 'DesignPermission');
--playgrounds
INSERT INTO Playgrounds (address, descriptionOfLand, surface, fenced, fenceHeight, OrderId, DesignerId, PlaygroundId)
VALUES ('123 Main St', 'Large green space', 1000.5, 1, 5.5, 1, 1, 1);
INSERT INTO Playgrounds (address, descriptionOfLand, surface, fenced, fenceHeight, OrderId, DesignerId, PlaygroundId)
VALUES ('456 Oak Ave', 'Play area with swings', 800.2, 0, 0, 2, 2, 2);
--employees
INSERT INTO Employees (Name, Surname, PhoneNumber, DateOfEmployment)
VALUES ('Bob', 'Johnson', '111-222-3333', '2023-01-10');
INSERT INTO Employees (Name, Surname, PhoneNumber, DateOfEmployment)
VALUES ('Mary', 'Williams', '444-555-6666', '2022-05-15');
INSERT INTO Employees (Name, Surname, PhoneNumber, DateOfEmployment)
VALUES ('James', 'Anderson', '777-888-9999', '2023-09-20');
INSERT INTO Employees (Name, Surname, PhoneNumber, DateOfEmployment)
VALUES ('Eva', 'Martinez', '123-456-7890', '2021-03-02');
INSERT INTO Employees (Name, Surname, PhoneNumber, DateOfEmployment)
VALUES ('Chris', 'Taylor', '987-654-3210', '2024-01-05');
--devices
INSERT INTO Devices (Name, SecurityCertificate, MinAge, MaxAge, Substrate, DeviceType, lengthOfExit, angleOfFall)
VALUES ('Slide1', 'CERT123', 3, 12, 'Grass','Slide' , 10.5, 30);
INSERT INTO Devices (Name, SecurityCertificate, MinAge, MaxAge, Substrate, DeviceType, lengthOfExit, angleOfFall)
VALUES ('Slide2', 'CERT456', 2, 10, 'Concrete', 'Slide', 8.5, 25);
INSERT INTO Devices (Name, SecurityCertificate, MinAge, MaxAge, Substrate, DeviceType, RopeLength)
VALUES ('Swing1', 'CERT789', 1, 8, 'Grass', 'Swing', 6.0);
INSERT INTO Devices (Name, SecurityCertificate, MinAge, MaxAge, Substrate, DeviceType, RopeLength)
VALUES ('Swing2', 'CERT101', 2, 10, 'Sand', 'Swing', 7.5);
--employees to playgrounds
INSERT INTO Employee_Playground (Id, expiryDate, EmployeeId, PlaygroundId)
VALUES 
(10, '2025-01-31', 1, 1),
(12, '2025-02-28', 2, 1),
(13, '2025-03-31', 3, 1);
INSERT INTO Employee_Playground (Id, expiryDate, EmployeeId, PlaygroundId)
VALUES 
(20, '2025-01-31', 1, 2),
(21, '2025-02-28', 2, 2),
(22, '2025-03-31', 4, 2),
(23, '2025-04-30', 5, 2);
--materials
INSERT INTO Materials VALUES
('Plastic'),
('Wood'),
('Metal');
--assign materials
INSERT INTO Device_Material (MaterialId, DeviceId) VALUES
(1,1),
(3,1),
(1,2),
(2,2),
(3,2),
(2,3),
(1,4),
(2,4);
--images
INSERT INTO DeviceImage VALUES 
('Basic_Slide01',1,'/images/Basic_Slide01'),
('Basic_Slide02',1,'/images/Basic_Slide02'),
('Basic_Slide03',1,'/images/Basic_Slide03'),
('Spiral_Slide01',2,'/images/Spiral_Slide01'),
('Spiral_Slide02',2,'/images/Spiral_Slide02');

