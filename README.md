Registro de Gastos

Descripción

Este programa sirve para llevar un registro de gastos usando C#. Es un programa de consola donde se pueden agregar gastos, verlos, buscar por categoría y guardarlos en un archivo.

Funciones

El programa tiene 4 opciones:

1. Agregar gasto
     Permite ingresar la descripción, monto y categoría.
     Le asigna un ID automáticamente.
     Verifica que los datos ingresados sean válidos.
2. Listar gastos
     Muestra todos los gastos registrados.
     También muestra el total gastado.
3. Buscar por categoría
     Permite buscar gastos escribiendo una categoría.
     Muestra los gastos que coincidan con la búsqueda.
4. Salir
     Guarda todos los gastos en el archivo gastos.csv.
     Después cierra el programa.

Archivos

El proyecto tiene principalmente:

 Gasto.cs: contiene la clase Gasto con las propiedades Id, Descripcion, Monto y Categoria.
 Program.cs: contiene el menú y las funciones principales del programa.
 gastos.csv: archivo donde se guardan los gastos.

Cómo funciona

Al iniciar el programa, primero revisa si existe el archivo gastos.csv. Si existe, carga los gastos que ya estaban guardados.

Después aparece el menú para que el usuario pueda elegir qué quiere hacer.

Cuando se agrega un gasto, se guarda en una lista y se le asigna un ID.

Cuando se selecciona la opción de salir, los gastos se guardan en el archivo para no perder la información.

Validaciones

El programa verifica que:

 El monto sea un número.
 El monto sea mayor que 0.
 La descripción no esté vacía.
 La categoría no esté vacía.

Conceptos utilizados

En este proyecto utilicé:

 Clases y objetos.
 Propiedades.
 Métodos.
 Listas.
 if y switch.
 foreach y do while.
 TryParse.
 Manejo de archivos.
 ToString().
 Arreglos.
 Split().

Tecnología

 C#
 .NET
 Visual Studio
 Aplicación de consola.
