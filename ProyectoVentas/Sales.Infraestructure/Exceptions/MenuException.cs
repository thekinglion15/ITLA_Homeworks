namespace Sales.Infraestructure.Exceptions
{
    public class MenuException : Exception
    {
        public MenuException(string message) :base(message)
        {
            SaveError(message);
        }

        void SaveError(string message)
        {
            // X logica para guardar el error ocurrido
        }
    }
}
