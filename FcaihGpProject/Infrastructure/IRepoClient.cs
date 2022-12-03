using FcaihGpProject.Models;

namespace FcaihGpProject.Infrastructure
{
    public interface IRepoClient
    {
        List<Client> GetAll();
        Client Get(Guid Id);
        Response Create(Client Client);
        Response Update(Client Client);
        Response Delete(Guid Id);
    }
}
