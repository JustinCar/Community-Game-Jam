using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WhiteLieSpawner : MonoBehaviour
{
    public GameObject whiteLie;
    public int stage = 0;

    public float stageOneCooldown;
    public float stageTwoCooldown;
    public float stageThreeCooldown;
    public float timer;

    public Slider barOne;
    public Slider barTwo;
    public Slider barThree;

    // Start is called before the first frame update
    void Start()
    {
        timer = Random.Range(-5, 0);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (stage == 1 && timer >= stageOneCooldown) 
        {
            if (barOne.value <= 0) 
            {
                stage = 2;
                timer = Random.Range(-5, 0);
                return;
            }

            GameObject lie = Instantiate(whiteLie, transform.position, whiteLie.transform.rotation) as GameObject;
            WhiteLie lieScript = lie.GetComponent<WhiteLie>();
            lieScript.bar1 = barOne;
            lieScript.stage = 1;

            lie.GetComponent<EnemyHealth>().isWhiteLie = true;
            timer = 0;
        } else if (stage == 2 && timer >= stageTwoCooldown) 
        {
            if (barTwo.value <= 0) 
            {
                stage = 3;
                timer = Random.Range(-5, 0);
                return;
            }

            GameObject lie = Instantiate(whiteLie, transform.position, whiteLie.transform.rotation) as GameObject;
            WhiteLie lieScript = lie.GetComponent<WhiteLie>();
            lieScript.bar2 = barTwo;
            lieScript.stage = 2;

            lie.GetComponent<EnemyHealth>().isWhiteLie = true;
            timer = 0;
        } else if (stage == 3 && timer >= stageThreeCooldown) 
        {
            if (barThree.value <= 0) 
            {
                stage = 4;
                return;
            }

            GameObject lie = Instantiate(whiteLie, transform.position, whiteLie.transform.rotation) as GameObject;
            WhiteLie lieScript = lie.GetComponent<WhiteLie>();
            lieScript.bar3 = barThree;
            lieScript.stage = 3;

            lie.GetComponent<EnemyHealth>().isWhiteLie = true;
            timer = 0;
        }
    }
}
