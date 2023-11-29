using System;

using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    private void Awake()
    {
        if(instance != null && instance != this)
            Destroy(this);

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.Name == name);

        if (s == null)
            return;

        musicSource.clip = s.Clip;
        musicSource.PlayOneShot(musicSource.clip);
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.Name == name);

        if (s == null)
            return;

        sfxSource.pitch = 1 + UnityEngine.Random.Range(-0.1f, 0.1f);
        sfxSource.clip = s.Clip;
        sfxSource.PlayOneShot(sfxSource.clip);
    }
}
