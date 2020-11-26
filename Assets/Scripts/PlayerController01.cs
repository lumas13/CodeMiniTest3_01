using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController01 : MonoBehaviour
{
    public Animator playerAni;
    public Renderer rendered1;
    public Renderer rendered2;
    public Renderer rendered3;
    public Renderer rendered4;
    public Material[] playerMats;
    public Rigidbody playerRB;
    
    int coinCount;
    float playerSpeed = 4f;
    float fallGameOver = -2f;
   
    bool isOnGround = true;

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

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRB.AddForce(Vector3.up * 5, ForceMode.Impulse);
            isOnGround = false;
            rendered1.material.color = playerMats[0].color;
            rendered2.material.color = playerMats[0].color;
            rendered3.material.color = playerMats[0].color;
            rendered4.material.color = playerMats[0].color;

            playerAni.SetTrigger("Jumped");
        }

        if (transform.position.y < fallGameOver)
        {
            SceneManager.LoadScene("EndScreen");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            rendered1.material.color = playerMats[1].color;
            rendered2.material.color = playerMats[1].color;
            rendered3.material.color = playerMats[1].color;
            rendered4.material.color = playerMats[1].color;
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
