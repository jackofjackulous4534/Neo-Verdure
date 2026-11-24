using UnityEngine;

public class TestSounds : MonoBehaviour
{
    [SerializeField] AudioClip _TestSound;

    public void PlaySoundTest()
    {
        SoundManager.Instance.PlaySFX(_TestSound, transform.position);
    }
}
