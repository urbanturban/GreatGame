using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateHandler : MonoBehaviour
{

    private GameObject decorations;

    private Light dLight; //directional light over entire scene

    private float lightIntensity = 0.25f;
    private ParticleSystem snowSystem;
    private float rateOverTime = 5f;
    private float rateOverDist = 0f;
    public ChristmasBGM xmasBGM;  


    // Start is called before the first frame update
    void Start()
    {
        decorations = GameObject.Find("ChristmasDeco");
        foreach (Transform child in decorations.transform)
            child.gameObject.SetActive(false);

        dLight = GameObject.Find("Directional Light").GetComponent<Light>();
        snowSystem = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<ParticleSystem>();
        if (xmasBGM == null)
        {
            xmasBGM = GameObject.FindGameObjectWithTag("BGM").GetComponent<ChristmasBGM>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        var em = snowSystem.emission;
        em.rateOverTime = rateOverTime;
        em.rateOverDistance = rateOverDist;
        dLight.intensity = lightIntensity;
    }


    public void incrementDecor() {
        //Light and SnowParticle System incrementation
        lightIntensity += 0.5f;
        rateOverTime += 10f;
        rateOverDist += 0.5f;
        xmasBGM.nextTrack();

        Transform previousChild = null;
        foreach (Transform child in decorations.transform) {
            if(child.gameObject.activeSelf && previousChild != null && !previousChild.gameObject.activeSelf) {
                previousChild.gameObject.SetActive(true);
                return;
            }
            previousChild = child;
        }
        if(previousChild != null)
            previousChild.gameObject.SetActive(true);
        //decorations.SetActive(true);


    }
}
