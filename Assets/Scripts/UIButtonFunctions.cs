using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonFunctions : MonoBehaviour
{
    [HideInInspector]
    public GameObject selectClass;
    [HideInInspector]
    public string chosen = "Throne";
    [HideInInspector]
    public bool gate = false;

	void Awake ()
    {
        this.selectClass = GameObject.Find("ClassSelectPanel");
	}
	
    void SelectClass()
    {
        this.chosen = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        this.selectClass.SetActive(false);
        this.gate = true;
    }
}
