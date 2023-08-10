namespace Patient_Tracker.Services
{
    public class AddressService
    {
        private readonly HttpClient _client = new();

        private List<ZipModel> items = new();

        private readonly string resp = "results";

        private readonly string url = "https://maps.googleapis.com/maps/api/geocode/json?components=postal_code:";

        private readonly string component = "|country:IE";

        private const string apiKey = "AIzaSyCXW3ZR9RgDYMJf3bq1tJW7kSoIJlOpMqU";

        public async Task<List<ZipModel>?> GetAddress(string eircode)
        {

            string fullUrl = url+eircode+component+"&key="+apiKey;

            var response = await _client.GetStreamAsync(fullUrl);

            using StreamReader reader = new(response);

            string value = await reader.ReadToEndAsync();

            JObject json = JObject.Parse(value);

            if (json.ContainsKey(resp))
            {
                var responseData = json[resp]?.ToString();
                if (responseData != null)
                {
                    items = JsonConvert.DeserializeObject<List<ZipModel>>(responseData);
                }
            }
            return items;
        }
    }
}
