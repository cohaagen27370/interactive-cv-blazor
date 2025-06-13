namespace interactiveCvBlazor.Components.Skill;

public class SkillModel
{
    public string Title { get; set; } = string.Empty;

    public List<SkillContentModel> Content { get; set; } = [];
}