
using Microsoft.Data.SqlClient;
using Nitrilon.Entities;

namespace Nitrilon.DataAccess
{
    public class Repository
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NitrilonDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public List<Event> GetAllEvents()
        {
            List<Event> events = new List<Event>();

            string sql = "SELECT * FROM Events";

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

                Event e = new()
                {
                    Id = id,
                    Date = date,
                    Name = name,
                    Attendees = attendees,
                    Description = description,
                };

                events.Add(e);
            }

            // 6. Close the connection when it is not needed anymore:
            connection.Close();

            return events;
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
    }
}
