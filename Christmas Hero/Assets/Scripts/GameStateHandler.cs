using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateHandler : MonoBehaviour
{

    private GameObject decorations;
    private GameObject presents;
    private GameObject finish;

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
        presents = GameObject.Find("Presents");
        finish = GameObject.Find("Finish_Canvas");
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
        finish.SetActive(false);
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

    private int level = 0;
    public void incrementDecor() {

        
        level = level + 1;
        if (level == 3)
        {
            finish.SetActive(true);
            Debug.Log("Finish");
        }
        //Light and SnowParticle System incrementation
        lightIntensity += 0.5f;
        rateOverTime += 10f;
        rateOverDist += 0.5f;
        xmasBGM.incrementMusic();

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
        Debug.Log("Incrementing decor!");
        foreach (Transform child in presents.transform){
            print("In presents loop");
            if(!child.gameObject.activeSelf){
                print("Incrementing present!");
                child.gameObject.SetActive(true);
                break;
            }
        }
        //decorations.SetActive(true);



    }
}
