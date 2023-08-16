namespace Patient_Tracker.Services
{
    public class EircodeService
    {
        private readonly HttpClient _client = new();

        private List<AddressModel> items = new();

        private readonly string resp = "results";

        private readonly string url = "https://maps.googleapis.com/maps/api/geocode/json?address=";

        private const string apiKey = "AIzaSyCXW3ZR9RgDYMJf3bq1tJW7kSoIJlOpMqU";

        public async Task<List<AddressModel>?> GetEircode(string address)
        {
            string fullUrl = url + address + "&key=" + apiKey;

            var response = await _client.GetStreamAsync(fullUrl);

            using StreamReader reader = new(response);

            string value = await reader.ReadToEndAsync();

            JObject json = JObject.Parse(value);

            if (json.ContainsKey(resp))
            {
                var responseData = json[resp]?.ToString();
                if (responseData != null)
                {
                    items = JsonConvert.DeserializeObject<List<AddressModel>>(responseData);
                }
            }
            return items;
        }
    }
}