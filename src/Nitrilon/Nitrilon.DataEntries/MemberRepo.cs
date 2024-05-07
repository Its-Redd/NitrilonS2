using Microsoft.Data.SqlClient;

using Nitrilon.Entities;

namespace Nitrilon.DataAccess
{
    public class MemberRepo : Repository
    {
        public MemberRepo() : base()
        {

        }

        /// <summary>
        /// Get all members from the database and return them as a list.
        /// </summary>
        /// <returns>A list of Member objects.</returns>
        public IEnumerable<Member> GetAllMembers()
        {
            List<Member> members = new List<Member>();

            string sql = $"SELECT * FROM Members;";

            // Execute query:
            SqlDataReader reader = Execute(sql);

            // Retrieve data from the data reader:
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["MemberId"]);
                int membershipId = Convert.ToInt32(reader["MembershipId"]);
                string name = Convert.ToString(reader["Name"]);
                DateTime joinDate = Convert.ToDateTime(reader["JoinDate"]);
                string phoneNumber = Convert.ToString(reader["PhoneNumber"]);
                string emailAdress = Convert.ToString(reader["EmailAdress"]);

                Member m = new(id, membershipId, name, joinDate, phoneNumber, emailAdress);

                members.Add(m);
            }

            CloseConnection();
            return members;
        }

        /// <summary>
        /// Create a new member in the database.
        /// </summary>
        /// <param name="member">The Member object to create.</param>
        public void CreateMember(Member member)
        {
            string sql = $"INSERT INTO Members (MembershipId, Name, JoinDate, PhoneNumber, EmailAdress) VALUES ({member.MembershipId}, '{member.Name}', '{member.JoinDate}', '{member.PhoneNumber}', '{member.EmailAdress}');";

            // Execute query:
            Execute(sql);

            CloseConnection();
        }

        /// <summary>
        /// Delete a member from the database by their ID.
        /// </summary>
        /// <param name="member">The Member object to delete.</param>
        public void DeleteMember(Member member)
        {
            string sql = $"DELETE FROM Members WHERE MemberId = {member.MemberId};";

            // Execute query:
            Execute(sql);

            CloseConnection();
        }

        /// <summary>
        /// Update a member in the database by their ID.
        /// </summary>
        /// <param name="member">The Member object to update.</param>
        public void UpdateMember(Member member)
        {
            string sql = $"UPDATE Members SET MembershipId = {member.MembershipId}, Name = '{member.Name}', JoinDate = '{member.JoinDate}', PhoneNumber = '{member.PhoneNumber}', EmailAdress = '{member.EmailAdress}' WHERE MemberId = {member.MemberId};";

            // Execute query:
            Execute(sql);

            CloseConnection();
        }
    }
}