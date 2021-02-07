using System;
using System.Runtime.Serialization;

namespace App
{
    [Serializable]
    public class BenchException : ApplicationException
    {
        protected BenchException()
        {
        }

        protected BenchException(string message) : base(message)
        {
        }

        protected BenchException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BenchException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public static BenchException UnfoundedMethod(string methodName, Type classType)
        {
            return new BenchException($"Unfounded method [{methodName}] in class type [{classType.Name}]");
        }
    }
}