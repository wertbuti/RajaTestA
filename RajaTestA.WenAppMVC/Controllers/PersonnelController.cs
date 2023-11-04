using Microsoft.AspNetCore.Mvc;
using RajaTestA.Models.ViewModels;
using RajaTestA.Services.Services.Interfaces;

namespace RajaTestA.WenAppMVC.Controllers
{
    public class PersonnelController : Controller
    {
        private readonly IPersonnelService _personnelService;
        public PersonnelController(IPersonnelService personnelService)
        {
            _personnelService = personnelService;
        }

        public ActionResult Index()
        {
            try
            {
                var personnels = _personnelService.GetAllPersonnel();
                var personnelVMs = PersonnelVM.From(personnels);
                return View(personnelVMs);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind("Id,FirstName,LastName,Age,Mobile")] PersonnelVM personnelVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var personnel = PersonnelVM.To(personnelVM);
                    _personnelService.InsertPersonnel(personnel);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    return Problem(ex.Message);
                }
            }
            return RedirectToAction(nameof(Create));
        }

        public ActionResult Edit(int id)
        {
            var personnel = _personnelService.GetPersonnelById(id);
            if (personnel == null)
            {
                return NotFound("not exist");
            }
            var personnelVM = PersonnelVM.From(personnel);
            return View(personnelVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id
            , [Bind("Id,FirstName,LastName,Age,Mobile")] PersonnelVM personnelVM)
        {
            if (id != personnelVM.Id)
            {
                return NotFound("not exist");
            }
            if (ModelState.IsValid)
            {
                try
                {
                    var personnel = PersonnelVM.To(personnelVM);
                    _personnelService.UpdatePersonnel(personnel);
                }
                catch (Exception ex)
                {
                    return Problem(ex.Message);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(personnelVM);
        }

        public ActionResult Details(int id)
        {
            var personnel = _personnelService.GetPersonnelById(id);
            var personnelVM = PersonnelVM.From(personnel);
            return View(personnelVM);
        }

        public ActionResult Delete(int id)
        {
            var personnel = _personnelService.GetPersonnelById(id);
            if (personnel == null)
            {
                return NotFound("not exist");
            }
            var personnelVM = PersonnelVM.From(personnel);
            return View(personnelVM);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _personnelService.DeletePersonnel(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(id);
            }
        }
    }
}
