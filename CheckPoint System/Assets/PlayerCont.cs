using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCont : MonoBehaviour {
    [SerializeField]
    private float speed;
    private Rigidbody2D rb;
    private float Hor;
    private Animator myAnim;
    private bool facingRight;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        Hor = Input.GetAxisRaw("Horizontal");
        Flip(Hor);
	}
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(Hor*speed*Time.fixedDeltaTime,rb.velocity.y);
        myAnim.SetFloat("speed", Mathf.Abs(Hor));
 
    }

    private void Flip(float horizontal)
    {
        if (Hor < 0 && !facingRight || Hor > 0 && facingRight)
        {
            facingRight = !facingRight;
            transform.Rotate(0f, 180f, 0f);
        }

    }
}
