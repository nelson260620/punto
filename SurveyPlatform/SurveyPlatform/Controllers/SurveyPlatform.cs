using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using SurveyPlatform.date;

namespace SurveyPlatform.Controllers
{
    public class SurveyController : Controller
    {
        private static List<Survey> surveys = new List<Survey>();

        public IActionResult Index()
        {
            return View(surveys);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Survey survey)
        {
            survey.CreatedAt = DateTime.Now;
            surveys.Add(survey);
            return RedirectToAction("Index");
        }

        public IActionResult Answer(int id)
        {
            var survey = surveys.FirstOrDefault(s => s.Id == id);
            if (survey == null)
                return NotFound();

            return View(survey);
        }

        [HttpPost]
        public IActionResult Answer(Survey survey)
        {
            // Aquí puedes guardar las respuestas enviadas por el usuario
            return RedirectToAction("Index");
        }

        public IActionResult Results(int id)
        {
            var survey = surveys.FirstOrDefault(s => s.Id == id);
            if (survey == null)
                return NotFound();

            var resultViewModel = new SurveyResultViewModel
            {
                Title = survey.Title,
                QuestionResults = survey.Questions?.Select(q => new QuestionResultViewModel
                {
                    Text = q.Text,
                    OptionResults = q.Options?.Select(o => new OptionResultViewModel
                    {
                        Text = o.Text,
                        Votes = o.Votes
                    }).ToList() ?? new List<OptionResultViewModel>()
                }).ToList() ?? new List<QuestionResultViewModel>()
            };

            return View(resultViewModel);
        }

    }
}
