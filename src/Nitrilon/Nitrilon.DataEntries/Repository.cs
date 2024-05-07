using Microsoft.Data.SqlClient;

namespace Nitrilon.DataAccess
{
    /// <summary>
    /// Represents a repository for data access operations.
    /// </summary>
    public class Repository
    {
        protected const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NitrilonDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        private SqlConnection connection;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository"/> class.
        /// </summary>
        /// <exception cref="Exception">Thrown when unable to connect to the database.</exception>
        public Repository()
        {
            if (!CanConnect())
            {
                throw new Exception("Cannot connect to the database");
            }
        }

        /// <summary>
        /// Closes the database connection.
        /// </summary>
        protected void CloseConnection()
        {
            if (connection != null && connection.State != System.Data.ConnectionState.Closed)
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Executes the specified SQL query and returns a data reader.
        /// </summary>
        /// <param name="sql">The SQL query to execute.</param>
        /// <returns>A <see cref="SqlDataReader"/> object containing the query results.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the SQL query is null.</exception>
        protected SqlDataReader Execute(string sql)
        {
            if (sql == null)
            {
                throw new ArgumentNullException(nameof(sql));
            }

            connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            return reader;
        }

        /// <summary>
        /// Checks if the repository can connect to the database.
        /// </summary>
        /// <returns>True if the connection is successful, otherwise false.</returns>
        public bool CanConnect()
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                sqlConnection.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}