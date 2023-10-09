using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDmage : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Invoke("Destroy", 0.5f);
        }


    }

    private void Destroy()
    {

       // if(GameManagerEnd.endmanager.loose ==false) { return; }
        GameManagerEnd.endmanager.loose = true;
        GameManagerEnd.endmanager.startresolvegameon();// the bool of endmanager is set to ture
        Debug.Log("You lost");
        //the function is loaded
        Destroy(gameObject);
    }

}
