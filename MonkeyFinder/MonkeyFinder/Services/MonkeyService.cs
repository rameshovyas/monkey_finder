
using MonkeyFinder.Model;
using System.Net.Http.Json;
using System.Text.Json;

namespace MonkeyFinder.Services
{    
    public class MonkeyService
    {
        //List of monkey data
        List<Monkey> monkeyList = new();
        HttpClient httpClient; // For fetching remote API service

        public MonkeyService()
        {
            this.httpClient = new HttpClient();
        }

        public async Task<List<Monkey>> GetMonkeys()
        {
            if (monkeyList.Count > 0)
                return monkeyList;

            //Reading data from remote api
            var response = await httpClient.GetAsync("https://montemagno.com/monkeys.json");

            if(response.IsSuccessStatusCode)
            {
                monkeyList = await response.Content.ReadFromJsonAsync<List<Monkey>>(); // Deserialize from json to monkeys list
            }
           

            // Reading from local file systems instead of remote api
           /* 
            using var stream = await FileSystem.OpenAppPackageFileAsync("monkeydata.json");
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();
            monkeyList = JsonSerializer.Deserialize<List<Monkey>>(contents);
           */

            return monkeyList;
        }



    }
}
