using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectClass : MonoBehaviour
{
    public GameObject throne;
    public GameObject seraphim;
    public GameObject cherubim;

    public Vector3 throneHome;
    public Vector3 seraphimHome;
    public Vector3 cherubimHome;


	void Awake ()
    {
        this.throne = GameObject.Find("Throne");
        this.seraphim = GameObject.Find("Seraphim");
        this.cherubim = GameObject.Find("Cherubim");

        this.throneHome = this.throne.transform.position;
        this.seraphimHome = this.seraphim.transform.position;
        this.cherubimHome = this.cherubim.transform.position;
	}
	
	void Update ()
    {
        SwapOnClick();
	}

    void SwapOnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(this.throne.transform.position != this.throneHome)
            {
                this.throne.GetComponent<AWSDMove>().enabled = false;
                this.throne.transform.position = this.throneHome;
                //this.otherAngel.enabled = true;
            }
        }
    }

}
