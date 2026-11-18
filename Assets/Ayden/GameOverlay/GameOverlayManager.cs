using System.Collections.Generic;
using UnityEngine;
//Enum.GetNames(typeof(TestEnum)).Length

public class GameOverlayManager : MonoBehaviour
{
    [SerializeField] List<GameObject> overlays = new List<GameObject>();
    private int _currentOverlay = 0;
    private enum GameOverlays
    {
        None,
        PauseMenu,
        SettingsMenu,
    }

    public void SetOverlay(int newOverlay)
    {
        Debug.Log("Setting overlay: " + newOverlay.ToString());
        //newOverlay += 1;
        if (newOverlay == _currentOverlay) return;
        if (_currentOverlay != 0 ) overlays[_currentOverlay - 1].SetActive(false);
        if (newOverlay != 0) overlays[newOverlay - 1].SetActive(true);
        _currentOverlay = newOverlay;
    }
}
