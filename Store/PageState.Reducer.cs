

using Fluxor;

namespace interactiveCvBlazor.States;

public static class SetPageReducer
{
    [ReducerMethod]
    public static PageState ReduceSetPageAction(PageState state, SetPageAction action)
    {
        return new PageState() { Page = action.NewPage};
    }
}