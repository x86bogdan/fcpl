// An interface defining the contract for our Pokedex
public interface IPokedex : IEnumerable<BasePokemon>
{
    // A property to get the count of Pokémon
    int Count { get; }
    
    // An indexer to get a Pokémon by its position in the list
    BasePokemon this[int index] { get; }
    
    // Method to add a new Pokémon
    void Add(BasePokemon pokemon);
    
    // Method to find a Pokémon by its name
    BasePokemon GetPokemonByName(string name);
}
