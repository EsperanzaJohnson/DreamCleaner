using NUnit.Framework;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class gameplayLoop : MonoBehaviour
{
    public AudioClip backgroundMusic;
    public AudioClip nightmaresSpawned;
    public AudioClip nightmaresDestroyed;
    public AudioClip win;
    public AudioClip lose;

    private AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.PlayOneShot(backgroundMusic);
        audioSource.loop = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            audioSource.PlayOneShot(nightmaresSpawned);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            audioSource.PlayOneShot(nightmaresDestroyed);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            audioSource.Stop();
            audioSource.PlayOneShot(win);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            audioSource.Stop();
            audioSource.PlayOneShot(lose);
        }
       
    }
}
