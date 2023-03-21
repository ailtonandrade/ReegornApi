using System;

namespace AuthApi.Core.HandleExceprions
{
    public class CustomException : Exception
    {
        public CustomException(string message)
        : base(message)
        {

        }
    }
}
