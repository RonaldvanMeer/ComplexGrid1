using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using TestComplexGrid.ViewModels;

namespace TestComplexGrid.Controllers
{
    public class HomeController : Controller
    {

        private static readonly List<LocationViewModel> _locations = new List<LocationViewModel>() {
            new LocationViewModel(){
                Id=1,
                Location = "Amsterdam",
                Active = true},
            new LocationViewModel(){
                Id=2,
                Location = "Rotterdam",
                Active = true}
        };

        private static readonly List<DepartmentViewModel> _departments = new List<DepartmentViewModel>() {
            new DepartmentViewModel(){
                    Id = 1,
                    Department = "Hrm",
                    Location = _locations.Single(x=> x.Id == 1),
                    Active = true
                },
                new DepartmentViewModel(){
                    Id = 2,
                    Department = "Hrm",
                    Location = _locations.Single(x=> x.Id == 2),
                    Active = true
                },
        };

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Read_Departments([DataSourceRequest]DataSourceRequest dataSourceRequest)
        {
            return Json(_departments.ToDataSourceResult(dataSourceRequest));
        }

        public IActionResult Create_Departments([DataSourceRequest] DataSourceRequest request, DepartmentViewModel departmentViewModel)
        {
            if (departmentViewModel != null && ModelState.IsValid)
            {
                int newId = new List<DepartmentViewModel>(_departments).Max(x => x.Id) + 1;
                departmentViewModel.Id = newId;
                _departments.Add(departmentViewModel);
            }
            return Json(new[] { departmentViewModel }.ToDataSourceResult(request, ModelState));
        }

        public IActionResult Update_Departments([DataSourceRequest] DataSourceRequest request, DepartmentViewModel departmentViewModel)
        {
            if (departmentViewModel != null && ModelState.IsValid)
            {
                DepartmentViewModel elementToReplace = _departments.Single(x => x.Id == departmentViewModel.Id);
                _departments.Remove(elementToReplace);
                _departments.Add(departmentViewModel);
            }
            return Json(new[] { departmentViewModel }.ToDataSourceResult(request, ModelState));
        }

        public IActionResult Read_Locations()
        {
            return Json(_locations);
        }
    }
}