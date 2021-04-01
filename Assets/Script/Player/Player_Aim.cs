using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Aim : MonoBehaviour
{
    public float Aim_Range;
    public Rigidbody2D rb2D;
    public Joystick joystick;
    public LayerMask TargetMask,ObstacleMask;
   

    public List<Transform> VisibleTargets = new List<Transform>();
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("FindTargetDelay",.2f);
    }
    // Update is called once per frame
    void Update()
    {
        LookAtTarget();
        
    }
    IEnumerator FindTargetDelay(float Delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(Delay);
            FindVisibleTargets();

        }
    }
   
    void LookAtTarget()
    {
        if (VisibleTargets.Count > 0)
        {
          Vector2 Lookdir = new Vector2(VisibleTargets[0].position.x, VisibleTargets[0].position.y) - rb2D.position;//
          float angle = Mathf.Atan2(Lookdir.y, Lookdir.x) * Mathf.Rad2Deg - 90;                                     //// มองไปที่ Target
          rb2D.rotation = angle;                                                                                    //
        }
        else
        {
            float angle = (Mathf.Atan2( joystick.Direction.x,joystick.Direction.y) * Mathf.Rad2Deg *-1);// 
            rb2D.rotation = angle;                                                                      // มองตาม JoyStick
            //Debug.LogError("angle = " + angle);
        }
    }
   
    void FindVisibleTargets()
    {
        VisibleTargets.Clear();
        //Collider[] targeInAim_Range = Physics.OverlapSphere(transform.position, Aim_Range, TargetMask);
       Collider2D[] targeInAim_Range = Physics2D.OverlapCircleAll(transform.position, Aim_Range, TargetMask);

        for (int i = 0; i < targeInAim_Range.Length; i++)
        {
            Transform target = targeInAim_Range[i].transform;
    
            Vector2 dirToTarget = (target.position - transform.position).normalized;
                float DstToTarget = Vector2.Distance(transform.position, target.position);
            if(!Physics.Raycast(transform.position, dirToTarget,DstToTarget, ObstacleMask))
            {
               VisibleTargets.Add(target);  
            }
        }
    }
    public Vector2 DirFromAngle(float AngleInDegrees)
    {
        return new Vector2(Mathf.Sin(AngleInDegrees*Mathf.Deg2Rad),Mathf.Cos(AngleInDegrees * Mathf.Deg2Rad));
    }
}
