using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using CreatorKitCode;

public class ChristmasBGM : MonoBehaviour
{
    public AudioClip[] audioClips;
    public AudioSource bgm;
    private int trackIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        bgm = gameObject.GetComponent<AudioSource>();
    }

    public void nextTrack()
    {
        trackIndex++;
        bgm.Stop();
        bgm.clip = audioClips[trackIndex];
        bgm.loop = true;
        bgm.PlayOneShot(bgm.clip);
    }
}
