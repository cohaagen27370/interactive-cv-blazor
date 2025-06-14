using Serilog;

namespace interactiveCvBlazor.Components.Skill;

public class SkillContentModel
{
    public string Name { get; set; } = string.Empty;

    public int Level { get; set; }

    public int LevelBy5
    {
        get
        {
            var propValue = (this.Level / 100.0) * 5.0;
            var value = (int)propValue;
            
            Log.Debug(value.ToString());
            return value == 0 ? 1 : value;;
        }
    } 

    public string Label { get; set; } = string.Empty;
    
}