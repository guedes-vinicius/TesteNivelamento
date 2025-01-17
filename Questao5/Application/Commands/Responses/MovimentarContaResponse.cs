namespace Application.Commands.Responses
{
    public class MovimentarContaResponse 
    {
        public MovimentarContaResponse(Guid idMovimento)
        {
            IdMovimento = idMovimento;
        }
        public Guid IdMovimento {get;set;}

    }
}