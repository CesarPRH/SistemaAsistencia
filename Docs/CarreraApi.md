# Api para Carreras
Estas son los servicios utilizados para añadir las carreras que serán registradas en el sistema.

El principio general de las carreras es para expandir el sistema si el coordinador lo desea.

## Create Carrera 
Se utilizaría este servicio si queremos añadir una carrera al sistema.
### Create Carrera Request

```js
POST /carrera
```
Como ejemplo, utilizaremos el siguiente JSON:

```json
{
    "Nombre" : "Ingenieria en Sistemas",
    "Nivel" : "Licenciatura"

}
```
### Create Carrera Response

```js
201 Created
```
```yml
Location: {{host}}/Carrera/{{id}}
```

Resultado:
```json
{
    "Id" : "0000",
    "Nombre" : "Ingenieria en Sistemas",
    "CreatedAt" : "{AÑADIR FECHA DE CREACION AQUI}",
    "LastModifiedDateTime": "{AÑADIR FECHA DE MODIFICACION AQUI}"
}
```
## Get Carrera

Este servicio se utilizaría para conseguir nuestra información de la base de datos sobre la carrera. Esto se utilizaría para:
- Demostrar todas las carreras en la sección de Carreras.
- Crear un curso, donde se utilizaría para asignarlo en la carrera.

### Get Carrera Request

```js
GET /carrera/{id}
```
### Get  Carrera Response
```js
200 Ok
```

```json
{
    "Id" : "0000",
    "Nombre" : "Ingenieria en Sistemas",
    "CreatedAt" : "{AÑADIR FECHA DE CREACION AQUI}",
    "LastModifiedDateTime": "{AÑADIR FECHA DE MODIFICACION AQUI}"
}
```

## Delete Carrera
Este servicio borraría completamente una carrera, borrando los cursos asignados en dicha carrera.

### Delete Carrera Request
```js
DELETE /carrera/{id}
```

### Delete Carrera Response

```js
204 No Content
```