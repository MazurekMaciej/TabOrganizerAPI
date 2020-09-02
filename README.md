# TabOrganizerAPI
ASP.NET Core 3.1 WebAPI

It's an api which allows to create a personal tab organizer where you can create containers which store links to saved websites based on their category.

<b>Building and Running</b>

1. Change to the api directory</br>
  <code>cd TabOrganizer-website</code>
  
2. Issue the dotnet restore command (this resolves all NuGet packages)</br>
  <code>dotnet restore</code>
  
3. Issue the dotnet build command</br>
  <code>dotnet build</code>
  
4. Issue the dotnet run command</br>
  <code>dotnet run</code>

<b>Usage of the API</b>

<code>TabOrganizerAPI</code> has the following Controllers:

1. Users</br>
  <b>Authenticate</b>
  
  <code>http://localhost:5000/api/users/authenticate</code>
  
   <pre>
    {
      "username": "testuser",
      "password": "testpass"
    }
   </pre>

  <b>Regsiter</b></br>
  
  <code>http://localhost:5000/api/users/register</code>
  
  <pre>
      {
        "username": "testuser",
        "password": "testpass"
      }
  </pre>
  
   <b>GET all users</b>:
   <code>http://localhost:5000/api/users</code></br>
   <b>GET single user</b>: 
   <code>http://localhost:5000/api/users/5</code></br>
   <b>PUT a user</b>: 
   <code>http://localhost:5000/api/users/5</code> + User body</br>
   <b>DELETE user</b>: 
   <code>http://localhost:5000/api/users/5</code>
  
 2. Containers</br>
    <b>GET all containers</b></br>
    <code>http://localhost:5000/api/containers</code>
    
    <b>GET single container</b></br>
    <code>http://localhost:5000/api/containers/5</code>
    
    <b>POST a container</b></br>
    <code>http://localhost:5000/api/containers</code>
   
    <pre>
        {
         "name": "Work2",
         "description": "work things"
        }
    </pre>
    
    <b>PUT a container</b></br>
    <code>http://localhost:5000/api/containers/5</code> + container body
    
    <b>DELETE a container</b></br>
    <code>http://localhost:5000/api/containers/5</code>
    
 3. Websites</br>
    <b>GET all websites</b></br>
    <code>http://localhost:5000/api/websites/2</code>
    
    <b>GET single website</b></br>
    <code>http://localhost:5000/api/websites/2/5</code>
    
    <b>POST a website</b></br>
    <code>http://localhost:5000/api/websites/2</code>
    
      <pre>
        {
            "name": "Google,
            "link": "google.com",
            "comment": "google page"
        }
      </pre>
      
    <b>PUT a website</b></br>
    <code>http://localhost:5000/api/websites/2/5</code> + website body
    
    <b>DELETE a website</b></br>
    <code>http://localhost:5000/api/websites/2/5</code>

<b>Built With</b>
<ul>
 <li>ASP.NET Core</li>
 
 <li>Entity Framework Core</li>
 
 <li>Jwt Bearer Authentication</li>
 
 <li>AutoMapper</li>
 </ul>
