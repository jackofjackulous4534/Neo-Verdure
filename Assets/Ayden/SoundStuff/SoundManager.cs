using System;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    static SoundManager _instance;
    public static SoundManager Instance { get { return _instance; } }

    [RuntimeInitializeOnLoadMethod]
    static void OnGameStart()
    {
        GameObject inst = new GameObject(MethodBase.GetCurrentMethod().DeclaringType.ToString(), typeof(AudioSource));
        inst.AddComponent<SoundManager>();
    }

    private AudioSource _musicSource;
    private AudioSource _SFXObject;

    private void Awake()
    {
        if (!_instance)
        {
            _instance = this;
            DontDestroyOnLoad(_instance);
            _musicSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(this);
        }
    }

    public void PlaySFX(AudioClip sfx, Vector3 spawnPos, float volume = 1f)
    {
        AudioSource audioInstance = Instantiate(_SFXObject, spawnPos, Quaternion.identity);
        audioInstance.volume = volume;
        audioInstance.PlayOneShot(sfx);
        Destroy(audioInstance, sfx.length);
    }

    public void SetMusicTrack(AudioClip musicTrack)
    {
        _musicSource.clip = musicTrack;
        _musicSource.Play();
    }

}
