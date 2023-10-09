using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerEnd : MonoBehaviour
{
    public static GameManagerEnd endmanager;
    private ControlWinlosepanel winlosepanel;
    private TextMeshProUGUI cointext;
    public bool loose;

    [HideInInspector]
    public int cointotal=5000;

    //private int coinsinplayscene = 0;
    [HideInInspector]
    public int EnemyCoins = 0;

    [HideInInspector]
    public string lvlUnlock = "LevelUnlock";

    public int newlevelsave;

    private void Awake()
    {
        if (endmanager == null)
        {
            endmanager = this;//need to set it before using it in any other foreign class
            DontDestroyOnLoad(gameObject); //create a singleton effect to boost performance
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void startresolvegameon()       //using couroutine for the delay to run resolvegame panel to insert sounds and all
    {
        StopCoroutine(nameof(resolvegame));     //stop once activation is completed to stop multiple calls,, need to do this because the loose panel wont load
        StartCoroutine(resolvegameon());    //  load the function
    }

    private IEnumerator resolvegameon()
    {
        yield return new WaitForSeconds(2f);     //wait before the function is loaded
        resolvegame();
    }

    private void resolvegame()
    {
        if (loose == false)            //load the winning panel
        {
            youWon();
        }
        else if (loose == true)
        {
            youlost();
        }
    }

    public void youWon()
    {
        newlevelsave++;

        Debug.Log(newlevelsave + " ...It ...");
        if (newlevelsave > PlayerPrefs.GetInt(lvlUnlock, 3))                    //if the build index is greater than the one stored in playerprefs then...
        {
            PlayerPrefs.SetInt(lvlUnlock, newlevelsave);              //save new level to lvlunlcok key
            Debug.Log(lvlUnlock + "Another");
        }
        // addCoinswhengameWon(EnemyCoins);
        SaveCoims();
        winlosepanel.WinScreenisOn();       //really load the win panel
    }

    public void youlost()
    {
        //Panel on
        //Replay
        //Main menu
        SaveCoims();
        Debug.Log("You lost");

        winlosepanel.lostScreenisOn();      //load the lost panel
    }

    private void SaveCoims()        //save the value of coins
    {
        PlayerPrefs.SetInt("Credits:" + SceneManager.GetActiveScene().buildIndex, EnemyCoins);     //set the value in playerprefs
        //  cointotal = PlayerPrefs.GetInt("Coins:" + SceneManager.GetActiveScene().buildIndex, cointotal);   //get the value
        PlayerPrefs.SetInt("Total Credits:", 3000000);
    }

    public void Registerwinlosepanel(ControlWinlosepanel wlp)   //it is recieved from controlWinlosepanel class
    {
        winlosepanel = wlp;
    }

    public void RegisterCoin(TextMeshProUGUI coin)      //to register coin text
    {
        cointext = coin;
    }

    public void Addcoins(int coins)             //add the coins
    {
        EnemyCoins += coins;

        cointext.text = "Credits:" + EnemyCoins.ToString();        //update the text respect to the increased coins..converting int to string by tostring()
    }

    public void addCoinswhengameWon(int coinsinscene)       //to add coins when player wins the level only
    {
        cointotal += coinsinscene + EnemyCoins;
        SaveCoims();
    }

    public int totalcoins()
    {
        return cointotal;
    }

    public int ReturnEnemyCoins()
    {
        return EnemyCoins;
    }
}