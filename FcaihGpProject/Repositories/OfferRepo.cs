using FcaihGpProject.Data;
using FcaihGpProject.Models;

namespace FcaihGpProject.Repositories
{
    public class OfferRepo
    {
        private readonly ApplicationDbContext DB;

        public Response Create(Offer Offer)
        {
            try
            {
                DB.Add(Offer);
                DB.SaveChanges();
                return new Response() { Id = Offer.Id, success = true, Message = "Offer is Added" };
            }
            catch (Exception e)
            {
                return new Response() { success = false, Message = e.Message };
            }
        }

        public Response Delete(Guid Id)
        {

            Offer Offer = DB.Offers.Where(p => p.Id == Id).SingleOrDefault();
            if (Offer != null)
            {
                try
                {
                    DB.Remove(Offer);
                    DB.SaveChanges();
                    return new Response() { success = true, Message = "Offer is Deleted" };
                }
                catch (Exception e)
                {
                    return new Response() { success = false, Message = e.Message };
                }
            }
            return new Response() { success = false, Message = "Offer is not Found" };

        }

        public Offer Get(Guid Id)
        {
            Offer Offer = DB.Offers.Where(p => p.Id == Id).SingleOrDefault();
            return Offer;
        }

        public List<Offer> GetAll()
        {
            var Offers = DB.Offers.ToList();
            return Offers;
        }

        public Response Update(Offer Offer)
        {
            Offer OldOffer = DB.Offers.Where(p => p.Id == Offer.Id).SingleOrDefault();
            //TODO: Link Offer to Identity Users First -- Do not Use Identity 
            return new Response();
        }
        public List<Offer> GetByRequest(Guid RequestId)
        {
            return DB.Offers.Where(offer => offer.RequestId == RequestId).ToList();
        }


    }
}
}
