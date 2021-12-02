using System.ComponentModel.DataAnnotations;

namespace Stoqui.Models;

public record RegisterProductViewModel
{
    [Required]
    public string? Name { get; set; }

    [Required]
    public string? Description { get; set; }
}