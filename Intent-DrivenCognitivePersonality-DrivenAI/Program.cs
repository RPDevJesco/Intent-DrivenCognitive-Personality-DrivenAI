using Intent_DrivenCognitivePersonality_DrivenAI;

public class Program
{
    public static void Main()
    {
        DoNothingAI newCharacter = new DoNothingAI("DoNothingAI");
        List<CharacterAI> characters = new List<CharacterAI>
        {
            new CharacterAI("AggressiveBot", 0.9, -0.2, 0.1, 0.5, 0.3),
            new CharacterAI("CautiousBot", 0.2, 0.9, 0.4, 0.6, 0.1),
            new CharacterAI("CuriousBot", 0.1, 0.3, 0.9, 0.5, 0.4),
            new CharacterAI("LoyalBot", 0.3, 0.4, 0.2, 0.9, 0.2),
            new CharacterAI("GreedyBot", 0.4, 0.2, 0.3, 0.3, 0.9)
        };

        // Simulate initial decisions
        foreach (var ai in characters)
        {
            ai.DecideAction("initial encounter");
        }
        newCharacter.DecideAction("initial encounter");

        // Simulate some events to update traits
        characters[0].UpdateTraits("victory");
        characters[1].UpdateTraits("defeat");
        characters[2].UpdateTraits("discovery");
        characters[3].UpdateTraits("betrayal");
        characters[4].UpdateTraits("victory");
        newCharacter.UpdateTraits("lazy");

        // Simulate decisions after trait updates
        foreach (var ai in characters)
        {
            ai.DecideAction("post-event encounter");
        }
        newCharacter.DecideAction("post-event encounter");
    }
}