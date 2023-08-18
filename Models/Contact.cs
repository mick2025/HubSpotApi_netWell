namespace HubSpotApi.Models
{
    public class Contact
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string platform { get; set; }
        public string contact_source { get; set; }
        public string contact_type { get; set; }
        public string hs_lead_status { get; set; }
        public string subject { get; set; }
        public string message { get; set; }
        public int campaign_id { get; set; }

    }

    public class Properties
    {
        public Contact properties { get; set; }
    }
}
