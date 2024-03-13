namespace Sales.Infraestructure.Exceptions
{
    public class RoleException : Exception
    {
        public RoleException(string message) :base(message)
        {
            SaveError(message);
        }

        void SaveError(string message)
        {
            // X logica para guardar el error ocurrido
        }
    }
}
