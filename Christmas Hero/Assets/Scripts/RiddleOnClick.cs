using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using CreatorKitCode;
using System.Collections.Generic;

public class RiddleOnClick : MonoBehaviour
{
    //Attached to Camera atm
    public float rayLength;
    public LayerMask giftLayermask;
    public LayerMask uiLayer;
    
    private GameObject hero;
    private Canvas canvas;
    private Collider present;
    //private MonoBehaviour levelHandler;

    private bool giftPressed;
    private bool buttonPressed;
    private bool riddleToggle; //Replacing bigRiddle and cornerRiddle. true:big, false:corner

    public AudioClip[] RiddleSFXClips;
    public SFXManager.Use UseType;

    void Start()
    {
        hero = GameObject.Find("SantaCharacter");
        buttonPressed = false;
        giftPressed = false;
        //levelHandler = GameObject.Find("Main Camera").GetComponent<GameStateHandler>();
    }

    private void Update()
    {
        if(giftPressed) {
            float dist = Vector3.Distance(hero.transform.position, present.transform.position);
            if(dist <= 2) {
                canvas = present.GetComponent<PresentScript>().getRiddleCanvas();
                giftPressed = false;
                StartCoroutine(waitOneSec());
                hero.GetComponent<Hero>().activateCarrying();
                present.GetComponent<PresentScript>().pickup();
                return;
            }
        }
        if(Input.GetMouseButtonUp(0)){
            buttonPressed = false;
        }
        if (Input.GetMouseButtonDown(0) && !buttonPressed && !EventSystem.current.IsPointerOverGameObject())
        {   
            buttonPressed = true;
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, rayLength, giftLayermask)) {
                if(hit.collider.tag == "Present") {
                    float dist = Vector3.Distance(hero.transform.position, hit.collider.transform.position);
                    if(dist > 2 && !hero.GetComponent<Hero>().carrying()) {
                        giftPressed = true;
                        present = hit.collider;
                        return;
                    }
                    giftPressed = false;
                    canvas = hit.collider.GetComponent<PresentScript>().getRiddleCanvas();
                    
                    if(hero.GetComponent<Hero>().carrying()){
                        hit.collider.GetComponent<PresentScript>().drop();
                        hero.GetComponent<Hero>().deactivateCarrying();
                        canvas.GetComponent<Canvas>().enabled = false;
                        if(hit.collider.GetComponent<PresentScript>().getDeliverInfo()
                        == hero.GetComponent<Hero>().getCurrentZone()){
                            GameObject.Find("Main Camera").GetComponent<GameStateHandler>().incrementDecor();
                            Destroy(hit.collider.GetComponent<PresentScript>());
                            Animator animator = GameObject.Find(hit.collider.GetComponent<PresentScript>().getDeliverInfo()).GetComponent<Animator>();
                            if(animator != null){
                                animator.SetBool("Delivered", true);
                            }
                        }
                    }
                    else {
                        StartCoroutine(waitOneSec());
                        hero.GetComponent<Hero>().activateCarrying();
                        hit.collider.GetComponent<PresentScript>().pickup();
                    }
                }
            } else {
                giftPressed = false;
            }
        } else if(Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (!Physics.Raycast(ray, out hit, rayLength, giftLayermask)) {
                giftPressed = false;
            }
        }
        if(Input.GetMouseButtonDown(0) && !buttonPressed && EventSystem.current.IsPointerOverGameObject())
        { 
            PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
            pointerEventData.position = Input.mousePosition;

            List<RaycastResult> raycastResultList = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerEventData, raycastResultList);
            for(int i = 0; i < raycastResultList.Count; i++){
                if(!(raycastResultList[i].gameObject.tag == "Riddle")){
                      raycastResultList.RemoveAt(i);
                      i--;
                }
            }
            if(raycastResultList.Count > 0) {
                giftPressed = false;
                buttonPressed = true;
                if (riddleToggle)
                    minimizeRiddle();
                else maximizeRiddle();  
            }
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
        riddleToggle = !riddleToggle;
        SFXManager.PlaySound(UseType, new SFXManager.PlayData()
        {
            Clip = RiddleSFXClips[riddleToggle?0:1],
            Position = transform.position
        });
    }

    private IEnumerator waitOneSec(){
        yield return new WaitForSeconds(1);
        canvas.GetComponent<Canvas>().enabled = true;
        maximizeRiddle();
    }
}
