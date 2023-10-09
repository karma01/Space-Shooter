using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] private int hitsbeforedestroy;
    public bool protectionenables = false;

    private void OnEnable()
    {
        hitsbeforedestroy = 4;
        protectionenables = true;
        Invoke("SetInactiveafterseconds", 7f);
    }

    private void damageShield()
    {
        hitsbeforedestroy -= 1;

        if (hitsbeforedestroy <= 0)
        {
            protectionenables = false;
            gameObject.SetActive(false);
        }
    }

    public void repair()
    {
        hitsbeforedestroy = 4;
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.tag == "ELaser")
        {
            damageShield();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            damageShield();
        }
    }

    private void SetInactiveafterseconds()
    {
        gameObject.SetActive(false);
        protectionenables = false;
    }
}