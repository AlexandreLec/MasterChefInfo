using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCI_Common.Recipes
{
    public class RecipeProcess
    {
        /// <summary>
        /// Table mapped for build request SQL
        /// </summary>
        public TB_Recipe MapTable { get; private set; }

        /// <summary>
        /// BDD connection object
        /// </summary>
        public DAO Bdd { get; private set; }

        /// <summary>
        /// SQL request
        /// </summary>
        public string Request { get; private set; }

        /// <summary>
        /// DataSet to get request results
        /// </summary>
        public DataSet Datas { get; private set; }

        /// <summary>
        /// Create a recipe process class
        /// </summary>
        public RecipeProcess()
        {
            this.MapTable = new TB_Recipe();
            this.Datas = new DataSet();
            this.Bdd = DAO.getInstance();
        }

        /// <summary>
        /// Define the recipe type according to database information
        /// </summary>
        /// <param name="Typeid">TypeRecetteId field value in database</param>
        /// <returns>The recipe type</returns>
        private RecipeType DefineRecipeType(int Typeid)
        {
            switch (Typeid)
            {
                case 1:
                    return RecipeType.STARTER;
                case 2:
                    return RecipeType.MAIN;
                case 3:
                    return RecipeType.DESSERT;
            }
            return RecipeType.UNKNOWN;
        }

        /// <summary>
        /// Build a Recipe from datarow
        /// </summary>
        /// <param name="row">Datarow from dataset</param>
        /// <returns>a recipe</returns>
        private Recipe CreateRecipe(DataRow row)
        {
            Recipe recipe = new Recipe();
            recipe.Name = row["Nom"].ToString();
            recipe.BreakTime = int.Parse(row["TempsPause"].ToString());
            recipe.Id = int.Parse(row["Id"].ToString());
            recipe.Persons = int.Parse(row["Personnes"].ToString());
            recipe.PrepTime = float.Parse(row["TempsPrep"].ToString());
            recipe.BakeTime = float.Parse(row["TempsCuisson"].ToString());
            recipe.Type = this.DefineRecipeType(int.Parse(row["TypeRecetteid"].ToString()));
            recipe.Steps = new StepProcess().ListAllByRecipe(recipe.Id);
            
            return recipe;
        }

        /// <summary>
        /// Get all recipes
        /// </summary>
        /// <returns>All recipe</returns>
        public List<Recipe> GetAll()
        {
            this.Datas.Clear();
            this.Request = this.MapTable.GetAll();
            this.Datas = this.Bdd.getRows(this.Request, "Recipe").Copy();

            List<Recipe> results = new List<Recipe>();

            foreach (DataRow item in this.Datas.Tables["Recipe"].Rows)
            {
                Recipe recipe = this.CreateRecipe(item);
                results.Add(recipe);
            }

            return results;
        }

        /// <summary>
        /// Get a specific recipe
        /// </summary>
        /// <param name="id">id of the recipe to get</param>
        /// <returns>A specific recipe</returns>
        public Recipe GetOne(int id)
        {
            this.Datas.Clear();
            this.MapTable.CurrentRecipe = new Recipe();
            this.MapTable.CurrentRecipe.Id = id;
            this.Request = this.MapTable.GetById();
            this.Datas = this.Bdd.getRows(this.Request, "Recipe");

            Recipe result = this.CreateRecipe(this.Datas.Tables["Recipe"].Rows[0]);

            return result;
        }

        /// <summary>
        /// Get a specific recipe
        /// </summary>
        /// <param name="id">name of the recipe to get</param>
        /// <returns>A specific recipe</returns>
        public Recipe GetOne(string name)
        {
            this.Datas.Clear();
            this.MapTable.CurrentRecipe = new Recipe();
            this.MapTable.CurrentRecipe.Name = name;
            this.Request = this.MapTable.GetByName();
            this.Datas = this.Bdd.getRows(this.Request, "Recipe");

            Recipe result = this.CreateRecipe(this.Datas.Tables["Recipe"].Rows[0]);

            return result;
        }
    }
}
