Lab 2
===
Write a console application where you can type in the name of a Pokémon, and our program will connect to a public online database, fetch that Pokémon's information (such as its type, abilities, and stats), and display it on the screen.

Presentation 
---
https://gamma.app/docs/C-From-Blueprints-to-Pokemon-ayp13uo21gnqa99


Lab 3
===
Implementation Exercises

Option A: Pokédex & Battle Simulator (Continuing Project)

Goal: Evolve your Pokédex by creating a battle simulator that uses advanced parameter passing to manage battles and analyze Pokémon data efficiently.

Setup: Create a new class BattleSimulator that implements the IBattleSimulator interface provided below.
[IBattleSimulator](IBattleSimulator.cs)

Option B: Music Playlist Manager (Standalone Project)

Goal: Build a robust playlist manager from scratch, focusing on safe and efficient data handling using advanced parameter passing techniques.

Setup: Create a Song class (with properties like Title, Artist, DurationInSeconds) and then create a PlaylistManager class that implements the IPlaylistManager interface provided below.
[PlaylistManager](PlaylistManager.cs)

Presentation
---
https://gamma.app/docs/Program-Context-Parameter-Transmission-aucu6e4uowexkin


Lab 4
==
Implementation Exercises (Choose One)

Option A: Pokédex Evolution (Continuing Project)

Goal: Refactor your Pokédex to use inheritance. Not all Pokémon are created equal; some are legendary, some are mythical!

Tasks:
- Create a new abstract class called BasePokemon. Move the common properties from your old Pokemon class into it (Id, Name, Weight, etc.).
- Create an abstract method in BasePokemon called DisplayInfo().
- Create a new class StandardPokemon that inherits from BasePokemon. override the DisplayInfo() method to print the Pokémon's info to the console.
- Create another class LegendaryPokemon that also inherits from BasePokemon.
- Add a new property: string SpecialType.
- Override the DisplayInfo() method to also include the SpecialType status, perhaps with a special border like *** MEWTWO ***.

Polymorphism in Action: In your main program, create a List<BasePokemon>. Add a StandardPokemon (like Pikachu) and a LegendaryPokemon (like Mewtwo) to the list. Loop through the list and call DisplayInfo() on each one, observing the different outputs.

Option B: E-Commerce Shopping Cart (Standalone Project)

Goal: Build the backend for a shopping cart that can handle different types of products, each with its own way of calculating a shipping fee.

Tasks:
- Create an abstract class called Product. It should have properties Id, Name, Price and an abstract method CalculateShippingCost() that returns a double.
- Create a class PhysicalProduct that inherits from Product.
- Add a Weight property.
- Override the CalculateShippingCost() method to return Weight * 1.5 (or any formula).
- Create a class DigitalProduct (like an e-book or software) that inherits from Product.
- Override the CalculateShippingCost() method to return 0.0.

Polymorphism in Action: In your main program, create a List<Product> (this is your shopping cart). Add a PhysicalProduct (like a "Laptop") and a DigitalProduct (like "Office Software").

Loop through your cart and sum the Price of all products, then loop again and sum the CalculateShippingCost() for all products. Display the grand total.


Presentation
---
https://gamma.app/docs/OOP-Superpowers-Inheritance-Polymorphism-v5s2a2wx61zxaau


Lab 5
===
Implementation Exercises (Choose One)

Option A: Pokédex Manager (Continuing Project)

Goal: Create a Pokedex class that manages all our BasePokemon objects, implementing collections, indexers, and iterators.

Tasks:
- Create a Pokedex class that implements the provided (IPokedex.cs) interface.
- Implement the interface: Count and Indexer, Iterator, Add, Lookup method
- Iterate through the Pokedex and display the pokemons
Bonus:
PC Storage Box: Create a BasePokemon[,] storageBox = new BasePokemon[6, 5]; and write a method to "deposit" a Pokémon at a specific (row, col).
Battle Log: Create a Stack<string> in your main program. After your try-catch block, Push a message like "Attempted to find Mewthree" onto the stack. At the end, loop and Pop all messages to show the log in reverse order.
Pokémon Daycare: Create a Queue<BasePokemon>. Enqueue two Pokémon. Then, Dequeue them and see that they come out in the same order.

Option B: E-Commerce Shopping Cart (Standalone Project)
Goal: Build a shopping cart app to manage products and orders.

Tasks:
- Define a Product class with properties like Id, Name, Price, and Quantity.
- Use a collection to store product items in the cart.
- Implement methods to add products, update quantities, remove products, and calculate totals.
- Iterate over the cart items to print a summary with prices.
- Allow searching products by name (simple linear search).
- Implement an indexer to retrieve a specific item from the shopping cart.

Option C: Movie Collection Organizer (Standalone Project)
Goal: Create an app to manage a personal movie collection.

Tasks:
- Create a Movie class with Title, Director, ReleaseYear, and Genres.
- Store movies in a List<Movie>.
- Implement methods to add and remove movies.
- Implement search methods to find movies by director or year.
- Use iteration to display the full movie list formatted properly.
- Implement an indexer to retrieve a specific movie from the list.

Presentation
---
https://gamma.app/docs/Lab-5-Deep-Dive-into-C-Arrays-Collections-and-Iterators-cgpnnd2f8cuyud6


Lab 6
===
Implementation Exercises (Choose One)

Option A: The Reactive Pokédex (Continuing Project)

Goal: Make your Pokedex class "broadcast" an event whenever a new Pokémon is added, and create a separate "Logger" class to listen for it.
Your Provided Interface (IPokedex):
- You will add an event to your IPokedex interface from Lab 5. ``` event Action<BasePokemon> PokemonAdded; ```

Tasks:
- Implement the Event: In your Pokedex class, add the public event: ``` public event Action<BasePokemon> PokemonAdded; ```
- Fire the Event: In your Pokedex.Add method, after you successfully add a Pokémon (and after checking that it's not a duplicate), "fire" the event. The C# syntax for this is:
```
// Fire the event. The '?' checks if anyone is subscribed.
PokemonAdded?.Invoke(pokemon);
```
- Create the "Listener": Create a new class called PokedexLogger. Its constructor should take an IPokedex as a parameter. In the constructor, subscribe to the event: ``` pokedex.PokemonAdded += OnPokemonAdded; ```
- Create the "Handler": Inside PokedexLogger, create the method that will handle the event. Its signature must match the Action<BasePokemon> delegate.
```
private void OnPokemonAdded(BasePokemon pokemon)
{
    Console.WriteLine($"[LOGGER] - {pokemon.Name.ToUpper()} was added to the Pokédex!");
}
```
- Test in Program.cs:
  - First, create your Pokedex object.
  - Then, create your PokedexLogger object, passing the Pokedex to its constructor.
  - Now, when you call myPokedex.Add(pikachu) and myPokedex.Add(mewtwo), you should automagically see the logger's messages appear in the console!


Option B: The "Discord Bot" Simulator (Standalone Project)

Goal: Create an "Input Reader" (the bot) that broadcasts events, and two "Listeners" (bot modules) that react to specific commands.

Your Provided Interface (IInputReader):
```
using System;

// The contract for our "Bot"
public interface IInputReader
{
    // The event that fires on every new line of input
    event Action<string> OnInputReceived;

    // A method to start the bot
    void StartListening();
}
```

Tasks:
- Create the InputReader (The Publisher):
  - Create a class InputReader that implements IInputReader.
  - Implement the StartListening() method. It should contain a while(true) loop that reads input from the console (Console.ReadLine()).
  - Inside the loop, after reading a line, fire the event: OnInputReceived?.Invoke(input);
- Create CommandLogger (Listener 1):
  - Create a class CommandLogger.
  - Its constructor should take an IInputReader and subscribe: reader.OnInputReceived += OnInput;
  - The OnInput handler method should just print: [LOG]: User typed: {input}.
- Create GreeterModule (Listener 2):
  - Create a class GreeterModule.
  - Its constructor should also take an IInputReader and subscribe: reader.OnInputReceived += OnInput;
  - The OnInput handler method should check the input: if (input.ToLower() == "hello") { ... } and print a greeting, starting with [GREET].
- Test in Program.cs:
  - Create one InputReader object.
  - Create one CommandLogger object, passing the InputReader to it.
  - Create one GreeterModule object, also passing the same InputPlayer.
  - Call myInputReader.StartListening().
- Test by typing "hello" in your console. You should see both the log message and the greeting message appear. This shows how multiple, separate objects can all listen to the same event.

Presentation
---
https://gamma.app/docs/Lab-6-Delegates-Events-f5aay9w3bt0qwn2
