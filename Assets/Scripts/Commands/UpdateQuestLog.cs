using Naninovel;

namespace Commands
{
    [CommandAlias("updateQuestLog")]
    public class UpdateQuestLog : Command
    {
        [ParameterAlias("text"), RequiredParameter]
        public StringParameter QuestLogText;

        public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
        {
            Internal.UI.UIManager.OnUpdateQuestLog?.Invoke(QuestLogText.Value);

            return UniTask.CompletedTask;
        }
    }
}