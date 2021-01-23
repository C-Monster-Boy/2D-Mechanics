using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlsDisplay : MonoBehaviour
{
    public int currImageIndex;
    public Image displayImage;
    public Sprite[] instructions;

    private int currDisplayImageIndex;

    // Start is called before the first frame update
    void Start()
    {
        currImageIndex = 0;

        for(int i=0; i< instructions.Length; i++)
        {
            if(displayImage.sprite == instructions[i])
            {
                currDisplayImageIndex = i;
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currDisplayImageIndex != currImageIndex)
        {
            displayImage.sprite = instructions[currImageIndex];
            currDisplayImageIndex = currImageIndex;
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            currImageIndex = 0;
            gameObject.SetActive(false);
        }
    }

    public void NextControlImage()
    {
        if (currImageIndex < instructions.Length - 1)
        {
            currImageIndex++;
        }
    }

    public void PrevControlImage()
    {
        if (currImageIndex > 0)
        {
            currImageIndex--;
        }
    }
    public void Close()
    {
        currImageIndex = 0;
        gameObject.SetActive(false);
    }
}   