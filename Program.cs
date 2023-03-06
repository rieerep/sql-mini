namespace miniprojekt_sql;
class Program
{
    static void Main(string[] args)
    {

        // Lists all projects in the database
		List<ProjectModel> allProjects = PostgressDataAccess.ListProjects();
        for (int i = 0; i < allProjects.Count; i++)
        {
            //Console.WriteLine(allProjects[i].project_name);
        }

        // Lists all persons in the database
		List<PersonModel> allUser = PostgressDataAccess.ListPersons();
        //string[] allUserArray = allUser.ToArray();
        for (int index = 0; index < allUser.Count; index++)
        {
            //Console.WriteLine($"All users: {allUser[index].person_name}");
        }

        List<string> menuOptions = new List<string> { "Create user", "Create a project", "Time reporting" };
        
        
        // Prints the menu users can choose between.
        MenuSystem(menuOptions);

        int userChoiceIndex = MenuSystem(menuOptions);

        // Om användaren trycker "1" och vill skapa en användare
        if (userChoiceIndex == 0) 
        {
            CreateUser(allUser);
            //Console.WriteLine("Du skapar en användare!");
            //Console.WriteLine("Skriv in in namn på användaren: ");
            //Console.Write(">>>> ");
            //string personName = Console.ReadLine();

            //PersonModel newPerson = new PersonModel()
            //{
            //    person_name = personName
            //};
            //PostgressDataAccess.NewPerson(newPerson);

        }
        // Om användaren trycker "2" och vill skapa ett projekt
        else if (userChoiceIndex == 1)
        {
            Console.WriteLine("Du skapar ett projekt.");
            CreateProject();
            Console.WriteLine("End of method!!!!!");
        }
        // Om användaren trycker "3" och vill välja användare och rapportera tid
        else if (userChoiceIndex == 2)
        {
            Console.WriteLine("Du valde rapportera tid");

            MenuSystem(allUser);
            int userHours = MenuSystem(allUser);
            MenuSystem(allProjects);
            int projectHours = MenuSystem(allProjects);
            AddHours(userHours, projectHours);
            //AddHours(projectUserChoice, personUserChoice)



            // Lista alla användare i databasen
            // Välj vilken användare som ska rapportera tid (Skicka in MenuSystem [] eller <> med namn)
            // Välj vilket projekt användaren ska rapportera tid till (Skicka in MenuSystem [] eller <> med projekt)
            //MenuSystem
        }


	}
    // RUBBER DUCKING!
    // skapa en funktion som tar in en array av strägnar
    // den visar en meny med alla element från arrayen
    // låt anändran välja med piltangenterna
    // returnera vilket index anvädnaren valt.
    // menuSystem(["Hej", "Yo", "Frank"]) -> 1 (anvädnarne valde Yo)

    static int MenuSystem(List<string> menuOptions)
    {
        for (int index = 0; index < menuOptions.Count; index++)
        {
            // Skriver ut menyvalen
            Console.WriteLine($"{index + 1}. {menuOptions[index]}");
        }
        Console.Write(">>>> ");
        string userInput = Console.ReadLine();
        int userChoice = int.Parse(userInput);

        return userChoice - 1;
    }

    // Listar alla projekt i rapporteringsmenyn
	static int MenuSystem(List<ProjectModel> allProjects)
	{
		for (int index = 0; index < allProjects.Count; index++)
		{
			// Skriver ut menyvalen
			Console.WriteLine($"{index + 1}. {allProjects[index].project_name}");
		}
		Console.Write(">>>> ");
		string userInput = Console.ReadLine();
		int projectUserChoice = int.Parse(userInput);

		return projectUserChoice - 1;
	}

	static int MenuSystem(List<PersonModel> allPeople)
	{
		for (int index = 0; index < allPeople.Count; index++)
		{
			// Skriver ut menyvalen
			Console.WriteLine($"{index + 1}. {allPeople[index].person_name}");
		}
		Console.Write(">>>> ");
		string userInput = Console.ReadLine();
		int personUserChoice = int.Parse(userInput);

		return personUserChoice - 1;
	}

	// Method to create a new user in the program
	static void CreateUser(List<PersonModel> createUser)
	{
        
		Console.WriteLine("Skriv in in namn på användaren: ");
		Console.Write(">>>> ");
		string personName = Console.ReadLine();

		PersonModel newPerson = new PersonModel()
		{
			person_name = personName
		};
		PostgressDataAccess.NewPerson(newPerson);
	}

    // Method made to create a new project in the program
    static void CreateProject() 
    {
        Console.WriteLine("Skriv in namn på projektet du vill skapa: ");
        Console.Write(">>>> ");
        string projectName = Console.ReadLine();

        ProjectModel newProject = new ProjectModel()
        {
            project_name = projectName
        };
        PostgressDataAccess.NewProject(newProject);
    }

    static void AddHours(int personUserChoice, int projectUserChoice)
    {
		Console.WriteLine("Skriv in hur många timmar du arbetade på projektet: ");
		int userInput = int.Parse(Console.ReadLine());

        ProjectPersonModel workedHours = new ProjectPersonModel()
        {
            project_id = projectUserChoice,
            person_id = personUserChoice,
            hours = userInput
        };
        PostgressDataAccess.AddTimeToProject(workedHours);

	}

}
