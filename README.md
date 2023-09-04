#Simple application that demonstrates reading movies from OMDB Api, caching the last 10 results, rendering the restuls in a react list component, and displaying it in a displayMovie component when a movie is selected.

The application is fully containerized and both frontend and backend can be run with a simple 'docker-compose up --build'.

#To run full application 
1. https://github.com/larisoft/movie-assessment.git
2. cd movie-assessment
3. docker-compose up --build 


#To run backend
1. https://github.com/larisoft/movie-assessment.git
2. cd movie-assessment/rest-api
3. dotnet run

#To run frontend
1. https://github.com/larisoft/movie-assessment.git
2. cd movie-assessment/react-frontend
3. npm run start 

#To Run unit test for backend 
1. https://github.com/larisoft/movie-assessment.git
2. cd movie-assessment/rest-api
3. dotnet test