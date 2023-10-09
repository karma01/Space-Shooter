using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowCoins : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinstext;
    [SerializeField] private TextMeshProUGUI totalcoinstext;

    private void OnEnable()
    {
        int coins = GameManagerEnd.endmanager.ReturnEnemyCoins();
        coinstext.text = "Credits:" + PlayerPrefs.GetInt("Credits:" + SceneManager.GetActiveScene().buildIndex, 0); ;        //to save the coins we got in match
                                                                                                                             // int totalcoins = PlayerPrefs.GetInt("Coins:" + SceneManager.GetActiveScene().buildIndex,GameManagerEnd.endmanager.cointotal);
                                                                                                                             //totalcoinstext.text = "Coins got:" +totalcoins.ToString();
        int totalcoins = GameManagerEnd.endmanager.totalcoins();
        totalcoinstext.text = "Total Credits:" + 300000;
    }
}