using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Autofac.Extras.Moq;
using BE;
using DAL;
using MPP;
using Xunit;

namespace UnitTests
{
    public class DalTests
    {
        [Fact]
        public void Escribir_GuardaDatosEnBbDd()
        {
            using (var mock = AutoMock.GetLoose())
            {
                // Arrange
                mock.Mock<IAcceso>()
                    .Setup(x => x.Escribir("sp_alta_producto", ParametrosSql()))
                    .Returns(true);

                 var clase = mock.Create<MapperProductos>();

                var producto = new EntidadProducto
                {
                    Nombre = "Producto 4",
                    Precio = 110,
                    Stock = 5
                };

                // Act
                var expected = true;
                var actual = clase.Escribir(producto);

                // Assert
                Assert.Equal(expected, actual);
            }
        }

        [Fact]
        public void Leer_LeeDatosDeBbDd()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IAcceso>()
                    .Setup(x => x.Leer("sp_listar_producto"))
                    .Returns(TablaDePrueba());

                var clase = mock.Create<MapperProductos>();
                var expected = TablaDePrueba();
                var actual = clase.Leer();

                Assert.True(actual != null);
                Assert.Equal(expected.Rows.Count, actual.Count);
            }
        }

        private DataTable TablaDePrueba()
        {
            DataTable tabla = new DataTable("Productos");
            tabla.Columns.Add("Id", typeof(Int32));
            tabla.Columns.Add("Nombre", typeof(string));
            tabla.Columns.Add("Precio", typeof(float));
            tabla.Columns.Add("Stock", typeof(int));

            tabla.Rows.Add(1, "Producto 1", 100, 1);
            tabla.Rows.Add(2, "Producto 2", 120, 5);
            tabla.Rows.Add(3, "Producto 3", 50, 20);

            return tabla;
        }

        private Hashtable ParametrosSql()
        {
            Hashtable parametros = new Hashtable();
            parametros.Add("@nombre", "Producto 4");
            parametros.Add("@precio", 110);
            parametros.Add("@stock", 5);

            return parametros;
        }
    }
}
