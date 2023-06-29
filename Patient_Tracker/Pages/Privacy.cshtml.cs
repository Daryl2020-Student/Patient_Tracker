namespace Patient_Tracker.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            // This method is executed when the HTTP GET request is made to the Privacy page.
            // Here, you can perform any necessary actions or retrieve data before rendering the page.
            // In this case, the method is empty as no specific actions are required for the Privacy page.
        }
    }
}
