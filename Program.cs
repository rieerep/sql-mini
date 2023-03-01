namespace miniprojekt_sql;
class Program
{
    static void Main(string[] args)
    {

        List<PersonModel> allUser = PostgressDataAccess.ListPersons();
        for (int index = 0; index < allUser.Count; index++)
        {
            Console.WriteLine($"All users: {allUser[index].person_name}");
        }

        //MenuSystem(["Hej", "Yo", "Frank"]);
        Console.WriteLine("Hello, World!");
        string[] menuOptions = { "Create user", "Create a project", "Rapportera tid" };
        //foreach (string choice in choices)
        //{
        //    Console.WriteLine(choice);
        //}
        MenuSystem(menuOptions);

        int userChoiceIndex = MenuSystem(menuOptions);
        if (userChoiceIndex == 0) 
        {
            Console.WriteLine("Du skapar en användare!");
        }
        else if (userChoiceIndex == 1)
        {
            Console.WriteLine("Du skapar ett projekt.");
        }
        else if (userChoiceIndex == 2)
        {
            Console.WriteLine("Du valde rapportera tid");
        }
        

    }
    // RUBBER DUCKING!
    // skapa en funktion som tar in en array av strägnar
    // den visar en meny med alla element från arrayen
    // låt anändran välja med piltangenterna
    // returnera vilket index anvädnaren valt.
    // menuSystem(["Hej", "Yo", "Frank"]) -> 1 (anvädnarne valde Yo)

    static int MenuSystem(string[] menuOptions)
    {
        for (int index = 0; index < menuOptions.Length; index++)
        {
            // Skriver ut menyvalen
            Console.WriteLine($"{index + 1}. {menuOptions[index]}");
        }
        string userInput = Console.ReadLine();
        int userChoice = int.Parse(userInput);

        return userChoice - 1;
    }
}
