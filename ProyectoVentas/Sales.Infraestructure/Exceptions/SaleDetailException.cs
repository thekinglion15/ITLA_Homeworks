namespace Sales.Infraestructure.Exceptions
{
    public class SaleDetailException : Exception
    {
        public SaleDetailException(string message) :base(message)
        {
            SaveError(message);
        }

        void SaveError(string message)
        {
            // X logica para guardar el error ocurrido
        }
    }
}
