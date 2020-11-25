using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BridgeController01 : MonoBehaviour
{
    public GameObject timerText;
    public GameObject Bridge;
    public GameObject Coin;

    bool timerIsRunning;
    bool bridgeTurn;

    int totalCoin;
    int coinCount;

    float timeRemaining = 5f;
    // Start is called before the first frame update
    void Start()
    {
        bridgeTurn = false;
        timerIsRunning = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(timerIsRunning == true && bridgeTurn == true)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                timerText.GetComponent<Text>().text = "Timer: " + (int)timeRemaining;
                //Debug.Log((int)timeRemaining);
            }
        }

        if (timeRemaining <= 0)
        {
            bridgeTurn = false;
            timerIsRunning = false;
            Bridge.transform.rotation = Quaternion.Euler(0, 0, 0);
            timeRemaining = 5f;
        }

        totalCoin = GameObject.FindGameObjectsWithTag("Coin").Length;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && coinCount == totalCoin)
        {
            bridgeTurn = true;
            timerIsRunning = true;
            Bridge.transform.rotation = Quaternion.Euler(0, 90, 0);
        }    
    }
}
