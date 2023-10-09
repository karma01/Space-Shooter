using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Laser : MonoBehaviour
{
    [SerializeField] private GameObject SideLaser1;
    [SerializeField] private GameObject SideLaser2;
    [SerializeField] private Image poweruplaser;
    [SerializeField]private GameObject imagelaser;
    private int i;

    private void Start()
    {
        Invoke("Findit", 0.5f);
       
        poweruplaser.fillAmount = 0;

    }

    private void Findit()
    {
        imagelaser = GameObject.FindWithTag("HealthSystem");
        poweruplaser = imagelaser.transform.Find("HealthWinAndLose/LaserUp").GetComponent<Image>(); 
    }

    public void Oncall()
    {
      
        i++;
        if (i == 1)
        {
            SideLaser1.SetActive(true);
           
        }
        else if (i == 2)
        {
            SideLaser2.SetActive(true);
        }
        poweruplaser.fillAmount += 0.34f;
    }
}
