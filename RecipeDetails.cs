using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_POE_Pt2
{

    class Ingredient
    {
        public string name { get; set; }
        public double quantities { get; set; }
        public string units { get; set; }
        public int calories { get; set; }
        public string foodGroup { get; set; }

    }
    class RecipeDetails
    {
        public string recipeName { get; set; }
        public List<Ingredient> ingredients { get; set; }
        public List<string> steps { get; set; }
        public int totalCalories { get; private set; }

        public event Action<string> RecipeExceedsCalories;

        public static double factor;


        public void EnterDetails()
        {
            try
            {
                // Prompt the user to enter the number of ingredient the user wishes to incorporate.
                Console.Write("Enter the Name of the recipe: ");
            recipeName = Console.ReadLine();

            // Prompt the user to enter the number of ingredient the user wishes to incorporate. 
            Console.Write("Enter the number of ingredients: ");
            int numIngredients = Convert.ToInt32(Console.ReadLine());


            // Prompt the user to enter the details for each ingredient.
            ingredients = new List<Ingredient>();

            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine($"Enter name for ingredient #{i + 1}:");

                Ingredient ingredient = new Ingredient();

                Console.Write("Name: ");
                ingredient.name = Console.ReadLine();

                Console.Write("Quantity: ");
                ingredient.quantities = double.Parse(Console.ReadLine());


                Console.Write("Unit of Measurement: ");
                ingredient.units = Console.ReadLine();

                Console.Write("Calories: ");
                ingredient.calories = Convert.ToInt32(Console.ReadLine());

                Console.Write("Food Group: ");
                ingredient.foodGroup = Console.ReadLine();

                ingredients.Add(ingredient);
            }

            // Promt the user to enter the number of steps used to make recipe.
            Console.Write("Enter the number of steps to prep the recipe: ");
            int numSteps = Convert.ToInt32(Console.ReadLine());

            steps = new List<string>();

            // Prompt the user to enter the details for each step.
            for (int i = 0; i < numSteps; i++)
            {
                Console.Write($"Enter step #{i + 1}: ");
                steps[i] = Console.ReadLine();
            }

            }
            catch (Exception) 
            {
                Console.WriteLine("Invalid input. Enter the correct value");

            }

        }

        public void DisplayRecipe()
        {
            // Display the ingredients and their quantities.
            Console.WriteLine("Recipe: {0}", recipeName);


            Console.WriteLine("\n----- INGREDIENTS -----");
            foreach (Ingredient ingredient in ingredients)
            {
                Console.WriteLine($"-", ingredient.name, ingredient.quantities, ingredient.units);
            }

            // Display the steps.
            Console.WriteLine("\n-------- STEPS --------");
            for (int i = 0; i < steps.Count; i++)
            {
                Console.WriteLine($" Step {i + 1} > {steps[i]}");
            }

            Console.WriteLine("\nTotal Calories: {0}", totalCalories);
        }

        public void ScaleRecipe()
        {
            while (true)
            {
                Console.Write("Enter scaling factor of '0.5' or '2' or '3': ");
                factor = double.Parse(Console.ReadLine());
                if (factor == 0.5)
                {
                    factor = 0.5;
                    break;
                }
                else if (factor == 2)
                {
                    factor = 2;
                    break;
                }
                else if (factor == 3)
                {
                    factor = 3;
                    break;
                }
                else
                { Console.WriteLine("Invalid choice. Please enter a valid option."); }
            }
            // Multiply all the quantities by the scaling factor.
           foreach(var objIng in ingredients)
            {
                objIng.quantities *= factor;
            }
        }

        public void ResetQuantities()
        {
            // Reset all the quantities to their original values.
            foreach (var objIng in ingredients)
            {
                objIng.quantities /= factor;
            }
        }

        public void ClearRecipe()
        {
            while (true)
            {
                Console.Write("Are you certain you wish to clear your data? (Yes or No) \n");
                string confirm = Console.ReadLine();
                if (confirm.ToLower() == "yes")
                {
                    ingredients.Clear();
                    break;
                }
                else if (confirm.ToLower() == "no")
                {
                    break;
                }
                else
                { Console.WriteLine("Invalid choice. Please enter a valid option."); }

                ingredients.Clear();
            }
        }
        public void CalculateTotalCalories()
        {
            totalCalories = ingredients.Sum(ingredient => ingredient.calories);
            if (totalCalories > 300)
            {
                RecipeExceedsCalories?.Invoke(recipeName);
            }
        }

    }
}
