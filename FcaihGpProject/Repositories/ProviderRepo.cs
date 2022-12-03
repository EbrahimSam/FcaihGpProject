
using FcaihGpProject.Data;
using FcaihGpProject.Infrastructure;
using FcaihGpProject.Models;
using System.Linq.Expressions;

namespace FcaihGpProject.Repositories
{
    public class ProviderRepo : IRepoProvider
    {
    private readonly ApplicationDbContext DB;
        public Response Create(Provider provider)
        {
            try
            {
                DB.Add(provider);
                DB.SaveChanges();
                return new Response() { Id = provider.Id, success = true, Message = "Provider is Added" };
            }
            catch (Exception e) {
                return new Response() { success = false, Message = e.Message };
            }
        }

        public Response Delete(Guid Id)
        {

            Provider provider = DB.Providers.Where(p => p.Id == Id).SingleOrDefault();
            if (provider != null)
            {
                try
                {
                    DB.Remove(provider);
                    DB.SaveChanges();
                    return new Response() { success = true, Message = "Provider is Deleted" };
                }
                catch (Exception e)
                {
                    return new Response() { success = false, Message = e.Message };
                }
            }
            return new Response() { success = false, Message = "Provider is not Found" };

        }

        public Provider Get(Guid Id)
        {
            Provider provider = DB.Providers.Where(p => p.Id == Id).SingleOrDefault();
            return provider;
        }

        public List<Provider> GetAll()
        {
            var Providers = DB.Providers.ToList();
            return Providers;
        }

        public Response Update(Provider provider)
        {
            Provider Oldprovider = DB.Providers.Where(p => p.Id == provider.Id).SingleOrDefault();
            //TODO: Link provider to Identity Users First -- Do not Use Identity 
            return new Response();
        }

       public  List<Provider> GetAllWithCondition(Expression<Func<Provider,bool>> Filter)
        {
           return   DB.Providers.Where(Filter).ToList(); 
        }

    }
}
