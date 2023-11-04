using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RajaTestA.DomainEntities.Entities;
using RajaTestA.Models.ViewModels;
using RajaTestA.Services.Services.Interfaces;
using RajaTestA.WenAppMVC.Models;

namespace RajaTestA.WenAppMVC.Controllers
{
    public class PersonnelCertificateController : Controller
    {
        private readonly IPersonnelCertificateService _personnelCertificateService;
        private readonly IPersonnelService _personnelService;
        private readonly ICertificateService _certificateService;
        public PersonnelCertificateController(
            IPersonnelCertificateService personnelCertificateService,
            IPersonnelService personnelService,
            ICertificateService certificateService)
        {
            _personnelCertificateService = personnelCertificateService;
            _personnelService = personnelService;
            _certificateService = certificateService;
        }

        public ActionResult Index(int personnelId)
        {
            try
            {
                var personnelCertificates = _personnelCertificateService.GetPersonnelCertificateByPersonnelId(personnelId);
                var personnelCertificateVMs = new List<PersonnelCertificateVM>();

                var personnel = new Personnel();
                if (personnelCertificates == null || personnelCertificates.Count == 0)
                {
                    personnel = _personnelService.GetPersonnelById(personnelId);
                }
                else
                {
                    personnel = personnelCertificates[0].Personnel;
                    personnelCertificateVMs = PersonnelCertificateVM.From(personnelCertificates);
                }

                var personnelVM = PersonnelVM.From(personnel);
                

                PersonnelAndPersonnelCertificate personnelAndPersonnelCertificate =
                    new PersonnelAndPersonnelCertificate { PersonnelVM = personnelVM, PersonnelCertificateVMs = personnelCertificateVMs };

                ViewData["PersonnelFullName"] = personnelVM.FullName;
                return View(personnelAndPersonnelCertificate);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        public ActionResult Create(int personnelId)
        {
            ViewBag.personnelId = personnelId;

            var certificates = _certificateService.GetAllCertificate();
            var certificateVMs = CertificateVM.From(certificates);
            certificateVMs.Insert(0, new CertificateVM());
            ViewData["CertificateId"] = new SelectList(certificateVMs, "Id", "Name", 0);

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind("Id,PersonnelId,CertificateId,YearCatch,Gpa")] PersonnelCertificateInsertVM personnelCertificateInsertVM)
        {
            //ModelState["Personnel"].ValidationState = Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Valid;
            //ModelState["Certificate"].ValidationState = Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Valid;
            if (ModelState.IsValid)
            {
                try
                {
                    var personnelCertificate = PersonnelCertificateInsertVM.To(personnelCertificateInsertVM);
                    _personnelCertificateService.InsertPersonnelCertificate(personnelCertificate);
                    return RedirectToAction(nameof(Index), new { personnelId = personnelCertificate.PersonnelId });
                }
                catch (Exception ex)
                {
                    return Problem(ex.Message);
                }
            }
            return RedirectToAction(nameof(Create), new { personnelId = personnelCertificateInsertVM.PersonnelId });
        }

        public ActionResult Edit(int id)
        {
            var personnelCertificate = _personnelCertificateService.GetPersonnelCertificateById(id);
            if (personnelCertificate == null)
            {
                return NotFound("not exist");
            }
            var personnelCertificateInsertVM = PersonnelCertificateInsertVM.From(personnelCertificate);

            var certificates = _certificateService.GetAllCertificate();
            var certificateVMs = CertificateVM.From(certificates);
            certificateVMs.Insert(0, new CertificateVM());
            ViewData["CertificateId"] = new SelectList(certificateVMs, "Id", "Name", 0);

            return View(personnelCertificateInsertVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id
            , [Bind("Id,PersonnelId,CertificateId,YearCatch,Gpa")] PersonnelCertificateInsertVM personnelCertificateInsertVM)
        {
            if (id != personnelCertificateInsertVM.Id)
            {
                return NotFound("not exist");
            }
            //ModelState["Personnel"].ValidationState = Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Valid;
            //ModelState["Certificate"].ValidationState = Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Valid;
            if (ModelState.IsValid)
            {
                try
                {
                    var personnelCertificate = PersonnelCertificateInsertVM.To(personnelCertificateInsertVM);
                    _personnelCertificateService.UpdatePersonnelCertificate(personnelCertificate);
                }
                catch (Exception ex)
                {
                    return Problem(ex.Message);
                }
                return RedirectToAction(nameof(Index), new { personnelId = personnelCertificateInsertVM.PersonnelId });
            }
            return View(personnelCertificateInsertVM);
        }

        public ActionResult Details(int id)
        {
            var personnelCertificate = _personnelCertificateService.GetPersonnelCertificateById(id);
            var personnelCertificateVM = PersonnelCertificateVM.From(personnelCertificate);
            return View(personnelCertificateVM);
        }

        public ActionResult Delete(int id)
        {
            var personnelCertificate = _personnelCertificateService.GetPersonnelCertificateById(id);
            if (personnelCertificate == null)
            {
                return NotFound("not exist");
            }
            var personnelCertificateVM = PersonnelCertificateVM.From(personnelCertificate);
            return View(personnelCertificateVM);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int personnelId)
        {
            try
            {
                _personnelCertificateService.DeletePersonnelCertificate(id);
                return RedirectToAction(nameof(Index), new { personnelId = personnelId });
            }
            catch
            {
                return View(id);
            }
        }
    }
}
