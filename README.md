# RabbitNet6Example
Proyecto ejemplo, implementacion de MessageBroker RabbitMQ con el framework .NET 6

Capas

Producer (Asp.Net Core WebApplication)
Consumer (Asp.Net Core WebApplication)
Common (Class library .Net Core)

# Agregar appsetings.json para que tomes los parametros de configuracion del RabbitMQ, tanto para el producer como para el consumer.

# appsettings.json (ejemplo)
{
  "RabbitMqConfiguration": {
    "HostName": "IP_SERVER_RABBITMQ",
    "Username": "USERNAME_RABBITMQ",
    "Password": "PASSOWRD_RABBITMQ"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
