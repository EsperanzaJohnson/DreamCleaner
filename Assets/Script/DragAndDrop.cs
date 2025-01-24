using UnityEngine;
using UnityEngine.Rendering;


public class DragAndDrop : MonoBehaviour
{
    Vector3 mousePositionOffset;

    private Vector3 GetMouseWorldPosition()
    {
        //Capture mouse position and return WorldPosition
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    
    private void OnMouseDown()
    {
        //Capture the mouse offset
        mousePositionOffset=gameObject.transform.position-GetMouseWorldPosition();
    }

    private void OnMouseDrag()
    {
        transform.position=GetMouseWorldPosition()+mousePositionOffset;
    }
}
