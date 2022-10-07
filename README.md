# the-lemonade-stand
Online lemonade stand project

## Deploy to Azure
az login
az acr login --name {cr}
docker build -t {cr}.azurecr.io/{image}:{tag} .
docker push {cr}.azurecr.io/{image}:{tag}