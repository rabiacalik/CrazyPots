using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    //Tencerenin algıladığı
    public Text CounterText;
    public int count = 0;  

    private void Start()
    {
        count = 0;
        UpdateCounterText();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Vegatable"))
        {
            count++;
            UpdateCounterText();
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Plate"))
        {
            count -= 5;
            UpdateCounterText();
            Destroy(collision.gameObject);
        }
    }

    public void UpdateCounterText()
    {
        CounterText.text = " " + count;
    }
}
