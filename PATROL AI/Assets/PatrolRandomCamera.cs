using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolRandomCamera : MonoBehaviour {

    /// <summary>
    /// Bu kod dizininde düşman yapay zekamız kamera da belirlediğimiz alan en fazla en az gidebileciği koordinatlar arasında serbest bir hareket yapmaktadır.
    /// </summary>

    public float speed;
    public Transform moveSpot;    
    private float waitTime;
    public float startWaitTime;

    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;

    private void Start()
    {
        waitTime = startWaitTime;
        moveSpot.position = new Vector2(Random.Range(xMin,xMax), Random.Range(yMin, yMax));
        
    }


    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, moveSpot.position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                moveSpot.position = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }

        }

    }
}
