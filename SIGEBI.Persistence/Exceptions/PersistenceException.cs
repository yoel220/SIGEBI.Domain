namespace SIGEBI.Persistence.Exceptions
{
    public class PersistenceException : Exception
    {
        public PersistenceException(string message) : base(message) { }
        public PersistenceException(string message, Exception inner) : base(message, inner) { }
    }
}