using GameStore.API.Data;
using GameStore.API.Dtos;
using GameStore.API.Entities;
using GameStore.API.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GameStore.API.Endpoints;

public static class GamesEndpoints
{
    private static readonly List<GameSummaryDto> games = [
            new (
            1,
            "Street Fighter II",
            "Fighting",
            19.99M,
            new DateOnly(1992, 7, 15)
        ),
        new (
            2,
            "Final Fantasy XIV",
            "Roleplaying",
            59.99M,
            new DateOnly(2010, 9, 30)
        ),
        new (
            3,
            "FIFA 23",
            "Sports",
            69.99M,
            new DateOnly(2022, 9, 27)
        ),
    ];

    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/games").WithParameterValidation();

        // GET /games
        group.MapGet("/", async (GameStoreContext context) =>
            await context.Games
                    .Include(g => g.Genre)
                    .Select(g => g.ToGameSummaryDto())
                    .AsNoTracking()
                    .ToListAsync());

        // GET /games/{id}
        group.MapGet("/{id:int}", async (int id, GameStoreContext context) =>
        {
            var game = await context.Games
                .Include(g => g.Genre)
                .FirstOrDefaultAsync(g => g.Id == id);
            return game is not null ? Results.Ok(game.ToGameDetailsDto()) : Results.NotFound();
        });

        // POST /games
        group.MapPost("/", async (CreateGameDto createGameDto, GameStoreContext context) =>
        {
            Game game = createGameDto.ToEntity();

            context.Games.Add(game);
            await context.SaveChangesAsync();

            return Results.Created($"/games/{game.Id}", game.ToGameDetailsDto());
        });

        // PUT /games/{id}
        group.MapPut("/{id:int}", async (int id, UpdateGameDto updateGameDto, GameStoreContext context) =>
        {
            var game = await context.Games.FirstOrDefaultAsync(g => g.Id == id);

            if (game is null)
            {
                return Results.NotFound();
            }

            context.Entry(game).CurrentValues.SetValues(updateGameDto);
            await context.SaveChangesAsync();

            return Results.Ok(game.ToGameDetailsDto());
        });

        // DELETE /games/{id}
        group.MapDelete("/{id:int}", async (int id, GameStoreContext context) =>
        {
            var game = await context.Games.FirstOrDefaultAsync(g => g.Id == id);

            if (game is null)
            {
                return Results.NotFound();
            }

            await context.Games.Where(g => g.Id == id)
                        .ExecuteDeleteAsync();

            return Results.NoContent();
        });

        return group;
    }
}
