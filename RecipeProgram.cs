using System;

class Recipe
{
    private string[] ingredients;
    private string[] steps;
    private double[] originalQuantities;

    public Recipe()
    {
        // arrays to store ingrediates and steps
        igredients = new string[0];
        steps = new string[0];

    }
    public void AddIngredient(string name, double quantities,string unit)
    {
        try{
            // Add new ingredient to the arrays 
            Array.Resize(ref igredients, igredients.Length + 1);
            ingredients[ingredients.Length - 1] = $"{quantity} {unit} of {name} ";

        }
        catch(Exception ex) {
            Console.WriteLine($"Error adding ingredient: {ex.Message}");
        }
    }
    public void AddStep(string step)
    {
        try {

            //add new step to the array
            Array.Resize(ref steps, steps.Length + 1);
            steps[steps.Length - 1] = step;

        }
        catch (Exception ex) {
            Console.WriteLine ($"Error adding step: {ex.Message}");

        }

    }
    public void ScaleQuantities(double factor)
    {
        try{
            // store Original quantities for reset
            originalQuantities = new double[igredients.Length];
            for(int i = 0; i < originalQuantities.Length; i++)
            {
                string[] parts = ingredients[i].Split(' ');
                double.TryParse(parts[0], out double quantity);

                //scale the quantity by factor
                quantity *=factor;

                //update ingredient string with scaled quantity
                ingredients[i] = $"{quantity} {string.Join(" ", parts[1..])}";

                // store original quantity for resetting 
                originalQuantities[i] = quantity / factor;
            }
            
        }
        catch (Exception ex) {
            Console.WriteLine($"Error resetting quantities: {ex.Message}"); 
        }

    }
    public void DisplayRecipe(){
        try{
            // display ingredients
            Console.WriteLine("Ingredients: ");
            foreach(string ingrediate in ingredients){
                Console.WriteLine(ingrediate);
            }

            // display steps
            Console.WriteLine("\nSteps:");
            for(int i = 0; i < steps.Length; 1++)
            {
                Console.WriteLine($"{i + 1}. {steps[i]}");
            }

        }
        catch(Exception ex) {
             Console.WriteLine($"Error resetting quantities: {ex.Message}"); 
        }
    }
}




 namespace RecipeProgram 
 {
    class Program
    {
      static void Main(string[] args)
      {
        // welcoming message 
        Console.WriteLine("Hello!! welcome to Recipe App! \n(press A to get started and press x to exit)");
        
        char choice = char.ToUpper(Console.ReadKey().KeyChar);
        Console.WriteLine();

        if (choice == 'X'){
            Console.WriteLine("Bye!!");
            break;
        }else if(choice !='A'){
            Console.WriteLine("Thanks, Take first step.");
        }
            Recipe recipe = new Recipe();

    // User input for ingredients.
    Console.WriteLine("Enter the number of ingredients:");
    int numIngredients = int.Parse(Console.ReadLine());
    for (int i = 0; i < numIngredients; i++)
    {
        Console.WriteLine($"Enter ingredient {i + 1} name:");
        string name = Console.ReadLine();
        Console.WriteLine($"Enter ingredient {i + 1} quantity:");
        double quantity = double.Parse(Console.ReadLine());
        Console.WriteLine($"Enter ingredient {i + 1} unit:");
        string unit = Console.ReadLine();

        recipe.AddIngredient(name, quantity, unit);
    }

    // User input for steps.
    Console.WriteLine("Enter the number of steps:");
    int numSteps = int.Parse(Console.ReadLine());
    for (int i = 0; i < numSteps; i++)
    {
        Console.WriteLine($"Enter step {i + 1}:");
        string step = Console.ReadLine();
        recipe.AddStep(step);
    }

    // Scaling the recipe.
    Console.WriteLine("Enter the scaling factor (0.5 for half, 2 for double, 3 for triple):");
    double factor = double.Parse(Console.ReadLine());
    recipe.ScaleQuantities(factor);

    // Display the scaled recipe.
    recipe.DisplayRecipe();

    // Resetting the recipe quantities to original.
    Console.WriteLine("Would you like to reset the quantities to original? (yes/no)");
    string resetChoice = Console.ReadLine().ToLower();
    if (resetChoice == "yes")
    {
        recipe.ResetQuantities();
        recipe.DisplayRecipe();
    }

    // Clearing the recipe data.
    Console.WriteLine("Would you like to clear the recipe to start a new one? (yes/no)");
    string clearChoice = Console.ReadLine().ToLower();
    if (clearChoice == "yes")
    {
        recipe.ClearRecipe();
    }

    
}
}
}