using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;

    // Start is called before the first frame update
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        instance.Play("Theme");
    }

    public void Play(string name)
    {
        Sound soundToPlay = null;
        foreach (Sound s in sounds)
        {
            if (s.name == name)
            {
                soundToPlay = s;
            }
        }

        if (soundToPlay == null)
        {
            return;
        }
        else
        {
            soundToPlay.source.Play();
        }
    }
}