Instructions/Notes on the project workflow:

- Levenshtein Distance project is built on Angular 9 and .Net Core 2.2 Web APIs (Visual Studio 2017)
- Angular project folder is "LevenshteinDistance" and .Net Core Web API project folder is "LevenshteinDistanceWorkflow"
- HTTPS is enabled for both the projects and Self-signed certificate is used for this
- Certificate file and its Key file are placed under "LevenshteinDistance\DistanceCalculator" folder
- Please install the certificate and add it to "Trusted Root Certification Authorities"
- All API calls from Angular app to Web APIs are communicated using HTTPS
- First run .Net project then followed by the Angular project
- Angular project will land on Login page first
- Please use predefined credentials as follows - Username: "gleacuser" & Password: "1234"
- Once login is successful, it creates JWT Token and redirects user to Calculator page
- Here we can input two strings and calculate the distance between them
- Note: Calculator API will not work without successful login to system as it requires JWT token for Authorization
- APIs work fine using Postman/Fiddler too

- API details:
   - Login API 
	- HttpPost 
	- https://localhost:44313/api/Login
	- Headers - Content-Type: application/json
	- Request Body
	- {
    		"UserName": "gleacuser",
    		"Password": "1234"
	  }
   - Calculator API 
	- HttpGet 
	- https://localhost:44313/api/calculator?source=Hyundai&target=Honda
	- Provide the Bearer token that got generated in Login API under Authorization
