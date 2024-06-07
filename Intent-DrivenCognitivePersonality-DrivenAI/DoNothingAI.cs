namespace Intent_DrivenCognitivePersonality_DrivenAI
{
    public class DoNothingAI : CharacterAI
    {
        public DoNothingAI(string name) : base(name, 0.0, 0.0, 0.0, 0.0, 0.0) { }

        // Override the decision-making process to always wait
        public override void DecideAction(string context)
        {
            NeutralAction(context);
        }
    }
}