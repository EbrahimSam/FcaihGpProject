using Microsoft.AspNetCore.Identity;

namespace FcaihGpProject.Models
{
    public class Client
    {
        public Guid Id { get; set; }
        public int FinshedContractsCount { get; set; }
        public int UnfinshedContractsCount { get; set; }
        public string NationalID { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        


}   
}
