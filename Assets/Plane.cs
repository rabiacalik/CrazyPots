using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Vegatable") || collision.gameObject.CompareTag("Plate"))
        {
            Destroy(collision.gameObject);
        }
    }
}
