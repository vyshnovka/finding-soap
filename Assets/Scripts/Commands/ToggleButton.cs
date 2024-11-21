using Naninovel;

namespace Commands
{
    [CommandAlias("toggleButton")]
    public class ToggleButton : Command
    {
        [ParameterAlias("name"), RequiredParameter]
        public StringParameter buttonName;

        public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
        {
            Internal.UI.UIManager.OnToggleButton.Invoke(buttonName.Value);

            return UniTask.CompletedTask;
        }
    }
}