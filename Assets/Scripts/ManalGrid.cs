using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManalGrid : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Deactive all LevelSprites game objects in LevelManager after instantiating 
         gameObject.transform.GetChild(0).gameObject.SetActive(false);
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
        gameObject.transform.GetChild(2).gameObject.SetActive(false);
        gameObject.transform.GetChild(3).gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
