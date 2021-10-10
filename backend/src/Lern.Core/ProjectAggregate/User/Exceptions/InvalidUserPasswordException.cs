using System;

namespace Lern.Core.ProjectAggregate.User.Exceptions
{
    public class InvalidUserPasswordException : Exception
    {
        public InvalidUserPasswordException(string message = "Invalid user password") : base(message)
        {
        }
    }
}