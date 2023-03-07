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
            // Kopplar upp mot DB:n 
            // läser ut alla Users
            // Returnerar en lista av Users
        }

		public static List<PersonModel> ListPersons()
		{
			using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
			{

				var output = cnn.Query<PersonModel>("SELECT * from rer_person", new DynamicParameters());
				return output.ToList();
			}
			// Kopplar upp mot DB:n
			// läser ut alla Users
			// Returnerar en lista av Users
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

        public static void AddTimeToProject(ProjectPersonModel addTime)
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
				Console.WriteLine(addTime.person_id);
				Console.WriteLine(addTime.project_id);
				cnn.Execute("INSERT INTO rer_project_person (project_id, person_id, hours) VALUES (@project_id, @person_id, @hours)", addTime);
            }
        }
    }
}
