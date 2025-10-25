using System.ComponentModel.DataAnnotations;

namespace BrokerDevWebsite.Models;

public class ContactFormModel
{
    [Required(ErrorMessage = "Please enter your name")]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please enter your email address")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please enter your company name")]
    [StringLength(200)]
    public string Company { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please select your current BMS")]
    public string CurrentSystem { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please tell us about your needs")]
    [StringLength(2000, MinimumLength = 20, ErrorMessage = "Please provide at least 20 characters describing your needs")]
    public string Message { get; set; } = string.Empty;
}
