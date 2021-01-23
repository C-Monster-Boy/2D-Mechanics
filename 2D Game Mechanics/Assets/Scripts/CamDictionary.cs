using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine; 

public class CamDictionary : MonoBehaviour
{
    public static List<CinemachineVirtualCamera> camDict;
    public static CinemachineVirtualCamera activeCam;
    public CinemachineVirtualCamera[] cd;

    private static float camShakeTime;
    // Start is called before the first frame update
    void Start()
    {
        camDict = new List<CinemachineVirtualCamera>();
        foreach (CinemachineVirtualCamera c in cd)
        {
            camDict.Add(c);
        }
        ChangeToCameraIndex(0);
        camShakeTime = -1;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
        }
    }


    private void LateUpdate()
    {
        if(camShakeTime > 0)
        {
            camShakeTime -= Time.deltaTime;
        }
        else if(camShakeTime < 0 && camShakeTime != -1)
        {
            try
            {
                CinemachineBasicMultiChannelPerlin noise = activeCam.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();
                noise.m_AmplitudeGain = 0f;
            }
            catch(Exception e)
            {
                print(e);
            }
            
            camShakeTime = -1;
        }
    }

    public static void ChangeToCameraIndex(int index)
    {
        foreach (CinemachineVirtualCamera c in camDict)
        {
            c.Priority = 5;
        }
        camDict[index].Priority = 10;
        activeCam = camDict[index];
    }

    public static void CamShake(float shakeDuration, float amplitude)
    {
        if(camShakeTime == -1)
        {
            try
            {
                CinemachineBasicMultiChannelPerlin noise = activeCam.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();
                noise.m_AmplitudeGain = amplitude;
            }
            catch (Exception e)
            {
                print(e);
            }
            finally
            {
                camShakeTime = shakeDuration;
            }
        }
        
        
    }
}
