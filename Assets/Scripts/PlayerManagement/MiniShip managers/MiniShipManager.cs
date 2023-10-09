using UnityEngine;

public class MiniShipManager : MonoBehaviour
{
    [SerializeField] private GameObject[] miniship;
    private int characterindex;
    [SerializeField] private Transform storeplayer;
    [SerializeField] private GameObject player;

    private void Start()
    {
        Invoke("OnCall", 0.5f);
    }

    private void OnCall()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        storeplayer = player.transform.Find("MiniShips").GetComponent<Transform>();

        characterindex = PlayerPrefs.GetInt("SelectedMiniShip", 0);   //store the selected miniship    //store the value in a key..if it doesnt exists creatre one with a vlaue 0

        GameObject miniShipInstance = Instantiate(miniship[characterindex], storeplayer.transform.localPosition, Quaternion.identity, storeplayer);         //instantiating the player in storeplayer gameobject for flexibility
    }
}