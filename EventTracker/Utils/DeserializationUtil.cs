using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventTracker.Models;
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