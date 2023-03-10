using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniprojekt_sql
{
    internal class PostgressDataAccess
    {
        public static List<ProjectModel> ListProjects()
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                var output = cnn.Query<ProjectModel>("select * from rer_project", new DynamicParameters());
                //Console.WriteLine(output);
                return output.ToList();
            }
        }

		public static List<PersonModel> ListPersons()
		{
			using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
			{
				var output = cnn.Query<PersonModel>("SELECT * from rer_person", new DynamicParameters());
				return output.ToList();
			}
		}

		public static List<PersonModel> ListOnePersonProjects()
		{
			using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
			{
				var output = cnn.Query<PersonModel>("SELECT * from rer_person", new DynamicParameters());
				return output.ToList();
			}
		}

		public static void NewPerson(PersonModel newPerson)
        {
			using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
			{
				cnn.Execute("INSERT INTO rer_person (person_name) VALUES (@person_name)", newPerson);
			}
		}

        public static void NewProject(ProjectModel newProject)
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                cnn.Execute("INSERT INTO rer_project (project_name) VALUES (@project_name)", newProject);
            }
        }
		private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }


        // Metod för att lägga till tid i tidsrappoertering - pratar med databasen.
        public static void AddTimeToProject(ProjectPersonModel addTime)
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
				Console.WriteLine(addTime.person_id);
				Console.WriteLine(addTime.project_id);
				cnn.Execute("INSERT INTO rer_project_person (project_id, person_id, hours) VALUES (@project_id, @person_id, @hours)", addTime);
            }
        }

		//Metod som inte används i programmet - WIP.
		public static void RemoveUser(string deleteChoice)
		{
			using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
			{
				//cnn.Execute($"UPDATE rer_student SET passw = '{password}' WHERE email = '{email}'");
				cnn.Execute($"DELETE FROM rer_person WHERE name = '{deleteChoice}'");
				//cnn.Execute("UPDATE rer_student SET passw = '1891' WHERE email = 'bob@bob.nu'");
				//cnn.Execute("insert into rer_student () values (@name, @points,@start_date, @end_date", changingpassword);
			}
		}

        //Metod som inte används i programmet - WIP.
        public static List<PersonModel> CheckPersonID(PersonModel userInput)
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                var output = cnn.Query<PersonModel>($"SELECT id FROM rer_person WHERE person_name = {userInput} ", new DynamicParameters());
                return output.ToList();
            }
            // Kopplar upp mot DB:n
            // läser ut alla Users
            // Returnerar en lista av Users
        }

		//Metod som inte används i programmet - WIP.
		public static void ChangeProjectName(ProjectModel project)
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                var output = cnn.Query<PersonModel>($"UPDATE rer_project SET project_name = @project_name WHERE id = @id", project);
            }
        }



    }
}
