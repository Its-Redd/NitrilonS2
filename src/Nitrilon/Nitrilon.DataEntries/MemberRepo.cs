using Microsoft.Data.SqlClient;

using Nitrilon.Entities;

namespace Nitrilon.DataAccess
{
    public class MemberRepo : Repository
    {
        public MemberRepo() : base()
        {

        }



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

        public void CreateMember(Member member)
        {
            string sql = $"INSERT INTO Members (MembershipId, Name, JoinDate, PhoneNumber, EmailAdress) VALUES ({member.MembershipId}, '{member.Name}', '{member.JoinDate}', '{member.PhoneNumber}', '{member.EmailAdress}');";

            // Execute query:
            Execute(sql);

            CloseConnection();
        }

        // Delete member by id
        public void DeleteMember(int memberId)
        {
            string sql = $"DELETE FROM Members WHERE MemberId = {memberId};";

            // Execute query:
            Execute(sql);

            CloseConnection();
        }

        // Update member by id
        public void UpdateMember(Member member)
        {
            string sql = $"UPDATE Members SET MembershipId = {member.MembershipId}, Name = '{member.Name}', JoinDate = '{member.JoinDate}', PhoneNumber = '{member.PhoneNumber}', EmailAdress = '{member.EmailAdress}' WHERE MemberId = {member.MemberId};";

            // Execute query:
            Execute(sql);

            CloseConnection();
        }

        // might change
        public Member GetMemberById(int memberId)
        {
            Member member = default;

            string sql = $"SELECT * FROM Members WHERE MemberId = {memberId};";

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

                member = new(id, membershipId, name, joinDate, phoneNumber, emailAdress);
            }

            CloseConnection();
            return member;
        }

        public List<Member> GetMembersByMembership(int membershipId)
        {
            List<Member> members = new List<Member>();

            string sql = $"SELECT * FROM Members WHERE MembershipId = {membershipId};";

            // Execute query:
            SqlDataReader reader = Execute(sql);

            // Retrieve data from the data reader:
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["MemberId"]);
                membershipId = Convert.ToInt32(reader["MembershipId"]);
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



    }
}