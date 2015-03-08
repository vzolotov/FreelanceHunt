using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Шаблон элемента пустой страницы задокументирован по адресу http://go.microsoft.com/fwlink/?LinkId=234238

namespace FreelanceHunt
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        


        /*private string GetSHA256Key(string url, string methodName, string postParams = default(string))
        {
            postParams = "";
            var secretKey = url + methodName + postParams;
            //$url.$method.$post_params, $api_secret
            var enc = System.Text.ASCIIEncoding.ASCII;
            var secretBytes = enc.GetBytes(secretKey);
            var key = enc.GetBytes(_secret);
            System.Security.Cryptography.HMACSHA256 a = new System.Security.Cryptography.HMACSHA256(key);
            var result = a.ComputeHash(secretBytes);
            var resstring = CryptographicBuffer.EncodeToBase64String(result.AsBuffer());
            return resstring;
        }*/

        public string CorrespondenceList()
        {
            string url = "https://api.freelancehunt.com/threads?filter=new";
            return url;
            //var sign = Signature(url, )
        }
    }
}
