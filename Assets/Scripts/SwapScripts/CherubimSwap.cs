using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherubimSwap : MonoBehaviour
{

    private Vector3 home;

    void Awake()
    {
        this.home = this.transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Cherubim")
        {
            this.GetComponent<AWSDMove>().enabled = false;
            this.transform.position = this.home;
            other.GetComponent<AWSDMove>().enabled = true;

        }

    }
}
