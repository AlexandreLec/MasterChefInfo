using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCI_Common.Recipes
{
    public class TB_Step
    {
        /// <summary>
        /// Step to use
        /// </summary>
        public Step CurrentStep { get; set; }

        /// <summary>
        /// Name of the table in database
        /// </summary>
        private static string DataTable = "Etape";

        /// <summary>
        /// Get a step by id
        /// </summary>
        /// <returns>SQL Request</returns>
        public string GetById()
        {
            return "SELECT * FROM " + DataTable + " WHERE Id = " + CurrentStep.Id + ";";
        }

        /// <summary>
        /// Get all steps for a given recipe
        /// </summary>
        /// <returns>SQL request</returns>
        public string GetAllByRecipe(int id)
        {
            return "SELECT * FROM Etape WHERE Recetteid = " + id + ";";
        }
    }
}
