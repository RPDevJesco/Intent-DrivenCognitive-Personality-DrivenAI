namespace Intent_DrivenCognitivePersonality_DrivenAI
{
    public class Intent
    {
        public string Name { get; private set; }
        public List<string> SubIntents { get; private set; }

        public Intent(string name)
        {
            Name = name;
            SubIntents = new List<string>();
        }

        public void AddSubIntent(string subIntent)
        {
            SubIntents.Add(subIntent);
        }
    }
}