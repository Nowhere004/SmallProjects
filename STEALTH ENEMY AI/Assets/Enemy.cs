using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public float rotSpeed;
    public float distance;
    public LineRenderer lineofSight;
    public Gradient redColor;
    public Gradient greenColor;


    private void Start()
    {
        Physics2D.queriesStartInColliders = false;//Düşman objemizin kendi Collider'ı ile etkileşime girmesini önledik.
    }
    private void Update()
    {
        transform.Rotate(Vector3.forward * rotSpeed * Time.deltaTime);
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position,transform.right,distance);
        if (hitInfo.collider!=null)
        {
            lineofSight.SetPosition(1,hitInfo.point);
            lineofSight.colorGradient = redColor;
            Debug.DrawLine(transform.position,hitInfo.point,Color.red);
            if (hitInfo.collider.CompareTag("Player"))
            {
                Destroy(hitInfo.collider.gameObject);
            }
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position+transform.right*distance, Color.green);
            lineofSight.SetPosition(1,transform.position+transform.right*distance);
            lineofSight.colorGradient = greenColor;
        }

        lineofSight.SetPosition(0,transform.position);
    }

}
