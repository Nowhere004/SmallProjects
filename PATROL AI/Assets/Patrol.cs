using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour {

    /// <summary>
    /// Bu kod dizinimizde bizim belirlediğimiz noktalar arasında random bir tane seçip dolaşan bir düşman yapay zekası yaptık
    /// </summary>
    public float speed;
    public Transform[] moveSpots;
    private int randomSpotIndex;
    private float waitTime;
    public float startWaitTime;

    private void Start()
    {
        waitTime = startWaitTime;
        randomSpotIndex = Random.Range(0,moveSpots.Length);
    }


    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpotIndex].position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position,moveSpots[randomSpotIndex].position)<0.2f)
        {
            if (waitTime<=0)
            {
                randomSpotIndex = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
            
        }
        
    }
}
