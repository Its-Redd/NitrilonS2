using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nitrilon.Entities
{
    internal class Member
    {
        #region Fields and constants
        private int memberId;
        private int membershipId;
        private string name;
        private DateOnly joinDate;
        private string phoneNumber;
        private string emailAdress;
        #endregion

        #region Constructors
        public Member(int memberId, int membershipId, string name, DateOnly joinDate, string phoneNumber, string emailAdress)
        {
            MemberId = memberId;
            MembershipId = membershipId;
            Name = name;
            JoinDate = joinDate;
            PhoneNumber = phoneNumber;
            EmailAdress = emailAdress;
        }
        #endregion

        #region Properties

        public int MemberId
        {
            get => memberId;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("MemberId cannot be negative");
                }
                memberId = value;

            }
        }

        public int MembershipId
        {
            get => membershipId;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("MembershipId cannot be negative");
                }
                membershipId = value;

            }
        }

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentOutOfRangeException("Name cannot be null or empty");
                }
                name = value;

            }
        }

        public DateOnly JoinDate
        {
            get => joinDate;
            set
            {
                if(joinDate < DateOnly.FromDateTime(DateTime.Now.AddYears(-100)))
                {
                    throw new ArgumentOutOfRangeException("Join date cannot be more than 100 year in the past");
                }
                joinDate = value;

            }
        }

        public string PhoneNumber
        {
            get => phoneNumber;
            set
            {
                phoneNumber = value;

            }
        }

        public string EmailAdress
        {
            get => emailAdress;
            set
            {
                emailAdress = value;
            }
        }

        #endregion




    }
}
