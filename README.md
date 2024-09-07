# SalesDatePrediction
Desarrollar una aplicación llamada “Sales Date Prediction” que tiene como objetivo crear órdenes y predecir cuándo ocurrirá la próxima orden por cliente de acuerdo con los registros almacenados en la base de datos.

# Empezando
Para comenzar con este projecto, aquí están las opciones disponibles:

# Development Environment - Prerequisitos

  - .NET SDK: 8.0
  - IDE: Visual studio 2022 o Visual studio Code
  - Base de datos: SQLServer - SQL Server Management Studio (SSMS)
  - API Testing Tools: POSTMAN
  - Angular CLI
  - node js
  - npm
    
# Guía de inicio rápido 
  - Cloné el repositorio SalesDatePrediction. Ahora que nuestra solución está generada, 
    naveguemos a la carpeta raíz de la solución y abramos una terminal de comandos para construir la solución.

Paso para correr los proyectos:
1) correr el backend - endpoint
2) Correr el frontend - angular
3) Revisar la aplicacion de graficos D3 

# Backend - WebApi .NET 8
  1) Se busca la carpeta de Recursos y se toma el script de la base de datos proporcionado "DBSetup.sql"
     y se ejecuta en el motor de SQL Server instalado local para crear la base de datos llamada "StoreSample".
  2) Cuando se tenga la base de datos creada se procese con abrir la solucion "SalesDatePrediction.sln" que esta en la raiz del proyecto
  en su editor o IDE preferido para correr el proyecto Web api "SalesDatePrediction.WebApi" y buscar el archivo "appsetting.json"
y modficar su cadena de conexion con las credenciales locales sin modificar el nombre de la base de datos "StoreSample".


    "ConnectionStrings": {
      "DefaultConnection": "Data Source=.;Initial Catalog=StoreSample;User ID=SA;Password=TestDB1234*;Integrated Security=True;MultipleActiveResultSets=True;TrustServerCertificate=true"
    }
3) Realizar los siguientes pasos para ejecutar la aplicacion desde la terminal o simplemente ejecutar la "SalesDatePrediction.WebApi" desde la web api

   3.1) Instalar el SDK de .NET
   Asegúrate de tener instalado el SDK de .NET en tu máquina. Puedes verificar si está instalado escribiendo en la terminal:

            dotnet --version
  Si no lo tienes instalado, puedes descargarlo desde la página oficial de .NET.
  
  3.2) Abrir la terminal
  Ve a la carpeta raíz de tu proyecto .NET utilizando la terminal.

        cd ruta/a/tu/proyecto/src/Applications/SalesDatePrediction.WebApi
  3.3) Restaurar dependencias (si es necesario)
  Si es la primera vez que corres el proyecto o si has agregado nuevas dependencias, es recomendable restaurarlas con el siguiente comando:

        dotnet restore
   
  3.4). Ejecutar el proyecto 
  Para ejecutar tu proyecto, simplemente usa el siguiente comando:

        dotnet run

  Esto compilará y ejecutará el proyecto. Si tu solución tiene varios proyectos, asegúrate de estar en la carpeta que contiene el proyecto que deseas ejecutar o especifica la ruta al archivo .csproj del proyecto.
  
  Nota: asegurese de que la aplicacion se este escuchando por "https://localhost:7119" la terminal le arrojara este mensaje Now listening on: https://localhost:7119
  con este podemos navergar a https://localhost:7119/swagger/index.html para ver la documentacion en swagger de los endpoints

# FrontEnd Angular
Para correr la aplicacion frontend volver a la raiz del proyecto y bucar la carpeta "angular-sale-date-prediction-app" abrirla con visual studio code y realizar lso siguientes paso:

1) puede usar la terminal o puede usar con control + j la terminal en visual studio y escribir los siguientes comandos:
2) Ejecutar npm install
3) Ejecutar la app npm start o bien ng serve -o
4) Abrir la aplicacion desde "http://localhost:4200/" verifique que la apliccio neste corriendo en este puerto
5) y con esto puede usar frontend llamando al backend

#APP - Graficos en D3
Para correr esta aplicacion basta en ir a la carpeta en la raiz del proyecto y buscar la carpeta llamada "D3-graphics" 
y abrir el archivo index.html en el navegador para poder verificar el funcionamiento y para revisar el codigo lo pueden abrir desde 
visual studio code de la carpeta.

Gracias por Atención.
   


