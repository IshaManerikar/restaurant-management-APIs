namespace Restaurant.Domain.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string resource , string identifier) : base($"{resource} with id : {identifier} does not exists")
        {
            
        }
    }
}
