using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private DifficultyManager difficultyManager;
    private EnemySpawner spawner;

    private float damage;
    [SerializeField] private float health;
    [SerializeField] private int coinsTobeadded;
    [SerializeField] private Scriptableobjectshere scriptobj;
    public Vector3 zAxis;

    private void Awake()
    {
        difficultyManager = FindObjectOfType<DifficultyManager>();
    }

    private void OnParticleCollision(GameObject other)
    {
        switch (other.gameObject.tag)           //using switch to make it easier to add new lasers
        {
            case "Default":
                damage = difficultyManager.defaultdamageEnemy;
                Debug.Log(damage);
                break;

            case "Line":
                damage = difficultyManager.Linelaserdamageenemy;

                break;

            case "ThunderLaser":
                damage = difficultyManager.thunderlaserdamageenemy;
                break;
        }

        health -= damage;
        Debug.Log(health);
        if (health < 0)
        {
            if (scriptobj != null)           ///to avoid object not set.... if it happens
            {
                scriptobj.spawnPowers(transform.position);      //pass the position to the script
            }
            onDead();
            Destroy(gameObject);
        }
    }

    private void onDead()
    {
        GameManagerEnd.endmanager.Addcoins(coinsTobeadded);
        GameManagerEnd.endmanager.addCoinswhengameWon(coinsTobeadded);
    }
}