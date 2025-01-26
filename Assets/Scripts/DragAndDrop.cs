using UnityEngine;
using UnityEngine.Rendering;



public class DragAndDrop : MonoBehaviour
{
    private bool isDragged = false;
    public int objectType;
    private string objectSpriteName = "";
    private string dreamTypeName = "";
    private Vector3 mouseDragStartPosition;
    private Vector3 spriteDragStartPosition;
    private GameObject objItem;
    public spawnItems Spawner;

    public enum ObjectType
    {
        Belt = -10,
        Binky = -1,
        Water = 0,
        Teddy = 1
    }

    private void OnMouseDown()
    {
        isDragged = true;
        mouseDragStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        objectSpriteName = GetComponent<SpriteRenderer>().sprite.name;
        spriteDragStartPosition = transform.localPosition;

        if (objectSpriteName.Contains("Plush"))
        {
            objectType = (int)ObjectType.Teddy;
            Debug.Log("Object Type");
            Debug.Log(objectType.ToString());
        }
        if (objectSpriteName.Contains("belt"))
        {
            objectType = (int)ObjectType.Belt;
            Debug.Log("Object Type");
            Debug.Log(objectType.ToString());
        }
        if (objectSpriteName.Contains("water"))
        {
            objectType = (int)ObjectType.Water;
            Debug.Log("Object Type");
            Debug.Log(objectType.ToString());
        }
        if (objectSpriteName.Contains("binky"))
        {
            objectType = (int)ObjectType.Binky;
            Debug.Log("Object Type");
            Debug.Log(objectType.ToString());
        }
        else
        {
            //Test value
            objectType = (int)ObjectType.Water;
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
            Spawner.currentlySpawned--;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        objItem = collision.gameObject;
        //Debug.Log("ON TRIGGER DRAG AND DROP");
        Destroy(gameObject);
        Spawner.currentlySpawned--;
    }

}
