using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public static bool isGrounded;

    public Transform groundCheckObject;
    public LayerMask whatIsGround;
    public float groundCheckRadius; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       isGrounded = Physics2D.OverlapCircle(groundCheckObject.position, groundCheckRadius, whatIsGround);
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(groundCheckObject.position, groundCheckRadius);
    }
}
