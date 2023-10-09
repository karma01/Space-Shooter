using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner spawner;
    private ResPlayerMove restrict;
    [SerializeField] private GameObject[] EnemyPrefabs;
    [SerializeField] private RuntimeAnimatorController[] Enemyclips;
    private WinCondition condition;
    public int totalspawned = 0;
    [HideInInspector] private int i;
    [HideInInspector] public int spawningNumb;
    private Vector3 spawnerpos;
    private List<GameObject> spawnlsit = new List<GameObject>();      //store the instantiated gameobj

    private void Start()
    {
        restrict = GetComponent<ResPlayerMove>();

        if (EnemyPrefabs.Length != Enemyclips.Length)

        {
            Debug.Log("Enemy prefabs is not equal to Anime . Create A animation First");
        }
    }

    private void Awake()
    {
        totalspawned = 0;
        if (spawner == null)  //singleton to improve performance
        {
            spawner = this;
        }
        else
        {
            // Destroy(gameObject);
        }
        // Invoke("onCall", 0.5f);
    }
    public void onScreenReset()
    {
         totalspawned = 0;

    }

    private void Update()
    {
       // WinCondition.win.wavesshow.text = totalspawned.ToString() + "/" + WinCondition.win.controlwaves.ToString();          //update the text
        float restrictx = Mathf.Clamp(transform.position.x, restrict.updatedleftpos, restrict.updatedrightpos);  //restrict in x
        float restricty = Mathf.Clamp(transform.position.y, restrict.updateddownpos, restrict.updateduppos);        //restrict in y

        spawnerpos = new Vector3(restrictx, restricty, 0); //transform according to restriction
    }

    public void Runondestroy()
    {
        totalspawned++;             //variable to compare the waves we want to waves formed
       // WinCondition.win.wavesshow.text = totalspawned.ToString() + "/" + WinCondition.win.controlwaves.ToString();
        if (totalspawned < WinCondition.win.controlwaves)   //if formed waves is less than wanted waves then...
        {
            SpawnEnemies();
            // StopCoroutine(spawn());
            // StartCoroutine(spawn());
        }
        else
        {
            // Send the value when its greater.. //dont put in winconditon
            GameManagerEnd.endmanager.addCoinswhengameWon(WinCondition.win.coinstobeadded);        //if player wins then only save the coins
        }
    }

    private IEnumerator spawn()
    {
        yield return new WaitForSeconds(1f);
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        i = UnityEngine.Random.Range(0, EnemyPrefabs.Length);           //it randomly stores the index from enemyprefabs...using unityEngine random than system..

        GameObject enemy = Instantiate(EnemyPrefabs[spawningNumb], spawnerpos, Quaternion.identity);   //instantiating the enemy
        ApplyAnimationController(enemy, Enemyclips[spawningNumb]);
        spawnlsit.Add(enemy);            //add enemies in list
    }

    public void Oninstantiate()
    {
        foreach (GameObject obj in spawnlsit)
        {
            Destroy(obj);
        }
        spawnlsit.Clear();
    }

    private void ApplyAnimationController(GameObject enemy, RuntimeAnimatorController animationClip)       //RuntimeanimatorController changes animations in runtime or playing
    {
        if (animationClip != null)
        {
            Animator animator = enemy.GetComponent<Animator>();     //to get animator controller from instantiated gameObject
            if (animator == null)
            {
                animator = enemy.AddComponent<Animator>();          //if it doesnt exist, adding the animator component
            }
            animator.runtimeAnimatorController = animationClip;         //putting the indexed animationclip to the animator
        }
    }
}   