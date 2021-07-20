using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloASPDotNET.Controllers
{
    [Route("/helloworld")]
    public class HelloController : Controller
    {
        

        //public static CreateMessage(string name, string language)
        //{

        //    if (language == "1") Console.WriteLine($"Hello {name}!");
        //    else if (language == "2") Console.WriteLine($"Bonjour {name}!");
        //    else if (language == "3") Console.WriteLine($"Hola {name}!");
        //    else if (language == "4") Console.WriteLine($"Ni Hau {name}!");
        //    else if (language == "5") Console.WriteLine($"Konnichiwa {name}!");
        //    else Console.WriteLine("Try Again");


        //}

        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            string openingFormTag = "<form method='post' action='/helloworld/welcome'>";
            string closingFormTag = " </ form > ";
            string nameInputTag = "<input type='text' name='name' />";
            string submitInputTag = "<input type='submit' value='Greet Me!' />";
            
            string html = openingFormTag + nameInputTag + submitInputTag + closingFormTag;

            return Content(html, "text/html");
        }

        // GET: /<controller>/welcome?name=value or GET: /<controller>/welcome/name
        //[HttpGet]
        //[Route("/helloworld/welcome/{name?}")]

        [HttpGet("welcome/{name?}")]
        [HttpPost]
        public IActionResult Welcome(string name = "World")
        {
            return Content("<h1>Welcome to my app, " + name + "!</h1>", "text/html");
        }

        // GET: /<controller>/
        [HttpGet("language/form")]
        public IActionResult LanguageForm()
        {
            string[] languageSelections = { "English", "French", "Spanish", "Chinese", "Japanese", };

            string openingFormTag = "<form method='post' action='greeting/'>";
            string closingFormTag = " </ form > ";
            string nameInputTag = "<input type='text' name='name' />";
            string submitInputTag = "<input type='submit' value='Greet Me!' />";
            string languageInputTag = "<select name='language'> <option value=''> *Select a language* </option>" +
            " <option value = '1'> English </option>" +
            " <option value = '2'> French </option>" +
            " <option value = '3'> Spanish </option>" +
            " <option value = '4'> Chinese </option>" +
            " <option value = '5'> Japanese </option>";

            //string optionTags = "";

            //foreach(string language in languageSelections)
            //{
            //    optionTags += $"<option value='{language}'>{language}</option>";
            //}

            string html = openingFormTag + nameInputTag + languageInputTag + submitInputTag + closingFormTag;

            return Content(html, "text/html");
        }

        // Roger's Code below. Couldn't get mine to work.
        [HttpGet("language/greeting/")]
        [HttpPost("language/greeting/")]
        public IActionResult HelloLanguage(string name = "Justin", string language = "English")
        {
            string languageSelection = CreateMessage(language);

            return Content($"<h1>{languageSelection} {name}!</h1>", "text/html");
        }

        public string CreateMessage(string language)
        {
            Dictionary<string, string> dictOfLanguages = new Dictionary<string, string>
            {
                {"1", "Hello" },
                {"2", "Bonjour" },
                {"3", "Hola" },
                {"4", "Ni Hau" },
                {"5", "Konnichiwa" },
            };

            return dictOfLanguages[language];
        }




    }
}
