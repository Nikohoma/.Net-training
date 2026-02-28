using FlightSearchEngine.Models;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Data;
using Microsoft.Data.SqlClient;
using System.Data;


namespace FlightSearchEngine.Data
{
    public class DatabaseHelper
    {
        private readonly string _connectionString;
        public DatabaseHelper(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<List<string>> GetSourcesAsync()
        {
            var sources = new List<string>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_GetSources", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                await con.OpenAsync();

                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        sources.Add(reader["Source"].ToString());
                    }
                }
            }

            return sources;
        }

        public async Task<List<string>> GetDestinationsAsync()
        {
            var destinations = new List<string>();
            using var con = new SqlConnection(_connectionString);
            using (var cmd = new SqlCommand("sp_GetDestinations", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                await con.OpenAsync();
                using(var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        destinations.Add(reader["Destination"].ToString());
                    }
                }
            }
            return destinations;
        }

        public async Task<List<FlightResult>> SearchFlightsAsync(string source, string destination, int persons)
        {
            var flights = new List<FlightResult>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_SearchFlights", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Source", source);
                cmd.Parameters.AddWithValue("@Destination", destination);
                cmd.Parameters.AddWithValue("@Persons", persons);

                await con.OpenAsync();

                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    string[] x;
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.WriteLine(reader.GetName(i));
                    }
                    while (await reader.ReadAsync())
                    {
                        flights.Add(new FlightResult
                        {
                            FlightId = Convert.ToInt32(reader["FlightId"]),
                            FlightName = reader["FlightName"].ToString(),
                            FlightType = reader["FlightType"].ToString(),
                            Source = reader["Source"].ToString(),
                            Destination = reader["Destination"].ToString(),
                            TotalCost = Convert.ToDecimal(reader["TotalCost"])
                        });
                    }
                }
            }

            return flights;
        }

        public async Task<List<FlightHotelResult>> SearchFlightsWithHotelsAsync(string source, string destination, int persons)
        {
            var flights = new List<FlightHotelResult>();
            var con = new SqlConnection(_connectionString);
            using (var cmd = new SqlCommand("sp_SearchFlightsWithHotels", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Source", source);
                cmd.Parameters.AddWithValue("@Destination", destination);
                cmd.Parameters.AddWithValue("@Persons", persons);
                await con.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while(await reader.ReadAsync())
                    {
                        flights.Add(new FlightHotelResult()
                        {
                            FlightId = Convert.ToInt32(reader["FlightId"]),
                            FlightName = reader["FlightName"].ToString(),
                            Source = reader["Source"].ToString(),
                            Destination = reader["Destination"].ToString(),
                            HotelName = reader["HotelName"].ToString(),
                            TotalCost = Convert.ToDecimal(reader["TotalCost"])
                        });
                    }
                }
            }
            return flights;
        }



    }
}
