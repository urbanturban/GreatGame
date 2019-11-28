using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RiddleClickFunction : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown( PointerEventData eventData )
     {
     }
 
     public void OnPointerUp( PointerEventData eventData )
     {
     }
 
     public void OnPointerClick( PointerEventData eventData )
     {
         Debug.Log( "Clicked!" );
     }

}
