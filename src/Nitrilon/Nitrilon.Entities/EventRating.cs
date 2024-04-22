namespace Nitrilon.Api.Models
{
    public class EventRating
    {
        public int EventRatingId { 
            get { return EventId; }
            set {
                if (value < 0)
                {
                    throw new ArgumentException("EventRatingId cannot be negative");
                }
                EventId = value; }
        }
        public int EventId { 
            get { return EventId; }
            set {
                if (value <= 0)
                {
                    throw new ArgumentException("EventId cannot be negative");
                }
                EventId = value; }
        }
        public int RatingId {
            get { return RatingId; }
            set { 
                if (value <= 1 || 3 >= value)
                {
                    throw new ArgumentException("RatingId cannot be negative");
                }
                RatingId = value; }
        }
    }
}
