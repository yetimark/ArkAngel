using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AWSDMove : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    private float moveSpeed = 7f;

	void Update ()
    {
        Move();
	}

    void Move()
    {
        this.horizontal = Input.GetAxis("Horizontal");
        this.vertical = Input.GetAxis("Vertical");

        this.transform.position += new Vector3(this.horizontal, 0, this.vertical) * Time.deltaTime * moveSpeed;
    }
}
