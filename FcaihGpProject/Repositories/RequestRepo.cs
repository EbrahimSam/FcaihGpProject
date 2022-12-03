using FcaihGpProject.Data;
using FcaihGpProject.Models;
using FcaihGpProject.Infrastructure;


namespace FcaihGpProject.Repositories
{
    public class RequestRepo : IRepoRequest
    {


        private readonly ApplicationDbContext DB;

        public Response Create(Request Request)
        {
            try
            {
                DB.Add(Request);
                DB.SaveChanges();
                return new Response() { Id = Request.Id, success = true, Message = "Request is Added" };
            }
            catch (Exception e)
            {
                return new Response() { success = false, Message = e.Message };
            }
        }

        public Response Delete(Guid Id)
        {

            Request Request = DB.Requests.Where(p => p.Id == Id).SingleOrDefault();
            if (Request != null)
            {
                try
                {
                    DB.Remove(Request);
                    DB.SaveChanges();
                    return new Response() { success = true, Message = "Request is Deleted" };
                }
                catch (Exception e)
                {
                    return new Response() { success = false, Message = e.Message };
                }
            }
            return new Response() { success = false, Message = "Request is not Found" };

        }

        public Request Get(Guid Id)
        {
            Request Request = DB.Requests.Where(p => p.Id == Id).SingleOrDefault();
            return Request;
        }

        public List<Request> GetAll()
        {
            var Requests = DB.Requests.ToList();
            return Requests;
        }

        public Response Update(Request Request)
        {
            Request OldRequest = DB.Requests.Where(p => p.Id == Request.Id).SingleOrDefault();
            return new Response();
        }

        public List<Request> GetClientRequests(Guid id)
        {
            return DB.Requests.Where(req => req.ClientId == id).ToList(); 
        }

    }
}
