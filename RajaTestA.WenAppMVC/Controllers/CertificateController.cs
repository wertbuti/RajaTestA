using Microsoft.AspNetCore.Mvc;
using RajaTestA.Models.ViewModels;
using RajaTestA.Services.Services.Interfaces;

namespace RajaTestA.WenAppMVC.Controllers
{
    public class CertificateController : Controller
    {
        private readonly ICertificateService _certificateService;
        public CertificateController(ICertificateService certificateService)
        {
            _certificateService = certificateService;
        }

        public ActionResult Index()
        {
            try
            {
                var certificates = _certificateService.GetAllCertificate();
                var certificateVMs = CertificateVM.From(certificates);
                return View(certificateVMs);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        public ActionResult Details(int id)
        {
            var certificate = _certificateService.GetCertificateById(id);
            var certificateVM = CertificateVM.From(certificate);
            return View(certificateVM);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind("Id,Name")] CertificateVM certificateVM)
        {
            try
            {
                var certificate = CertificateVM.To(certificateVM);
                _certificateService.InsertCertificate(certificate);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        public ActionResult Edit(int id)
        {
            var certificate = _certificateService.GetCertificateById(id);
            if (certificate == null)
            {
                return NotFound("not exist");
            }
            var certificateVM = CertificateVM.From(certificate);
            return View(certificateVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id
            , [Bind("Id,Name")] CertificateVM certificateVM)
        {
            if (id != certificateVM.Id)
            {
                return NotFound("not exist");
            }
            if (ModelState.IsValid)
            {
                try
                {
                    var certificate = CertificateVM.To(certificateVM);
                    _certificateService.UpdateCertificate(certificate);
                }
                catch (Exception ex)
                {
                    return Problem(ex.Message);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(certificateVM);
        }

        public ActionResult Delete(int id)
        {
            var certificate = _certificateService.GetCertificateById(id);
            if (certificate == null)
            {
                return NotFound("not exist");
            }
            var certificateVM = CertificateVM.From(certificate);
            return View(certificateVM);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _certificateService.DeleteCertificate(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(id);
            }
        }
    }
}
