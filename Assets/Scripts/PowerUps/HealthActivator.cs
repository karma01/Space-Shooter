using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthActivator : MonoBehaviour
{
 private PlayerHealth health;
    private void Start()
    {
        health =FindObjectOfType<PlayerHealth>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

       if(collision.gameObject.tag =="Player")
        {
            health.Oncall();
            Destroy(gameObject);

        }
       else
        {
            Invoke("onDestroyed", 7f);
        }
     

    }
    private void OnDestroyed()
    {
        Destroy(gameObject);
    }
}
