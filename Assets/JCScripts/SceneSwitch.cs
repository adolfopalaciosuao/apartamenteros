using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public void SceneSwitcher ()
    {

     UnityEngine.SceneManagement.SceneManager.LoadScene(1);

    }
}
