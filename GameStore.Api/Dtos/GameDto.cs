// DTOs are objects that carries data between processes or applications. DTOs are used to encapsulate data and send it from one subsystem of an application to another or between applications. 

namespace GameStore.Api.Dtos;

public record class GameDto(
    int Id, 
    string Name, 
    string Genre, 
    decimal Price,
    DateOnly ReleaseDate);
