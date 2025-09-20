using Act_01.Domain;

namespace Act_03.Services
{
    public interface IGenericService<Tentity> where Tentity :class
    {
        List<Tentity> GetAll();
        Tentity? GetById(int id);
        bool Insert(Tentity tentity);
        bool Update(int id, Tentity tentity);
        bool Delete(int id);
    }
}
