#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;

namespace DojoSurveywithModel.Models;

public class Survey
{
    public string yourName { get; set; }
    public string dojoLocation { get; set; }
    public string favoriteLanguage { get; set; }
    public string comments { get; set; }
}
