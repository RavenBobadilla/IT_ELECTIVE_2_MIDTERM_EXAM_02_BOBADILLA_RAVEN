using System.Collections.Generic;
using System.Linq;

public static class PatientVisitRepository
{
    private static List<PatientVisit> visits = new List<PatientVisit>();

    public static void Add(PatientVisit visit)
    {
        visit.Id = visits.Count + 1;
        visit.VisitNumber = $"V{visit.Id:0000}";
        visits.Add(visit);
    }

    public static List<PatientVisit> GetAll() => visits;

    public static PatientVisit GetById(int id)
    {
        var visit = visits.FirstOrDefault(v => v.Id == id);
        if (visit == null)
            throw new KeyNotFoundException($"No patient visit found with Id {id}");
        return visit;
    }


    public static void Update(PatientVisit visit)
    {
        var existing = GetById(visit.Id);
        if (existing != null)
        {
            existing.FirstName = visit.FirstName;
            existing.LastName = visit.LastName;
            existing.Age = visit.Age;
            existing.Sex = visit.Sex;
            existing.ContactNumber = visit.ContactNumber;
            existing.Address = visit.Address;
            existing.Physician = visit.Physician;
            existing.VisitType = visit.VisitType;
            existing.ArrivalDateTime = visit.ArrivalDateTime;
            existing.ChiefComplaint = visit.ChiefComplaint;
            existing.Notes = visit.Notes;
            existing.Status = visit.Status;
            existing.ConsultationCompletedDateTime = visit.ConsultationCompletedDateTime;
        }
    }


    public static void CompleteConsultation(int id)
    {
        var visit = GetById(id);
        if (visit != null)
        {
            visit.Status = "Completed";
            visit.ConsultationCompletedDateTime = System.DateTime.Now;
        }
    }

    public static List<PatientVisit> Search(string keyword)
    {
        if (string.IsNullOrEmpty(keyword))
            return visits;

        return visits.Where(v =>
            (!string.IsNullOrEmpty(v.FirstName) && v.FirstName.ToLower().Contains(keyword.ToLower())) ||
            (!string.IsNullOrEmpty(v.LastName) && v.LastName.ToLower().Contains(keyword.ToLower()))
        ).ToList();
    }
}
