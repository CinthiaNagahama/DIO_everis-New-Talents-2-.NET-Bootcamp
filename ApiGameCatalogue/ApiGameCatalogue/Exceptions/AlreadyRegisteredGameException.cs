using System;

namespace ApiGameCatalogue.Exceptions {
  public class AlreadyRegisteredGameException : Exception
  {
    public AlreadyRegisteredGameException() : base("Jogo já cadastrado") { }
  }
}
