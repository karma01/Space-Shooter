using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using touched = UnityEngine.InputSystem.EnhancedTouch.Touch;       /// <summary>

///  using Enhanced touch system rather than touch as it is more advanced as there are two name spaces i.e Enhanced touch and touch
///  the type Touch is stored in touched for smooth handleing of input

/// </summary>
///
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 gettouchpos;
    private Vector3 dis;
    private ResPlayerMove Restrict;         //using another class

 

    private void Awake()
    {
        Restrict = GetComponent<ResPlayerMove>();   //get component of the class
    }

    private void Update()
    {
        CalculateTouchAndMove();

    }

    private void CalculateTouchAndMove()
    {
        bool isTouched = touched.fingers[0].isActive;  //check whether the first finger is active or is touched in screen
        if (isTouched)
        {
            Debug.Log("Touched");
            touched mytouch = touched.activeTouches[0]; //store the touch input
            gettouchpos = mytouch.screenPosition;      //store position that is touched
            gettouchpos = Camera.main.ScreenToWorldPoint(gettouchpos);  //to convert screen position to world positon with the help of camera

            if (mytouch.phase == TouchPhase.Began) //if touch input has just began then..
            {
                dis = gettouchpos - transform.position; /// <summary>
                                                        ///     calculate relative vector of touched position and player position for removing the error of player transporting to the touched position.
                                                        /// </summary>
            }
            else if (mytouch.phase == TouchPhase.Moved)
            {
                TransformResToTouch();                   //transform the position of player respect to touch when moved
            }
            if (mytouch.phase == TouchPhase.Stationary)      //transform the position of player respect to touch when stationary
            {
                TransformResToTouch();
            }

            ClammpedPosandMove();
        }
    }

    private void TransformResToTouch()
    {
        transform.position = new Vector2(gettouchpos.x - dis.x, gettouchpos.y - dis.y);
    }

    private void ClammpedPosandMove()
    {
        float restrictx = Mathf.Clamp(transform.position.x, Restrict.updatedleftpos, Restrict.updatedrightpos);  //restrict in x
        float restricty = Mathf.Clamp(transform.position.y, Restrict.updateddownpos, Restrict.updateduppos);        //restrict in y

        transform.position = new Vector3(restrictx, restricty, 0); //transform according to restriction
    }
    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
    }

    private void OnDisable()
    {
        EnhancedTouchSupport.Disable();
    }

}