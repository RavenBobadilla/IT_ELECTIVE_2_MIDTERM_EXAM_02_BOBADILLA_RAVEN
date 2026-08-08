using System;
using System.ComponentModel.DataAnnotations;

public class PatientVisit
{
    public int Id { get; set; }

    [Display(Name = "Visit Number")]
    public string? VisitNumber { get; set; }

    [Required(ErrorMessage = "First name is required")]
    public string? FirstName { get; set; }

    [Required(ErrorMessage = "Last name is required")]
    public string? LastName { get; set; }

    [Required(ErrorMessage = "Age is required")]
    [Range(0, 120, ErrorMessage = "Age must be between 0 and 120")]
    public int Age { get; set; }

    [Required(ErrorMessage = "Sex is required")]
    public string? Sex { get; set; }

    [Phone(ErrorMessage = "Invalid phone number")]
    public string? ContactNumber { get; set; }

    public string? Address { get; set; }

    public string? Physician { get; set; }

    public string? VisitType { get; set; }

    [Required(ErrorMessage = "Arrival date and time is required")]
    [DataType(DataType.DateTime)]
    public DateTime ArrivalDateTime { get; set; }

    public DateTime? ConsultationCompletedDateTime { get; set; }

    [Required]
    public string Status { get; set; } = "Waiting";

    public string? ChiefComplaint { get; set; }

    public string? Notes { get; set; }
}
