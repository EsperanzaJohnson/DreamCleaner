using UnityEngine;
using UnityEngine.Rendering;



public class DragAndDrop : MonoBehaviour
{
    private bool isDragged=false;
    private Vector3 mouseDragStartPosition;
    private Vector3 spriteDragStartPosition;
    public spawnItems Spawner;
   
    
    private void OnMouseDown()
    {
        isDragged=true;
        mouseDragStartPosition=Camera.main.ScreenToWorldPoint(Input.mousePosition);
        spriteDragStartPosition=transform.localPosition;
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

        Collider2D dreamObject = Physics2D.OverlapPoint(transform.position, LayerMask.GetMask("Dream"));
        if (dreamObject == null)
        {
            //Destroy(gameObject);
        }
    }
}
