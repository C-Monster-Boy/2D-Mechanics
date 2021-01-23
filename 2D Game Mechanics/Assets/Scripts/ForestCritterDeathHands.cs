using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestCritterDeathHands : MonoBehaviour
{
    public GameObject arm1;
    public GameObject arm2;

    public Transform armSpanPoint;

    public Vector2 arm1Force;
    public Vector2 arm2Force;

    // Start is called before the first frame update
    void Start()
    {
        ShootOutArms(arm1, arm1Force);
        ShootOutArms(arm2, arm2Force);
    }

    void ShootOutArms(GameObject g, Vector2 force)
    {
        GameObject arm = Instantiate(g, armSpanPoint.position, Quaternion.identity) as GameObject;
        arm.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
        Destroy(arm, 5f);
    }

}
