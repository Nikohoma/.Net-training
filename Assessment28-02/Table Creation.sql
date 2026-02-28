
CREATE TABLE Flights
(
    FlightId INT PRIMARY KEY IDENTITY(1,1),
    FlightName NVARCHAR(100) NOT NULL,
    FlightType NVARCHAR(50) NOT NULL,
    Source NVARCHAR(100) NOT NULL,
    Destination NVARCHAR(100) NOT NULL,
    PricePerSeat DECIMAL(18,2) NOT NULL
);



CREATE TABLE Hotels
(
    HotelId INT PRIMARY KEY IDENTITY(1,1),
    HotelName NVARCHAR(100) NOT NULL,
    HotelType NVARCHAR(50) NOT NULL,
    Location NVARCHAR(100) NOT NULL,
    PricePerDay DECIMAL(18,2) NOT NULL
);



INSERT INTO Flights VALUES
('Air India 101', 'Domestic', 'Delhi', 'Mumbai', 5000),
('Indigo 202', 'Domestic', 'Delhi', 'Chennai', 4500),
('SpiceJet 303', 'Domestic', 'Mumbai', 'Delhi', 4800),
('Emirates 404', 'International', 'Delhi', 'Dubai', 25000);

INSERT INTO Hotels VALUES
('Taj Mumbai', '5 Star', 'Mumbai', 7000),
('ITC Chennai', '5 Star', 'Chennai', 6500),
('Leela Delhi', '5 Star', 'Delhi', 8000),
('Burj Hotel', 'Luxury', 'Dubai', 20000);

