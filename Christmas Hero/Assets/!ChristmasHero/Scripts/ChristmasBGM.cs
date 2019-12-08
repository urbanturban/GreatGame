using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CreatorKitCode;

public class ChristmasBGM : MonoBehaviour
{
    public SFXManager.Use UseType;
    public AudioClip[] audioClips;
    public AudioSource[] allTracks;
    private int trackIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
       // bgm = gameObject.GetComponent<AudioSource>();
       // Queue<AudioSource> a_queue = new Queue<AudioSource>();
        
    }
    public void incrementMusic()
    {
        deliverySFX();
        StartCoroutine(FadeOut(allTracks[trackIndex], 1f));
        trackIndex++;
        StartCoroutine(FadeIn(allTracks[trackIndex], 5f));
    }

    private void deliverySFX()
    {
        SFXManager.PlaySound(UseType, new SFXManager.PlayData()
        {
            Clip = audioClips[0],
            Position = transform.position
        });
    }



    public static IEnumerator FadeIn(AudioSource audioSource, float FadeTime)
    {
        float startVolume = 0.2f;

        audioSource.volume = 0;
        audioSource.Play();

        while (audioSource.volume < 1.0f)
        {
            audioSource.volume += startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }

        audioSource.volume = 1f;
    }

    public IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }
        audioSource.Stop();
        audioSource.volume = startVolume;
    }
}
