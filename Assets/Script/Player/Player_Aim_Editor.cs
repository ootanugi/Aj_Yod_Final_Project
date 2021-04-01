using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor (typeof (Player_Aim))]
public class Player_Aim_Editor : Editor
{
    private void OnSceneGUI()
    {
        Player_Aim fow = (Player_Aim)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(fow.transform.position,Vector3.forward,Vector3.up,360,fow.Aim_Range);

        Handles.color = Color.red;
        foreach (Transform VisibleTarget in fow.VisibleTargets)
        {
            Handles.DrawLine(fow.transform.position,VisibleTarget.position);
        }
    }
}
