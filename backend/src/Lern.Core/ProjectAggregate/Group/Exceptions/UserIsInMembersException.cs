using System;

namespace Lern.Core.ProjectAggregate.Group.Exceptions
{
    public class UserIsInMembersException : Exception
    {
        public UserIsInMembersException(string message = "User was found in members of the group") : base(message)
        {
        }
    }
}