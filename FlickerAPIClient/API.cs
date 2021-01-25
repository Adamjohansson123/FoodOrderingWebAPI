using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FlickerAPIClient
{
    public static class API
    {
        private const string API_KEY = "08f3783f96193a84c4cb52e595c7fdcb";

        //https://www.flickr.com/services/rest/?method=flickr.photos.search&api_key=08f3783f96193a84c4cb52e595c7fdcb&text=pizza+food&sort=interestingness-desc&privacy_filter=1&safe_search=1&content_type=1&format=json&nojsoncallback=1

        private static async Task<Answer> GetAllRaw(string foodItemName)
        {
            string url = "https://www.flickr.com/services/rest/?method=flickr.photos.search&api_key="+API_KEY+"&text="+foodItemName+"&sort=interestingness-desc&privacy_filter=1&safe_search=1&content_type=1&format=json&nojsoncallback=1";
            try
            {
                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                HttpContent content = new StringContent("", Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("", content);

                var responseString = await response.Content.ReadAsStringAsync();

                return Answer.Complete(responseString);
            }
            catch (Exception ex)
            {
                return Answer.Error("[Log: RestCallAsync()] " + ex.ToString());
            }
        }
        public static async Task<Answer> GetAll(string[] foodItemNames)
        {
            InputValidation(foodItemNames);

            string foodItemName = string.Empty;
            foreach (string item in foodItemNames)
            {
                foodItemName += item + "+";
            }
            foodItemName = foodItemName.Substring(0, foodItemName.LastIndexOf('+'));


            Task<Answer> call = GetAllRaw(foodItemName);

            Answer answer = await call;

            if (!answer.IsASuccess)
                return answer;

            JSON.Root root = JsonConvert.DeserializeObject<JSON.Root>((string)answer.Json);

            List<string> hrefs = new List<string>();

            foreach (JSON.Photo photo in root.photos.photo)
                hrefs.Add(photo.getLink());

            answer = Answer.Complete(hrefs);

            return answer;
        }
        private static void InputValidation(string[] inputs)
        {
            if (inputs.Length == 0)
                throw new ArgumentException("Input string[] can not be empty.");

            foreach (string input in inputs)
            {
                if (string.IsNullOrEmpty(input))
                    throw new ArgumentException("Values in input string[] can not be empty or null.");
                if (string.IsNullOrWhiteSpace(input))
                    throw new ArgumentException("Values in input string[] can not be white Spaces or null.");
            }
        }
    }
}
