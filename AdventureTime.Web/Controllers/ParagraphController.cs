using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdventureTime.Data.Concrete;
using AdventureTime.Data.Entities;
using AdventureTime.Data.Abstract;

namespace AdventureTime.Web.Controllers
{
    public class ParagraphController : Controller
    {
        private IParagraphRepository paraRepo;
        private IStoryRepository storyRepo;

        public ParagraphController(IParagraphRepository paragraphs, IStoryRepository stories)
        {
            this.paraRepo = paragraphs;
            this.storyRepo = stories;
        }

        public ActionResult List()
        {
            return View(paraRepo.Paragraphs);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public  ActionResult Create(AdventureTime_Paragraph newPara)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    paraRepo.SaveParagraph(newPara);
                    return View("List");
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Paragraph", "Create"));

            }
            return View();
        }

        public ViewResult Details(int id)
        {
            AdventureTime_Paragraph para = paraRepo.Paragraphs.FirstOrDefault(p => p.ParagraphID == id);

            return View(para);
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            AdventureTime_Paragraph para = paraRepo.Paragraphs.FirstOrDefault(p => p.ParagraphID == id);
            return View(para);
        }

        [HttpPost]
        public ActionResult Edit(AdventureTime_Paragraph para)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    paraRepo.SaveParagraph(para);
                    return RedirectToAction("List");
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Paragraph", "Edit"));
            }
            return View(para);
        }
    }
}