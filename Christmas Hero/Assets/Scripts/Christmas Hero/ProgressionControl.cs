using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressionControl : MonoBehaviour
{
    public int progIndex = 1;
    [SerializeField]
    private GameObject christmasDeco;
    private const int LAST_LVL = 4; //we start on 1
    /// <summary>
    /// Makes changes in the scene that adds to the progression towards Christmas. 
    /// </summary>

    void Start()
    { 
        if (gameObject.CompareTag("ChristmasDeco")) //If we put this script on ChristmasDeco
        {
            christmasDeco = gameObject;
        }
        else //If we just keep it as a script, not attached to anything
        {
            christmasDeco = GameObject.FindWithTag("ChristmasDeco");
            if (christmasDeco == null) Debug.Log("Can't find ChristmasDeco gamebject");
        }
    }

    void Update() //Just for testing purposes, wont need update()
    {
        if (Input.GetKeyUp(KeyCode.KeypadPlus))
        {
            IncrementProgress();
        }
    }

    public void IncrementProgress()
    {
        if (progIndex > LAST_LVL) { Debug.Log("Max Xmas progression level reached already"); return; }
        progIndex++;
        transform.Find("Level " + progIndex).gameObject.SetActive(true);
    }




}
