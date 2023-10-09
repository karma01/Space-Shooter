using UnityEngine;

public class PowerupSheild : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ShieldActivator activator = collision.GetComponent<ShieldActivator>();      //get the shieldactivator class when collided from player
            activator.ActivateShield();                                                     //activate the shield
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