# CMS
## Contact Management System

Here I have developed a small contact management system using ASP.Net MVC framework which is consuming .Net Web API to perform basic CRUD
operations to maintain contact information.

Following are the steps to integrate this project on your system,

### 1) Integration of Database file

* Open Microsoft SQL Server Managenent Studio and make Windows Authentication connection
* Right Click on Databases Folder and click on attach option
* A attach database pop up will open. Now click on Add option to select the CMS.mdf file from the desired location.
* Now you are ready with your data base having table ContactList with dummy entries in it.

### 2) Project Setup

* Now start Visual Studio and open the ContactManagement Solution file in it.
* Now you have to change the connection string in CMS.WebAPI project.
* In Visual Studio select View option and from Server Explorer make connection with CMS database.
* After connection established right click on connection to select properties and replace data source with connected in web.config
  file for CMS.WebAPI project.
  
At this point you have successfully integrated database and project folder.

Now, set ContactInformation solution as startup project so that both CMS.Web and CMS.WebAPI project will run simaultaneously.

I have created one static class in CMS.Web project to call http client class. We can use this throughout the project to make the connection.
If each time we will create an object for http client in each call then request will exhaust the sockets available in heavy loads.
