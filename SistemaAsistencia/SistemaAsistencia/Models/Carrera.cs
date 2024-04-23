namespace SistemaAsistencia.Models;
/*
    Autor: César Gilberto Solares Castellanos
    Fecha: 19/04/2024 20:54PM
    Descripcion: Modelo de las carreras
    Encontramos los public getters y el constructor de Carreras
*/
//El modelo es utilizado en EntityFramework para automaticamente crear
//una base de datos, según lo que está escrito en dicho modelo.
public class Career{

    public Guid Id { get; set; }
   

    public string Nombre { get; set; }

    public string Nivel{get; set;
    }

    public DateTime CreatedAt{get; set;
    }

    public DateTime LastTimeModified{get; set;
    }

public Career(

    Guid id,
    string nombre,
    string nivel,
    DateTime createdAt,
    DateTime lastTimeModified
)
{
    Id = id;
    Nombre = nombre;
    Nivel = nivel;
    CreatedAt = createdAt;
    LastTimeModified = lastTimeModified;
    
}

}


