using AgentTester.Cards;
using AgentTester.Config;

var settings = AppConfigLoader.Load(AppContext.BaseDirectory);
var deck = new Deck();

Console.WriteLine(settings.WelcomeMessage);

if (settings.AutoShuffleOnStart)
{
    deck.Shuffle();
    Console.WriteLine("Deck shuffled automatically.");
}

PrintHelp();

while (true)
{
    Console.Write("\n> ");
    var input = Console.ReadLine()?.Trim().ToLowerInvariant();

    switch (input)
    {
        case "shuffle":
            deck.Shuffle();
            Console.WriteLine("Deck shuffled.");
            break;

        case "draw":
            try
            {
                var card = deck.Draw();
                Console.WriteLine($"You drew: {card}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            break;

        case "count":
            Console.WriteLine($"Cards remaining: {deck.RemainingCount}");
            break;

        case "help":
            PrintHelp();
            break;

        case "exit":
        case "quit":
            Console.WriteLine("Goodbye!");
            return;

        case null:
            Console.WriteLine("Goodbye!");
            return;

        default:
            Console.WriteLine($"Unknown command: '{input}'. Type 'help' for a list of commands.");
            break;
    }
}

static void PrintHelp()
{
    Console.WriteLine("""
        Commands:
          shuffle  - Shuffle the deck
          draw     - Draw a card from the deck
          count    - Show how many cards remain
          help     - Show this message
          exit     - Quit the app
        """);
}
