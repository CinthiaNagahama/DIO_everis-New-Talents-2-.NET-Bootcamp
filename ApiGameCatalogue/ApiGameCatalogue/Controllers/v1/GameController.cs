using ApiGameCatalogue.Exceptions;
using ApiGameCatalogue.InputModel;
using ApiGameCatalogue.Services;
using ApiGameCatalogue.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace ApiGameCatalogue.Controllers.v1 
{
  [Route("api/V1/[controller]")]
  [ApiController]
  public class GameController : ControllerBase 
  {
    private readonly IGameService _gameService;

    public GameController(IGameService gameService) 
    {
      _gameService = gameService;
    }

    [HttpGet]
    public async Task<ActionResult<List<GameViewModel>>> Get(
      [FromQuery, Range(1, int.MaxValue)] int page = 1, 
      [FromQuery, Range(1, 50)] int quantity = 5
    ) {
      var result = await _gameService.Get(page, quantity);

      return result.Count == 0 ? NoContent() : Ok(result);
    }

    [HttpGet("{gameId:guid}")]
    public async Task<ActionResult<GameViewModel>> Get([FromRoute] Guid gameId) 
    {
      var game = await _gameService.Get(gameId);

      return game == null ? NoContent() : Ok(game);
    }

    [HttpPost]
    public async Task<ActionResult<GameViewModel>> InsertGame([FromBody] GameInputModel inputGame) 
    {
      try
      {
        var game = await _gameService.Insert(inputGame);
        return Ok(game);
      } 
      catch(AlreadyRegisteredGameException)
      {
        return UnprocessableEntity("Já existe um jogo com esse nome para essa produtora");
      }
    }

    [HttpPut("{gameId:guid}")]
    public async Task<ActionResult> UpdateGame([FromRoute] Guid gameId, [FromBody] GameInputModel inputGame) {
      try 
      {
        await _gameService.Update(gameId, inputGame);
        return Ok();
      }
      catch(NotRegisteredGameException)
      {
        return UnprocessableEntity("Esse jogo não existe");
      }
    }

    [HttpPatch("{gameId:guid}/{price:double}")]
    public async Task<ActionResult> UpdateGame([FromRoute] Guid gameId, [FromRoute] double price) {
      try 
      {
        await _gameService.Update(gameId, price);
        return Ok();
      }
      catch(NotRegisteredGameException)
      {
        return UnprocessableEntity("Esse jogo não existe");
      }
    }

    [HttpDelete("{gameId:guid}")]
    public async Task<ActionResult> RemoveGame([FromRoute] Guid gameId) 
    {
      try 
      {
        await _gameService.Remove(gameId);
        return Ok();
      }
      catch(NotRegisteredGameException)
      {
        return UnprocessableEntity("Esse jogo não existe");
      }
    }
  }
}
