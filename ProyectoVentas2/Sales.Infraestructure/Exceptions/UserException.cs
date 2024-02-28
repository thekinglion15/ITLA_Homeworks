namespace Sales.Infraestructure.Exceptions
{
    public class UserException : Exception
    {
        public UserException(string message) : base(message)
        {
            SaveError(message);
        }

        void SaveError(string message)
        {
            // X logica para guardar el error ocurrido
        }
    }
}
