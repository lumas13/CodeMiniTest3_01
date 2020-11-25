using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController01 : MonoBehaviour
{
    public GameObject playerFollow;
    Vector3 posOffset = new Vector3(0, 3, -3f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, playerFollow.transform.position + posOffset, 0.1f);
    }
}
