using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateHandler : MonoBehaviour
{

    private GameObject decorations;
    private Light dLight; //directional light over entire scene

    // Start is called before the first frame update
    void Start()
    {
        decorations = GameObject.Find("ChristmasDeco");
        foreach (Transform child in decorations.transform)
            child.gameObject.SetActive(false);

        dLight = GameObject.Find("Directional Light").GetComponent<Light>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void incrementDecor() {
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
        dLight.intensity += 0.5f;
    }
}
