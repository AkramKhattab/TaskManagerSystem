using Company.G02.BLL.Interfaces;
using Company.G02.BLL.Repositories;
using Company.G02.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Company.G02.PL.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;   // NULL


        public DepartmentsController(IDepartmentRepository departmentRepository) // ASK the CLR to Create Object From DepartmentRepositroy
        {
            _departmentRepository = departmentRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var departments = _departmentRepository.GetAll();
            return View(departments);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //--------- Create ---------//


        [HttpPost]
        [ValidateAntiForgeryToken] // Prevent any Request Outside My Application from Any Tool Or Any Outside Application
        public IActionResult Create(Department model)  /// Returning the view if has no Data = Stay in the same page
        {
            if (ModelState.IsValid) // Server Side Validation
            {
                var count = _departmentRepository.Add(model);
                if (count > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(model);
        }

        //--------- Details ---------//


        public IActionResult Details(int? id, string viewName = "Details") // 100
        {
            if (id is null) return BadRequest(); // 400

            var department = _departmentRepository.Get(id.Value);

            if (department == null) return NotFound(); // 404

            return View(viewName,department);

        }


        //--------- Update ---------//

        [HttpGet]
        public IActionResult Edit(int? id) // 100
        {
            //if (id is null) return BadRequest(); // 400

            //var department = _departmentRepository.Get(id.Value);

            //if (department == null) return NotFound(); // 404

            //return View(department);
            
            return Details(id, "Edit");
        }

        // Posting the Updated Id
        [HttpPost]
        [ValidateAntiForgeryToken] // Prevent any Request Outside My Application from Any Tool Or Any Outside Application
        public IActionResult Edit([FromRoute] int? id, Department model) // 100
        {
            try
            {
                if (id != model.Id) return BadRequest(); //400

                if (ModelState.IsValid)
                {
                    var count = _departmentRepository.Update(model);
                    if (count > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            catch (Exception Ex)
            {
                ModelState.AddModelError(string.Empty, Ex.Message);
            }
            return View(model);

        }


        //--------- Delete ---------//

        [HttpGet]
         public IActionResult Delete(int? id) // 100
         {
            //if (id is null) return BadRequest(); // 400

            //var department = _departmentRepository.Get(id.Value);

            //if (department == null) return NotFound(); // 404

            //return View(department);

            return Details(id, "Delete");

        }



        [HttpPost]
        [ValidateAntiForgeryToken] // Prevent any Request Outside My Application from Any Tool Or Any Outside Application
        public IActionResult Delete([FromRoute] int? id, Department model) // 100
        {
            try
            {
                if (id != model.Id) return BadRequest(); // 400

                if (ModelState.IsValid) // Server Side Validation
                {
                    var count = _departmentRepository.Delete(model);
                    if (count > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            catch (Exception Ex)
            {
                ModelState.AddModelError(string.Empty, Ex.Message);
            }
            return View(model);

        }


    }
}
