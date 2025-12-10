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

Feedback form
---
https://forms.gle/f4mwBHt4fzeveikQ7

Lab 7
===
Implementation Exercises (Choose One)

Option A: The Pokédex Data Analyst

Prerequisite: Your IPokedex collection from Lab 5. Ensure your BasePokemon class has queryable properties (e.g., Type1 (string), Attack (int), IsLegendary (bool)).

Tasks:
- Find all Pokémon of a specific type:
```
var firePokemon = myPokedex.Where(p => p.Type1 == "fire");
```
- Loop and display the names of the results.
- Find the single strongest Pokémon:
```
var strongest = myPokedex.OrderByDescending(p => p.Attack).FirstOrDefault();
```
- Display this Pokémon's name and attack stat.
- Get just the names of all Legendary Pokémon:
```
var legendaryNames = myPokedex.Where(p => p.IsLegendary).Select(p => p.Name);
```
- Loop and display the names (they will be strings, not Pokémon objects).
- Check if a "water" type Pokémon exists:
```
bool hasWater = myPokedex.Any(p => p.Type1 == "water");
```
- Print the true/false result.
- Calculate the average weight of all Pokémon:
```
double avgWeight = myPokedex.Average(p => p.Weight);
```
- Print the result.

Option B: The Game Store Manager (Standalone Project)

Goal: Create a GameStore app and use LINQ to query its inventory.
Your Provided Classes (Game.cs, IGameStore.cs):
```
using System;
using System.Collections.Generic;

public enum Genre { Action, RPG, Strategy, Puzzle }

public class Game
{
    public string Name { get; set; }
    public string Developer { get; set; }
    public Genre GameGenre { get; set; }
    public DateTime ReleaseDate { get; set; }
    public double Price { get; set; }
}

public interface IGameStore
{
    List<Game> Games { get; }
    void AddGame(Game game);

    // --- Methods you will implement using LINQ ---
    List<Game> GetGamesByDeveloper(string developer);
    List<string> GetGameNamesReleasedBefore(int year);
    Game GetMostExpensiveGame();
    bool AnyGamesFromDeveloper(string developer);
    double GetAveragePriceForGenre(Genre genre);
}
```

Tasks:

- Create a GameStore class that implements IGameStore. The Games property will be a List<Game>. AddGame just adds to the list.
- In your Program.cs, create a GameStore and add 5-10 sample Game objects with different developers, prices, and genres.
- Implement the Interface Methods using LINQ: Your job is to implement each of the 5 query methods in the interface using a single line of LINQ.
- GetGamesByDeveloper: Use .Where()
- GetGameNamesReleasedBefore: Use .Where() and .Select()
- GetMostExpensiveGame: Use .OrderByDescending() and .FirstOrDefault()
- AnyGamesFromDeveloper: Use .Any()
- GetAveragePriceForGenre: Use .Where() and .Average()
- In Program.cs, call each of your new methods and print the results to the console to prove they work.

Option C: The Social Media Feed Analyzer (Standalone Project)

Goal: Create a SocialFeed app and use LINQ to query a list of posts.
Your Provided Classes (Post.cs, ISocialFeed.cs):
```
using System;
using System.Collections.Generic;

public class Post
{
    public int PostId { get; set; }
    public string Author { get; set; }
    public string Text { get; set; }
    public int Likes { get; set; }
    public List<string> Tags { get; set; }
}

public interface ISocialFeed
{
    List<Post> Posts { get; }
    void AddPost(Post post);

    // --- Methods you will implement using LINQ ---
    List<Post> GetPostsByAuthor(string author);
    List<Post> GetPopularPosts(int minLikes);
    List<string> GetAllUniqueTags();
    Post GetPostById(int id);
    double GetAverageLikesForAuthor(string author);
}
```

Tasks:
- Create a SocialFeed class that implements ISocialFeed. The Posts property will be a List<Post>. AddPost just adds to the list.
- In your Program.C#, create a SocialFeed and add 5-10 sample Post objects. Be sure to include multiple posts from the same author and duplicate tags.
- Implement the Interface Methods using LINQ:
- GetPostsByAuthor: Use .Where()
- GetPopularPosts: Use .Where(p => p.Likes >= minLikes)
- GetAllUniqueTags: Use .SelectMany(p => p.Tags) to flatten the list of lists, then .Distinct() to get unique tags.
- GetPostById: Use .FirstOrDefault(p => p.PostId == id)
- GetAverageLikesForAuthor: Use .Where() to get the author's posts, then .Average(p => p.Likes)
- In Program.cs, call each of your new methods and print the results to the console.

Presentation
---
https://gamma.app/docs/Lab-9-LINQ-The-Super-Search-for-Your-Data-cdvl0lvnaekmx56

Lab 8
===
Implementation Exercises (Choose One)

Option A: The Persistent Pokédex (Continuing Project)

Goal: Make your Pokedex class save/load to a file asynchronously and add support for task cancellation.

Tasks:
- Create PokedexPersistence.cs: Create a static class for saving/loading.
- Implement SavePokedexAsync:
```
public static async Task SavePokedexAsync(IPokedex pokedex, string filename, CancellationToken token)
```
Inside, serialize the pokedex. Use ```await File.WriteAllTextAsync(filename, jsonString, token);``` (Notice we pass the token!). Wrap in a try-catch block.
- Implement LoadPokedexAsync:
```
public static async Task<IPokedex> LoadPokedexAsync(string filename, CancellationToken token)
```
Inside try, use ```string jsonString = await File.ReadAllTextAsync(filename, token);```

return JsonSerializer.Deserialize<Pokedex>(jsonString);

In a catch (FileNotFoundException), return new Pokedex();.

In a catch (TaskCanceledException), print "Load canceled!" and return new Pokedex();.

- Update Program.cs:
- Make Main async Task.
- Create a CancellationTokenSource: var cts = new CancellationTokenSource();
- Call IPokedex myPokedex = await PokedexPersistence.LoadPokedexAsync(saveFile, cts.Token);
- (Demo Cancellation): To test it, you can add this line right after the LoadPokedexAsync call: cts.CancelAfter(TimeSpan.FromMilliseconds(100)); This will simulate a "timeout" and cancel the load if it takes longer than 100ms.
- At the end of your program, save the Pokédex.

Option B: The Digital Recipe Book (Standalone Project)

Goal: Create a console-based Recipe Book that can save and load your recipes asynchronously.

Your Provided Models (Recipe.cs, IRecipeBook.cs):
```
public class Recipe
{
    public string Title { get; set; }
    public List<string> Ingredients { get; set; } = new();
    public string Instructions { get; set; }
}

public interface IRecipeBook
{
    void AddRecipe(Recipe recipe);
    void ListAllRecipes();
    Recipe FindRecipe(string title);
    List<Recipe> AllRecipes { get; }
}
```

Tasks:

- Create RecipeBook.cs: Implement the IRecipeBook interface using a List<Recipe> internally. ListAllRecipes should just print the titles. FindRecipe can use LINQ.
- Create RecipePersistence.cs: Create a static class to save/load the IRecipeBook (similar to Option A).
- public static async Task SaveAsync(IRecipeBook book, string filename)
- public static async Task<IRecipeBook> LoadAsync(string filename)
- Implement these using JsonSerializer and the async file methods.
- Create Program.cs:
- Make Main async Task.
```
IRecipeBook myBook = await RecipePersistence.LoadAsync("recipes.json");
```
- Create a while loop with commands: "add", "list", "find [name]", "exit".
- "exit" command must call await RecipePersistence.SaveAsync(myBook, "recipes.json"); before breaking the loop.

Option C: The Async Tamagotchi (Standalone Project)

Goal: Create a virtual pet that "lives" in real-time using async methods and "reacts" to input using events (from Lab 6).

Tasks:

- Create InputReader.cs: (From Lab 6)
- This class has an event Action<string> OnKeyPressed;
- It has one method public void StartListening() that runs a while(true) loop, reads console input, and fires the OnKeyPressed event with the input.
- Create Tamagotchi.cs:
- Properties: Name (string), Food (int, default 10), HungerRate (int, e.g., 3000 ms), Alive (bool, default true), Key (char).
- Constructor: public Tamagotchi(string name, char key, InputReader reader)
- Subscribe to Event: In the constructor, subscribe to the input reader's event: reader.OnKeyPressed += HandleKeyPressed;
- Event Handler: private void HandleKeyPressed(string input): If input matches the Key, add 5 to Food and print a "Fed!" message.

- The async "Life" Method:
Create public async Task Run()
This method should have a while (this.Alive) loop.
- Inside the loop:
```
await Task.Delay(this.HungerRate); (This is the non-blocking "wait" for time to pass).
this.Food -= 3;
Console.WriteLine(this.ToString()); (Display status).
Check for death: if (this.Food <= 0 || this.Food > 20) { this.Alive = false; }
ToString() Method: Override ToString() to display the pet's status (alive/dead and food level).
```
- Create Program.cs:
InputReader reader = new InputReader();
Tamagotchi pet1 = new Tamagotchi("Pikachu", 'p', reader);
- Run both tasks in parallel!
```
Task inputTask = Task.Run(() => reader.StartListening()); (Run the input listener on a background thread)
Task petTask = pet1.Run(); (Run the pet's life)
await Task.WhenAll(inputTask, petTask); (Wait for both to finish... though inputTask won't).
```

Presentation
---
https://gamma.app/docs/Lab-8-Persistence-asyncawait-and-Task-Control-684jo01o6gcpvvc

Lab 9
===

Option A: The Visual Pokédex (Continuing Project)

Goal: Build a GUI viewer for your JSON Pokédex.

UI Layout (XAML):
- A 2-Column Grid.
- Left: A ListBox to show the list of Pokémon names.
- Right: A StackPanel showing the details of the selected Pokémon (Large Name, Type, Stats).

Tasks:
- Create PokedexViewModel.cs inheriting from BaseViewModel.
- Add an ObservableCollection<BasePokemon> AllPokemon { get; }.
- Load your pokedex.json data into this collection in the constructor.
- Add a property BasePokemon SelectedPokemon (use the SetProperty helper!).
- Binding: Bind ListBox.ItemsSource to AllPokemon. Bind ListBox.SelectedItem to SelectedPokemon. Bind the right-side text blocks to SelectedPokemon.Name, SelectedPokemon.Type, etc.
- Result: Clicking a name in the list instantly updates the details panel.

Option B: The "Pizza Builder" (Standalone Project)

Goal: Create an order form that dynamically calculates the price of a pizza based on user selection.

UI Layout (XAML):
- Header: "Mario's Pizza Builder" (Large Text).
- Size: A ComboBox or 3 RadioButtons (Small, Medium, Large).
- Toppings: CheckBoxes for "Pepperoni (+$2)", "Mushrooms (+$1)", "Extra Cheese (+$2)".
- Footer: A large text block: "Total Price: $15.00".

Tasks:
- Create PizzaViewModel.cs inheriting from BaseViewModel.
- Create bool properties for toppings: IsPepperoni, IsMushrooms, IsExtraCheese. Important: Inside the set for these, call OnPropertyChanged(nameof(TotalPrice))!
- Create a decimal property BasePrice (default to 10.00).
- Create a Calculated Property TotalPrice:
```
public decimal TotalPrice
{
    get
    {
        decimal total = BasePrice;
        if (IsPepperoni) total += 2;
        if (IsMushrooms) total += 1;
        if (IsExtraCheese) total += 2;
        return total;
    }
}
```
- Binding: Bind the CheckBoxes to the bool properties. Bind the Footer TextBlock to TotalPrice (use StringFormat in XAML or format it in the ViewModel).
- Result: As you check and uncheck boxes, the price updates instantly without clicking a "Calculate" button.

Option C: The "Smart Home" Dashboard (Standalone Project)

Goal: A dashboard to control lights and temperature in a house.

UI Layout (XAML):
- Living Room: A Slider for Light Brightness (0-100) and a TextBlock showing the %.
- Thermostat: Two Buttons ("+" and "-") and a large number showing the temperature.
- System Status: A colored Rectangle (Green = OK, Red = Alert).

Tasks:
- Create DashboardViewModel.cs inheriting from BaseViewModel.
- Brightness: Create an int Brightness property. Bind the Slider.Value to it. Bind the TextBlock.Text to it.
- Temperature: Create a double Temperature property (default 70).
- Commands (Buttons): Create methods void IncreaseTemp() and void DecreaseTemp().
Note: To bind Buttons in MVVM, you typically use ICommand. For this lab, it is acceptable to use Click event handlers in the code-behind (.xaml.cs) that simply call methods on your ViewModel: ((DashboardViewModel)DataContext).IncreaseTemp();.
- Logic: If Temperature goes above 80, set a StatusColor property to "Red". Otherwise "Green". Bind the Rectangle's Fill to this color string.

Presentation
---
https://gamma.app/docs/Giving-Your-Code-a-Face-xkmfnq3su89kqgc

Lab 10
===
Option A: The Pokédex API (Continuing Project)

Goal: Expose your Pokedex data from Lab 7 to the world.

Tasks:
- Migrate Logic: Copy your BasePokemon, Pokedex, and Persistence files into the new project.
- State Management: In Program.cs, load the data once before the app builds.
```
string saveFile = "pokedex.json"; // On Linux, ensure this path is writable!
IPokedex pokedex = await PokedexPersistence.LoadPokedexAsync(saveFile);
var builder = WebApplication.CreateBuilder(args);
// ...
```
- Implement endpoints
```
GET Endpoint: app.MapGet("/api/pokemon", () => Results.Ok(pokedex));

GET Single: app.MapGet("/api/pokemon/{name}", (string name) => { ...linq search... });

POST Endpoint (New!): Allow adding Pokémon via the API.

app.MapPost("/api/pokemon", (StandardPokemon newPoke) => {
    pokedex.Add(newPoke);
    // In a real app, we would save to disk here too
    return Results.Created($"/api/pokemon/{newPoke.Name}", newPoke);
});
```

Option B: Space Mission Control (Standalone)

Goal: Build the backend for a rocket launch facility. Manage missions and their status.

Tasks:
- Create Model: public record Mission(int Id, string Name, string Destination, DateTime LaunchDate) { public string Status { get; set; } = "Scheduled"; }
- Create "Database":
```
var missions = new List<Mission> {
    new Mission(1, "Artemis I", "Moon", DateTime.Now.AddDays(100)),
    new Mission(2, "Voyager 3", "Mars", DateTime.Now.AddYears(2))
};
```
- Implement endpoints
```
GET All: app.MapGet("/api/missions", () => missions);

POST (Schedule Launch): Create an endpoint that accepts a Mission object, adds it to the list, and returns it.

PUT (Update Status): Create an endpoint to update a mission's status (e.g., "Launched", "Aborted").

app.MapPut("/api/missions/{id}/status", (int id, string newStatus) => {
    var mission = missions.FirstOrDefault(m => m.Id == id);
    if (mission == null) return Results.NotFound();
    mission.Status = newStatus;
    return Results.Ok(mission);
});
```

Option C: The Digital Bookstore (Standalone)

Goal: Create a simple backend for a bookstore with search capabilities.

Tasks:
- Create Model: ```public class Book { public int Id { get; set; } public string Title { get; set; } public string Author { get; set; } public double Price { get; set; } }```
- Database: Create a static List<Book> with sample data.
- Search Endpoint: Create an endpoint /api/books/search that accepts an author query parameter.
```
app.MapGet("/api/books/search", (string author) => {
     return db.Where(b => b.Author.Contains(author, StringComparison.OrdinalIgnoreCase));
});
```
- Price Filter: Create an endpoint /api/books/bargains that returns all books under a specific price (passed as a parameter).

Option D: The Music Streaming Backend (Standalone)

Goal: Build the API for a Spotify clone. Manage songs and track play counts.

Tasks:
- Create Model: ```public class Song { public int Id { get; set; } public string Title { get; set; } public string Artist { get; set; } public int Streams { get; set; } }```
- Database: Create a List<Song> with some hits.
- Implement endpoints
```
GET (Catalog): Return all songs, ordered by Streams (descending).

PUT (Play Song): Create an endpoint that simulates a user listening to a song. It should increment the Streams counter.

app.MapPut("/api/songs/{id}/play", (int id) => {
    var song = db.FirstOrDefault(s => s.Id == id);
    if (song is null) return Results.NotFound();
    song.Streams++;
    return Results.Ok(new { Message = $"Now playing {song.Title}", NewStreamCount = song.Streams });
});

DELETE (Remove Song): Create an endpoint to delete a song by ID (e.g., for copyright takedowns). db.RemoveAll(s => s.Id == id);
```

Presentation
---
https://gamma.app/docs/Building-a-Web-API-0anv24vyv5m1af2


Lab 11
===
Option A: The Pokedex Database (Continuing Project)

Goal: Migrate your Pokédex from JSON to SQLite and add "Trainers."

Tasks:
- Define Model: Create Pokemon and Trainer classes. Trainer should have a List<Pokemon>.
- The Context:
```
Create a class PokedexContext : DbContext.
Add public DbSet<Pokemon> Pokemons { get; set; }
Add public DbSet<Trainer> Trainers { get; set; }
```
- Override OnConfiguring to set the data source: ```options.UseSqlite("Data Source=pokedex.db");```
- Migration: Run the command ```dotnet ef migrations add InitialCreate``` and then ```dotnet ef database update```. This creates the .db file.
- Insert Data:
```
Create a new Trainer ("Ash").
Add a new Pokemon ("Pikachu") to Ash's list.
db.Trainers.Add(ash);
db.SaveChanges(); (This generates the SQL INSERTs).
```
- Query Data: Use ```db.Trainers.Include(t => t.Team).First(t => t.Name == "Ash").```
- Print Ash's name and all his Pokémon. The .Include() is crucial—it tells EF to do a SQL JOIN to get the related data.

Option B: The Blogging Platform (Standalone)

Goal: Create a system for Blogs and Posts (Classic 1-to-Many example).

Tasks:
- Define Model:
```
Blog: int BlogId, string Url, List<Post> Posts.
Post: int PostId, string Title, string Content, int BlogId (Foreign Key).
```
- The Context: Create ```BloggingContext``` with ```DbSet<Blog>``` and ```DbSet<Post>```. Configure for SQLite.
- Migration: Run ```dotnet ef migrations add InitialCreate``` and ```dotnet ef database update```.
- Functionality:
```
Create: Ask user for a Blog URL. Save it.
Add Post: Ask user for a Blog ID and Post Title. Find the blog, add the post, SaveChanges().
List: List all Blogs.
View Blog: User types a Blog ID. You fetch the blog AND its posts (.Include(b => b.Posts)). Display them.
```
- Update: Allow the user to "edit" a post title. Fetch it, change the property, and call SaveChanges(). EF Core detects the change automatically!

Option C: The Inventory System (Standalone)

Goal: A Product/Category manager for a store.

Tasks:
- Define Model:
```
Category: int Id, string Name, List<Product> Products.
Product: int Id, string Name, decimal Price, Category Category.
```
- Setup: Setup StoreContext, SQLite, and run Migrations.
```
Seed Data: In Program.cs, check if (!db.Categories.Any()). If true, create some default categories (Electronics, Clothing) and Products.
```
- Reporting Queries (LINQ to SQL):
```
Price Check: Find all products over $50: db.Products.Where(p => p.Price > 50).
Category Count: Count how many products are in "Electronics".
Delete: Find a product by name and remove it: db.Remove(product); db.SaveChanges();.
```

Option D: The Project Tracker (Standalone)

Goal: Build a "Jira-lite" system to track Projects and their Tickets (Bugs/Tasks).

Tasks:
- Define Model:
```
Project: int Id, string Name, string Code (e.g., "DEV"), List<Ticket> Tickets.
Ticket: int Id, string Title, string Status (New, InProgress, Done), Project Project.
```
- The Context: Create TrackerContext. Configure SQLite.
- Migration: Run the standard migration commands to build the database.
- Functionality:
```
New Project: Create a project "Website Redesign" with code "WEB".
Add Ticket: Add a ticket "Fix Login Bug" to the "WEB" project.
Move Ticket: Find a ticket by ID. Change its status from "New" to "Done". Call SaveChanges().
```
- LINQ Reporting: Print a report showing the Count of open tickets (Status != "Done") for each Project.
Hint: ```db.Projects.Select(p => new { p.Name, OpenCount = p.Tickets.Count(t => t.Status != "Done") })```.

https://learn.microsoft.com/en-us/ef/core/cli/dotnet

Presentation
---
https://gamma.app/docs/The-Data-Layer-Databases-ORMs-and-Relationships-ey7knzpty84pb9t
