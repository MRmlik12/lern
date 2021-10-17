using Lern.Core.Utils;
using Xunit;

namespace Lern.UnitTests.Core.Utils
{
    public class PasswordUtilityTest
    {
        private const string PlainPassword = "example123";

        [Fact]
        public void TestPasswordHashing_ChecksDecryptedPasswordIsCorrectWithPlainPassword()
        {
            Assert.True(PasswordUtility.VerifyPassword(
                PlainPassword,
                PasswordUtility.GetEncryptedPassword(PlainPassword))
            );
        }
    }
}