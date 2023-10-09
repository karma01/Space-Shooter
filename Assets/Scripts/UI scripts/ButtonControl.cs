using UnityEngine;

public class ButtonControl : MonoBehaviour
{
    private int storelevelnumber;

    public static ButtonControl control;
    private void Awake()
    {
        if(control == null)
        {
            control = this;
        }
    }
    public void LoadLevelInt()
    {
       // GameManagerEnd.endmanager.newlevelsave = storelevelnumber++;
       
        Invoke("ControlWaves", 0.5f);
        //  EnemySpawner.spawner.onSceneReset(); //to restart the value of total waves to 0

        Invoke("ReallyLoadNextLevel", 2f);
        GameManagerEnd.endmanager.EnemyCoins = 0;
    }

    public void ReallyLoadNextLevel()
    {
        EnemySpawner.spawner.onScreenReset();

        Time.timeScale = 1f;
        if (EnemySpawner.spawner != null)        //run this method to destroy all previous instantiated gameobjects
        {
            EnemySpawner.spawner.Oninstantiate();
        }

        // storelevelnumber++;
        TextFileReader.fileread.LevelLoader(storelevelnumber);

        Invoke("ControlWaves", 0.5f);
    }

    public void ReplayScene()
    {
        GameManagerEnd.endmanager.EnemyCoins = 0;           //ensure that enemycoins has value 0 while changing scenesS
                                                            // EnemySpawner.spawner.onSceneReset();//to restart the value of total waves to 0
        Invoke("ControlWaves", 0.5f);
        Invoke("ReallyReplayScene", 2f);
    }

    public void ReallyReplayScene()
    {
        Time.timeScale = 1f;//////////////
        EnemySpawner.spawner.Oninstantiate();
        if (EnemySpawner.spawner != null)
        {
            EnemySpawner.spawner.Oninstantiate();
        }          //run this method to destroy all previous instantiated gameobjects
                   //EnemySpawner.spawner.gameObject.SetActive(false);
                   //TextFileReader.fileread.LevelLoader(storelevelnumber);
        Levelloader.load.fadeoutInt(storelevelnumber);            //passs the current build index to the method when button is clicked
        Invoke("ControlWaves", 0.5f);
    }

    public void LoadScene(int levelNumber)     //transfer between scenes

    {
        storelevelnumber = levelNumber;
        GameManagerEnd.endmanager.newlevelsave = storelevelnumber;
    
        // GameManagerEnd.endmanager.newlevelsave = levelNumber;
        Time.timeScale = 1f;
      

        Levelloader.load.fadeoutInt(levelNumber);

        //TextFileReader.fileread.LevelLoader(storelevelnumber);

        if (GameManagerEnd.endmanager != null && EnemySpawner.spawner != null)
        {
            GameManagerEnd.endmanager.EnemyCoins = 0;
            EnemySpawner.spawner.Oninstantiate();
        }
        else
        {
            return;
        }

        Invoke("ControlWaves", 0.5f);
    }

    public void PauseGame()                 //pause method
    {
        Time.timeScale = 0f;            //pause the game time
    }

    public void ResumeGame()                 //resume method
    {
        Time.timeScale = 1f;            //resume the game time
    }

    public void OnClickedQuit()
    {
        Debug.Log("Application Quitted");
        Application.Quit();
    }

    public void Update()
    {
        if (WinCondition.win != null)
        {
            WaveHandler.wave.EnemyGeneration(storelevelnumber);
        }
        else if (WinCondition.win == null)
        {
            return;
        }
    }

    public void SetTimeScale0ne()
    {
        Time.timeScale = 1f;
    }

    public void SetTimeScalezero()
    {
        Time.timeScale = 0f;
    }

    public void ControlWaves()
    {
        if (WinCondition.win != null)
        {
            if (storelevelnumber <= 4)
            {
                WinCondition.win.controlwaves = 4;
            }
            else if (storelevelnumber > 4 && storelevelnumber < 8)
            {
                WinCondition.win.controlwaves = 6;
            }
            else if (storelevelnumber < 16 && storelevelnumber > 9)
            {
                WinCondition.win.controlwaves = 8;
            }
        }
    }
}