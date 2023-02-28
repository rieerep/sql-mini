namespace miniprojekt_sql;
class Program
{
    static void Main(string[] args)
    {
        //MenuSystem(["Hej", "Yo", "Frank"]);
        Console.WriteLine("Hello, World!");
        string[] menuOptions = { "Hej", "Yo", "Tja" };
        //foreach (string choice in choices)
        //{
        //    Console.WriteLine(choice);
        //}
        MenuSystem(menuOptions);

        string userChoiceIndex = MenuSystem(menuOptions);
        // Här körs "Hej" "yo" eller "Tja"
        // Bygg vidare

    }
    // RUBBER DUCKING!
    // skapa en funktion som tar in en array av strägnar
    // den visar en meny med alla element från arrayen
    // låt anändran välja med piltangenterna
    // returnera vilket index anvädnaren valt.
    // menuSystem(["Hej", "Yo", "Frank"]) -> 1 (anvädnarne valde Yo)

    static string MenuSystem(string[] menuOptions)
    {
        for (int index = 0; index < menuOptions.Length; index++)
        {
            // Skriver ut menyvalen
            Console.WriteLine($"{index + 1}. {menuOptions[index]}");
        }
        string userChoice = Console.ReadLine();

        return userChoice;
    }
}
