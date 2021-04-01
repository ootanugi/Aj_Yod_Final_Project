using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager GameManager_Instant;
    public static GameManager GetInstant() {return GameManager_Instant; }//5555
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager_Instant == null)
        {
            GameManager_Instant = this;
        }
        else
        {
            Destroy(gameObject);
        }



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
