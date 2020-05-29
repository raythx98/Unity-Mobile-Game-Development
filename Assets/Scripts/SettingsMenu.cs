using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetMaster(float volume) 
    {
        audioMixer.SetFloat("volumeMaster", volume);
    }

    public void SetMusic(float volume)
    {
        audioMixer.SetFloat("volumeMusic", volume);
    }

    public void SetEffects(float volume)
    {
        audioMixer.SetFloat("volumeSFX", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}
