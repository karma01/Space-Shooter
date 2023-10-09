using UnityEngine;

public class LoopBg : MonoBehaviour
{
    [SerializeField] private float speedofbg;
    private float bgheight;
    private Vector2 startingpsotion;

    private void Start()
    {
        startingpsotion = transform.position;
        bgheight = GetComponent<SpriteRenderer>().bounds.size.y;        // calculates height of the background image in y axis using bound(box) size
    }

    private void Update()
    {
        transform.Translate(Vector2.down * speedofbg * Time.deltaTime);  // transform the background image in -y axis
        float equivalencedistance = startingpsotion.y - bgheight;          // calculate and store the value of distance covered by image equivalence to its bound size or height

        if (transform.position.y < equivalencedistance)            // This indicates that the background image has completed its distance equivalent to its height and moving beyond the height

        {
            transform.position = startingpsotion;                               //reset the position to starting position
        }
    }
}