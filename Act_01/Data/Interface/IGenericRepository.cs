using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_Facultad.Data.Interfaces
{
    public interface IGenericRepository<Tentity> where Tentity : class
    {
        List<Tentity> GetAll();
        Tentity? GetById(int id);
        int Save(Tentity entity);
        int Delete(int id);
    }
}
