using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//this script only needs to be on while in a place characters should be able to change their class.
public class SwapClass : MonoBehaviour
{
    //switches from current character to desired character on contact of characters
    //add rotation change to home
    
    public Vector3 home;
    public Quaternion homeRot;
    public GameObject[] characters;// is this being used?

    public string standingOne = "";

    public bool allowedToCollide = false;

	void Awake ()
    {
        this.home = this.transform.position;
        this.homeRot = this.transform.rotation;

        this.characters = GameObject.FindGameObjectsWithTag("Player");
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name != "Plane" && this.allowedToCollide)// not required if plane or terrain does not have a collider enabled. had some issues with it activating trigger events.
        {
            this.allowedToCollide = false;
            GameObject.Find("WakeUp").GetComponent<Awaken>().allowedToFill = true;

            this.standingOne = other.gameObject.name;
            //turns trigger for new character off and movement for old character off
            other.GetComponent<Collider>().isTrigger = false;
            this.GetComponent<AWSDMove>().enabled = false;

            //returns old player to starting spot
            this.transform.position = this.home;
            this.transform.rotation = this.homeRot;

            StopMovement();

            //turns movement on for new character and trigger for old character off
            other.GetComponent<AWSDMove>().enabled = true;
            this.GetComponent<Collider>().isTrigger = true;
        }
    }


    public void StopMovement()
    {
        for (int i = 0; i < this.characters.Length; i++)
        {
            this.characters[i].GetComponent<AWSDMove>().enabled = false;
            Debug.Log("did we stop moving?" + this.characters[i]);
        }
    }
}

