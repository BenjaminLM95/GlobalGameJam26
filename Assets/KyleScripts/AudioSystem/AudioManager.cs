using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    private List<AudioClip> musicClips;
    private List<AudioClip> sfxClips;

    private Dictionary<string, AudioClip> musicDict = new Dictionary<string , AudioClip>();
    private Dictionary<string, AudioClip> sfxDict = new Dictionary<string, AudioClip>();

    public override void Awake()
    {
        base.Awake();
        PopulateAudioLibrary();
    }

    private void PopulateAudioLibrary()
    {
        musicClips = new List<AudioClip>(Resources.LoadAll<AudioClip>("Audio/Music"));
        sfxClips = new List<AudioClip>(Resources.LoadAll<AudioClip>("Audio/SF"));
        foreach (AudioClip clip in musicClips)
        {
            musicDict[clip.name] = clip;
        }
        foreach (AudioClip clip in sfxClips)
        {
            sfxDict[clip.name] = clip;
        }
    }
    public void PlayMusic(string clipName)
    {
        if (musicDict.TryGetValue(clipName, out AudioClip clip))
        {
            musicSource.clip = clip;
            musicSource.Play();
        }
    }

    public void PlaySFX(string clipName)
    {
        if (sfxDict.TryGetValue(clipName, out AudioClip clip))
        {
            sfxSource.PlayOneShot(clip);
        }
    }
    }
