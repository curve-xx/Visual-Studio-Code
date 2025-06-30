using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients;

public class GamesClient
{
    private readonly List<GameSummary> games =
    [
        new () {
            Id = 1,
            Name = "Street Fighter II",
            Genre = "Fighting",
            Price = 19.99m,
            ReleaseDate = new DateOnly(1992, 7, 15)
        },
        new () {
            Id = 2,
            Name = "Final Fantasy XIV",
            Genre = "Roleplaying",
            Price = 59.99m,
            ReleaseDate = new DateOnly(2010, 9, 30)
        },
        new () {
            Id = 3,
            Name = "FIFA 23",
            Genre = "Sports",
            Price = 69.99m,
            ReleaseDate = new DateOnly(2022, 9, 27)
        }
    ];

    private readonly Genre[] genres = new GenresClient().GetGenres();

    public GameSummary[] GetGames() => [.. games];

    public void AddGame(GameDetails game)
    {
        if (game == null)
        {
            throw new ArgumentNullException(nameof(game));
        }

        Genre genre = GetGenreById(game.GenreId);

        var gameSummary = new GameSummary
        {
            Id = games.Max(g => g.Id) + 1,
            Name = game.Name,
            Genre = genre.Name,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };

        games.Add(gameSummary);
    }

    public GameDetails GetGameDetails(int id)
    {
        GameSummary game = GetGameSummaryById(id);

        var genre = genres.Single(g => string.Equals(g.Name, game.Genre, StringComparison.OrdinalIgnoreCase));

        return new GameDetails
        {
            Id = game.Id,
            Name = game.Name,
            GenreId = genre.Id.ToString(),
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };
    }

    public void UpdateGame(GameDetails updateGame)
    {
        if (updateGame == null)
        {
            throw new ArgumentNullException(nameof(updateGame));
        }

        Genre genre = GetGenreById(updateGame.GenreId);

        GameSummary existingGame = GetGameSummaryById(updateGame.Id);

        existingGame.Name = updateGame.Name;
        existingGame.Genre = genre.Name;
        existingGame.Price = updateGame.Price;
        existingGame.ReleaseDate = updateGame.ReleaseDate;
    }

    public void DeleteGame(int id)
    {
        GameSummary game = GetGameSummaryById(id);
        games.Remove(game);
    }

    private GameSummary GetGameSummaryById(int id)
    {
        var game = games.SingleOrDefault(g => g.Id == id);
        ArgumentNullException.ThrowIfNull(game, nameof(game));
        return game;
    }

    private Genre GetGenreById(string id)
    {
        ArgumentException.ThrowIfNullOrEmpty(id, nameof(id));
        var genre = genres.Single(g => g.Id == int.Parse(id));
        return genre;
    }
}
