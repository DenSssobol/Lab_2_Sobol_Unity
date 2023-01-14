using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Collector : MonoBehaviour
{
    int bank_of_coins = 0;
    [SerializeField] TMP_Text textMsg;
    void Start()
    {

    }


    // Update frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            bank_of_coins++;
            textMsg.text = "Coins:" + bank_of_coins;
        }

    }
}
