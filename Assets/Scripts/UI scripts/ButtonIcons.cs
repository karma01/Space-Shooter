using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonIcons : MonoBehaviour
{
    [SerializeField] private Button[] buttons;
    [SerializeField] private Sprite Unlockedsprite;
    [SerializeField] private Sprite lockedsprite;
    private int firstbuildindex = 30
  ;
    [SerializeField] private ButtonControl buttonControl;

    private void Awake()
    {
        PlayerPrefs.SetInt("LevelUnlock", 30);
        int unlockedlevel = PlayerPrefs.GetInt("LevelUnlock", firstbuildindex);       //get the saved value from gamemanager..unlocledlevel ia higheat unlocked level
        for (int i = 0; i < buttons.Length; i++)
        {
            if (i + firstbuildindex <= unlockedlevel)                                        //if you unlocked the level then
            {
                buttons[i].interactable = true;                                         //set the buttons equals to and less than unlocked level to interacable
                buttons[i].image.sprite = Unlockedsprite;                               //set the image to unlocked
                TextMeshProUGUI buttontext = buttons[i].GetComponentInChildren<TextMeshProUGUI>();  //as text is the child of button so..
                buttontext.text = (i + 1).ToString();                                 //set the level number to unlocked number..
                buttontext.enabled = true;                                         //enable the text

                int sceneIndex = i + firstbuildindex; // Calculate the scene index based on button position and firstbuildindex
                buttons[i].onClick.AddListener(() => OnLevelButtonClicked(sceneIndex)); // uaing lamda function..listner is added to every button....Add a listener for the button click ..when button is clicked it passes the sceneindex to the respective function..
            }
            else
            {
                buttons[i].interactable = true;
                buttons[i].image.sprite = Unlockedsprite;
                buttons[i].GetComponentInChildren<TextMeshProUGUI>().enabled = true;
            }
        }
    }

    private void OnLevelButtonClicked(int sceneIndex)
    {
        // buttonControl.LoadScene(sceneIndex); // Call the LoadScene method in ButtonControl with the selected scene index
    }
}