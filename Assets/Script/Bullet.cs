using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed,setTime;
    float Bullet_LifeTime;
    public Rigidbody2D rb2D;
    // Start is called before the first frame update
    void Start()
    {
        Bullet_LifeTime = setTime;
    }

    // Update is called once per frame
    void Update()
    {
        
        rb2D.AddForce(transform.up * speed * Time.deltaTime);
        Bullet_LifeTime -= Time.deltaTime * setTime;
        if(Bullet_LifeTime <=0)
        {
            Destroy(gameObject);
            Bullet_LifeTime = setTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
    }
}
