using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private PlayerHealth Playerhealth;
    private float maxHealth;
    [SerializeField] private DifficultyManager difficultyManager;

    private void Start()
    {
        Playerhealth = GetComponent<PlayerHealth>();
        difficultyManager = FindObjectOfType<DifficultyManager>();

        maxHealth = difficultyManager.Playerhealth;
    }

    public void onCall()
    {
        Playerhealth.health += 10;
    }
}