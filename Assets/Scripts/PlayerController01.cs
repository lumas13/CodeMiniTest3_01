using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController01 : MonoBehaviour
{
    public Animator playerAni;

    float playerSpeed = 4f;
    int coinCount;
    float fallGameOver = -2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            playerAni.SetBool("isRunning", true);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.Translate(Vector3.forward * playerSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            playerAni.SetBool("isRunning", true);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            transform.Translate(Vector3.forward * playerSpeed * Time.deltaTime);
        }

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            playerAni.SetBool("isRunning", false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            playerAni.SetBool("isRunning", true);
            transform.rotation = Quaternion.Euler(0, 270, 0);
            transform.Translate(Vector3.forward * playerSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            playerAni.SetBool("isRunning", true);
            transform.rotation = Quaternion.Euler(0, 90, 0);
            transform.Translate(Vector3.forward * playerSpeed * Time.deltaTime);
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            playerAni.SetBool("isRunning", false);
        }

        if (transform.position.y < fallGameOver)
        {
            SceneManager.LoadScene("EndScreen");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        { 
            coinCount++;
            Destroy(other.gameObject);
        }
    }
    
}
