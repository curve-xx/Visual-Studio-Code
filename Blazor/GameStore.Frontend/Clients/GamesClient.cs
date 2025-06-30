using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients;

public class GamesClient(HttpClient httpClient)
{
    public async Task<GameSummary[]> GetGamesAsync()
   => await httpClient.GetFromJsonAsync<GameSummary[]>("games") ?? [];

    public async Task<GameDetails> GetGameDetailsAsync(int id)
    => await httpClient.GetFromJsonAsync<GameDetails>($"games/{id}") ?? throw new ArgumentException("Game not found!", nameof(id));

    public async Task AddGameAsync(GameDetails game)
    => await httpClient.PostAsJsonAsync("games", game);


    public async Task UpdateGameAsync(GameDetails updateGame)
    => await httpClient.PutAsJsonAsync($"games/{updateGame.Id}", updateGame);

    public async Task DeleteGameAsync(int id)
    => await httpClient.DeleteAsync($"games/{id}");

    // Mock data for demonstration purposes
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

    private readonly Task<Genre[]> genres = new GenresClient(httpClient).GetGenresAsync();

    private GameSummary GetGameSummaryById(int id)
    {
        var game = games.SingleOrDefault(g => g.Id == id);
        ArgumentNullException.ThrowIfNull(game, nameof(game));
        return game;
    }

    private Genre GetGenreById(string id)
    {
        ArgumentException.ThrowIfNullOrEmpty(id, nameof(id));
        var genre = genres.Result.Single(g => g.Id == int.Parse(id));
        return genre;
    }
}
