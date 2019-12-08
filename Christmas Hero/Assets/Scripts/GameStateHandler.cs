using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateHandler : MonoBehaviour
{

    private GameObject decorations;
    private GameObject presents;

    private Light dLight; //directional light over entire scene
    private float lightIntensity = 0.25f;
    private ParticleSystem snowSystem;
    [SerializeField]
    private float rateOverTime = 5f;
    [SerializeField]
    private float rateOverDist = 0f;

    // Start is called before the first frame update
    void Start()
    {
        decorations = GameObject.Find("ChristmasDeco");
        presents = GameObject.Find("Presents");
        foreach (Transform child in decorations.transform)
            child.gameObject.SetActive(false);

        // De-activate all presents except for the first
        bool first = true;
        foreach (Transform child in presents.transform) {
            if(!first){
                child.gameObject.SetActive(false);
            } else {
                first = false;
            }
        }
        dLight = GameObject.Find("Directional Light").GetComponent<Light>();
        snowSystem = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<ParticleSystem>();
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

        Transform previousChild = null;
        foreach (Transform child in decorations.transform) {
            if(child.gameObject.activeSelf && previousChild != null && !previousChild.gameObject.activeSelf) {
                previousChild.gameObject.SetActive(true);
                break;
            }
            previousChild = child;
        }
        if(previousChild != null)
            previousChild.gameObject.SetActive(true);

        foreach (Transform child in presents.transform){
            if(!child.gameObject.activeSelf){
                child.gameObject.SetActive(true);
                break;
            }
        }
        //decorations.SetActive(true);


    }

    void OnGUI()
    {
        rateOverTime = GUI.HorizontalSlider(new Rect(25, 45, 100, 30), rateOverTime, 5.0f, 200.0f);
    }
}
