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
