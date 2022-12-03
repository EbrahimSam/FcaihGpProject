using FcaihGpProject.Models;

namespace FcaihGpProject.Infrastructure
{
    public interface IRepoRequest
    {

        List<Request> GetAll();
        Request Get(Guid Id);
        Response Create(Request Request);
        Response Update(Request Request);
        Response Delete(Guid Id);
        List<Request> GetClientRequests(Guid id);

    }
}
