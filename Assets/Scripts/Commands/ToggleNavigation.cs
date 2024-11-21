using Naninovel;

namespace Commands
{
    [CommandAlias("toggleNavigation")]
    public class ToggleNavigation : Command
    {
        public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
        {
            Internal.UI.UIManager.OnToggleNavigation.Invoke();

            return UniTask.CompletedTask;
        }
    }
}
