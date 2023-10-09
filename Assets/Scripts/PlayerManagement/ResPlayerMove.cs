using UnityEngine;

public class ResPlayerMove : MonoBehaviour
{
    private Vector3 leftscreenpos;
    private Vector3 rightscreenpos;
    private Vector3 upscreenpos;
    private Vector3 downscreenpos;

    public float updatedleftpos;
    public float updatedrightpos;
    public float updateduppos;
    public float updateddownpos;
    private void Awake()
    {
      
    }
    private void Start()
    {
        leftscreenpos = new Vector2(0.15f, 0);/// <summary> These are all viewport co -ordinates as they deal in (0,0) bottom left and (1,1) in top right of every smart phones.
        rightscreenpos = new Vector2(0.85f, 0);
        upscreenpos = new Vector2(0, 0.85f);
        downscreenpos = new Vector2(0, 0.15f);   /// so, to have restrictions of player movement in every phone. This needs to be done
                                                 /// </summary>

        updatedleftpos = Camera.main.ViewportToWorldPoint(leftscreenpos).x;   //we can only move around in a world space so, we need to calculate from viewport to world point
        updatedrightpos = Camera.main.ViewportToWorldPoint(rightscreenpos).x;
        updateduppos = Camera.main.ViewportToWorldPoint(upscreenpos).y;
        updateddownpos = Camera.main.ViewportToWorldPoint(downscreenpos).y;
        EnemySpawner.spawner.totalspawned = 0;

    }
}