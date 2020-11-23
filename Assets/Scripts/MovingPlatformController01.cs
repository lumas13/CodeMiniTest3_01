using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformController01 : MonoBehaviour
{
    public GameObject MovingPlatform;
    public Animator MovingPlat;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            MovingPlat.SetTrigger("Moving");
        }
    }
}
