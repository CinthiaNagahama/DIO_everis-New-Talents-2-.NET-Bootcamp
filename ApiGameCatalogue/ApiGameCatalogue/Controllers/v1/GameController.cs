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

    /// <summary>
    /// Busca todos os jogos de forma paginada
    /// </summary>
    /// <remarks>
    /// Não é possível retornar os jogos sem paginação
    /// </remarks>
    /// <param name="page">Indica a página que está sendo consultada. Mínimo 1</param>
    /// <param name="quantity">Indica a quantidade de jogos por página. Mínimo 1</param>
    /// <response code="200">Retorna a lista de jogos</response>
    /// <response code="204">Caso não haja jogos</response>
    [HttpGet]
    public async Task<ActionResult<List<GameViewModel>>> Get(
      [FromQuery, Range(1, int.MaxValue)] int page = 1, 
      [FromQuery, Range(1, 50)] int quantity = 5
    ) {
      var result = await _gameService.Get(page, quantity);

      return result.Count == 0 ? NoContent() : Ok(result);
    }

    /// <summary>
    /// Busca jogo pelo id
    /// </summary>
    /// <param name="gameId">Indica o Id do jogo</param>
    /// <response code="200">Retorna a lista de jogos</response>
    /// <response code="204">Caso não haja jogos</response>
    [HttpGet("{gameId:guid}")]
    public async Task<ActionResult<GameViewModel>> Get([FromRoute] Guid gameId) 
    {
      var game = await _gameService.Get(gameId);

      return game == null ? NoContent() : Ok(game);
    }

    /// <summary>
    /// Cadastra um novo jogo
    /// </summary>
    /// <param name="inputGame">Indica o jogo</param>
    /// <response code="200">Retorna os dados do jogo inserido</response>
    /// <response code="422">Caso já exista um jogo com o mesmo nome da produtora</response>
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

    /// <summary>
    /// Atualiza um jogo existente
    /// </summary>
    /// <param name="gameId">Indica o Id do jogo a ser atualizado</param>
    /// <param name="inputGame">Indica os dados atualizados</param>
    /// <response code="200">Caso a atualização ocorra com sucesso</response>
    /// <response code="422">Caso o jogo não exista</response>
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

    /// <summary>
    /// Atualiza o preço de um jogo existente
    /// </summary>
    /// <param name="gameId">Indica o Id do jogo a ser atualizado</param>
    /// <param name="price">Indica o preço atualizado</param>
    /// <response code="200">Caso a atualização ocorra com sucesso</response>
    /// <response code="422">Caso o jogo não exista</response>
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

    /// <summary>
    /// Remove um jogo existente
    /// </summary>
    /// <param name="gameId">Indica o Id do jogo a ser removido</param>
    /// <response code="200">Caso a remoção ocorra com sucesso</response>
    /// <response code="422">Caso o jogo não exista</response>
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
