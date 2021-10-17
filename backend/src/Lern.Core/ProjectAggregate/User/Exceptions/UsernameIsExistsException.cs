using System;

namespace Lern.Core.ProjectAggregate.User.Exceptions
{
    public class UsernameIsExistsException : Exception
    {
        public UsernameIsExistsException(string message = "This username has exists in db, please choose another") :
            base(message)
        {
        }
    }
}