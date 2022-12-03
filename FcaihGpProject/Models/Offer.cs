namespace FcaihGpProject.Models
{
    public class Offer
    {
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Description { get; set; }
        public int? OfferPrice { get; set; }
        public int? DaysOfWork { get; set; }
        public Guid ProviderId { get; set; }
        public virtual Provider Provider { get; set; }
        public Guid RequestId { get; set; }
        public virtual Request Request { get; set; }

    }
}
