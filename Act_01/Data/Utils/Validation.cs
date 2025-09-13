using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Act_01.Data.Utils
{
    public static class Validation
    {
        public static string GetString(this DataRow row, string column)
        {
            if (row == null)
            {
                throw new InvalidOperationException($"La fila es null.");
            }
            if (row.IsNull(column))
            {
                throw new InvalidOperationException($"La columna {column} no puede ser null.");
            }
            var value = row[column];
            if (value is string str)
            { return Convert.ToString(value); }

            throw new InvalidOperationException();
        }
        public static int GetInt(this DataRow row, string column)
        {
            if (row == null)
            {
                throw new InvalidOperationException($"La fila es null.");
            }
            if (row.IsNull(column))
            {
                throw new InvalidOperationException($"La columna {column} no puede ser null.");
            }
            else
            {
                return Convert.ToInt32(row[column]);
            }
        }
        public static decimal GetDecimal(this DataRow row, string column)
        {
            if (row == null)
            {
                throw new InvalidOperationException($"La fila es null.");
            }
            if (row.IsNull(column))
            {
                throw new InvalidOperationException($"La columna {column} no puede ser null.");
            }
            else
            {
                return Convert.ToDecimal(row[column]);
            }
        }
        public static DateTime GetDateTime(this DataRow row, string column)
        {
            if (row == null)
            {
                throw new InvalidOperationException($"La fila es null.");
            }
            if (row.IsNull(column))
            {
                throw new InvalidOperationException($"La columna {column} no puede ser null.");
            }
            else
            {
                return Convert.ToDateTime(row[column]);
            }
        }
    }
}
