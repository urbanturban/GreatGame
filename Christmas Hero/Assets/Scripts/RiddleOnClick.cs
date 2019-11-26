using UnityEngine;
using UnityEngine.EventSystems;

public class RiddleOnClick : MonoBehaviour
{
    public float rayLength;
    public LayerMask giftLayermask;
    public LayerMask uiLayer;

    private GameObject hero;
    private Canvas canvas;
    private bool bigRiddle;
    private bool cornerRiddle;
    private bool buttonPressed;

    void Start()
    {
        hero = GameObject.Find("SantaCharacter");
        bigRiddle = false;
        cornerRiddle = false;
        buttonPressed = false;
    }

    private void Update()
    {
        if(Input.GetMouseButtonUp(0)){
            buttonPressed = false;
        }
        if (Input.GetMouseButton(0) && !buttonPressed && !EventSystem.current.IsPointerOverGameObject())
        {
            buttonPressed = true;
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, rayLength, giftLayermask)) {
                if(hit.collider.tag == "Present") {
                    canvas = hit.collider.GetComponent<PresentScript>().getRiddleCanvas();
                    if(hero.GetComponent<Hero>().carrying()){
                        hit.collider.GetComponent<PresentScript>().drop();
                        hero.GetComponent<Hero>().deactivateCarrying();
                        canvas.GetComponent<Canvas>().enabled = false;
                        bigRiddle = false;
                        cornerRiddle = false;
                    }else{
                        hero.GetComponent<Hero>().activateCarrying();
                        hit.collider.GetComponent<PresentScript>().pickup();
                        canvas.GetComponent<Canvas>().enabled = true;
                        bigRiddle = true;
                        cornerRiddle = false;
                        maximizeRiddle();
                    }
                    
                }
            }else if(Physics.Raycast(ray, out hit, rayLength, uiLayer) && cornerRiddle && !buttonPressed) {
                Debug.Log("Clicked corner-riddle!");
            }
        }
        if(Input.GetMouseButton(0) && bigRiddle && !buttonPressed){
            buttonPressed = true;
            minimizeRiddle();
        }
        if(Input.GetMouseButton(0) && cornerRiddle && !buttonPressed){
            buttonPressed = true;
            maximizeRiddle();
        }
    }

    private void minimizeRiddle()
    {
        RectTransform rt = canvas.transform.Find("Image").gameObject.GetComponent (typeof (RectTransform)) as RectTransform;
        rt.anchorMin = new Vector2(0, 1);
        rt.anchorMax = new Vector2(0, 1);
        rt.pivot = new Vector2(0, 1);
        rt.sizeDelta = new Vector2 (30, 30);
        toggleRiddleState();
    }

    private void maximizeRiddle()
    {
        RectTransform rt = canvas.transform.Find("Image").gameObject.GetComponent (typeof (RectTransform)) as RectTransform;
        rt.anchorMin = new Vector2(0.5f, 0.5f);
        rt.anchorMax = new Vector2(0.5f, 0.5f);
        rt.pivot = new Vector2(0.5f, 0.5f);
        rt.sizeDelta = new Vector2 (100, 100);
        toggleRiddleState();
    }

    private void toggleRiddleState()
    {
        bigRiddle = !bigRiddle;
        cornerRiddle = !cornerRiddle;
    }
}
