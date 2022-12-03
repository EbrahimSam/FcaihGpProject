using FcaihGpProject.Data;
using FcaihGpProject.Infrastructure;
using FcaihGpProject.Models;

namespace FcaihGpProject.Repositories
{
    public class ClientRepo : IRepoClient
    {
        private readonly ApplicationDbContext DB;

        public Response Create(Client Client)
        {
            try
            {
                DB.Add(Client);
                DB.SaveChanges();
                return new Response() { Id = Client.Id, success = true, Message = "Client is Added" };
            }
            catch (Exception e)
            {
                return new Response() { success = false, Message = e.Message };
            }
        }

        public Response Delete(Guid Id)
        {

            Client Client = DB.Clients.Where(p => p.Id == Id).SingleOrDefault();
            if (Client != null)
            {
                try
                {
                    DB.Remove(Client);
                    DB.SaveChanges();
                    return new Response() { success = true, Message = "Client is Deleted" };
                }
                catch (Exception e)
                {
                    return new Response() { success = false, Message = e.Message };
                }
            }
            return new Response() { success = false, Message = "Client is not Found" };

        }

        public Client Get(Guid Id)
        {
            Client Client = DB.Clients.Where(p => p.Id == Id).SingleOrDefault();
            return Client;
        }

        public List<Client> GetAll()
        {
            var Clients = DB.Clients.ToList();
            return Clients;
        }

        public Response Update(Client Client)
        {
            Client OldClient = DB.Clients.Where(p => p.Id == Client.Id).SingleOrDefault();
            //TODO: Link Client to Identity Users First -- Do not Use Identity 
            return new Response();
        }

       
    }
}
