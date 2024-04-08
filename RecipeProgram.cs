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
        //give the user a choice to enter the number of recipes. 
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
      }
    }
 }