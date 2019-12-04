using Newtonsoft.Json;
using RestSharp;

namespace EventTracker.Utils
{
  public static class DeserializationUtil
  {
    public static T DeserializeRestResponse<T>(IRestResponse response)
    {
      var deserializedObject = JsonConvert.DeserializeObject<T>(response.Content);

      return deserializedObject;
    }
  }
}