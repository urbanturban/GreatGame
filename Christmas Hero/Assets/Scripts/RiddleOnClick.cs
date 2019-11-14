using UnityEngine;
using UnityEngine.EventSystems;

public class RiddleOnClick : MonoBehaviour
{
    public float rayLength;
    public LayerMask layermask;
    public Canvas canvas;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, rayLength, layermask))
            {
                Debug.Log(hit.collider.name);
                canvas.GetComponent<Canvas>().enabled = true;

            }
        }
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            canvas.GetComponent<Canvas>().enabled = false;
        }
    }
}
