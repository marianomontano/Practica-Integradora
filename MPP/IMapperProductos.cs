using System.Collections.Generic;
using BE;

namespace MPP
{
    public interface IMapperProductos
    {
        bool Eliminar(EntidadProducto producto);
        bool Escribir(EntidadProducto producto);
        EntidadProducto Filtrar(EntidadProducto producto);
        List<EntidadProducto> Leer();
    }
}