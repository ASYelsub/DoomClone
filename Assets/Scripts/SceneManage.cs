using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;



public class SceneManage : MonoBehaviour
{
  
    public void StartThisShit(int SceneNumber)
    {
        SceneManager.LoadScene(SceneNumber);
    }
    
}
