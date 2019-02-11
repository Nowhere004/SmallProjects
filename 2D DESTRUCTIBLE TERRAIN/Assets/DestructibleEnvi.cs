using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleEnvi : MonoBehaviour {

    public int health;
    public GameObject destroyEffect;
    /// <summary>
    /// Bütün Wall elementlerimize eklediğimiz script.
    /// </summary>


    private void Update()
    {
        if (health<=0)
        {
            GameObject terEffect=Instantiate(destroyEffect, transform.position, Quaternion.identity);            
            Destroy(gameObject);
            Destroy(terEffect, 0.5f);
        }
    }

}
