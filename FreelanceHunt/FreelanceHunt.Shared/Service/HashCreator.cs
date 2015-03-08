using System;
using System.Collections.Generic;
using System.Text;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
using Windows.Foundation;
using System.Runtime.InteropServices.WindowsRuntime;

namespace FreelanceHunt.Service
{
    public class HashCreator
    {
        #region Члены IHashCreator

        public static string GetSHA256Key(string data, string key, string @params = default(string))
        {
#if WINDOWS_APP
            //$url.$method.$post_params, $api_secret
            var enc = System.Text.ASCIIEncoding.ASCII;
            var secretBytes = enc.GetBytes(data);
            var keyData = enc.GetBytes(key);
            System.Security.Cryptography.HMACSHA256 hash = new System.Security.Cryptography.HMACSHA256(keyData);
            var result = hash.ComputeHash(secretBytes);
            var resstring = CryptographicBuffer.EncodeToBase64String(result.AsBuffer());
#endif
#if WINDOWS_PHONE_APP
            var enc = FreelanceHunt.Common.Encoding.ASCII;
            var secretBytes = enc.GetBytes(data+@params);
            var keyData = enc.GetBytes(key);
            MacAlgorithmProvider provider = MacAlgorithmProvider.OpenAlgorithm(MacAlgorithmNames.HmacSha256);
            var cryptKey = provider.CreateKey(keyData.AsBuffer());
            var result = CryptographicEngine.Sign(cryptKey, secretBytes.AsBuffer());
            var resstring = CryptographicBuffer.EncodeToBase64String(result);
#endif
            
            return resstring;
        }
        #endregion
    }
}
