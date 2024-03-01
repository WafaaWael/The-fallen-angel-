using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private List<AudioClip> clipList;
    [SerializeField] private AudioMixer mixer;
    public const string Music_Key = "Music";
    public const string SFX_Key = "SFX";

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        loadVolum();
    }
    public void eatSFX()
    {
        AudioClip clip = clipList[Random.Range(0, clipList.Count)];
        audioSource.PlayOneShot(clip);
    }
    private void loadVolum()
    {
        float musicVolum = PlayerPrefs.GetFloat(Music_Key, 1);
        float SFXVolum = PlayerPrefs.GetFloat(SFX_Key, 1);

        mixer.SetFloat(VolumeSetting.MIX_MUSIC, Mathf.Log10(musicVolum) * 20);
        mixer.SetFloat(VolumeSetting.MIX_SFX, Mathf.Log10(SFXVolum) * 20);

    }
}
