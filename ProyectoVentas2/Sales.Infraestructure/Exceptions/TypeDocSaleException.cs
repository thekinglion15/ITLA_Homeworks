namespace Sales.Infraestructure.Exceptions
{
    public class TypeDocSaleException : Exception
    {
        public TypeDocSaleException(string message) :base(message)
        {
            SaveError(message);
        }

        void SaveError(string message)
        {
            // X logica para guardar el error ocurrido
        }
    }
}
