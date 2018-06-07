using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewCharacter : MonoBehaviour
{
    public GameObject[] classPrefabs; //filled with three class prefabs
    public GameObject[] characters = new GameObject[8];
    public GameObject classPanel;
    public GameObject newCharacter;

    public Vector3 nextSpawn;

    private int spawnNum = 0;
    private string spawnName = "";

    void Awake()
    {
        this.classPanel = GameObject.Find("ClassSelectPanel");
    }

    void Start ()
    {
        this.classPanel.SetActive(false);
    }

     void OnTriggerEnter(Collider other) //other is current Character
     {
        if(other.name != "Plane" && other.name != "TriggerEnable")
        {
            //create new character
            //class select/info panel... chooses correct prefab with button click event name
            this.classPanel.SetActive(true);
            Debug.Log(other.name);
            //name panel.. stores name on character above head

            if (other.name == "Ghost")       //other.gameObject.name?
            {
                Destroy(GameObject.Find("Ghost"));
            }
          
            //turn on movement variable or turn on script
        }
     }

    public void CreateCharacter()      //places new character of the class selected in the world
    {
        //this.newCharacter = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        FindOpenSpawn();
        Instantiate(this.newCharacter, this.nextSpawn, Quaternion.identity);
        //camera to newCharacter?
        this.classPanel.SetActive(false);
    }

    void FindOpenSpawn()
    {
        this.spawnName = this.spawnNum.ToString();
        this.nextSpawn = GameObject.Find(this.spawnName).transform.position;
        this.spawnNum++;
    }
}
