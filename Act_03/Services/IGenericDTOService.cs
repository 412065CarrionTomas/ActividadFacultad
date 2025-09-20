namespace Act_03.Services
{
    public interface IGenericDTOService<Tentity> where Tentity : class
    {
        List<Tentity> GetAllDTO();
        Tentity? GetDTOById(int id);
        bool InsertDTO(Tentity tentity);
        bool UpdateDTO(int id, Tentity tentity);
        bool DeleteDTO(int id);
    }
}
