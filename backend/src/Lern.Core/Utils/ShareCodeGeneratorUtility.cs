using System;
using System.Text;
using Lern.Core.ProjectAggregate.Group;

namespace Lern.Core.Utils
{
    public static class ShareCodeGeneratorUtility
    {
        public static string GetShortCode(Group group)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(@group.GetHashCode().ToString()))[..10];
        }
    }
}