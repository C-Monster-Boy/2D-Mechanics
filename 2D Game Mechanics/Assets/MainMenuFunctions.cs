using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuFunctions : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public GameObject controlsPanel;
    public GameObject aboutPanel;

    public void ChangeScene(string str)
    {
        SceneManager.LoadScene(str);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void OpenControls()
    {
        controlsPanel.SetActive(true);
    }

    public void OpenAbout()
    {
       aboutPanel.SetActive(true);
    }
}
