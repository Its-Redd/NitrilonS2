using Microsoft.Data.SqlClient;

using Nitrilon.Entities;

using System.Data;

namespace Nitrilon.DataAccess
{
    public class Repository
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NitrilonDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public List<Event> GetAllEvents()
        {
            List<Event> events = new List<Event>();

            string sql = $"SELECT * FROM Events;";

            // 1: make a SqlConnection object:
            SqlConnection connection = new SqlConnection(connectionString);

            // 2: make a SqlCommand object:
            SqlCommand command = new SqlCommand(sql, connection);

            // TODO: try catchify this:
            // 3. Open the connection:
            connection.Open();

            // 4. Execute query:
            SqlDataReader reader = command.ExecuteReader();

            // 5. Retrieve data from the data reader:
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["EventId"]);
                DateTime date = Convert.ToDateTime(reader["Date"]);
                string name = Convert.ToString(reader["Name"]);
                int attendees = Convert.ToInt32(reader["Attendees"]);
                string description = Convert.ToString(reader["Description"]);

                Event e = new(id, name, date, attendees, description);

                events.Add(e);
            }

            // 6. Close the connection when it is not needed anymore:
            connection.Close();

            return events;
        }

        public EventRatingData GetEventRatingDataBy(int eventId)
        {
            int badRatingCount = 0;
            int neutralRatingCount = 0;
            int goodRatingCount = 0;
            EventRatingData eventRatingData = default;

            string sql = $"EXEC CountAllowedRatingsForEvent @EventId = {eventId}";

            // 1: make a SqlConnection object:
            SqlConnection connection = new SqlConnection(connectionString);

            // 2: make a SqlCommand object:
            SqlCommand command = new SqlCommand(sql, connection);

            // TODO: try catchify this:
            // 3. Open the connection:
            connection.Open();

            // 4. Execute query:
            SqlDataReader reader = command.ExecuteReader();

            // 5. Retrieve data from the data reader:
            while (reader.Read())
            {
                badRatingCount = Convert.ToInt32(reader["RatingId1Count"]);
                neutralRatingCount = Convert.ToInt32(reader["RatingId2Count"]);
                goodRatingCount = Convert.ToInt32(reader["RatingId3Count"]);
                eventRatingData = new(badRatingCount, neutralRatingCount, goodRatingCount);
            }
            connection.Close();

            return eventRatingData;
        }

        public int Save(Event newEvent)
        {
            int newId = 0;

            // TODO: handle attendees when the event is not yet over.
            // Don't forget to format a date as 'yyyy-MM-dd'
            string sql = $"INSERT INTO Events (Date, Name, Attendees, Description) VALUES ('{newEvent.Date.ToString("yyyy-MM-dd")}', '{newEvent.Name}', {newEvent.Attendees}, '{newEvent.Description}'); SELECT SCOPE_IDENTITY();";

            // 1: make a SqlConnection object:
            SqlConnection connection = new SqlConnection(connectionString);

            // 2: make a SqlCommand object:
            SqlCommand command = new SqlCommand(sql, connection);

            // 3. Open the connection:
            connection.Open();

            // 4. Execute the insert command and get the newly created id for the row:
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                newId = (int)sqlDataReader.GetDecimal(0);
            }

            // 5. Close the connection when it is not needed anymore:
            connection.Close();

            return newId;
        }

        public int SaveEventRating(int eventId, int ratingId)
        {
            int newId = 0;

            // TODO: handle attendees when the event is not yet over.
            // Don't forget to format a date as 'yyyy-MM-dd'
            string sql = $"INSERT INTO EventRatings (EventId, RatingId) VALUES ({eventId},{ratingId});";

            // 1: make a SqlConnection object:
            SqlConnection connection = new SqlConnection(connectionString);

            // 2: make a SqlCommand object:
            SqlCommand command = new SqlCommand(sql, connection);

            // 3. Open the connection:
            connection.Open();

            // 4. Execute the insert command and get the newly created id for the row:
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                newId = (int)sqlDataReader.GetDecimal(0);
            }

            // 5. Close the connection when it is not needed anymore:
            connection.Close();

            return newId;
        }

        public (int, int, int) GetRatingsFor(Event ev)
        {
            // 1: make a SqlConnection object:
            SqlConnection connection = new SqlConnection(connectionString);

            // 2: make a SqlCommand object:
            SqlCommand command = new SqlCommand("CountAllowedRatingsForEvent", connection);

            connection.Open();
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@EventId", ev.Id);
            int ratingId1Count = 0, ratingId2Count = 0, ratingId3Count = 0;
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    ratingId1Count = Convert.ToInt32(reader["RatingId1Count"]);
                    ratingId2Count = Convert.ToInt32(reader["RatingId2Count"]);
                    ratingId3Count = Convert.ToInt32(reader["RatingId3Count"]);

                    Console.WriteLine($"RatingId 1 count: {ratingId1Count}");
                    Console.WriteLine($"RatingId 2 count: {ratingId2Count}");
                    Console.WriteLine($"RatingId 3 count: {ratingId3Count}");
                }
                else
                {
                    Console.WriteLine("No data found for the specified EventId.");
                }
            }

            return (ratingId1Count, ratingId2Count, ratingId3Count);
        }
    }

 
}