using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    public GameObject cam;
    public float[] parallaxConstant;

    private List<List<GameObject>> backgroundObjs = new List<List<GameObject>>();
    private List<List<Vector2>> initPos = new List<List<Vector2>>();

    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<10; i++)
        {
            backgroundObjs.Add(new List<GameObject>());
            initPos.Add(new List<Vector2>());
        }
        for(int i=0; i<transform.childCount; i++)
        {
            GameObject g = transform.GetChild(i).gameObject;
            int layerIndex = g.GetComponent<SpriteRenderer>().sortingOrder;
            if(layerIndex < 10)
            {
                backgroundObjs[layerIndex].Add(g);
                initPos[layerIndex].Add(g.transform.position);
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0; i< backgroundObjs.Count; i++)
        {
            for(int j=0; j<backgroundObjs[i].Count; j++)
            {
                Transform t = backgroundObjs[i][j].transform;
                float calc = initPos[i][j].x + cam.transform.position.x - (cam.transform.position.x * parallaxConstant[i]);
                t.position = new Vector2(calc , t.position.y);
                backgroundObjs[i][j].transform.position = t.position;
            }
        }
    }
}
