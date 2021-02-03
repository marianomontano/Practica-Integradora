using BLL;
using DAL;
using GUI;
using MPP;

namespace Servicios
{
    public static class Factory
    {
        public static IAcceso CrearAcceso()
        {
            return new FakeAcceso();
        }

        public static IMapperProductos CrearMapperProductos()
        {
            return new MapperProductos(CrearAcceso());
        }

        public static IBLLProducto CrearBllProducto()
        {
            return new BLLProducto(CrearMapperProductos());
        }

        //public static FormProductos CrearFormProductos()
        //{
        //    return FormProductos.Instancia(CrearBllProducto());
        //}
    }
}
