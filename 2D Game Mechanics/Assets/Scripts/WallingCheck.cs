using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallingCheck : MonoBehaviour
{
    public static bool isWalling;

    public float wallingCheckRadius;
    public Transform wallingCheckObject;
    public LayerMask whatIsWall;

    // Start is called before the first frame update
    void Start()
    {
        isWalling = false;

    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        isWalling = Physics2D.OverlapCircle(wallingCheckObject.position, wallingCheckRadius, whatIsWall);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(wallingCheckObject.position, wallingCheckRadius);
    }
}
