using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    //Merminin hareketi
    private float speed = 30f;
    private Counter _counterScript;

    private void Start() 
    {
        _counterScript = GameObject.Find("Player").GetComponent<Counter>();
    }

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);

    if (transform.position.y > 18)
    {
        Destroy(gameObject);
    }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Plate"))
        {
            _counterScript.count += 5;
            _counterScript.UpdateCounterText();
        }
   
        Destroy(gameObject);
        Destroy(collision.gameObject);
    }
}
