// The contract for our Battle Simulator
public interface IBattleSimulator
{
    // Uses 'out' to return multiple values: the strongest stat's name and its value.
    bool TryFindStrongestStat(Pokemon pokemon, out string statName, out int statValue);

    // Uses 'ref' to directly modify the state of the battling Pokémon.
    void SimulateAttack(ref Pokemon attacker, ref Pokemon defender);
    
    // Uses 'params' to accept a variable number of Pokémon for analysis.
    double CalculateAverageStat(string statName, params Pokemon[] pokemonTeam);
}
