using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserActivator : MonoBehaviour
{
    private Laser laser;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           laser = collision.GetComponent<Laser>();      //get the shieldactivator class when collided from player
            laser.Oncall();                                                     //activate the shield
            Destroy(gameObject);                                                            //destroy the gameobject after everything
        }
        else
        {
            Invoke("Destroygameobj", 10f);
        }
    }
    private void Destroygameobj()
    {
        Destroy(gameObject);
    }



}
