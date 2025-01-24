using Unity.Mathematics;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Rendering;


public class DragAndDrop : MonoBehaviour
{
    Vector3 mousePositionOffset;
    public int objType = 0;

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

    void Start()
    {
        SetObjectType();
    }
    public void SetObjectType()
    {
        objType = UnityEngine.Random.Range(1, 2);
        Debug.Log(objType.ToString());
    }
}
