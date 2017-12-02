namespace Assets.Scripts.Quests
{
    public abstract class Quest
    {
        public string Name { get; set; }

        public void Complete(PlayerStats stats)
        {
            OnQuestCompleted(stats);
        }

        public abstract void OnQuestCompleted(PlayerStats stats); //todo should pass player reference here
    }
}