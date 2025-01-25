using UnityEngine;
using UnityEngine.Rendering;



public class DragAndDrop : MonoBehaviour
{
    private bool isDragged=false;
    private Vector3 mouseDragStartPosition;
    private Vector3 spriteDragStartPosition;
    private string objectSpriteName = "";

    public enum ObjectType
    {
        Alcohol = -2,
        Tea = -1,
        Water = 0,
        Teddy = 1
    }

    private void OnMouseDown()
    {
        isDragged=true;
        mouseDragStartPosition=Camera.main.ScreenToWorldPoint(Input.mousePosition);
        objectSpriteName = GetComponent<SpriteRenderer>().sprite.name;
        Debug.Log(objectSpriteName);
        spriteDragStartPosition =transform.localPosition;
    }

    private void OnMouseDrag()
    {
        if(isDragged)
        {
            transform.localPosition=spriteDragStartPosition+(Camera.main.ScreenToWorldPoint(Input.mousePosition)-mouseDragStartPosition);

        }
    }

    private void OnMouseUp()
    {
        isDragged=false;
        
        Collider2D trashCan = Physics2D.OverlapPoint(transform.position, LayerMask.GetMask("TrashCan"));
        if (trashCan != null)
        {
            Destroy(gameObject);
        }

        Collider2D dreamObject = Physics2D.OverlapPoint(transform.position, LayerMask.GetMask("Dream"));
        if (dreamObject == null)
        {
            Destroy(gameObject);
        }
    }
}
