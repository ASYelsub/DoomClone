using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTriggerManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player" || other.tag == "Player")
        {
            transform.parent.gameObject.GetComponent<EnemyManager>().state = 1;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Player" || other.tag == "Player")
        {
            transform.parent.gameObject.GetComponent<EnemyManager>().state = 0;
        }
    }
}
