using Newtonsoft.Json;
using SBLibraryWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SBLibraryWebApi
{
    public class GoogleBooks
    {
        public List<Item> GetGoogleBooks(string searchBookName)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://www.googleapis.com/books/v1/volumes?q=" + searchBookName + "&filter=free-ebooks&maxResults=40&key=AIzaSyCaCtbmSAdS-razqtBaDIddkZzHkXBLvaI"),
            };
            using (var response = client.SendAsync(request))
            {
                //response.EnsureSuccessStatusCode();
                var body = response.Result.Content.ReadAsStringAsync();
                Root googleBooks = new Root();
                try
                {
                    //googleBooks = response.Result.Content.ReadAsAsync<Root>();
                    googleBooks = JsonConvert.DeserializeObject<Root>(body.Result);
                    return googleBooks.items;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            return null;
        }
    }
}
