namespace FcaihGpProject.Models
{
    public class Request
    {
        public Guid Id { get; set; }    
        public DateTime CreatedOn { get; set; }
        public string Description { get; set;  }
        public int? RequestPrice { get; set;}
        public DateTime? DeadLine { get; set; }
        public int? DaysOfWork { get; set; }
        public Guid ClientId { get; set; }
        public virtual Client Client { get; set; }
        public Guid? ProviderId { get; set; }
        public virtual Provider? Provider { get; set; }




    }
}
