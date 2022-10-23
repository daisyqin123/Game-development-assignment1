using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class NodeController : MonoBehaviour
{
    public bool canMoveLeft = false;
    public bool canMoveRight = false;
    public bool canMoveUp = false;
    public bool canMoveDown = false;

    public GameObject nodeLeft;
    public GameObject nodeRighr;
    public GameObject nodeUp;
    public GameObject nodeDown;
    // Start is called before the first frame update
    void Start()
    {
      //  RaycastHit2D[] hitsDown;
      //  hitsDown = Physics2D.RaycastAll(transform.position, -vector2.up);

      ///  for(int i = 0; i < hitsDown.Length; i++)
       // {
        //    float distance = Mathf.Abs(hitsDown[i].point.y - CryptoAPITransform.position.y);
         //   if(distance < 0.4f)
         //   {
        //        canMoveDown = true;
        //    }
       // }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
