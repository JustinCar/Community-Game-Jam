using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pupils : MonoBehaviour
{
    public GameObject leftPupil;
    public GameObject rightPupil;
    public Transform leftEye;
    public Transform rightEye;

    public float rightPupilOffset;
    public float leftPupilOffset;
    public float speed;

    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (leftPupil) 
        {
            Vector3 directionToPlayer = player.position - leftPupil.transform.position;
            directionToPlayer = directionToPlayer.normalized;
            leftPupil.transform.localPosition = leftEye.transform.localPosition + directionToPlayer * leftPupilOffset;
        }

        if (rightPupil) 
        {
            Vector3 directionToPlayer = player.position - rightPupil.transform.position;
            directionToPlayer = directionToPlayer.normalized;
            rightPupil.transform.localPosition = rightEye.transform.localPosition + directionToPlayer * rightPupilOffset;
        }


    }
}
