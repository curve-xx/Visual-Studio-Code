using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients;

public class GenresClient(HttpClient httpClient)
{
    public async Task<Genre[]> GetGenresAsync()
    => await httpClient.GetFromJsonAsync<Genre[]>("genres") ?? [];

    // Mock data for demonstration purposes
    private readonly Genre[] genres =
    [
        new () {
            Id = 1,
            Name = "Fighting"
        },
        new Genre {
            Id = 2,
            Name = "Roleplaying"
        },
        new Genre {
            Id = 3,
            Name = "Sports"
        },
        new Genre {
            Id = 4,
            Name = "Racing"
        },
        new Genre {
            Id = 5,
            Name = "Kids & Family"
        }
    ];
}
