using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace Testing
{
    [TestClass]
    public class InventarioTest
    {
        [TestMethod]
        public void OperadorIgual_ProductoExistente_DeberiaRetornarTrue()
        {
            // Arrange
            bool resultadoEsperado = true;
            Inventario<ProductoGamer> inventario = new Inventario<ProductoGamer>();
            ProductoGamer producto = new Teclado(1,"Tec1",EMarcasAutorizadas.Asus,100,ETipoTeclado.Mecanico,true,true);
            inventario.Productos.Add(producto);

            // Act
            bool resultado = inventario == producto;

            // Assert
            Assert.AreEqual(resultadoEsperado, resultado);
        }

        [TestMethod]
        public void OperadorIgual_ProductoNoExistente_DeberiaRetornarFalse()
        {
            // Arrange
            bool resultadoEsperado = false;
            Inventario<ProductoGamer> inventario = new Inventario<ProductoGamer>();
            ProductoGamer producto = new Teclado(1, "Tec1", EMarcasAutorizadas.Asus, 100, ETipoTeclado.Mecanico, true, true);

            // Act
            bool resultado = inventario == producto;

            // Assert
            Assert.AreEqual(resultadoEsperado, resultado);
        }


        [TestMethod]
        public void OperadorNoIgual_ProductoNoExistente_DeberiaRetornarTrue()
        {
            // Arrange
            bool resultadoEsperado = true;
            Inventario<ProductoGamer> inventario = new Inventario<ProductoGamer>();
            ProductoGamer producto = new Teclado(1, "Tec1", EMarcasAutorizadas.Asus, 100, ETipoTeclado.Mecanico, true, true);

            // Act
            bool resultado = inventario != producto;

            // Assert
            Assert.AreEqual(resultadoEsperado, resultado);
        }

        [TestMethod]
        public void OperadorNoIgual_ProductoExistente_DeberiaRetornarFalse()
        {
            // Arrange
            bool resultadoEsperado = false;
            Inventario<ProductoGamer> inventario = new Inventario<ProductoGamer>();
            ProductoGamer producto = new Teclado(1, "Tec1", EMarcasAutorizadas.Asus, 100, ETipoTeclado.Mecanico, true, true);
            inventario.Productos.Add(producto);

            // Act
            bool resultado = inventario != producto;

            // Assert
            Assert.AreEqual(resultadoEsperado, resultado);
        }

        [TestMethod]
        public void OperadorSuma_ProductoNoExistente_DeberiaAgregarProducto()
        {
            // Arrange
            Inventario<ProductoGamer> inventario = new Inventario<ProductoGamer>();
            ProductoGamer producto = new Teclado(1, "Tec1", EMarcasAutorizadas.Asus, 100, ETipoTeclado.Mecanico, true, true);

            // Act
            inventario += producto;

            // Assert
            Assert.IsTrue(inventario.Productos.Contains(producto));
        }

        [TestMethod]
        public void OperadorResta_ProductoExistente_DeberiaEliminarProducto()
        {
            // Arrange
            Inventario<ProductoGamer> inventario = new Inventario<ProductoGamer>();
            ProductoGamer producto = new Teclado(1, "Tec1", EMarcasAutorizadas.Asus, 100, ETipoTeclado.Mecanico, true, true);
            inventario.Productos.Add(producto);

            // Act
            inventario -= producto;

            // Assert
            Assert.IsFalse(inventario.Productos.Contains(producto));
        }

        [TestMethod]
        public void OperadorResta_ProductoNoExistente_DeberiaNoEliminarProducto()
        {
            // Arrange
            Inventario<ProductoGamer> inventario = new Inventario<ProductoGamer>();
            ProductoGamer producto = new Teclado(1, "Tec1", EMarcasAutorizadas.Asus, 100, ETipoTeclado.Mecanico, true, true);
            inventario.Productos.Add(producto);
            ProductoGamer producto2 = new Teclado(2, "Tec2", EMarcasAutorizadas.Logitech, 120, ETipoTeclado.Mecanico, true, true);

            // Act
            inventario -= producto2;

            // Assert
            Assert.IsFalse(inventario.Productos.Contains(producto2));
        }
    }
}