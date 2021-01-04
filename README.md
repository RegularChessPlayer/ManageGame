# ManageGame
A ASP.NET Core web application to manage games. Using .Net Web Api Core and PostgreSQL with Docker support.Both the Web Applicaiton and the Postgres DB runs in container. Added Swagger support to interact with API’s resources.

## Prerequisites
1. [Docker](https://www.docker.com/)

## Steps
1. `https://github.com/RegularChessPlayer/ManageGame`

2. `cd ManageGame`

3. `docker-compose build`

4. `docker-compose up`

5.  Navigate to http://localhost:8000/swagger


## Authenticate on App

On endpoint /api/Auth/login
Request with json: 
{
  "email": "admin",
  "password": "admin"
}
