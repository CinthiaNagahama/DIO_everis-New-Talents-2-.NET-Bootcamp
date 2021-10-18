using System;
using System.ComponentModel.DataAnnotations;

namespace ApiGameCatalogue.InputModel 
{
  public class GameInputModel 
  {
    [Required]
    [StringLength(100, MinimumLength = 1, ErrorMessage = "O nome do jogo deve conter entre 1 e 100 caracteres")]
    public string Name { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 1, ErrorMessage = "O nome da produtora deve conter entre 1 e 100 caracteres")]
    public string Producer { get; set; }
    
    [Required]
    [Range(1, 1000, ErrorMessage = "O preço do jogo deve ser de no mínimo R$1,00 e no máximo R$1000,00")]
    public double Price { get; set; }
  }
}
