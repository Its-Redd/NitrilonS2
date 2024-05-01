using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nitrilon.Entities
{
    public class Member
    {
        #region Fields and constants
        private int memberId;
        private int membershipId;
        private string name;
        private DateTime joinDate;

        private string phoneNumber;
        private string emailAdress;

        #endregion

        #region Constructors
        
        public Member(int memberId, int membershipId, string name, DateTime joinDate, string phoneNumber, string emailAdress)
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
                    throw new ArgumentException("MembershipName cannot be null or empty");
                }
                name = value;
            }
        }

        public DateTime JoinDate
        {
            get => joinDate;
            set
            {
                if (joinDate < DateTime.Now.AddYears(-100))
                {
                    throw new ArgumentOutOfRangeException("JoinDate cannot be earlier than 100 years ago");
                }
                joinDate = value;
            }
        }

        public string EmailAdress
        {
            get => emailAdress;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("EmailAdress cannot be null or empty");
                }
                emailAdress = value;
            }
        }


        public string PhoneNumber
        {
            get => phoneNumber;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("PhoneNumber cannot be null or empty");
                }
                phoneNumber = value;
            }
        }

        #endregion
    }
}
