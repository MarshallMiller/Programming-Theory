using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class PegController : MonoBehaviour
{
    private AudioSource[] pegAudio;
    public AudioClip collisionSound;
    private int numAudioSources = 3;
    private int currentAudioSourceIndex = 0;

    public virtual string audioPath
    {
        get
        {
            return Path.Combine(Application.dataPath, "Audio", "plastic-collision.ogg");
        }
    }

    // Start is called before the first frame update
    async void Start()
    {
        await InitAudio();
        InitColor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Hit()
    {
    }

    public virtual void PlaySound()
    {
        pegAudio[currentAudioSourceIndex].PlayOneShot(collisionSound, 1.0f);
        currentAudioSourceIndex = (currentAudioSourceIndex + 1) % numAudioSources;
    }

    private void OnCollisionEnter2D(Collision2D collision)
	{
        Hit();
        PlaySound();
	}

    public virtual void InitColor()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.color = Color.blue;
    }

    async public virtual Task<int> InitAudio()
    {
        // wait for the load and set your property
        collisionSound = await LoadClip(audioPath);

        //... do something with it

        pegAudio = new AudioSource[numAudioSources];
        for (int i = 0; i < numAudioSources; i++)
        {
            pegAudio[i] = GetComponent<AudioSource>();
            pegAudio[i] = new AudioSource();
            pegAudio[i] = new GameObject("SFX " + i, typeof(AudioSource)).GetComponent<AudioSource>();
            pegAudio[i].transform.position = transform.position;
            pegAudio[i].transform.parent = transform;
            //pegAudio[i].outputAudioMixerGroup = sfxMixer;
            pegAudio[i].playOnAwake = false;
        }
        return 0;

    }

    async Task<AudioClip> LoadClip(string path)
    {
        AudioClip clip = null;
        using (UnityWebRequest uwr = UnityWebRequestMultimedia.GetAudioClip(path, AudioType.OGGVORBIS))
        {
            uwr.SendWebRequest();

            // wrap tasks in try/catch, otherwise it'll fail silently
            try
            {
                while (!uwr.isDone) await Task.Delay(5);

                if (uwr.result == UnityWebRequest.Result.ConnectionError || uwr.result == UnityWebRequest.Result.ProtocolError)
                {
                    Debug.Log($"{uwr.error}");
                }
                else
                {
                    clip = DownloadHandlerAudioClip.GetContent(uwr);
                }
            }
            catch (Exception err)
            {
                Debug.Log($"{err.Message}, {err.StackTrace}");
            }
        }

        return clip;
    }
}
