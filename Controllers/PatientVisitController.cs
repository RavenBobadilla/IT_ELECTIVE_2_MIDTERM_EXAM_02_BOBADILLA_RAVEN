using Microsoft.AspNetCore.Mvc;

public class PatientVisitController : Controller {
    public IActionResult Index() {
        return View(PatientVisitRepository.GetAll());
    }

    public IActionResult Create() => View();

    [HttpPost]
    public IActionResult Create(PatientVisit visit) {
        if (ModelState.IsValid) {
            PatientVisitRepository.Add(visit);
            return RedirectToAction("Index");
        }
        return View(visit);
    }

    public IActionResult Edit(int id) {
        var visit = PatientVisitRepository.GetById(id);
        return View(visit);
    }

    [HttpPost]
    public IActionResult Edit(PatientVisit visit) {
        if (ModelState.IsValid) {
            PatientVisitRepository.Update(visit);
            return RedirectToAction("Index");
        }
        return View(visit);
    }

    public IActionResult Details(int id) {
        var visit = PatientVisitRepository.GetById(id);
        return View(visit);
    }

    public IActionResult Complete(int id) {
        PatientVisitRepository.CompleteConsultation(id);
        return RedirectToAction("Index");
    }

    public IActionResult Search(string keyword) {
        var results = PatientVisitRepository.Search(keyword);
        return View("Index", results);
    }
}
