using Autofac;
using BLL;
using DAL;
using MPP;

namespace GUI
{
    public class ContainerConfig
    {
        public static IContainer Configurar()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<FakeAcceso>().As<IAcceso>();
            builder.RegisterType<MapperProductos>().As<IMapperProductos>();
            builder.RegisterType<BLLProducto>().As<IBLLProducto>();
            builder.RegisterType<Menu>().SingleInstance();
            builder.RegisterType<FormProductos>().SingleInstance();

            return builder.Build();
        }
    }
}
