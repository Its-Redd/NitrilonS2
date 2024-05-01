namespace Nitrilon.Entities
{
    public class Membership
    {
        #region Fields
        private int membershipId;
        private string name;
        private string description;

        #endregion

        #region Constructors

        public Membership(int membershipId, string name, string description)
        {
            MembershipId = membershipId;
            Name = name;
            Description = description;
        }

        #endregion

        #region Properties

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
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or empty");
                }
                name = value;
            }
        }

        public string Description
        {
            get => description;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Description cannot be null or empty");
                }
                description = value;
            }
        }

        #endregion
    }
}
