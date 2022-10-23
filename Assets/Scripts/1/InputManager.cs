using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {
    [SerializeField] private GameObject item;
    private Tweener tweener;
    private List<GameObject> itemList;


	// Use this for initialization
	void Start () {
        tweener = GetComponent<Tweener>();
        itemList = new List<GameObject>();
        itemList.Add(item);
	}
	
	// Update is called once per frame
	void Update () {
       //
     
        
        if (Input.GetKeyDown("a"))
            LoopAddTween("a");
        if (Input.GetKeyDown("d"))
            LoopAddTween("d");
        if (Input.GetKeyDown("s"))
            LoopAddTween("s");
        if (Input.GetKeyDown("w"))
            LoopAddTween("w");

        

       
    }


    private void LoopAddTween(string key)
    {
        bool added = false;
        foreach (GameObject item in itemList)
        {
            if (key == "a")
                added = tweener.AddTween(item.transform, item.transform.position, new Vector2(-1.0f, 0.0f), 0.5f);
			if (key == "d")
				added = tweener.AddTween(item.transform, item.transform.position, new Vector2(1.0f, 0.0f), 0.5f);
			if (key == "s")
				added = tweener.AddTween(item.transform, item.transform.position, new Vector2(0.0f, -1f), 0.5f);
			if (key == "w")
				added = tweener.AddTween(item.transform, item.transform.position, new Vector2(0.0f, 1f), 0.5f);

            if (added)
                break;
        }
    }



   
}
