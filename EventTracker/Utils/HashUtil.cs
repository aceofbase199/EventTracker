﻿using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTracker.Utils
{
  public class HashUtil
  {
    public static string Create(string value, string salt)
    {
      var valueBytes = KeyDerivation.Pbkdf2(
                password: value,
                salt: Encoding.UTF8.GetBytes(salt),
                prf: KeyDerivationPrf.HMACSHA512,
                iterationCount: 10000,
                numBytesRequested: 256 / 8);

      return Convert.ToBase64String(valueBytes);
    }

    public static bool Validate(string value, string salt, string hash) => Create(value, salt) == hash;
  }
}
