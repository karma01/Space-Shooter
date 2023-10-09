using System.Collections;
using UnityEngine;

public class Levelloader : MonoBehaviour
{
    public static Levelloader load { get; private set; }

    //[SerializeField] private GameObject loadingScreen;
    // [SerializeField] private Image loadingBar;
    [SerializeField] private CanvasGroup loadingCanvasGroup;

    [SerializeField] private float waitingtime;
    [SerializeField] private float changerate;
    private bool fadeon = false;

    private void Awake()
    {
        if (load == null)
        {
            load = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
        }
    }

    private void Start()
    {
        StartCoroutine(fadeOut());           //run fade in start
    }

    public void fadeoutInt(int buildi)
    {
        StartCoroutine(fadeIn(buildi));
    }

    private IEnumerator fadeOut()        //using couroutine to turn black fade screen to transparent mode
    {
        // loadingScreen.SetActive(false);
        fadeon = false;
        while (loadingCanvasGroup.alpha > 0)
        {
            if (fadeon) { yield break; }
            loadingCanvasGroup.alpha -= changerate;       //fade at the rate of change value
            yield return new WaitForSeconds(waitingtime);       //how much fast do you want the fade to wait        increasing waiting time or decreasing change rate gives same result
            Debug.Log("Fade is out");
        }
    }

    public IEnumerator fadeIn(int buildindex)        //using couroutine to turn black fade screen to transparent mode
    {
        fadeon = true;
        while (loadingCanvasGroup.alpha < 1)
        {
            loadingCanvasGroup.alpha += changerate;       //increase at the rate of change value
            yield return new WaitForSeconds(waitingtime);       //how much fast do you want the fade to wait        decreasing waiting time or icnreasing change rate gives same result
            Debug.Log("Fade is in");
        }
        StartCoroutine(fadeOut());           //fade the black screen when level is called
        /// AsyncOperation asy = SceneManager.LoadSceneAsync(buildindex);       //to run the level in background and keeps record of it
        TextFileReader.fileread.LevelLoader(buildindex);

        // asy.allowSceneActivation = false;       //have more control in scene control
        // loadingScreen.SetActive(true);      //enable loading screen
        //loadingBar.fillAmount = 0;          //initialy, set fill amount to 0

        //  while (asy.isDone == false)        //while the game is not full loaded then...
        {
            // loadingBar.fillAmount = asy.progress / 0.9f;      //then fill amount == asy ko progress /0.9 as its value ranges from 0 to 0.9 but fill amount ranges from 0 to 1

            //    if (asy.progress == 0.9f)       //0.9 is max value of asyncoperation .at this value the scene is fully loaded
            {
                //        asy.allowSceneActivation = true;
            }
            //     yield return null;      //to wait till the fade in function is called
        }
    }
}