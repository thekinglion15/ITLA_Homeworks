namespace Sales.Infraestructure.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException(string message) :base(message)
        {
            SaveError(message);
        }

        void SaveError(string message)
        {
            // X logica para guardar el error ocurrido
        }
    }
}
