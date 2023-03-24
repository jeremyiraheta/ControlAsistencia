sudo docker stop api
sudo docker rm api
sudo docker rmi controlapi
sudo docker build -t controlapi .
sudo docker run --name=api -d -v /var/api/public:/App/public --network=host controlapi
