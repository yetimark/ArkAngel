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
    public GameObject[] characters;

    public string standingOne = "";

	void Awake ()
    {
        this.home = this.transform.position;
        this.homeRot = this.transform.rotation;

        this.characters = GameObject.FindGameObjectsWithTag("Player");
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name != "Plane")// not required if plane or terrain does not have a collider enabled. had some issues with it activating trigger events.
        {
            this.standingOne = other.gameObject.name;
            //turns trigger for new character off and movement for old character off
            other.GetComponent<Collider>().isTrigger = false;
            this.GetComponent<AWSDMove>().enabled = false;

            //returns old player to starting spot
            this.transform.position = this.home;
            this.transform.rotation = this.homeRot;

            CheckName();

            //turns movement on for new character and trigger for old character off
            other.GetComponent<AWSDMove>().enabled = true;
            this.GetComponent<Collider>().isTrigger = true;
            Debug.Log(this.name + this.GetComponent<Collider>().isTrigger);
            Debug.Log(other.name + other.GetComponent<Collider>().isTrigger);
        }
    }

    public void CheckName()
    {
        if(GameObject.Find((this.standingOne) + "Name").GetComponent<Text>().text == "")//if no name pause game and pull up name prompt
        {
            GameObject.Find("UI Controller").GetComponent<UIButtonFunctions>().namePrompt.SetActive(true);//pull up name prompt
            GameObject.Find("UI Controller").GetComponent<UIButtonFunctions>().pauseGame = true;//stops game (movement)
        }
        else if(GameObject.Find((this.standingOne) + "Name").GetComponent<Text>().text != "")
        {
            Debug.Log(this.standingOne + "new Guy");
            StopMovement();
            //GameObject.Find("WakeUp").GetComponent<Awaken>().allowedToFill = true;//the addition that breaks it
        }
    }

    public void StopMovement()
    {
        for (int i = 0; i < this.characters.Length; i++)
        {
            this.characters[i].GetComponent<AWSDMove>().enabled = false;
        }
    }
}

