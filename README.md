
# Cirqulor BackEnd 

.Net FrameWork , MongoDb





## 

####  Login

```http
  POST /api/Account
```

| Parametre | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `email` | `string` | **Required**|
| `passwrod` | `string` | **Required** |

#### Bio-Based -Materials

```http
  GET /api/BioBasedMaterial
```
Returns a list of Bio Based Materials

```http
  GET /api/BioBasedMaterial/{id}
```
| Parametre | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `id` | `string` | **Required**|

Returns a bio based material 
```http
  POST /api/BioBasedMaterial
```
| Parametre | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `name` | `string` | **Required**|

Create a bio based - material
```http
  PUT /api/BioBasedMaterial/{id}
```
| Parametre | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `id` | `string` | **Required**|

Update a bio based - material

```http
  DELETE /api/BioBasedMaterial/{id}
```
| Parametre | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `id` | `string` | **Required**|

Delete a bio based material

#### Type Of Material - Base Of Material -Name Of Material - Source Of Material - Production
Has same using with Bio Based Materials




  
## Install

#### Pull request on github or Download as Zip

#### If downloaded zip folder 

````
1-Unzip the folder
2-Open Visual Studio
3- Select <strong> Open a project or solution </stong>
4- Select CirqulorBeMongo.sln
5- Run

