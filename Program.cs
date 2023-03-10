namespace miniprojekt_sql;
class Program
{
    static void Main(string[] args)
    {
		string aNumberToConvert = "100a";
		string message;

		int result;
		bool success = int.TryParse(aNumberToConvert, out result);

		if (success == true)
		{
			message = "Yay";
		}
		else
		{
			message = "Boo, not valid";
		}

        Console.WriteLine(message);
        Console.WriteLine(success);
        Console.WriteLine(result);

        List<ProjectModel> allProjects = PostgressDataAccess.ListProjects();
		List<PersonModel> allUser = PostgressDataAccess.ListPersons();

		List<string> menuOptions = new List<string> {"Create user", "Create a project", "Time reporting"};


		//MenuSystem(menuOptions);
		//int userChoice = MenuSystem(menuOptions);
		//Console.WriteLine(userChoice);

		// Prints the menu users can choose between.
		//int userChoiceIndex = MenuSystem(menuOptions);
        bool loggedIn = true;
        while (loggedIn)
        {

			int userChoiceIndex = MenuSystem(menuOptions);
			// Om användaren trycker "1" och vill skapa en användare
			if (userChoiceIndex == 0)
			{
				CreateUser();
				return;
			}
			// Om användaren trycker "2" och vill skapa ett projekt
			else if (userChoiceIndex == 1)
			{
				Console.WriteLine("Du skapar ett projekt.");
				CreateProject();
			}
			// Om användaren trycker "3" och vill välja användare och rapportera tid
			else if (userChoiceIndex == 2)
			{
				Console.WriteLine("Du valde rapportera tid");
				// MenuSystem(allUser);
				int userHours = MenuSystem(allUser);
				// MenuSystem(allProjects);
				int projectHours = MenuSystem(allProjects);
				AddHours(userHours, projectHours);
				int chosenID = allProjects[projectHours].id;
                Console.WriteLine("Chosen ID: " + chosenID);
            }
			else if (userChoiceIndex == 3)
			{
				Console.WriteLine("Ändra tid: ");
			}
			else Console.WriteLine("Invalid input!");
			return;
		}
		

    }

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
        // Console.WriteLine($"Du valde {menuOptions[userChoice - 1]}");
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
        personUserChoice++;
		return personUserChoice - 1;
	}

	// Method to create a new user in the program
	static void CreateUser()
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
