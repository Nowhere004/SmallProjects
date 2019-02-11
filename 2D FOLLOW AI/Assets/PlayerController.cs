using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rb;
    public float speed;
    private float moveHor;
    private float moveVer;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
        moveHor = Input.GetAxisRaw("Horizontal");
        moveVer = Input.GetAxisRaw("Vertical");
        
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveHor*speed*Time.fixedDeltaTime,moveVer*speed*Time.fixedDeltaTime);
    }
}
