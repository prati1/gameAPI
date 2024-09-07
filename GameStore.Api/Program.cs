using GameStore.Api.Dtos;

var builder = WebApplication.CreateBuilder(args);

// We can configure services such as middleware, dependencies, etc by adding them to builder object

var app = builder.Build();

const string GetGameEndpointName = "GetGame";

List<GameDto> games = [
    new GameDto(1, "Super Mario Bros", "Platformer", 29.99m, new DateOnly(1985, 9, 13)),
    new GameDto(2, "The Legend of Zelda", "Action-adventure", 49.99m, new DateOnly(1986, 2, 21)),
    new GameDto(3, "Minecraft", "Sandbox", 19.99m, new DateOnly(2011, 11, 18))
];

// GET /games
app.MapGet("/games", () => games);

// GET /games/1
app.MapGet("/games/{id}", (int id) => games.Find(game => game.Id == id))
    .WithName(GetGameEndpointName);

// POST /games
app.MapPost("/games", (CreateGameDto newGame) => {
    GameDto game = new(
        games.Count + 1,
        newGame.Name,
        newGame.Genre,
        newGame.Price,
        newGame.ReleaseDate
    );

    games.Add(game);

    // CratedAtRoute(route_name_where_resource_can_be_found, route_values_that_needs_to_be_provided_to_get_game_route, resource)
    return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game);
});

app.MapGet("/", () => "Hello World!");

app.Run();
