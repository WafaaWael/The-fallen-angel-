using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class VolumeSetting : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider Music;
    [SerializeField] private Slider SFM;
    public const string MIX_MUSIC = "Music";
    public const string MIX_SFX = "SFX";

    private void Awake()
    {
        Music.onValueChanged.AddListener(setMusic);
        SFM.onValueChanged.AddListener(setSFX);

    }
    private void Start()
    {
        Music.value = PlayerPrefs.GetFloat(AudioManager.Music_Key, 1);
        SFM.value = PlayerPrefs.GetFloat(AudioManager.SFX_Key, 1);

    }
    private void OnDisable()
    {
        PlayerPrefs.SetFloat(AudioManager.Music_Key, Music.value);
        PlayerPrefs.SetFloat(AudioManager.SFX_Key, SFM.value);

    }
    private void setMusic(float value)
    {
        audioMixer.SetFloat(MIX_MUSIC, Mathf.Log10(value) * 20);
    }
    private void setSFX(float value)
    {
        audioMixer.SetFloat(MIX_SFX, Mathf.Log10(value) * 20);
    }
}
