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
        Music = -1,
        Water = 0,
        Teddy = 1
    }

    private void OnMouseDown()
    {
        isDragged = true;
        mouseDragStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        objectSpriteName = GetComponent<SpriteRenderer>().sprite.name;
        spriteDragStartPosition = transform.localPosition;

        if (objectSpriteName.Contains("Bear"))
        {
            objectType = (int)ObjectType.Teddy;
        }
        else
        {
            if (objectSpriteName.Contains("water"))
            {
                objectType = (int)ObjectType.Water;
            }
            else
            {
                if (objectSpriteName.Contains("Music"))
                {
                    objectType = (int)ObjectType.Music;
                }
                else
                {
                    if (objectSpriteName.Contains("Belt"))
                    {
                        objectType = (int)ObjectType.Belt;
                    }
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Dream"))
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }

    private void OnMouseDrag()
    {
        if(isDragged)
        {
            transform.localPosition=spriteDragStartPosition+(Camera.main.ScreenToWorldPoint(Input.mousePosition)-mouseDragStartPosition);

            Collider2D trashCan = Physics2D.OverlapPoint(transform.position, LayerMask.GetMask("TrashCan"));
            if (trashCan != null)
            {
                AudioSource audioSource = trashCan.GetComponent<AudioSource>();
                if (audioSource != null)
                {
                    audioSource.Play();
                }

                Destroy(gameObject);

                if (this.gameObject.CompareTag("Dream"))
                {
                    Destroy(this.gameObject);
                }
                Spawner.currentlySpawned--;
            }
            
        }
    }

    private void OnMouseUp()
    {
        isDragged=false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        objItem = collision.gameObject;
        Destroy(gameObject);
        Spawner.currentlySpawned--;
    }

}
