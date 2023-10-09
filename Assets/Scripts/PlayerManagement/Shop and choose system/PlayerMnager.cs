using UnityEngine;
using UnityEngine.UI;

public class PlayerMnager : MonoBehaviour
{
    [SerializeField] private GameObject[] player;
    private int characterindex;
    public GameObject Healthfillimage;
    public Image Healthfill;
    private Transform storeplayer;

    private void Start()
    {
        Invoke("Oncall", 0.2f);
     
    }
    private void Oncall()
    {
        Debug.Log("It is runnninggggg:::::::::::::::");
        storeplayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Healthfillimage = GameObject.FindGameObjectWithTag("HealthSystem");
        Healthfill = Healthfillimage.transform.Find("HealthWinAndLose/Healthsystem/Healthbackground/healthfill").GetComponent<Image>();
        characterindex = PlayerPrefs.GetInt("SelectedCharater", 0);       //store the value in a key..if it doesnt exists creatre one with a vlaue 0
        GameObject InsPlayer = Instantiate(player[characterindex], storeplayer.transform.position, Quaternion.identity, storeplayer);         //instantiating the player in storeplayer gameobject for flexibility
        PlayerHealth playerhealth = InsPlayer.GetComponent<PlayerHealth>();         //get the playerhealth component from the player
        playerhealth.healthfill = Healthfill;
    }
    
}