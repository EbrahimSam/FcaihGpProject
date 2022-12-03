namespace FcaihGpProject.Models
{
    public class Provider
    {
        public Guid Id { get; set; }
        public double Score { get; set; }
        public double  BadRateFactor {get;set;}
        public double Rate { get; set;  }
        public int FinshedContractsCount { get; set; }
        public int UnfinshedContractsCount { get; set; }
        public string NationalID { get; set; }
        public string City { get; set; }
        public string Address { get; set; }

    }
   
}
