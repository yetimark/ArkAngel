using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapClass : MonoBehaviour
{
    //switches from current character to desired character on contact of characters
    //add rotation change to home
    
    public Vector3 home;
    public Quaternion homeRot;

	void Awake ()
    {
        this.home = this.transform.position;
        this.homeRot = this.transform.rotation;
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name != "Plane")// not required if plane or terrain does not have a collider enabled. had some issues with it activating trigger events.
        {
            //turns trigger for new character off and movement for old character off
            other.GetComponent<Collider>().isTrigger = false;
            this.GetComponent<AWSDMove>().enabled = false;

            //returns old player to starting spot
            this.transform.position = this.home;
            this.transform.rotation = this.homeRot;

            //turns movement on for new character and trigger for old character off
            other.GetComponent<AWSDMove>().enabled = true;
            this.GetComponent<Collider>().isTrigger = true;
        }


    }

}
