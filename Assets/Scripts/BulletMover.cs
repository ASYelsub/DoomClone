using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 15);
    }

    private void OnTriggerEnter(Collider other)
    {
        print(other.name);
        if(other.name.Contains("surface") || other.name.Contains("Concrete") || other.name.Contains("Cube"))
        Destroy(gameObject);
    }
}
