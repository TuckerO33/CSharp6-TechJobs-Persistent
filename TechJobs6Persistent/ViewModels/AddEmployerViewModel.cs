using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using TechJobs6Persistent.Models;

namespace TechJobs6Persistent.ViewModels;

public class AddEmployerViewModel
{
    [Required(ErrorMessage = "Username is required")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Username is required")]
    public string? Location { get; set; }



}