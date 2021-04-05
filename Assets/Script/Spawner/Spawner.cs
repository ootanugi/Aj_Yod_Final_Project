using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public Transform VisibleTargets ;
    public float Delay_Num;
    public GameObject Enemy;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Spaen_EnemyDelay", Delay_Num );
    }

    // Update is called once per frame
    void Update()
    {
        LookAtTarget();
    }
    IEnumerator Spaen_EnemyDelay(float Delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(Delay);
            Spaen_Enemy();

        }
    }
    void Spaen_Enemy()
    {
        Instantiate(Enemy,transform.position,transform.rotation);
    }

    void LookAtTarget()
    {        
            Vector2 Lookdir = new Vector2(VisibleTargets.position.x, VisibleTargets.position.y) - rb2D.position;//
            float angle = Mathf.Atan2(Lookdir.y, Lookdir.x) * Mathf.Rad2Deg - 90;                                     //// มองไปที่ Target
            rb2D.rotation = angle;                                                                                    //
    }
}
