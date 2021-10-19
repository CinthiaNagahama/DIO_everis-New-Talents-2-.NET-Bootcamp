using ApiGameCatalogue.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGameCatalogue.Repositories 
{
  public class GameRepository : IGameRepository
  {
    // Mock database
    private static Dictionary<Guid, Game> games = new Dictionary<Guid, Game>() 
    {
      {
        Guid.Parse("a4b1c58d-05cb-46cc-afd5-0adf6c452341"), new Game{
        Id =  Guid.Parse("a4b1c58d-05cb-46cc-afd5-0adf6c452341"), 
        Name = "FIFA 21",
        Producer = "EA",
        Price = 200
      }},
      {
        Guid.Parse("960951bf-8b61-4756-85e7-20bcc39e2e3a"), new Game{
        Id =  Guid.Parse("960951bf-8b61-4756-85e7-20bcc39e2e3a"),
        Name = "FIFA 20",
        Producer = "EA",
        Price = 190
      }},
      {
        Guid.Parse("6c6cd58a-2fa5-4aa9-a3b5-76d7b8965da8"), new Game{
        Id =  Guid.Parse("6c6cd58a-2fa5-4aa9-a3b5-76d7b8965da8"),
        Name = "FIFA 19",
        Producer = "EA",
        Price = 180
      }},
      {
        Guid.Parse("500211c8-2d5f-4999-b141-53b552f8611e"), new Game{
        Id =  Guid.Parse("500211c8-2d5f-4999-b141-53b552f8611e"),
        Name = "FIFA 18",
        Producer = "EA",
        Price = 170
      }},
      {
        Guid.Parse("5ea15d28-3584-4cb9-a25c-5df14dec3fbe"), new Game{
        Id =  Guid.Parse("5ea15d28-3584-4cb9-a25c-5df14dec3fbe"),
        Name = "Street Fighter V",
        Producer = "Capcom",
        Price = 80
      }},
      {
        Guid.Parse("db608302-70a6-4252-bb2c-c2fa0dae282a"), new Game{
        Id =  Guid.Parse("db608302-70a6-4252-bb2c-c2fa0dae282a"),
        Name = "Grand Theft Auto V",
        Producer = "Rockstar",
        Price = 190
      }},
    };

    public Task<List<Game>> Get(int page, int quantity) 
    {
      return Task.FromResult(games.Values.Skip((page - 1) * quantity).Take(quantity).ToList());
    }

    public Task<Game> Get(Guid id) 
    {
      return games.ContainsKey(id) ? Task.FromResult(games[id]) : null;
    }

    public Task<List<Game>> Get(string name, string producer) 
    {
      return Task.FromResult(games.Values.Where(game => game.Name.Equals(name) && game.Producer.Equals(producer)).ToList());
    }

    public Task Insert(Game game) 
    {
      games.Add(game.Id, game);
      return Task.CompletedTask;
    }

    public Task Update(Game game) 
    {
      games[game.Id] = game;
      return Task.CompletedTask;
    }

    public Task Remove(Guid id) 
    {
      games.Remove(id);
      return Task.CompletedTask;
    }

    public void Dispose() 
    {
      // Fecha conexão com DB
    }
  }
}
