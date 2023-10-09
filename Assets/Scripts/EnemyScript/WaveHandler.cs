using UnityEngine;

public class WaveHandler : MonoBehaviour
{
    public static WaveHandler wave;

    public GameObject player;

    private void Start()
    {
        if (wave == null)
        {
            wave = this;
        }
    }

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (transform.childCount == 1) //if all childs of wave are destroyed then destroy game object
        {
            Destroy(gameObject);
            if (EnemySpawner.spawner.totalspawned >= WinCondition.win.controlwaves)     //if waves spawned  equals to total waves you want then..return    //gave me headache.. never put this on Ondestroy().. gives trouble while restarting the level
            {
                return;
            }
            else
            {
                EnemySpawner.spawner.Runondestroy();        //if its equal then run this
            }
        }
    }

    public void EnemyGeneration(int storelevelnumber)
    {
        if (storelevelnumber <= 8)
        {
            EnemySpawner.spawner.spawningNumb = UnityEngine.Random.Range(0, 8);
        }
        else if (storelevelnumber >8 && storelevelnumber < 16)
        {
            EnemySpawner.spawner.spawningNumb = UnityEngine.Random.Range(3, 7);
        }
        else if (storelevelnumber < 16 && storelevelnumber > 9)
        {
            EnemySpawner.spawner.spawningNumb = UnityEngine.Random.Range(2, 12);
        }
    }
}