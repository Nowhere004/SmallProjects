using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    private Rigidbody2D rb;
    private Vector2 moveVector;
    public GameObject shotPrefab;
    public GameObject bombPrefab;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(shotPrefab, transform.position, Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bombPrefab, transform.position, Quaternion.identity);
        }
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
        moveVector = moveInput * speed;
    
	}

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVector * Time.fixedDeltaTime);
    }
}
