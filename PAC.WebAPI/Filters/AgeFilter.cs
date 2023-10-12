using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using PAC.Domain;

namespace PAC.WebAPI.Filters
{
    public class AgeFilter : Attribute, IActionFilter
    {
        public int MinAge { get; set; }
        public int MaxAge { get; set; }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var students = context.HttpContext.Items["Students"] as List<Student>;

            if (students != null)
            {
                var filteredStudents = students
                    .Where(student => student.Age >= MinAge && student.Age <= MaxAge)
                    .ToList();
                context.HttpContext.Items["Students"] = filteredStudents;
            }
        }
    }
}
