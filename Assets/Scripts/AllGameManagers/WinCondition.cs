using TMPro;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public float controlwaves = 1;
    public static WinCondition win;
    public int coinstobeadded;
    public TextMeshProUGUI wavesshow;

    private void Awake()
    {
        if (win == null)
        {
            win = this;
        }
    }

    private void Start()
    {
        //controlwaves = Random.Range(4, 11);
    }

    private void Update()
    {
        Invoke("onCall", 0f);
    }

    private void onCall()
    {
        wavesshow.text = EnemySpawner.spawner.totalspawned.ToString() + "/" + controlwaves.ToString();
        if (EnemySpawner.spawner.totalspawned >= controlwaves) //compare between totalspawned and controlwaves
        {
            GameManagerEnd.endmanager.startresolvegameon();     //load the successs method
            Destroy(gameObject);
        }
    }
}