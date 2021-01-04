using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Data;
using DAL;
using BE;

namespace MPP
{
    public class MapperProductos : IMapperProductos
    {
        IAcceso dal;

        public MapperProductos(IAcceso _dal)
        {
            dal = _dal;
        }

        public bool Escribir(EntidadProducto producto)
        {
            Hashtable parametros = new Hashtable();
            string consulta = "sp_alta_producto";
            if (producto.Id != 0)
            {
                consulta = "sp_modificar_producto";
                parametros.Add("@id", producto.Id);
            }
            parametros.Add("@nombre", producto.Nombre);
            parametros.Add("@precio", producto.Precio);
            parametros.Add("@stock", producto.Stock);

            bool resultado = dal.Escribir(consulta, parametros);
            return resultado;
        }

        public bool Eliminar(EntidadProducto producto)
        {
            Hashtable parametros = new Hashtable();
            string consulta = "sp_baja_producto";
            parametros.Add("@id", producto.Id);

            bool resultado = dal.Escribir(consulta, parametros);
            return resultado;
        }

        public List<EntidadProducto> Leer()
        {
            DataTable table = new DataTable();
            string consulta = "sp_listar_producto";
            List<EntidadProducto> listaproductos = new List<EntidadProducto>();
            table = dal.Leer(consulta);
            foreach (DataRow fila in table.Rows)
            {
                var producto = new EntidadProducto();
                producto.Id = Convert.ToInt32(fila[0]);
                producto.Nombre = fila[1].ToString();
                producto.Precio = float.Parse(fila[2].ToString());
                producto.Stock = Convert.ToInt32(fila[3]);
                listaproductos.Add(producto);
            }
            return listaproductos;
        }

        public EntidadProducto Filtrar(EntidadProducto producto)
        {
            return Leer().FirstOrDefault(p => p.Id == producto.Id);
        }
    }
}
