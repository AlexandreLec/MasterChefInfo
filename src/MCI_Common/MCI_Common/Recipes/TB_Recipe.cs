using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCI_Common.Recipes
{
    public class TB_Recipe
    {
        /// <summary>
        /// Step to use
        /// </summary>
        public Recipe CurrentRecipe { get; set; }

        /// <summary>
        /// Name of the table in database
        /// </summary>
        private static string DataTable = "Recette";

        /// <summary>
        /// Get all the recipe available
        /// </summary>
        /// <returns>SQL Request</returns>
        public string GetAll()
        {
            return "SELECT * FROM " + DataTable +";";
        }

        /// <summary>
        /// Get a recipe by id
        /// </summary>
        /// <returns>SQL Request</returns>
        public string GetById()
        {
            return "SELECT * FROM " + DataTable + " WHERE Id = " + CurrentRecipe.Id + ";";
        }

        /// <summary>
        /// Get a recipe by Name
        /// </summary>
        /// <returns>SQL Request</returns>
        public string GetByName()
        {
            return "SELECT * FROM " + DataTable + " WHERE Nom = '" + CurrentRecipe.Name + "';";
        }
    }
}
