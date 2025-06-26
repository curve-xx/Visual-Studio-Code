using GameStore.API.Data;
using GameStore.API.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GameStore.API.Endpoints;

public static class GenreEndPoints
{
    public static RouteGroupBuilder MapGenreEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/genres").WithParameterValidation();

        group.MapGet("/", async (GameStoreContext dbContext) =>
            await dbContext.Genres
                        .Select(g => g.ToDto())
                        .AsNoTracking()
                        .ToListAsync());

        // group.MapGet("/{id}", async (int id, GameStoreContext dbContext) =>
        // {
        //     var genre = await genreRepository.GetByIdAsync(id);
        //     return genre is not null ? Results.Ok(genre.ToDto()) : Results.NotFound();
        // });

        // group.MapPost("/", async (GenreDto genreDto, IGenreRepository genreRepository) =>
        // {
        //     var genre = genreDto.ToEntity();
        //     await genreRepository.AddAsync(genre);
        //     return Results.Created($"/genres/{genre.Id}", genre.ToDto());
        // });

        // group.MapPut("/{id}", async (int id, GenreDto genreDto, IGenreRepository genreRepository) =>
        // {
        //     var genre = await genreRepository.GetByIdAsync(id);
        //     if (genre is null) return Results.NotFound();

        //     genre.Name = genreDto.Name;
        //     await genreRepository.UpdateAsync(genre);
        //     return Results.Ok(genre.ToDto());
        // });

        // group.MapDelete("/{id}", async (int id, IGenreRepository genreRepository) =>
        // {
        //     var genre = await genreRepository.GetByIdAsync(id);
        //     if (genre is null) return Results.NotFound();

        //     await genreRepository.DeleteAsync(genre);
        //     return Results.NoContent();
        // });

        return group;
    }
}
