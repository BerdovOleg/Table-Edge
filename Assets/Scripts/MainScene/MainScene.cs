using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadOne()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadSecond()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadThird()
    {
        SceneManager.LoadScene(3);
    }
    public void LoadArenaOne()
    {
        SceneManager.LoadScene(4);
    }


}
