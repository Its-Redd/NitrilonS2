﻿namespace Nitrilon.Entities
{
    public class Member
    {
        #region Fields and constants
        private int memberId;
        private int membershipId;
        private string name;
        private DateTime joinDate;

        private string? phoneNumber;
        private string? emailAdress;

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
            set
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
            set
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
                    throw new ArgumentException("Name cannot be null or empty");
                }
                name = value;
            }
        }

        public DateTime JoinDate
        {
            get => joinDate;
            set
            {
                if (value < DateTime.Now.AddYears(-100))
                {
                    throw new ArgumentException("JoinDate cannot be earlier than 100 years ago");
                }
                joinDate = value;
            }
        }

        public string? EmailAdress
        {
            get => emailAdress;
            set
            {
                // would be better to use a regex to validate email address but
                // since i dont have the time to implement it,
                // i will just check if the string is null or empty
                if (string.IsNullOrWhiteSpace(value))
                {
                    value = "Emailadresse ikke tilknyttet";
                }
                emailAdress = value;
            }
        }


        public string? PhoneNumber
        {
            get => phoneNumber;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    value = "Nummer ikke tilknyttet";
                }
                phoneNumber = value;
            }
        }

        #endregion
    }
}
