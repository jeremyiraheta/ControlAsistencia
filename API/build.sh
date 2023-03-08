sudo docker stop api
sudo docker rm api
sudo docker rmi controlapi
sudo docker build -t controlapi .
sudo docker run -p 8081:8081 --name=api -d --network=host controlapi
