using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_shooter : MonoBehaviour
{

    public GameObject Bullet_Prefab;
    public Transform BulletSpawn;
    public float Fire_Rate,Next_Fire,Speed_Fire;
    bool ShootButtonIsOnClick = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ShootButtonIsOnClick)
        {
            if(Next_Fire < 0 )
            {
              Shoot();
                Next_Fire = Fire_Rate;
            }
            Next_Fire -= Time.deltaTime * Speed_Fire;
        }
        
    }
    public void ShootButtonOnClick()
    {
        ShootButtonIsOnClick = true;
    }
    public void ShootButtonNotOnClick()
    {
        ShootButtonIsOnClick = false;
    }

    void Shoot()
    {
       Instantiate(Bullet_Prefab, new Vector2(BulletSpawn.position.x, BulletSpawn.position.y), BulletSpawn.transform.rotation);    
        
    }
}
