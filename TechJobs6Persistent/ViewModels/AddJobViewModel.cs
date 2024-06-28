using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using TechJobs6Persistent.Models;

namespace TechJobs6Persistent.ViewModels;

public class AddJobViewModel
{
    public int EmployerId {get; set;}

    [Required(ErrorMessage = "Name is required.")]
    public string Name { get; set; }
    
    public List<SelectListItem>? Employers {get; set;}

    public AddJobViewModel(List<Employer> employers)
    {
        Employers = [];

        foreach (var employer in employers)
        {
            Employers.Add(
                new SelectListItem
                {
                    Value = employer.Id.ToString(),
                    Text = employer.Name
                }
            );
        }
    }

    public AddJobViewModel(){}
}