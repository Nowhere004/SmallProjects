using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed;
    private Rigidbody2D rb;
    private Vector2 moveVel;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
      Vector2  moveInputs = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
        moveVel = moveInputs.normalized * speed; 
	}

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position+moveVel*Time.fixedDeltaTime);
    }
}
