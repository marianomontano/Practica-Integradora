using System.Collections;
using System.Data;

namespace DAL
{
    public interface IAcceso
    {
        bool Escribir(string consulta, Hashtable parametros);
        DataTable Leer(string consulta);
    }
}