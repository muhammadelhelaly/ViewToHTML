using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ViewToHTML.Example.Models;
using ViewToHTML.Services;

namespace ViewToHTML.Example.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IViewRendererService _viewRendererService;

        private readonly List<Book> _books = new ();

        public HomeController(ILogger<HomeController> logger, IViewRendererService viewRendererService)
        {
            _logger = logger;
            _viewRendererService = viewRendererService;

            _books.AddRange(new List<Book>()
            {
                new Book { Id = 1, Title = "Book 1" },
                new Book { Id = 2, Title = "Book 2" },
                new Book { Id = 3, Title = "Book 3" },
                new Book { Id = 4, Title = "Book 4" },
                new Book { Id = 5, Title = "Book 4" },
                new Book { Id = 6, Title = "Book 6" }
            });
        }

        public IActionResult Index()
        {
            return View(_books);
        }

        public async Task<IActionResult> GetHTML()
        {
            var templatePath = "~/Views/Home/Index.cshtml";
            var html = await _viewRendererService.RenderViewToStringAsync(ControllerContext, templatePath, _books);

            return Ok(html);

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}