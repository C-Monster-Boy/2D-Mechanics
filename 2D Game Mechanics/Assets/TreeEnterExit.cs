using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeEnterExit : MonoBehaviour
{
    public GameObject treeOuter;
    public GameObject treeInner;

    // Start is called before the first frame update
    void Start()
    {
        treeInner.SetActive(false);
        treeOuter.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            CamDictionary.ChangeToCameraIndex(2);
            ToggleTreeInner(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            CamDictionary.ChangeToCameraIndex(1);
            ToggleTreeInner(false);
        }
    }

    void ToggleTreeInner (bool val)
    {
        if(val)
        {
            treeInner.SetActive(val);
            treeOuter.SetActive(!val);
        }
        else
        {
            treeOuter.SetActive(!val);
            treeInner.SetActive(val);
        }
    }
}
