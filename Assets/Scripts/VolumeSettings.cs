using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider volumeSlider;

    private const string MasterVolumeParam = "MasterVolume";

    private void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat(MasterVolumeParam, 0f);
        volumeSlider.value = savedVolume;
        SetVolume(savedVolume);

        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    
    public void SetVolume(float value)
    {
        float volumeInDb = value > 0.0001f ? Mathf.Log10(value) * 20f : -80f;

        audioMixer.SetFloat(MasterVolumeParam, volumeInDb);
        PlayerPrefs.SetFloat(MasterVolumeParam, value);
    }
}
