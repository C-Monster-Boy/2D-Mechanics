using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public Image filled;

    // Start is called before the first frame update
    void Start()
    {
        filled.fillAmount = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        filled.fillAmount = (float)(Health.currHealth * 1f) / Health.maxHealth;
    }
}
