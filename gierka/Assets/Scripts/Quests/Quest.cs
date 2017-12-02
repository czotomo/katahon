namespace Assets.Scripts.Quests
{
    public abstract class Quest
    {
        public string Name { get; set; }

        public void Complete()
        {
            OnQuestCompleted();
        }

        public abstract void OnQuestCompleted(); //todo should pass player reference here
    }
}