using System.Reflection.Metadata.Ecma335;
using interactive;

namespace interactiveCvBlazor.Components.Experience;

public class ExperienceModel
{
    public SocietyModel Society { get; set; } = new();

    public string Job { get; set; } = string.Empty;

    public int StartYear { get; set; }
    public int? EndYear { get; set; }
    public string Description { get; set; } = string.Empty;
    public List<TagModel> Tags { get; set; } = [];
}