using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
    public float speed;
    private WayPoints Wpoints;
    private int wayPointIndex;


	// Use this for initialization
	void Start () {
        Wpoints = GameObject.FindGameObjectWithTag("Waypoints").GetComponent<WayPoints>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector2.MoveTowards(transform.position,Wpoints.waypoints[wayPointIndex].position,speed*Time.deltaTime);
        Vector3 dir = Wpoints.waypoints[wayPointIndex].position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle,Vector3.forward);


        if (Vector2.Distance(transform.position,Wpoints.waypoints[wayPointIndex].position)<0.1f)
        {
            if (wayPointIndex<Wpoints.waypoints.Length-1)
            {
                wayPointIndex++;
            }
            else
            {
                Destroy(gameObject);
            }            
        }
	}
}
