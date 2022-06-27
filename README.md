# ProyectoEquipo7

![img](https://images-na.ssl-images-amazon.com/images/I/A13vvsoih5L.png)

### El diagrama UML del proyecto y el informe de nuestra solución se encuentra cargado en "docs".

Para comenzar a abordar este proyecto se nos presentaron varios desafíos como puede ser reconocer las diferentes clases que iban a ser necesarias para nuestro proyecto y poder imaginar una solución que se ajuste a lo necesario, debido a que hasta que no se comience a pasar a código todo lo que se planificó en el diagrama no tenemos la certeza de que la solución está completa o le falta algo en particular . 
Entre estos desafios otro de los que se destaca es tratar de cubrir todos los requerimientos de nuestro proyecto sin crear clases por demás o que no tengan un propósito general.
Finalmente debíamos asignarle roles a las clases de nuestra solucion lo cual fue un desafío tratar de asignarle el rol correcto a cada una de estas pero nos ayudó bastante a organizarlas y hacer una solucón lo mas completa posible.

En la segunda entrega, quisimos corregir la observación de los profesores brindada en el feedback de la primera entrega: "si en un futuro deseo agregar un modo de juego debería modificar las clases: Menu, Administrator y crear una nueva clase subtipo de Game. Y eso no es correcto."
Buscando la solución, Fernando nos sugirió implementar un Singleton para instanciar una única vez la clase Administrator y con ello traer todos los métodos de una sola vez. Sin embargo, resultó ser más complejo de los esperado y no logramos hacerlo funcionar correctamente para que identificara los distintos modos de juegos.
Esto nos retrasó bastante en el avance del proyecto y nos generó inconsistencias a la hora de ejecución y selección entre modos, por lo que para esta entrega quedó habilitado solo el modo Clásico el cual era requerimiento base de esta entrega.
Para la próxima entrega tenemos pensando terminar de hacer la implementación del Singleton para que identifique todos los modos de juego posibles y no sea necesario modificar las clases Administrator y Menu cuando suceda.
Otra problemática resuelta fue la de tener dos instancias de Board dentro de Board, cambiamos esto y ahora Board está vinculada a un usuario. Por lo que en Game se inicializan dos instancias de Board.
Por último, nos dimos cuenta que debido a la forma en la que realizamos el código era muy difícil realizar correctamente los tests. Por lo que fue otra complicación en la recta final de la segunda entrega.
Finalmente logramos realizar el juego el cual tiene todo lo necesario para su funcionamiento en esta instancia.

