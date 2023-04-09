using System.ComponentModel.DataAnnotations;

namespace RazorPagesMusic.Models;

public class Music
{
    public int Id {get; set;}
    public string? Title {get; set;}

    //public string? Singer {get; set;}

    [Display(Name = "Release Date")]
    [DataType(DataType.Date)]
    public DateTime ReleaseDate {get; set;}
    public string? Key {get; set;}
    public int Bpm {get; set;}
}