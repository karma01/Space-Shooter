using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [HideInInspector] public float health;
    private float maxhelth;
    private float damage;
    private DifficultyManager difficultyManager;
    [SerializeField] public Image healthfill;
    [SerializeField] private Shield shield;
    [SerializeField] private ParticleSystem particles;
    [SerializeField] private AudioSource Shoot;

    // [SerializeField] private ParticleSystem laser;
    private ResPlayerMove restriction;

    private float restrictx;
    private float restricty;

    private void Awake()
    {
        // restriction = GetComponent<ResPlayerMove>();
        difficultyManager = FindObjectOfType<DifficultyManager>();
    }

    private void Start()
    {
        //restrictx = Mathf.Clamp(transform.position.x, restriction.updatedleftpos, restriction.updatedrightpos);
        // restricty = Mathf.Clamp(transform.position.y, restriction.updateddownpos, restriction.updateddownpos);

        health = difficultyManager.Playerhealth;
        damage = difficultyManager.damagecausedbyenemylaser;
        maxhelth = difficultyManager.Playerhealth;
        healthfill.fillAmount = health / maxhelth;          //As the value of fill amount ranges between 1 and 0, at start it is 1 i.e max
        shield = FindObjectOfType<Shield>();
        GameManagerEnd.endmanager.loose = false;        //need to declare it because it causes error in reloading scenes
    }

    private void OnParticleCollision(GameObject other)
    {
        if (shield.protectionenables)
            return;
        if (other.gameObject.tag == "ELaser" || Input.GetKey(KeyCode.H))
        {
            health -= damage;

            healthfill.fillAmount = health / maxhelth;

            if (health <= 0)
            {
                Destroy();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (shield.protectionenables)
            return;
        if (collision.gameObject.tag == "Enemy")
        {
            Invoke("Destroy", 0.5f);
        }
    }

    private void Destroy()
    {
        // if(GameManagerEnd.endmanager.loose ==false) { return; }
        GameManagerEnd.endmanager.loose = true;
        GameManagerEnd.endmanager.startresolvegameon();// the bool of endmanager is set to ture
        Debug.Log("You lost");
        //the function is loaded
        Destroy(gameObject);
    }

    private void Update()
    {
        if (particles.isPlaying)
        {
            if (Shoot.isPlaying == false)
            {
                Shoot.Play();
            }
        }
    }
    public void Oncall()
    {
        
      if(maxhelth ==health) return;
      else if (maxhelth >health)
        {
            health += 10;
            healthfill.fillAmount += health /10;
        }


    }
}