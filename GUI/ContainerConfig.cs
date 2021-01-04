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

            builder.RegisterType<Acceso>().As<IAcceso>();
            builder.RegisterType<MapperProductos>().As<IMapperProductos>();
            builder.RegisterType<BLLProducto>().As<IBLLProducto>();
            builder.RegisterType<FormProductos>().AsSelf();
            builder.RegisterType<Menu>();

            return builder.Build();
        }
    }
}
