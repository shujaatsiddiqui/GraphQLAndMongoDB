# GraphQL with HotChocolate & Apollo

**Serverside**: ASP.Net Core API with HotChocolate GraphQL and  MongoDB

**Clientside**: Reactjs with Apollo Client

## Getting Started

Clone the repository to your local machine or download project zip file to your local machine.

For running this project you need the following items to Installed on your local machine

### Serverside Prerequisites

* [Microsoft Visual Studio 2022](https://visualstudio.microsoft.com/vs/) - IDE
* [Dotnet 6 ](https://maven.apache.org/) - Framework
* [MongoDB](https://www.mongodb.com/try/download/community) - DataBase Engine for store data

### Clientside Prerequisites

* [Microsoft Visual Studio Code](https://code.visualstudio.com/download) - IDE
* [NPM](https://nodejs.org/en/download/) - Package Manager


### Serverside Installing

Run the below command to restore, build and run the project

Restore the nuget packages
```
dotnet restore
```

Buid the project

```
dotnet build
```

Run Server Project

```
dotnet run
```

### Clientside Installing

Run the below command to install dependencies and run project

Install Dependencies
```
npm install
```

Run Client Project

```
npm start
```


## Deployment

This project is a easy sample for GraphQL in Dotnet with MongoDB and there is no need to Deployed

## Authors

* **Mohsen Asadi** - *Initial work* - [MohsenAsadi](https://github.com/mohsenasadi501)


## License

This project is licensed under the MIT License

## Acknowledgments

* Storing data in mongoDB
* GraphQL Query, Mutation, Subscription Example
* Apollo Client


# =============== MONGO CLUSTER ===========================

#Reference
https://github.com/minhhungit/mongodb-cluster-docker-compose/tree/master/minimize

MongoDB cluster minimize
=========================================

* Config Server: `configsvr01`
* 2 Shards (each a 2 member `PSS` replica set):
	* `shard01-a`,`shard01-b`, `shard01-c`
	* `shard02-a`,`shard02-b`, `shard02-c`
* 1 Routers (mongos): `router01`

### 👉 Step 1
```bash
docker-compose up -d
```

### 👉 Step 2

```bash

docker-compose exec configsvr01 sh -c "mongosh < /scripts/init-configserver.js"

docker-compose exec shard01-a sh -c "mongosh < /scripts/init-shard01.js"
docker-compose exec shard02-a sh -c "mongosh < /scripts/init-shard02.js"
```

### 👉 Step 3
>Note: Wait a bit for the config server and shards to elect their primaries before initializing the router

```bash
docker-compose exec router01 sh -c "mongosh < /scripts/init-router.js"
```

### 👉 Step 4
```bash
docker-compose exec router01 mongosh --port 27017

// Enable sharding for database `MyDatabase`
sh.enableSharding("MyDatabase")

// Setup shardingKey for collection `MyCollection`**
db.adminCommand( { shardCollection: "NFTDB.Post", key: { _id: "hashed"} } )

```

---
### ✔️ Done !!!

#### But before you start inserting data you should verify them first
---

## !!! If you want to add new shard to existed cluster, [check more here](https://github.com/minhhungit/mongodb-cluster-docker-compose/tree/master/minimize/scripts/update01)

---

## 📋 Verify [🔝](#-table-of-contents)

### ✅ Verify the status of the sharded cluster [🔝](#-table-of-contents)

```bash
docker-compose exec router01 mongosh --port 27017
sh.status()
```

### ✅ Verify status of replica set for each shard [🔝](#-table-of-contents)
> You should see 1 PRIMARY, 2 SECONDARY

```bash
docker exec -it shard-01-node-a bash -c "echo 'rs.status()' | mongosh --port 27017" 
docker exec -it shard-02-node-a bash -c "echo 'rs.status()' | mongosh --port 27017" 
```

### ✅ Check database status
```bash
docker-compose exec router01 mongosh --port 27017
use MyDatabase
db.stats()
db.MyCollection.getShardDistribution()
```

### 🔎 More commands 

```bash
docker exec -it mongo-config-01 bash -c "echo 'rs.status()' | mongosh --port 27017"


docker exec -it shard-01-node-a bash -c "echo 'rs.help()' | mongosh --port 27017"
docker exec -it shard-01-node-a bash -c "echo 'rs.status()' | mongosh --port 27017" 
docker exec -it shard-01-node-a bash -c "echo 'rs.printReplicationInfo()' | mongosh --port 27017" 
docker exec -it shard-01-node-a bash -c "echo 'rs.printSlaveReplicationInfo()' | mongosh --port 27017"
```
