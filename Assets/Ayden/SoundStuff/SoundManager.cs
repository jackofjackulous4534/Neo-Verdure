using System;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    static SoundManager _instance;
    public static SoundManager Instance { get { return _instance; } }

    [RuntimeInitializeOnLoadMethod]
    static void OnGameStart()
    {
        GameObject inst = new GameObject(MethodBase.GetCurrentMethod().DeclaringType.ToString(), typeof(SoundManager));
    }

    private AudioSource _musicObject;
    private AudioSource _musicInstance;
    private AudioSource _SFXObject;

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

    private void Start()
    {
        _musicObject = Resources.Load<AudioSource>("MusicObject");
        if (!_musicObject) Debug.LogError("FAILED TO GET MusicObject");
        _musicInstance = Instantiate(_musicObject, Vector3.zero, Quaternion.identity);

        _SFXObject = Resources.Load<AudioSource>("SFXObject");
        if (!_SFXObject) Debug.LogError("FAILED TO GET SFXObject");
    }

    public void PlaySFX(AudioClip sfx, Vector3 spawnPos, float volume = 1f)
    {
        AudioSource audioInstance = Instantiate(_SFXObject, spawnPos, Quaternion.identity);
        audioInstance.volume = volume;
        audioInstance.PlayOneShot(sfx);
        Destroy(audioInstance.gameObject, sfx.length);
    }

    public void PlayMusic(AudioClip musicTrack, float volume = 1f, bool resetTrackIfSame = false)
    {
        //if ()
        _musicInstance.clip = musicTrack;
        _musicInstance.volume = volume;
        _musicInstance.Play();
    }

}
