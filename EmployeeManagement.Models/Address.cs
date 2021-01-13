using Newtonsoft.Json;

public class Address
{
    [JsonProperty("street")]
    public string StreetAddress { get; set; }

    public string Suite { get; set; }
    public string City { get; set; }
    public string ZipCode { get; set; }
    //public Geo Geo { get; set; }
}