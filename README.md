# .Net8.DDD.Microservices

# Services

## 1) ToDo

### Features

* ### CRUD
* ### Log time devoted for ToDo
* ### Immitaion of the parallel access while trying to update ToDo

## 2) Account

### Features

* ### CRUD
* ### JWT + Cookie authentication
* ### External authentication providers ( Google, Github, etc. )

## 3) Statistics

### Features

* ### Collection and analysis user activity
* ### Generate suggestions based on user activity

## 4) Notification

### Features

* ### Send email
* ### Send notification

## 5) Payment ?

### Features

* ### Go to premium ( pay for subscription )

##

# Architecture and Technologies

## Backend

* ### Microservices, DDD, REST API, GRPC --> ASP NET CORE 8
* ### Databases --> PostgreSQL / MongoDB + Amazon s3 / MinIO 
* ### Caching --> Redis
* ### Message bus --> RabbitMQ / MassTransit
* ### Logging --> Serilog, ELK
* ### Tracing --> OpenTelemetry
* ### Metrics --> Prometheus, Grafana
* ### Unit tests --> XUnit, NSubstitute
* ### Integration tests --> WebApplicationFactory

## Frontend

* ### Framework --> React
* ### State manager --> mobx / redux

## Deployment

* ### Containerization --> Docker
* ### Orchestration --> Kubernetes
* ### CI/CD --> GitHub actions / Jenkins