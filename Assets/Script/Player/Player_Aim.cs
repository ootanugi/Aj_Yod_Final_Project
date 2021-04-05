using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Experimental.Rendering.Universal;


public class Player_Aim : MonoBehaviour
{
    public float Aim_Range;
    public Light2D light2D;
    public CinemachineVirtualCamera virtualCamera1;
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
        if(light2D.pointLightOuterRadius != Aim_Range)
        {
            Light_Radius();
        }
    }

    public void Light_Radius()
    {
        if (light2D.pointLightOuterRadius > Aim_Range)
        {
            light2D.pointLightOuterRadius-=.01f;
          
        }
        else if(light2D.pointLightOuterRadius < Aim_Range)
        {
            light2D.pointLightOuterRadius +=.01f;
        }
        if(virtualCamera1.m_Lens.OrthographicSize < Aim_Range+1)
        {
          virtualCamera1.m_Lens.OrthographicSize += .03f;
        }
        else if(virtualCamera1.m_Lens.OrthographicSize > Aim_Range + 1)
        {
            virtualCamera1.m_Lens.OrthographicSize -= .03f;
        }
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
