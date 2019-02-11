using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    /// <summary>
    /// Bu uygulamada karakterimiz Space tuşuna basılı tutarak daha uzağa zıplayabilecek.
    /// Space tuşuna basış süresine göre daha fazla veya daha az zıplayacak.
    /// </summary>


    private Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    private float moveInput;
    private bool isGrounded;//Yerde mi olduğumuzu anlatacağımız ve True,False ifadeleri döndereceğimiz değişkenimiz.
    public Transform feetPos;//Bir obje oluşturarak karakterimizin ayağının altına koyuyoruz ve çevresine bir alan ekliyoruz bu alan isGrounded olan LayerMask'e değdiği zaman true yapıyor
    public float checkRadius;//Karakterin ayağında oluşturduğumuz çembersel alan ile isGrounded'in True,False ayarı yapılır
    public LayerMask whatIsGround;//Karakterimizin neye değdiği zaman zemin olacağını ayarlar.
    private float jumpTimeCounter;//Zıpladığımız zaman ne kadar süre havada kalıp zıplayabileceğimizi ayarlar.
    public float jumpTime;//Hardcoding yapmamak için bu değeri Unity'de ayarlayıp jumpTimeCounter'a eşitleriz
    private bool isJumping;//Havalandıysak bir kez daha Space tuşuna bastığımız zaman İkili,Üçlü atlama yapmasını engellemek için oluşturulmuş True,False ifadesi.


	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
    private void Update()
    {
        //Yerde olup olmadığımızı anlamak için oluşturduğumuz feetpos'u pozisyonundaki checkRadius çemberinde altımızdakinin whatIsGround ile aradığımız zemin olup olmadığını tespit ediyoruz.
        isGrounded = Physics2D.OverlapCircle(feetPos.position,checkRadius,whatIsGround);
        if (moveInput>0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);//Karakterimizin doğru yöne bakmasını sağlayan kodumuz.(Sağ)
        }
        else if(moveInput<0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);//(Sol)
        }

        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }
        if (Input.GetKey(KeyCode.Space) && isJumping==true)
        {
            if (jumpTimeCounter>0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }          
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }

    }

    // Update is called once per frame
    void FixedUpdate () {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput*speed*Time.fixedDeltaTime,rb.velocity.y);
	}
}
