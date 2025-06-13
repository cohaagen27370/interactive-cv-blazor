

namespace interactiveCvBlazor.States;

public class SetPageAction(string newPage)
{
    public string NewPage { get; set; } = newPage;
}