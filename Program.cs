﻿using System.Collections.Generic;

namespace miniprojekt_sql;
class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("Welcome to the time report program.");

        List<ProjectModel> allProjects = PostgressDataAccess.ListProjects();
		List<PersonModel> allUser = PostgressDataAccess.ListPersons();

		List<string> menuOptions = new List<string> {"Create user", "Create a project", "Time reporting", "Edit project name"};


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
				Console.WriteLine("Create project");
				CreateProject();
			}
			// Om användaren trycker "3" och vill välja användare och rapportera tid
			else if (userChoiceIndex == 2)
			{
				Console.WriteLine("Time report");
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
				Console.WriteLine("Change time: ");
				UpdateProjectName();
			}
			else Console.WriteLine("Invalid input!");
			return;
		}
		

    }

	// Listar alla menyval via en List av strings
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
    static void UpdateProjectName()
	{
		List<ProjectModel> projects = PostgressDataAccess.ListProjects();

		int i = 1;
		foreach (ProjectModel project in projects)
		{
            Console.WriteLine(i++ + " " + project.project_name);
        }

        Console.WriteLine("Skriv in nummret på projektet du vill ändra: ");
		int userInput = Convert.ToInt32(Console.ReadLine());	

			if (userInput <= projects.Count() && userInput > 0)
			{
				Console.WriteLine("Please enter a new name: ");
				string newprojectname = Console.ReadLine();

				projects[userInput - 1].project_name = newprojectname;
				PostgressDataAccess.ChangeProjectName(projects[userInput - 1]);
            }
        
    }

}
