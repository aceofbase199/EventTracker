using NUnit.Framework;
using EventTracker.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventTracker.Utils.Tests
{
  [TestFixture()]
  public class HashUtilTests
  {
    [Test()]
    public void HashMatchesText()
    {
      // Arrange  
      var message = "passw0rd";
      var salt = SaltUtil.Create();
      var hash = HashUtil.Create(message, salt);

      // Act  
      var match = HashUtil.Validate(message, salt, hash);

      // Assert  
      Assert.True(match);
    }

    [Test]
    public void Hash_does_not_matches_the_text()
    {
      // Arrange  
      var message = "passw0rd";
      var salt = SaltUtil.Create();
      var hash = "blahblahblah";

      // Act  
      var match = HashUtil.Validate(message, salt, hash);

      // Assert  
      Assert.False(match);
    }

    [Test]
    public void Hash_of_two_different_messages_dont_match()
    {
      // Arrange
      var message1 = "passw0rd";
      var message2 = "password";
      var salt = SaltUtil.Create();

      // Act
      var hash1 = HashUtil.Create(message1, salt);
      var hash2 = HashUtil.Create(message2, salt);

      // Assert
      Assert.AreNotEqual(hash1, hash2);
    }
  }
}