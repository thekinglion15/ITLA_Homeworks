namespace Sales.Infraestructure.Exceptions
{
    public class RoleMenuException : Exception
    {
        public RoleMenuException(string message) : base(message)
        {
            SaveError(message);
        }

        void SaveError(string message)
        {
            // X logica para guardar el error ocurrido
        }
    }
}
