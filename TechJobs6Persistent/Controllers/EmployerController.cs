﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechJobs6Persistent.Data;
using TechJobs6Persistent.Models;
using TechJobs6Persistent.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobs6Persistent.Controllers
{
    public class EmployerController : Controller
    { 
        private JobDbContext context;
        

        public EmployerController(JobDbContext dbContext)
        {  
            context = dbContext;
        }
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            List<Employer> employers = [.. context.Employers];

            return View(employers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            AddEmployerViewModel addEmployerViewModel = new();
            return View(addEmployerViewModel);
        }

        [HttpPost]
        public IActionResult ProcessCreateEmployerForm(Employer employer)
        {
            if(ModelState.IsValid)
            {
                Employer newEmployer = new()
                {
                    Name = employer.Name,
                    Location = employer.Location
                };

                context.Employers.Add(newEmployer);
                context.SaveChanges();
                return Redirect("Index");
            }
            else
            {
                return View("Create");
            }
        }

        public IActionResult About(int id)
        {
            Employer theEmployer = context.Employers.Find(id);
            ViewBag.Employers.Add(theEmployer);

            return View();
        }

    }
}

