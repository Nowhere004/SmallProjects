using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

    public float timer;
    public float areaOfEffect;
    public LayerMask whatIsDestructible;
    public int damage;
    public GameObject bombEffect;
    private Shake shake;
    /// <summary>
    /// Burada yazdığımız script oluşturduğumuz atışın hareket etmesini gittiği cisimleri tanıyıp hareket etmesi içindir.
    /// Oyunda görünmesini(eklenmesini) player klavyeden Space tuşuna basarak yapar bu kod PlayerController'da yazılmıştır.
    /// </summary>
    private void Start()
    {
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
    }
    void Update () {
        if (timer<=0)
        {
            Collider2D[] objectsToDamage = Physics2D.OverlapCircleAll(transform.position, areaOfEffect, whatIsDestructible);
            for (int i = 0; i < objectsToDamage.Length; i++)
            {
                objectsToDamage[i].GetComponent<DestructibleEnvi>().health -= damage;
                shake.ShakeCam();
            }
            GameObject effectD = Instantiate(bombEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(effectD, 1f);
        }
        else
        {
            timer -= Time.deltaTime;
        }
	}
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, areaOfEffect);
    }
}
