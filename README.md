-- Region syd SQL:
 
CREATE TABLE REGION(
	RegionalID VarChar(2) PRIMARY KEY
);
 
CREATE TABLE DISPONENT(
	DisponentID VarChar(5) PRIMARY KEY, 
	RegionalID VarChar(2) NOT NULL,
 
	FOREIGN KEY (RegionalID) REFERENCES REGION(RegionalID)
);
 
CREATE TABLE ASSIGNMENT (
    RegionalAssignmentID VARCHAR(20) PRIMARY KEY,
    AssignmentType NVARCHAR(50) NOT NULL,
    AssignmentDescription NVARCHAR(400) NOT NULL,
    PatientName NVARCHAR(100) NOT NULL,
    AppointmentTime TIME NOT NULL,
    AppointmentDate DATE NOT NULL,
    StreetNameFrom NVarChar(30) NOT NULL,
    StreetNumberFrom INT NOT NULL,
    ZipCodeFrom INT NOT NULL,
    StreetNameTo NVarChar(30) NOT NULL,
    StreetNumberTo INT NOT NULL,
    ZipCodeTo INT NOT NULL,
    DisponentIDDelegator VarChar(5),
    DisponentIDCreator VarChar(5) NOT NULL,
	FOREIGN KEY (DisponentIDDelegator) REFERENCES DISPONENT(DisponentID), 
    FOREIGN KEY (DisponentIDCreator) REFERENCES DISPONENT(DisponentID)
	);
