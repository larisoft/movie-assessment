A Simple application that demonstrates reading movies from OMDB Api, caching the last 10 results, rendering the results in a react list component, and displaying it in a displayMovie component when a movie is selected. The application is fully containerized and all services can be run at the same time with a simple 'docker-compose up --build'.

<img width="1413" alt="image" src="https://github.com/larisoft/movie-assessment/assets/11951443/90092ed5-574a-44df-b2fc-e7f87760152b">
<img width="1413" alt="image" src="https://github.com/larisoft/movie-assessment/assets/11951443/466c5415-d247-40dd-8398-3b4e477c625c">



#To run full application 
1. git clone https://github.com/larisoft/movie-assessment.git
2. cd movie-assessment
3. docker-compose up --build 
4. Visit http://localhost:3000 (backend should be running already at http://localhost:5000)


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
