using UnityEngine;

public class MiniShipController : MonoBehaviour
{
    public EnemyScript Script;

    private void Update()
    {
        Script = FindObjectOfType<EnemyScript>();
        Vector3 targetPosition = Script.transform.position;

        // Calculate the rotation needed to look at the target position
        Vector3 lookDirection = targetPosition - transform.position;
        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, lookDirection);

        // Apply the rotation to the game object
        transform.rotation = rotation;
    }
}