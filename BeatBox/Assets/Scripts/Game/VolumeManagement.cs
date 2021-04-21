using UnityEngine;
using UnityEngine.Audio;

public class VolumeManagement : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetVolumeMusic(float volume)
    {
        audioMixer.SetFloat("MusicVolumeParam", Mathf.Log10(volume) * 20f);
    }

    public void SetVolumeUI(float volume)
    {
        audioMixer.SetFloat("UIVolumeParam", Mathf.Log10(volume) * 20f);
    }
}
