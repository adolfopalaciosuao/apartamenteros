using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//

using UnityEngine.Video;

public class CerrarVideo : MonoBehaviour
{

    public VideoPlayer video;
    // Start is called before the first frame update

    void Awake()

    {
        video = GetComponent<VideoPlayer>();
        video.Play();
        video.loopPointReached += CheckOver;

    }

 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    
    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene(6);
    }
}
