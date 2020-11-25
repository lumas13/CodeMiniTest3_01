using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform01 : MonoBehaviour
{
    float zUpper = 23f;
    float zLower = 16.5f;
    float moveSpeed = 5f;

    bool isFwd = false;
    bool isBck = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isBck && !isFwd)
        {
            if (transform.position.z >= zLower)
            {
                transform.Translate(Vector3.back * Time.deltaTime * moveSpeed);
            }
            else
            {
                isBck = false;
                isFwd = true;
            }
        }



        if (isFwd && !isBck)
        {
            if (transform.position.z <= zUpper)
            {
                transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
            }
            else
            {
                isBck = true;
                isFwd = false;
            }
        }

    }
}
