namespace Sales.Infraestructure.Exceptions
{
    public class SaleException : Exception
    {
        public SaleException(string message) :base(message)
        {
            SaveError(message);
        }

        void SaveError(string message)
        {
            // X logica para guardar el error ocurrido
        }
    }
}
