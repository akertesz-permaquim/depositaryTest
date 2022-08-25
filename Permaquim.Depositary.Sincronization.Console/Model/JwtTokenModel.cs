using Permaquim.Depositary.Sincronization.Console.Interfaces;

namespace Permaquim.Depositary.Sincronization.Console
{
    public class JwtTokenModel : IModel
    {
        public DateTime Expiration { get; set; }

        public string Token { get; set; }
        public Dictionary<string, DateTime> SincroDates { get; set; } = new();

        public void Process()
        {
            throw new NotImplementedException();
        }

        public void Process(DateTime dateTime)
        {
            throw new NotImplementedException();
        }
        public void Persist()
        {
            throw new NotImplementedException();
        }

    }
}
