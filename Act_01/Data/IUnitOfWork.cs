using Act_01.Data.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Act_01.Data
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        void Rollback();
        int SaveChangesWhitOutput(string sp, string paramOutput, List<ParameterSP>? parameters = null);
        int SaveChanges(string sp, List<ParameterSP>? parameters = null);
        DataTable? ExecuteSPQuery(string sp, List<ParameterSP>? parameters = null);
        int ExecuteSPWithReturn(string sp, List<ParameterSP>? parameters = null);
        int ExecuteSPNonQuery(string sp, List<ParameterSP>? parameters = null);
    }
}
