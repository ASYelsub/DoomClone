using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaceMovement : MonoBehaviour
{
    public Sprite lookLeft;
    public Sprite lookRight;
    public Image image;
    
    // Start is called before the first frame update
    void Start()
    {
        //Image image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    void changeRight()
    {

    }
    void changeLeft()
    {

    }
    IEnumerator BackAndForth()
    {
       
        yield return new WaitForSeconds(10f);
       
    }
}
