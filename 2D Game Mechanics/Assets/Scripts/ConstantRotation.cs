using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantRotation : MonoBehaviour
{
    public bool canRotate;
    public float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        canRotate = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(canRotate)
        {
            Vector3 temp = transform.eulerAngles;
            temp.z += rotationSpeed * Time.deltaTime;
            transform.eulerAngles = temp;
        }
    }
}
