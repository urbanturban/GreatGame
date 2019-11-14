using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CreatorKitCodeInternal 
{
    public class RandomBGMPlayer : MonoBehaviour
    {
        public AudioClip clip;

        // Start is called before the first frame update
        void Start()
        {
            if (clip == null)
            {
                Destroy(this);
                return;
            }

            var source = GetComponent<AudioSource>();
            source.clip = clip;
            source.Play();
        }
    }
}

//To make the constant entering/exiting play mode in editor less annoying in this kit, we pick one of 3 random BGM
//track at random every game start