--CREATE DATABASE SimpleBankDB;
Use SimpleBankDB;

CREATE TABLE Persons(
	PersonID int NOT NULL IDENTITY(1,1),
    LastName varchar(255) NOT NULL,
    FirstName varchar(255) NOT NULL,
	EMail varchar(255) NOT NULL,
	TelNumber varchar(255),
	Address varchar(255) NOT NULL,
	PostCode int NOT NULL,
	Place varchar(255) NOT NULL
    PRIMARY KEY (PersonID)
);

CREATE TABLE AccountTypes(
	AccountTypeID int NOT NULL IDENTITY(1,1),
	InterestRate FLOAT NOT NULL,
	PersonID int NOT NULL,
	PRIMARY KEY (AccountTypeID),
);

CREATE TABLE Accounts(
	AccountID int NOT NULL IDENTITY(1,1),
	Balance FLOAT NOT NULL,
	PersonID int NOT NULL,
	AccountTypeID int NOT NULL,
	PRIMARY KEY (AccountID),
	FOREIGN KEY (PersonID) REFERENCES Persons(PersonID),
	FOREIGN KEY (AccountTypeID) REFERENCES AccountTypes(AccountTypeID)
);
