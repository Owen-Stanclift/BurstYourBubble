using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoScript : MonoBehaviour
{
    [SerializeField] string videoFileName;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        PlayVideo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayVideo()
    {
        VideoPlayer player = GetComponent<VideoPlayer>();

        if(player)
        {
            string pathName = System.IO.Path.Combine(Application.streamingAssetsPath,videoFileName);
            player.url = pathName;
            gameObject.SetActive(true);
            player.Play();
        }
    }
}
