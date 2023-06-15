using Microsoft.AspNetCore.Mvc;
using Pesquisa.WebApp.Mvc.Models;

namespace Pesquisa.WebApp.Mvc.Controllers
{
    public class HomeController : MainController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger) : base(logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Home page loaded");

            return View();
        }

        public IActionResult Privacy()
        {
            _logger.LogInformation("Privacy page loaded");

            return View();
        }

        [Route("erro/{id:length(3,3)}")]
        public IActionResult Error(int id)
        {
            _logger.LogError($"Erro: {id}");

            var modelErro = new ErrorViewModel();

            if (id == 500)
            {
                modelErro.ErrorMessage = "Ocorreu um erro! Tente novamente mais tarde ou contate nosso suporte.";
                modelErro.ErrorTitle = "Ocorreu um erro!";
                modelErro.ErrorCode = id;
            }
            else if (id == 404)
            {
                modelErro.ErrorMessage =
                    "A página que está procurando não existe! <br />Em caso de dúvidas entre em contato com nosso suporte";
                modelErro.ErrorTitle = "Ops! Página não encontrada.";
                modelErro.ErrorCode = id;
            }
            else if (id == 403)
            {
                modelErro.ErrorMessage = "Você não tem permissão para fazer isto.";
                modelErro.ErrorTitle = "Acesso Negado";
                modelErro.ErrorCode = id;
            }
            else
            {
                return StatusCode(404);
            }

            return View("Error", modelErro);
        }
    }
}