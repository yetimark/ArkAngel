using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonFunctions : MonoBehaviour
{
    [HideInInspector]
    public GameObject selectClass, namePrompt;
    [HideInInspector]
    public string chosen;
    [HideInInspector]
    public bool gate = false;

	void Awake ()
    {
        this.selectClass = GameObject.Find("ClassSelectPanel");
        this.namePrompt = GameObject.Find("NameCharacterPrompt");
	}
	
    public void SelectClass()
    {
        //returns the string of the button clicked
        this.chosen = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        
        //turns off UI panel
        this.selectClass.SetActive(false);

        //allows GroundRuleDecision to pull new value for this.chosen
        this.gate = true;
    }

    public void InitializeAngel()
    {
        GameObject.Find("Main Camera").GetComponent<CameraFollow>().currAngel = GameObject.Find(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
        //this.firstAngel = GameObject.Find(this.chosen);
    }

    public void SaveButton()
    {
        //save name to this.class of player data
        //turn off prompt
        this.namePrompt.SetActive(false);

    }
}
