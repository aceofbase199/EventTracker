using NUnit.Framework;
using RestSharp;
using EventTracker.Entities;

namespace EventTracker.Utils.Tests
{
  [TestFixture()]
  public class DeserializationUtilTests
  {
    private IRestResponse _response;
    private User _user;

    [SetUp]
    public void Setup()
    {
      _response = new RestResponse();
      _user = new User
      {
        UserName = "test",
        Password = "test"
      };
    }

    [Test()]
    public void DeserializeRestResponseTest()
    {
      _response.Content = "{\"userName\":\"test\", \"password\":\"test\"}";

      var actualUser = DeserializationUtil.DeserializeRestResponse<User>(_response);

      Assert.IsNotNull(actualUser);
      Assert.AreEqual(_user.UserName, actualUser.UserName);
      Assert.AreEqual(_user.Password, actualUser.Password);
    }
  }
}