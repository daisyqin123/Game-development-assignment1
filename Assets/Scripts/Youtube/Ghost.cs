using UnityEngine;

[RequireComponent(typeof(Movement))]
public class Ghost : MonoBehaviour
{
    
    public int points = 200;

    public void ResetState()
    {
        gameObject.SetActive(true);
        

        
    }

}
