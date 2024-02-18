namespace VerifyNullablesObjects
{
    /// <summary>
    /// This class receive an object and verify if is null. Case true, throw an exception passed from parameter. Else, returns the object.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class NullOrEmptyVariable<T> : Exception
    {
        private const string DefaultErrorMessage = "Null or empty parameter";

        public NullOrEmptyVariable(string message = DefaultErrorMessage) : base(message) { }

        public static T ThrowIfNull(T? item, string message = DefaultErrorMessage)
        {
            if (item == null)
                throw new NullOrEmptyVariable<T>(message);
            return item;
        }
    }
}