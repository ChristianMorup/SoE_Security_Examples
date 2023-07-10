using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace XSS.Pages
{
    public class SearchPageModel : PageModel
    {
        public string Result { get; set; } = string.Empty;
        private readonly ILogger<SearchPageModel> _logger;

        public SearchPageModel(ILogger<SearchPageModel> logger)
        {
            _logger = logger;
        }

        public void OnGet(string searchTerm)
        {
            this.Result = string.IsNullOrEmpty(searchTerm)
                ? ""
                : $"Your search for <i>{searchTerm}</i> did not yield any results";
        }
    }
}