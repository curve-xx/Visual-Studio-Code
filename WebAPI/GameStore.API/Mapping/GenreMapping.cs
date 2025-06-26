using System;
using GameStore.API.Dtos;
using GameStore.API.Entities;

namespace GameStore.API.Mapping;

public static class GenreMapping
{
    public static GenreDto ToDto(this Genre genre)
    {
        return new GenreDto(genre.Id, genre.Name);
    }

    // public static Genre ToEntity(this GenreDto genreDto)
    // {
    //     return new Genre(genreDto.Id, genreDto.Name);
    // }
}
