using UnityEngine;

public class MaskFollowCursor : MonoBehaviour
{
    public Material blackMaskMat; 
    public Camera mainCamera;    
    public float holeSize = 0.2f; 

    void Update()
    {
        if (blackMaskMat != null && mainCamera != null)
        {
      
            Vector3 mousePosition = Input.mousePosition;

           
            Vector3 viewportPos = mainCamera.ScreenToViewportPoint(mousePosition);
            
            viewportPos.y = 1 - viewportPos.y;
            
            blackMaskMat.SetVector("_CursorPosition", new Vector4(viewportPos.x, viewportPos.y, 0, 0));
            blackMaskMat.SetFloat("_HoleSize", holeSize);
        }
    }
}
    