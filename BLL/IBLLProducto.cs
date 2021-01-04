using System.Collections.Generic;
using BE;

namespace BLL
{
    public interface IBLLProducto
    {
        bool Crear(EntidadProducto producto);
        bool Editar(EntidadProducto producto);
        bool Eliminar(EntidadProducto producto);
        List<EntidadProducto> Filtrar(EntidadProducto _producto);
        List<EntidadProducto> Listar();
        List<EntidadProducto> MostrarPrimero();
        List<EntidadProducto> MostrarUltimo();
    }
}