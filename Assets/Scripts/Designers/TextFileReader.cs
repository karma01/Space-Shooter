using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class TextFileReader : MonoBehaviour
{
    private string path;        // stores filename
    private string LevelName;
    private StreamReader reader;
    public char[] seperators;
    public static TextFileReader fileread;
    private float controlwaves1;
    private string[] array = new string[0];

    [HideInInspector] public string levelNumber;
    private List<GameObject> instantiatedobj = new List<GameObject>();   //to dave the previous game objectss

    public void Awake()
    {
        //  LevelLoader(1);
        if (fileread == null)
        {
            fileread = this;
        }
    }

    private void Start()
    {
        LevelLoader(1);
    }

    private void Update()
    {
        //LevelLoader(1);
    }

    public void LevelLoader(int levelnumber)
    {
        Debug.Log("Run");
        destroyBeforeLoad();                //destroy the previous instantiated object

        LevelName = "LevelTexts/Level" + levelnumber + ".txt";
        Debug.Log("Destroyed:");
        StartCoroutine(levelGenerator(LevelName));
    }

    public IEnumerator levelGenerator(string levelName)
    {
        //path = Application.dataPath + levelName;
        path = Path.Combine(Application.streamingAssetsPath, levelName);
        UnityWebRequest www = UnityWebRequest.Get(path);            //requesitng the path to the http get unitywebrequest api
        yield return www.SendWebRequest();          //wait till the request is done
        // reader = new StreamReader(path);

        {
            if (www.result != UnityWebRequest.Result.Success)       //checks if the webrequest is successful
            {
                Debug.LogError("Error loading level file: " + www.error);
                yield break;
            }
            string fileContents = www.downloadHandler.text;     //reads the downloaded content or likely stores
            string[] lines = fileContents.Split('\n'); // Split by lines

            foreach (string line in lines)      // iterates between the lines and generate the adequate data
            {
                levelGenerator_Function(line);          //pass the data
            }
        }
        // while (!reader.EndOfStream)
        {
            // levelGenerator_Function();
        }
    }

    private void levelGenerator_Function(string line)
    {
        array = line.Split(seperators);     //seperate the lines using seperators char

        Vector3 position = new Vector3(float.Parse(array[2]), float.Parse(array[4]), float.Parse(array[6]));        //store the position of gameobj
        Vector3 rotation = new Vector3(float.Parse(array[8]), float.Parse(array[10]), float.Parse(array[12]));          //store the rotation
        string objectname = array[0];
        // float thisw = float.Parse(array[2]);
        // Debug.Log(thisw);
        GameObject _temp_object = Instantiate(Resources.Load<GameObject>(objectname), position, Quaternion.Euler(rotation));        //instantiate the object

        instantiatedobj.Add(_temp_object);      //add the instantiaed objects in the list
    }

    public void destroyBeforeLoad()            //destory the previous game objects
    {
        foreach (GameObject obj in instantiatedobj)        //for every game objects in the saved list...
        {
            Destroy(obj);           //destroy the obj
        }
        instantiatedobj.Clear();            //clear the list
    }
}