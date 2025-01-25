using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;



public class DragAndDrop : MonoBehaviour
{
    private bool isDragged=false;
    private int objectType;
    private string objectSpriteName = "";
    private string dreamTypeName = "";
    private Vector3 mouseDragStartPosition;
    private Vector3 spriteDragStartPosition;
    private GameObject objItem;
    //public GameObject dreamGObject;

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
        spriteDragStartPosition =transform.localPosition;

        if (objectSpriteName.Contains("Plush"))
        {
            objectType = (int) ObjectType.Water;
        }
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        objItem = collision.gameObject;

        if (objItem != null)
        {
            Debug.Log("Object Hit!!");
            Debug.Log(objItem.name);
        }
    }
}
