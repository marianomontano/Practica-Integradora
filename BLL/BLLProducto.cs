using System.Collections.Generic;
using System.Linq;
using MPP;
using BE;

namespace BLL
{
    public class BLLProducto : IBLLProducto
    {
        IMapperProductos mpp;

        public BLLProducto(IMapperProductos _mpp)
        {
            mpp = _mpp;
        }

        public bool Crear(EntidadProducto producto)
        {
            return mpp.Escribir(producto);
        }

        public bool Editar(EntidadProducto producto)
        {
            return mpp.Escribir(producto);
        }

        public bool Eliminar(EntidadProducto producto)
        {
            return mpp.Eliminar(producto);
        }

        public List<EntidadProducto> Listar()
        {
            List<EntidadProducto> lista = new List<EntidadProducto>();
            return lista = mpp.Leer();
        }

        public List<EntidadProducto> Filtrar(EntidadProducto _producto)
        {
            List<EntidadProducto> lista = new List<EntidadProducto>();
            EntidadProducto producto = new EntidadProducto();
            producto = mpp.Filtrar(_producto);
            lista.Add(producto);
            return lista;
        }

        public List<EntidadProducto> MostrarUltimo()
        {
            List<EntidadProducto> lista = new List<EntidadProducto>();
            lista = mpp.Leer();

            var ultimo = lista.OrderByDescending(p => p.Id).First();

            lista.Clear();
            lista.Add(ultimo);

            return lista;
        }

        public List<EntidadProducto> MostrarPrimero()
        {
            List<EntidadProducto> lista = new List<EntidadProducto>();
            lista = mpp.Leer();

            var primero = lista.OrderBy(p => p.Id).First();

            lista.Clear();
            lista.Add(primero);

            return lista;
        }
    }
}
