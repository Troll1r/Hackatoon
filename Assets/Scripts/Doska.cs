using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doska : MonoBehaviour
{
    int speed;
    GameObject frog;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Frog"))
        {
            //frog.transform = other.transform;
            transform.parent = frog.transform;
        }
    }
}
