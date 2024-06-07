namespace Intent_DrivenCognitivePersonality_DrivenAI
{
    public class CharacterAI
    {
        public string Name { get; private set; }
        public double Aggression { get; private set; }
        public double Caution { get; private set; }
        public double Curiosity { get; private set; }
        public double Loyalty { get; private set; }
        public double Greed { get; private set; }

        protected List<Intent> intents;

        public CharacterAI(string name, double aggression, double caution, double curiosity, double loyalty, double greed)
        {
            Name = name;
            Aggression = aggression;
            Caution = caution;
            Curiosity = curiosity;
            Loyalty = loyalty;
            Greed = greed;

            intents = new List<Intent>
            {
                new Intent("Conquer Territory"),
                new Intent("Protect Ally"),
                new Intent("Acquire Resources")
            };
        }

        // Determine behavior based on traits and intents
        public virtual void DecideAction(string context)
        {
            // Prioritize intents based on traits
            Intent chosenIntent = ChooseIntent();

            // Determine action based on the chosen intent
            switch (chosenIntent.Name)
            {
                case "Conquer Territory":
                    Attack(context);
                    break;
                case "Protect Ally":
                    Defend(context);
                    break;
                case "Acquire Resources":
                    Explore(context);
                    break;
                default:
                    NeutralAction(context);
                    break;
            }
        }

        // Choose intent based on personality traits
        protected virtual Intent ChooseIntent()
        {
            // Example of simple prioritization based on Aggression trait
            if (Aggression > 0.5)
            {
                return intents.Find(i => i.Name == "Conquer Territory");
            }
            else if (Caution > 0.5)
            {
                return intents.Find(i => i.Name == "Protect Ally");
            }
            else if (Curiosity > 0.5)
            {
                return intents.Find(i => i.Name == "Acquire Resources");
            }
            else
            {
                return intents[new Random().Next(intents.Count)];
            }
        }

        // Example actions
        protected void Attack(string context)
        {
            Console.WriteLine($"{Name} decides to attack in the context of {context}!");
            // Attack logic here
        }

        protected void Defend(string context)
        {
            Console.WriteLine($"{Name} decides to defend in the context of {context}!");
            // Defend logic here
        }

        protected void Explore(string context)
        {
            Console.WriteLine($"{Name} decides to explore in the context of {context}!");
            // Explore logic here
        }

        protected void NeutralAction(string context)
        {
            Console.WriteLine($"{Name} decides to wait in the context of {context}.");
            // Neutral action logic here
        }

        // Update traits based on experiences
        public void UpdateTraits(string eventType)
        {
            switch (eventType)
            {
                case "victory":
                    Aggression = AdjustTrait(Aggression, 0.1);
                    break;
                case "defeat":
                    Caution = AdjustTrait(Caution, 0.1);
                    break;
                case "discovery":
                    Curiosity = AdjustTrait(Curiosity, 0.1);
                    break;
                case "betrayal":
                    Loyalty = AdjustTrait(Loyalty, -0.1);
                    break;
                case "lazy":
                    Loyalty = AdjustTrait(Loyalty, 0.0);
                    break;
            }
        }

        // Adjust trait value ensuring it remains within bounds [-1, 1]
        private double AdjustTrait(double trait, double change)
        {
            trait += change;
            return Math.Max(-1, Math.Min(1, trait));
        }
    }
}