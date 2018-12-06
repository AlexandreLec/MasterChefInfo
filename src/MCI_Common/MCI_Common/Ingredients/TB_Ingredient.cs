using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCI_Common.Ingredients
{
    public class TB_Ingredient
    {
        /// <summary>
        /// Ingredient use to interact with database (get and set)
        /// </summary>
        public Ingredient CurrentIngredient { get; set; }

        /// <summary>
        /// Name of the table in database
        /// </summary>
        private static string DataTable = "Ingredient";

        /// <summary>
        /// Get all rows in table
        /// </summary>
        /// <returns>SQL request</returns>
        public string GetAll()
        {
            return "SELECT * FROM " + DataTable + ";";
        }

        /// <summary>
        /// Get an ingredient by Id
        /// </summary>
        /// <returns>SQL request</returns>
        public string GetById()
        {
            return "SELECT * FROM " + DataTable + " WHERE Id = " + CurrentIngredient.Id + ";";
        }

        /// <summary>
        /// Get an ingredient by Name
        /// </summary>
        /// <returns>SQL request</returns>
        public string GetByName()
        {
            return "SELECT * FROM " + DataTable + " WHERE Nom = '" + CurrentIngredient.Name + "';";
        }

        /// <summary>
        /// Get all ingredient for a given step
        /// </summary>
        /// <returns>SQL request</returns>
        public string GetAllByStep(int id)
        {
            return "SELECT * FROM DenreeParEtape WHERE Etapeid = " + id + ";";
        }

        /// <summary>
        /// Add to stock for a specific ingredient
        /// </summary>
        /// <returns>SQL request</returns>
        public string AddStock()
        {
            return "UPDATE " + DataTable + "SET Quantite = Quantite + "+CurrentIngredient.Quantity+" WHERE Id = '" + CurrentIngredient.Id + "';";
        }

        /// <summary>
        /// Remove to stock for a specific ingredient
        /// </summary>
        /// <returns>SQL request</returns>
        public string RemoveStock()
        {
            return "UPDATE " + DataTable + "SET Quantite = Quantite - " + CurrentIngredient.Quantity + " WHERE Id = '" + CurrentIngredient.Id + "';";
        }
    }
}
