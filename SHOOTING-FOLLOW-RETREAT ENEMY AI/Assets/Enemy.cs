using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    private Transform player;
    private float timeBtwShots;
    public float startTimeBtwShots;
    public GameObject projectTile;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position,player.position)>stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position,player.position,speed*Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, player.position) <retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }

        if (timeBtwShots<=0)
        {
            Instantiate(projectTile,transform.position,Quaternion.identity);
            timeBtwShots = startTimeBtwShots;

        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
