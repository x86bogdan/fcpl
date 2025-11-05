using System.Collections.Generic;
// An interface defining the contract for our Pokedex
public interface IPokedex : IEnumerable<BasePokemon>
{
    // The event listener for lab 6
    event Action<BasePokemon> PokemonAdded;

    // A property to get the count of Pokémon
    int Count { get; }
    
    // An indexer to get a Pokémon by its position in the list
    BasePokemon this[int index] { get; }
    
    // Method to add a new Pokémon
    void Add(BasePokemon pokemon);
    
    // Method to find a Pokémon by its name
    BasePokemon GetPokemonByName(string name);
}
