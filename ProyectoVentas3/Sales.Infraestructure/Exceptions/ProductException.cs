namespace Sales.Infraestructure.Exceptions
{
    public class ProductException : Exception
    {
        public ProductException(string message) : base(message)
        {
            SaveError(message);
        }

        void SaveError(string message)
        {
            // X logica para guardar el error ocurrido
        }
    }
}
