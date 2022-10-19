using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       // SceneManager.sceneLoaded += OnSceneLoaded;
    }

  

   

    public void LoadStartScene()
    {
        DontDestroyOnLoad(this);
        SceneManager.LoadSceneAsync(0);
    }

    public void LoadFirstLevel()
    {
        DontDestroyOnLoad(this);
        SceneManager.LoadSceneAsync(1);
    }

   
}
