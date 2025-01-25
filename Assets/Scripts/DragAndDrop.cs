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
        Alcohol = -2,
        Tea = -1,
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
            objectType = (int)ObjectType.Water;
            Debug.Log("Object Type");
            Debug.Log(objectType.ToString());
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
        Destroy(gameObject);
        Spawner.currentlySpawned--;
    }

}
