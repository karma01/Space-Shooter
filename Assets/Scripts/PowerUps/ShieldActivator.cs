using UnityEngine;

public class ShieldActivator : MonoBehaviour
{
    [SerializeField] private Shield shield;

    public void Start()
    {
        shield = FindObjectOfType<Shield>();
    }

    public void ActivateShield()
    {
        if (shield.gameObject.activeSelf == false)         //if shield is not activated then..
        {
            shield.gameObject.SetActive(true);                  //activate it\
        }
        else if (shield.gameObject.activeSelf == true)
        {
            shield.repair();
        }
    }
}