using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaceMovement : MonoBehaviour
{
    public Sprite lookLeft;
    public Sprite lookRight;
    public Image image;
    public bool lookingRight;
    // Start is called before the first frame update
    void Start()
    {
        //Image image = GetComponent<Image>();
        StartCoroutine("BackAndForth");
    }

    // Update is called once per frame

    void changeRight()
    {
        lookingRight = true;
        image.sprite = lookRight;
        StartCoroutine(BackAndForth());
    }
    void changeLeft()
    {
        lookingRight = false;
        image.sprite = lookLeft;
        StartCoroutine(BackAndForth());
    }
    IEnumerator BackAndForth()
    {
        Debug.Log("Called");
        yield return new WaitForSeconds(5f);
        if (lookingRight == false)
        {
            Debug.Log("Change to left");
            changeRight();
        }
        else if(lookingRight == true)
        {
            Debug.Log("change to right");
            changeLeft();
        }
    }
}
