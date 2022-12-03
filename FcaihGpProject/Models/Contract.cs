namespace FcaihGpProject.Models
{
    public class Contract
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public Guid ProviderId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DeadLine { get; set; }
        public int Price { get; set; }
        public int ContractStatus { get; set;}
        public virtual Provider Provider { get; set; }
        public virtual Client Client { get; set;  }

    }
}
