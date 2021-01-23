using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    public int changeToCamera;
  
    // Start is called before the first frame update
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            CamDictionary.ChangeToCameraIndex(changeToCamera);
        }
    }
}
