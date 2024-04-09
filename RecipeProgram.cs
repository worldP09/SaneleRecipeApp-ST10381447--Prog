using System;

class Recipe
{
    private string[] igredients;
    private string[] steps;
    private double[] originalQuantities;

    public Recipe()
    {
        // arrays to store ingrediates and steps
        
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