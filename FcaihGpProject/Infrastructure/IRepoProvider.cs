using FcaihGpProject.Models;
using System.Linq.Expressions;

namespace FcaihGpProject.Infrastructure
{
    public interface IRepoProvider
    {
        List<Provider> GetAll();
        Provider Get (Guid Id);
        Response Create(Provider provider);
        Response Update(Provider provider);
        Response Delete(Guid Id);
        List<Provider> GetAllWithCondition(Expression<Func<Provider, bool>> Filter); 

    }
}
