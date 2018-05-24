using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject throne;
    public GameObject seraphim;
    public GameObject cherubim;

    private Vector3 cameraHeight = new Vector3(0, 1, 0);

    //private Vector3 thronePos;
    //private Vector3 seraphimPos;
    //private Vector3 cherubimPos;

	void Awake ()
    {
        this.throne = GameObject.Find("Throne");
        this.seraphim = GameObject.Find("Seraphim");
        this.cherubim = GameObject.Find("Cherubim");
	}
	
	void Update ()
    {
        Follow(this.throne);
	}

    void Follow(GameObject angel) //camera is slightly behind character movement because of follow and not moving directly with input
    {
        this.transform.position = angel.transform.position + this.cameraHeight;
    }
}
