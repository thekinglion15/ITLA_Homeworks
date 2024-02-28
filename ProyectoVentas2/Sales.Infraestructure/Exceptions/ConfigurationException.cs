namespace Sales.Infraestructure.Exceptions
{
    public class ConfigurationException : Exception
    {
        public ConfigurationException(string message) :base(message)
        {
            SaveError(message);
        }

        void SaveError(string message)
        {
            // X logica para guardar el error ocurrido
        }
    }
}
