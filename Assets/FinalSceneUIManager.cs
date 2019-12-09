using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalSceneUIManager : MonoBehaviour
{
    public static FinalSceneUIManager instance;
    public Text[] uis; //0: kills 1: items 2: secret 3: time
    public int[] uisInts; //actual numbers that serve to the stats
    public bool canShow;
    public Animation anim;

    // Start is called before the first frame update
    void Start()
    {
        instance = this.GetComponent<FinalSceneUIManager>();
        anim = this.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        uis[0].text = uisInts[0].ToString() + "%";
        uis[1].text = uisInts[1].ToString() + "%";
        uis[2].text = uisInts[2].ToString() + "%";
        uis[3].text = uisInts[3].ToString() + "s";
        if (canShow && !anim.isPlaying)
        {
            anim.Play();
            canShow = false;
        }

    }
}
