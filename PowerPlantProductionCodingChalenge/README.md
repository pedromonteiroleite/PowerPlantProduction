1 - Install and run latest version of Docker 

	https://docs.docker.com/engine/install/

2 - Install and run a API client program 

	https://www.postman.com/downloads/

3 - Download project source files to your local machine

4 - Open a terminal window and navigate to the docker-compose.yml location

5 - Run the following command on terminal so docker creates a image on your machine
	
	docker-compose build 

6 - Run the following command on terminal so docker run the application in a container
	
	docker-compose up -d
	
7 - Open Postman and create a POST request to the following endpoint
	
	http://localhost:8888/productionplan

8 - Open Postman and create a GET request to the following endpoint

	http://localhost:8888/exception

9 - Check the logs folder
