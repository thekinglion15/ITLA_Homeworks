namespace Sales.Infraestructure.Exceptions
{
    public class CorrelativeNumberException : Exception
    {
        public CorrelativeNumberException(string message) : base(message)
        {
            SaveError(message);
        }

        void SaveError(string message)
        {
            // X logica para guardar el error ocurrido
        }
    }
}
