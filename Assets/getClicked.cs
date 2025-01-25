using UnityEditor;
using UnityEngine;

public class getClicked : MonoBehaviour
{
    public

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Destroy(this.gameObject);
        }
    }
}
