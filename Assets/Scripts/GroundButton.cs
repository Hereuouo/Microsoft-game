using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundButton : MonoBehaviour
{
    public GameObject[] Activate;
    bool active = false;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player") && active == false)
        {
            GetComponent<Animator>().Play("activate");

            for (int i = 0; i < Activate.Length; i++) 
            {
                Activate[i].GetComponent<Animator>().Play("activate");
            }
        }
    }
}
