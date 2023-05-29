using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_POE_Pt2
{
    class Recipe
    {

        static List<RecipeDetails> recipe = new List<RecipeDetails>();

        static void Main(string[] args)
        {
            

                Console.ForegroundColor = ConsoleColor.Cyan;


                while (true)
                {
                    Console.WriteLine("\n-------------- MAIN MENU ---------------");
                    Console.WriteLine(" Enter '1' to enter Recipe Details.");
                    Console.WriteLine(" Enter '2' to Display Recipe.");
                    Console.WriteLine(" Enter '3' to Display All Recipes");
                    Console.WriteLine(" Enter '4' to Scale Recipe.");
                    Console.WriteLine(" Enter '5' to Reset Quantities.");
                    Console.WriteLine(" Enter '6' to Clear Recipe.");
                    Console.WriteLine(" Enter '7' to Exit.\n");


                    string choice = Console.ReadLine();
                    switch (choice)
                    {

                        case "1":
                            RecipeDetails newRecipe = new RecipeDetails();
                            newRecipe.RecipeExceedsCalories += HandleRecipeExceedsCalories;
                            newRecipe.EnterDetails();
                            newRecipe.CalculateTotalCalories();
                            recipe.Add(newRecipe);
                            break;

                        case "2":
                            Console.WriteLine("Choose a Recipe you wish to display: ");

                            for (int i = 0; i < recipe.Count; i++)
                            {
                                Console.WriteLine("{0}. {1}", i + 1, recipe[i].recipeName);
                            }
                            Console.Write("Enter your choice: ");
                            int rChoice = Convert.ToInt32(Console.ReadLine());
                            if (rChoice >= 1 && rChoice <= recipe.Count)
                            {
                                RecipeDetails selectedRecipe = recipe[rChoice - 1];
                                selectedRecipe.DisplayRecipe();
                            }
                            else
                            {
                                Console.WriteLine("Invalid choice. Pleaase enter the correct option.");
                            }
                            break;

                        case "3":
                            Console.WriteLine("All Recipes:");
                            List<RecipeDetails> sortedRecipes = recipe.OrderBy(r => r.recipeName).ToList();
                            foreach (RecipeDetails recipe in sortedRecipes)
                            {
                                Console.WriteLine("- {0}", recipe.recipeName);
                            }
                            break;

                        case "4":
                            RecipeDetails newDetails = new RecipeDetails();
                            newDetails.ScaleRecipe();
                            break;

                        case "5":
                            RecipeDetails newQuantities = new RecipeDetails();
                            newQuantities.ResetQuantities();
                            break;

                        case "6":
                            RecipeDetails clearRecipe = new RecipeDetails();
                            clearRecipe.ClearRecipe();
                            break;

                        case "7":
                            Console.WriteLine("Exiting program...");
                            return;

                        default:
                            Console.WriteLine("Invalid choice. Please enter a valid option.");
                            break;
                    }
                }


            

        }

static void HandleRecipeExceedsCalories(string recipeName)
        {
            Console.WriteLine("Warning: The recipe \"{0}\" exceeds 300 calories.", recipeName);
        }

    }
}
