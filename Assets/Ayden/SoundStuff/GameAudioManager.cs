using System;
using System.Reflection;
using UnityEngine;

public class GameAudioManager : MonoBehaviour
{
    static GameAudioManager _instance;
    public static GameAudioManager Instance { get { return _instance; } }

    [RuntimeInitializeOnLoadMethod]
    static void OnGameStart()
    {
        new GameObject(MethodBase.GetCurrentMethod().DeclaringType.ToString(), typeof(GameAudioManager), typeof(AudioSource));
    }
    private void Awake()
    {
        if (!_instance)
        {
            _instance = this;
            DontDestroyOnLoad(_instance);
        }
        else
        {
            Destroy(this);
        }
    }

    public void PlaySFX(AudioClip sfx, float volume = 1f)
    {
        GameObject templol = new GameObject("AudioSource lul", typeof(AudioSource));
        AudioSource audioInstance = templol.GetComponent<AudioSource>();

        audioInstance.volume = volume;
        audioInstance.PlayOneShot(sfx);
        Destroy(audioInstance, sfx.length);
    }
}
