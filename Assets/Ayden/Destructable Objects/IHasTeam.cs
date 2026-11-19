using UnityEngine;

public enum PlayerTeams
{
    None,
    Player,
    Enemy,
    
}
public interface IHasTeam
{
    PlayerTeams PlayerTeam { get; }
}
