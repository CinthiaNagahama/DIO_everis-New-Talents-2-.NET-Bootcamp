using System;

namespace ApiGameCatalogue.Exceptions {
  public class NotRegisteredGameException : Exception
  {
    public NotRegisteredGameException() : base("Jogo não encontrado") { }
  }
}
