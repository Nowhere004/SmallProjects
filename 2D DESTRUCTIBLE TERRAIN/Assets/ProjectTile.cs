using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectTile : MonoBehaviour {

    private Vector2 target;
    public float speed;
    public GameObject effect;
    /// <summary>
    /// Burada yazdığımız script oluşturduğumuz atışın hareket etmesini gittiği cisimleri tanıyıp hareket etmesi içindir.
    /// Oyunda görünmesini(eklenmesini) player Farenin sol tuşuna basarak yapar bu kod PlayerController'da yazılmıştır.
    /// </summary>
    public float areaOfEffect;
    public LayerMask whatIsDestructible;
    public int damage;
    private Shake shake;

    // Use this for initialization
    void Start () {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector2.MoveTowards(transform.position,target,speed*Time.deltaTime);
        if (Vector2.Distance(transform.position,target)<0.1f)
        {
           GameObject shotEffect= Instantiate(effect,transform.position,Quaternion.identity);            
            Destroy(gameObject);
            Destroy(shotEffect, 0.5f);
        }
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Environment"))
        {
            Collider2D[] objectsToDamage = Physics2D.OverlapCircleAll(transform.position, areaOfEffect, whatIsDestructible);
            for (int i = 0; i < objectsToDamage.Length; i++)
            {
                objectsToDamage[i].GetComponent<DestructibleEnvi>().health -= damage;
                shake.ShakeCam();
            }
            GameObject terEffect = Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(terEffect, 0.5f);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,areaOfEffect);
    }
}
