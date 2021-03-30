using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flies : MonoBehaviour
{
    int flies;
    float timeLife;
    void Start()
    {
        StartCoroutine(Dying());
    }
    IEnumerator Dying()
    {
        if(0 > timeLife)
        {
            
        }
        yield return new WaitForSeconds(1f);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fly"))
        {
            flies++;
            timeLife += 10;
        }
    }
}
