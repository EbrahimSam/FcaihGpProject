using FcaihGpProject.Models;

namespace FcaihGpProject.Infrastructure
{
    public interface IRepoOffer
    {
        List<Offer> GetAll();
        Offer Get(Guid Id);
        Response Create(Offer Offer);
        Response Update(Offer Offer);
        Response Delete(Guid Id);
        List<Offer> GetByRequest(Guid RequestId);
    }
}
