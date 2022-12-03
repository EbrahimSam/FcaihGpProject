using FcaihGpProject.Models;

namespace FcaihGpProject.Infrastructure
{
    public interface IRepoContract
    {
        List<Contract> GetAll();
        Contract Get(Guid Id);
        Response Create(Contract Contract);
        Response Update(Contract Contract);
        Response Delete(Guid Id);
    }
}
