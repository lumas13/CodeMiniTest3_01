using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformController01 : MonoBehaviour
{
    public GameObject MovingPlatform;

    float zUpper = 23f;
    float zLower = 16.5f;
    float moveSpeed = 2f;

    bool isFwd = false;
    bool isBck = true;
    bool hasCollided = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if(hasCollided == true)
        {
            if (isBck && !isFwd)
            {
                if (MovingPlatform.transform.position.z >= zLower)
                {
                    MovingPlatform.transform.Translate(Vector3.back * Time.deltaTime * moveSpeed);
                }
                else
                {
                    isBck = false;
                    isFwd = true;
                }
            }

            if (isFwd && !isBck)
            {
                if (MovingPlatform.transform.position.z <= zUpper)
                {
                    MovingPlatform.transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
                }
                else
                {
                    isBck = true;
                    isFwd = false;
                }
            }
        }    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            hasCollided = true;

        }
        
    }
}
