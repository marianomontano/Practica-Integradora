using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FakeAcceso : IAcceso
    {
        public bool Escribir(string consulta, Hashtable parametros)
        {
            return true;
        }

        public DataTable Leer(string consulta)
        {
            DataTable tabla = new DataTable("Productos");
            tabla.Columns.Add("Id", typeof(int));
            tabla.Columns.Add("Nombre", typeof(string));
            tabla.Columns.Add("Precio", typeof(float));
            tabla.Columns.Add("Stock", typeof(int));

            tabla.Rows.Add(1, "Producto1", 100, 30);
            tabla.Rows.Add(2, "Producto2", 150, 30);
            tabla.Rows.Add(3, "Producto3", 200, 30);
            tabla.Rows.Add(4, "Producto4", 250, 30);
            tabla.Rows.Add(5, "Producto5", 300, 30);
            tabla.Rows.Add(6, "Producto6", 350, 30);
            tabla.Rows.Add(7, "Producto7", 400, 30);

            tabla.AcceptChanges();
            return tabla;
        }
    }
}
