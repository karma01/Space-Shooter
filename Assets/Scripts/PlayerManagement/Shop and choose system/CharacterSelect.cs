using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
public class CharacterSelect : MonoBehaviour
{
    public GameObject[] SpaceshipSkins;
    public int selectedplayer;
    public PlayerStats[] playerStats;

    public Button unlockbutton;
    public TextMeshProUGUI totalcredits;
  
    private void Awake()
    {
     
        selectedplayer = PlayerPrefs.GetInt("SelectedCharater", 0);     //load the selectedchar.. amd assign in selectedplayer
        foreach (GameObject player in SpaceshipSkins)
        {
            player.SetActive(false);            //set every player false of the respective indexes
            SpaceshipSkins[selectedplayer].SetActive(true);     //set the player that is active to true
        }

        foreach (PlayerStats character in playerStats)       //run a loop in the array of characters
        {
            if (character.price == 0)
            {
                character.isUnlocked = true;
            }
            else
            {
                if (PlayerPrefs.GetInt(character.Name, 0) == 0) //as default spaceship is not unlocked
                {     
                    character.isUnlocked = false;
                }
                else
                {
                    character.isUnlocked = true;
                }
            }
        }
        UpdateThisUI();   //call the updateui in awake
    }

    public void changeNext()
    {
        SpaceshipSkins[selectedplayer].SetActive(false);        //set the current selected player to false to change to next player
        selectedplayer++;                                       //increase the selectedchar by 1 to load another character

        if (selectedplayer == SpaceshipSkins.Length)          ///if you reached the limit of skins then..

        {
            selectedplayer = 0;             //set it to initial
        }
        SpaceshipSkins[selectedplayer].SetActive(true);            ///set the skin to true or enabled
        if (playerStats[selectedplayer].isUnlocked)     //if the spaceship is unlocked then..
        {
            PlayerPrefs.SetInt("SelectedCharater", selectedplayer);     //Set the new value of playerprefs to selectedplayer so we can instantiate the same player}
        }  
            UpdateThisUI();                                         // call it when changed next
    }

    public void changePrevious()
    {
        SpaceshipSkins[selectedplayer].SetActive(false);        //set the current selected player to false to change to next player
        selectedplayer--;                                       //decrease the selectedchar by 1 to load another character

        if (selectedplayer == -1)          ///if you reached the limit of skins then..

        {
            selectedplayer = SpaceshipSkins.Length - 1;      //set the player to previous if it is less
        }
        SpaceshipSkins[selectedplayer].SetActive(true);            ///set the skin to true or enabled
      
        if (playerStats[selectedplayer].isUnlocked)     //if the spaceship is unlocked then..
        {
            PlayerPrefs.SetInt("SelectedCharater", selectedplayer);     //Set the new value of playerprefs to selectedplayer so we can instantiate the same player
        }
        else
        {

        }
        UpdateThisUI();                                         // call it when changed previous
    }

    public void UpdateThisUI()              //method for buying system
    {
       totalcredits.text = "Total Credits:" + PlayerPrefs.GetInt("Total Credits:", 0);      //show the total credits 
        int totalcoins = PlayerPrefs.GetInt("Total Credits:", 0);            //get the total coins from playerprefs
        if (playerStats[selectedplayer].isUnlocked == true)                //if spaceship is  unlocked then...
        {
            unlockbutton.gameObject.SetActive(false);                   //set the button inactive
        }
        else
        {
            unlockbutton.GetComponentInChildren<TextMeshProUGUI>().text = "Total Credits:" + playerStats[selectedplayer].price;          //set the text to the price that is set in inspector
            if (totalcoins < playerStats[selectedplayer].price)                 //if the player dont have enough money then..
            {
                unlockbutton.gameObject.SetActive(true);                        // set the button active but not interactable
                unlockbutton.interactable = false;


            }
            else
            {
                unlockbutton.gameObject.SetActive(true);                        // set the button active but not interactable
                unlockbutton.interactable = true;

            }

        }
    }
    public void UNlocked()
    {

        int coins = PlayerPrefs.GetInt("Total Credits:",0);
        int price = playerStats[selectedplayer].price;
        PlayerPrefs.SetInt("Total Credits:", coins-price);
        PlayerPrefs.SetInt(playerStats[selectedplayer].Name, 1);        //set the boolean to 1 i.e true when player is unlocked
        PlayerPrefs.SetInt("SelectedCharater", selectedplayer);             //set the index value of player to the selectedplayer so that user can play with the selected spaceship
        playerStats[selectedplayer].isUnlocked = true;      //set the boolean to true
        UpdateThisUI();

    }
}