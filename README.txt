--------  Instructivo Prueba Miles Car Rental ----------

Folder: MilesCarRentalSln

- Se creó una rest API con Net core 6, asegurada con JWT
  URLapi: https://localhost:7030

- La aplicación está creada en capas:
	
1. Domain: Capa donde se definen los models/entidades y los settings para la conexion de base de datos
2. Infrastructure: Capa donde se definen los repositories; esta capa tiene como finalidad interactuar 
   con la base de datos. Hace uso de la capa de Domain
3. Application: Capa donde se definen los servicios (Lógica de negocio); hace uso del Domain y Repositories
4. Presentation: WebApp donde se definen los Controller API los cuales son presentados por medio de Swagger;
   esta capa hace uso de el Domain y consume los servicios y está asegurada [Authorize]
5. Test: Proyecto de Xunit que permite testear los servicios de acuerdo al standard (AAA)

- La aplicación usa inyeccion de dependencias configurado tanto en la capa Infrastructure como en la capa Application
  el archivo DependencyInjection el cual es una clase static donde se define un metodo de extension static que tiene 
  como objeto registrar los servicios de cada capa para luego ser llamado en la clase program para el registro del 
  contenedor de dependencias

- Se utiliza en cada capa clases base con Generics para la rapida implementación de los metodos del CRUD: tanto en 
  los Services, Repositories y Controller se tiene esta funcionalidad

- Utilización del patron Repository empleando interfaces que generan un desacoplamiento de la aplicación y permiten
  la herencia multiple, extendiendo funcionalidades.

- Se utilizó una base de datos de MongoDB

- Los parametros de la base de datos se encuentran en el archivo appsettings.json de la capa de presentación:
  ConnectionString, DatabaseName y Collections creadas para el desarrollo de la prueba.


Folder: milescarrentalapp


- Se creó una aplicación de Reactjs con vitejs para consumir la Api
- La aplicación de reactjs es una aplicación de componentes funcionales en la cual se implementan diferentes
  propiedades de react como lo son los hooks, Context, useState, useEffect entre otras caracteristicas propias
  de la libreria.

   UrlFront: http://localhost:5173/
