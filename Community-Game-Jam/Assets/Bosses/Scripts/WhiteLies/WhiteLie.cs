using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WhiteLie : MonoBehaviour
{
    public Slider bar1;
    public Slider bar2;
    public Slider bar3;
    public int stage;
    public ParticleSystem explode;

    public void die()
    {
        if (stage == 1) 
        {
            bar1.value--;
        } else if (stage == 2) 
        {
            bar2.value--;
        } else if (stage == 3) 
        {
            bar3.value--;
        }

        Instantiate(explode, transform.position, explode.transform.rotation);
        Destroy(gameObject);
    }
}
