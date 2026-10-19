# Trabajo Práctico: Pruebas del Software - Uso de un Framework de Testing

* **Lenguaje utilizado:** C#
* **Frameworks y Librerias:** .NET / xUnit y Moq 

## Integrantes
* Cantos Jimenez, Fabricio Ivan
* Ferreyra, Milena Arlene

# Respuestas Teóricas

## Punto 1 -
**¿Puedes identificar pruebas de unidad y de integración en la práctica que se realizó?**
- En esta etapa inicial, implementamos **pruebas unitarias** sobre las clases del dominio (Producto y Tienda). Se evaluaron de forma aislada y directa componentes individuales como la correcta asignación de atributos en el constructor de Producto y la manipulación básica de elementos dentro de la lista de inventario en Tienda.

## Punto 2 - 
**¿Podría haber escrito las pruebas primero antes de modificar el código de la aplicación?**
- Sí, totalmente. Es la base de la metodología **TDD (Test-Driven Development)**.

**¿Cómo sería el proceso de escribir primero los tests? Describe el proceso con tus palabras:**
- Se escribe la prueba unitaria que valida una nueva regla o comportamiento antes de que el código exista, ejecutándola y comprobando que falla pero se detecta, luego se escribe el código mínimo e indispensable en las clases de la aplicación para hacer que la prueba pase exitosamente, por ultimo se limpia y optimiza el código con la total tranquilidad de que la suite de pruebas automatizadas garantiza que no se rompió ninguna funcionalidad .

## Punto 3 -
**En lo que va del trabajo práctico, ¿puedes identificar 'Controladores' y 'Resguardos'?**
- La clase Tienda actúa como un **controlador** o coordinador de la lógica de negocio, mientras que los objetos simulados creados a través de la interfaz IProducto y la librería Moq actúan como **resguardos** o dobles para aislar la unidad bajo prueba de dependencias externas.

**¿Qué es un "test double"?**
- Es un término genérico que se utiliza para denominar a cualquier objeto que reemplaza a un componente real durante la ejecución de una prueba con el propósito de aislar la unidad analizada.

**¿Hay otros nombres para los objetos/funciones simulados?**
- Sí, se dividen en diferentes tipos según su comportamiento y propósito:

- **Dummies:** Objetos que se pasan simplemente para cumplir con los parámetros requeridos por una firma de método, pero que nunca se llegan a utilizar realmente.
- **Fakes:** Objetos que cuentan con una implementación funcional real pero simplificada (por ejemplo, una implementación de repositorio en memoria en lugar de una base de datos real).
- **Stubs:** Objetos que proporcionan respuestas prefijadas o hardcodeadas a las llamadas que reciben durante la prueba.
- **Spies (Espías):** Stubs que además registran información sobre cómo fueron utilizados (como registrar cuántas veces se invocó un método o con qué argumentos exactos).
- **Mocks:** Objetos preconfigurados con expectativas específicas que verifican de manera activa si se produjeron las interacciones esperadas (por ejemplo, verificar que el método ActualizarPrecio fue llamado exactamente una vez con un parámetro determinado).

## Punto 4 -
**Defina usando palabras propias y según la práctica realizada qué es un fixture.** 
- Un fixture es un mecanismo que permite configurar un conjunto de datos de prueba predecible y reutilizable antes de ejecutar los test.
En este caso, el fixture fue el constructor de "TiendaTests", donde inicializamos la clase Tienda y precargamos productos para no tener que instanciarlos repetidamente en cada método de prueba.

**¿Qué ventajas ve en el uso de fixtures? ¿Qué enfoque de diseño de pruebas estaríamos aplicando (caja negra/blanca)?**
- La mayor ventaja que veo en el uso de fixtures es que permite la reutilización del código, lo cual ayuda a mantenerlo limpio y más legible. Aumenta la mantenibilidad también, ya que si se cambia la forma de instanciar un producto o la tienda sólo se debe modificar en el fixture y no en cada test.
El enfoque de prueba que estamos aplicando sería el de caja blanca, ya que en cada prueba unitaria y de integración con fixtures y mocks se conoce la estructura interna del código, las interfaces, los atributos de los objetos y las excepciones específicas que lanza la implementación interna.

**Explique los conceptos de Setup y Teardown en testing.**
- Setup: etapa inicial donde se preparan las condiciones, dependencias y datos necesarios antes de correr las pruebas.
- Teardown: etapa posterior a la ejecución de la prueba, encargada de liberar recursos, borrar datos temporales o cerrar conexiones.

## Punto 5 -
**¿Realizó una prueba de cobertura completa? ¿Qué tipo de cobertura utilizó?**
- No se realizó una cobertura completa de todas las lineas y caminos del sistema, pero si se realizó una cobertura del tipo de sentencias y de caminos principales pra las funciones clave del flujo (Agregar, Buscar y Eliminar Producto, AplicarDescuento y CalcularTotalCarrito). 

**¿Puede describir una situación de desarrollo para este caso en donde se plantee pruebas de integración ascendente? Describa la situación.**
- Primero, las pruebas de integración ascendente requieren que primero se prueben de forma exhaustiva los módulos de menor nivel, para que luego se vayan integrando gradualmente los componentes de mayor nivel que dependen de ellos. 
Una situación de desarrollo donde podríamos plantear este modo de prueba se daría de la siguiente forma:

- 1 - Nivel inferior: se desarrolla y prueba unitariamente la clase Producto, su constructor y método.
- 2 - Nivel intermedio: se integra Producto dentro de la base Tienda, probando de forma aislada que los métodos AgregarProducto, BuscarProducto, EliminarProducto y AplicarDescuento funcionen llamando correctamente a las propiedades y métodos del objeto. 
- 3 - Nivel superior: se construye sobre los componentes validados la función "CalcularTotalCarrito", probando la interacción conjunta entre el inventario de la tienda, la actualización de precios por descuento y el cálculo del monto final acumulado en el carrito.

