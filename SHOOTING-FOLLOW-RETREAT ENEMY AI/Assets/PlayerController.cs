using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Rigidbody2D rb;
    public float speed;
    private Vector2 moveVel;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        moveVel = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
	}

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position+moveVel*speed*Time.fixedDeltaTime);
    }
}
