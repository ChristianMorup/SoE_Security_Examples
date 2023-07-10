using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace XSS_JSContext.Pages
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
            Result = searchTerm;
        }
    }
}