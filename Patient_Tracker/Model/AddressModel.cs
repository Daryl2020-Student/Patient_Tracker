namespace Patient_Tracker.Model
{
#nullable disable
    public class AddressModel
    {
        public List<AddressComponent> address_components { get; set; }
        public string formatted_address { get; set; }
        public Geometry geometry { get; set; }
        public string place_id { get; set; }
    }
}
