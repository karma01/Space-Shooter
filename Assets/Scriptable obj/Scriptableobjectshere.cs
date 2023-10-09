using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObj/Powers", fileName = "Spawner")]        //make it a asset so we can play with it in project menu
public class Scriptableobjectshere : ScriptableObject
{
    public GameObject[] powers;
    public int spawnthreshold;

    public void spawnPowers(Vector3 spawnPos)
    {
        int randomness = Random.Range(0, 100);          //randomize a number between 0 and 101
        if (randomness > spawnthreshold)                  // if random number is greater than the given number in thereshold then..
        {
            int randompowerup = Random.Range(0, powers.Length); //store the number of powerups
            Instantiate(powers[randompowerup], spawnPos, Quaternion.identity);          //instanitate the powers
        }
    }
}