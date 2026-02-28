
CREATE PROCEDURE sp_GetSources
AS
BEGIN
	SELECT DISTINCT Source FROM dbo.Flights
END


CREATE PROCEDURE sp_GetDestinations
AS
BEGIN
	SELECT DISTINCT Destination FROM dbo.Flights
END



use [FlightSearchMVC]

ALTER PROCEDURE sp_SearchFlights
@Source nvarchar(100),
@Destination nvarchar(100),
@Persons int
AS
BEGIN
	SELECT FlightId, FlightName, FlightType,Source, Destination, PricePerSeat * @Persons AS TotalCost
	FROM dbo.Flights
	WHERE Source = @Source 
	AND Destination = @Destination;
END




CREATE PROCEDURE sp_SearchFlightsWithHotels
    @Source NVARCHAR(100),
    @Destination NVARCHAR(100),
    @Persons INT
AS
BEGIN
    SELECT 
        f.FlightId,
        f.FlightName,
        f.Source,
        f.Destination,
        h.HotelName,
        (f.PricePerSeat * @Persons) + h.PricePerDay AS TotalCost
    FROM Flights f
    INNER JOIN Hotels h 
        ON f.Destination = h.Location
    WHERE f.Source = @Source
      AND f.Destination = @Destination;
END