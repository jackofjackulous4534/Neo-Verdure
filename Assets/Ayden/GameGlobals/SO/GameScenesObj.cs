using UnityEngine;

[CreateAssetMenu(fileName = "GameScenesObj", menuName = "Scriptable Objects/GameScenesObj")]
public class GameScenesObj : ScriptableObject
{
    [Scene] public string MainMenu;
    [Scene] public string Credits;
    [Scene] public string Intermission;
    [Scene] public string[] Levels;
}
