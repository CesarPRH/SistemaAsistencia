# Api para Estudiantes

###### Documentación hecho por César Solares.

Se necesitaran las siguientes acciones para los estudiantes:

### Create Estudiante Request

```js
POST /Estudiante
```

JSON de ejemplos que se utilizaria para el CREATE:
```json
{
    "Nombre" : "Cesar Gilberto",
    "Apellidos" : "Solares Castellanos",
    "Direccion" : "Melchor de Mencos, Barrio Fallabón",
    "DPI" : "0000-0000-00000",
    
}
```

### Create Estudiante Response
Lo siguiente debería ser el resultado al solicitar CreateEstudiante.

```js
201 created

```

```yml
Location: {{host}}//Estudiante/{{id}}
```


```json

    {
        "Id": "0000-00-0000",
        "Nombre": "Cesar Gilberto",
        "Apellidos": "Solares Castellanos",
        "Direccion" : "Melchor de Mencos, Barrio Fallabón",
        "Dpi": "0000-0000-00000",
        "CreatedAt": "{FECHA CREADA AQUI}",
        "LastmodifiedDateTime": "{FECHA DE ULTIMA MODIFICACION AQUI}"
    }

```

### Get Estudiante Request

```js
GET /Estudiante/{id}
```

### Get Estudiante Response
```json
200 Ok
```

```json
{
        "Id": "0000-00-0000",
        "Nombre": "Cesar Gilberto",
        "Apellidos": "Solares Castellanos",
        "Direccion" : "Melchor de Mencos, Barrio Fallabón",
        "Dpi": "0000-0000-00000",
        "CreatedAt": "{FECHA CREADA AQUI}",
        "LastmodifiedDateTime": "{FECHA DE ULTIMA MODIFICACION AQUI}"
}
```
## Update Estudiante
Esto se usaria si por algunas razones se quiere editar al estudiante. Todos Excepto el catedratico pudiera modificar a un estudiante.

### Update Estudiante Request
```js
PUT /Estudiante/{id}
```
Texto de Ejemplo para actualizar este estudiante:

```json
{
        "Nombre" : "Cesar Gilberto",
    "Apellidos" : "Solares Castellanos",
    "Direccion" : "Ciudad de Guatemala, Barrio Los Vengadores",
    "DPI" : "0000-0000-00000",
}
```

### Update Estudiante Response

``` js
204 No Content
```
o

```js
201 Created
```
```yml
Location: {{host}}/Estudiante/{{id}}
```

### Delete Estudiante
En el caso que quisieramos borrar un estudiante de nuestro sistema, utilizariamos este servicio.
SIN EMBARGO:
Como practica general, no es adecuado borrar un estudiante del sistema, sino desactivarlo. Para eso utilizaríamos Update Estudiante.

### Delete Estudiante Request
```js
DELETE /Estudiante
```
### Delete Estudiante Response
```js
204 No Content
```





