using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMain : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
