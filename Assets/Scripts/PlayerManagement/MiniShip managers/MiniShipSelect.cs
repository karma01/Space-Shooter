using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MiniShipSelect : MonoBehaviour
{
    public GameObject[] miniShipSkins;
    public int selectedSpaceShip;
    public MiniShipStats[] MiniShipStats;

    public Button unlockbutton;
    public TextMeshProUGUI totalcredits;

    private void Awake()
    {

        selectedSpaceShip = PlayerPrefs.GetInt("SelectedMiniShip", 0);     //load the selectedchar.. amd assign in selectedplayer
        foreach (GameObject Miniship in miniShipSkins)
        {
            Miniship.SetActive(false);            //set every player false of the respective indexes
            miniShipSkins[selectedSpaceShip].SetActive(true);     //set the player that is active to true
        }

        foreach (MiniShipStats character in MiniShipStats)       //run a loop in the array of characters
        {
            if (character.price == 0)
            {
                character.isUnlocked = true;
            }
            else
            {
                if (PlayerPrefs.GetInt(character.Name, 0) == 0) //as default spaceships are not unlocked
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
        miniShipSkins[selectedSpaceShip].SetActive(false);        //set the current selected player to false to change to next player
        selectedSpaceShip++;                                       //increase the selectedchar by 1 to load another character

        if (selectedSpaceShip == miniShipSkins.Length)          ///if you reached the limit of skins then..

        {
            selectedSpaceShip = 0;             //set it to initial
        }
        miniShipSkins[selectedSpaceShip].SetActive(true);            ///set the skin to true or enabled
        if (MiniShipStats[selectedSpaceShip].isUnlocked)     //if the spaceship is unlocked then..
        {
            PlayerPrefs.SetInt("SelectedMiniShip", selectedSpaceShip);     //Set the new value of playerprefs to selectedplayer so we can instantiate the same player}
        }
        UpdateThisUI();                                         // call it when changed next
    }

    public void changePrevious()
    {
        miniShipSkins[selectedSpaceShip].SetActive(false);        //set the current selected player to false to change to next player
        selectedSpaceShip--;                                       //decrease the selectedchar by 1 to load another character

        if (selectedSpaceShip == -1)          ///if you reached the limit of skins then..

        {
            selectedSpaceShip = miniShipSkins.Length - 1;      //set the player to previous if it is less
        }
        miniShipSkins[selectedSpaceShip].SetActive(true);            ///set the skin to true or enabled

        if (MiniShipStats[selectedSpaceShip].isUnlocked)     //if the spaceship is unlocked then..
        {
            PlayerPrefs.SetInt("SelectedMiniShip", selectedSpaceShip);     //Set the new value of playerprefs to selectedplayer so we can instantiate the same player
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
        if (MiniShipStats[selectedSpaceShip].isUnlocked == true)                //if spaceship is  unlocked then...
        {
            unlockbutton.gameObject.SetActive(false);                   //set the button inactive
        }
        else
        {
            unlockbutton.GetComponentInChildren<TextMeshProUGUI>().text = "Total Credits:" + MiniShipStats[selectedSpaceShip].price;          //set the text to the price that is set in inspector
            if (totalcoins < MiniShipStats[selectedSpaceShip].price)                 //if the player dont have enough money then..
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

        int coins = PlayerPrefs.GetInt("Total Credits:", 0);
        int price = MiniShipStats[selectedSpaceShip].price;
        PlayerPrefs.SetInt("Total Credits:", coins - price);
        PlayerPrefs.SetInt(MiniShipStats[selectedSpaceShip].Name, 1);        //set the boolean to 1 i.e true when player is unlocked
        PlayerPrefs.SetInt("SelectedMiniShip", selectedSpaceShip);             //set the index value of player to the selectedplayer so that user can play with the selected spaceship
        MiniShipStats[selectedSpaceShip].isUnlocked = true;      //set the boolean to true
        UpdateThisUI();

    }
}

