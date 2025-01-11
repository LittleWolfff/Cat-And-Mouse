using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(WayPoints))]
public class WaypointEditor : Editor
{
    WayPoints WayPoints => target as WayPoints;

    private void OnSceneGUI()
    {
        Handles.color = Color.red;
        for (int i = 0; i < WayPoints.Points.Length; i++)
        {
            EditorGUI.BeginChangeCheck();

            //�������Ƶ��λ��
            Vector3 currentWaypointPoint = WayPoints.Points[i] + WayPoints.CurrentPosition;
            Vector3 newWaypointPoint = Handles.FreeMoveHandle(currentWaypointPoint, 0.1f, new Vector3(0.2f, 0.2f, 0.2f), Handles.SphereHandleCap);

            //�������Ƶ��˳����ʾ
            GUIStyle textstyle = new GUIStyle();
            textstyle.fontSize = 15;
            textstyle.fontStyle = FontStyle.Bold;
            textstyle.normal.textColor = Color.yellow;
            Vector3 textALLigment = Vector3.down * 0.1f + Vector3.right * 0.1f;
            Handles.Label(WayPoints.CurrentPosition + WayPoints.Points[i]+textALLigment, $"{i+1}", textstyle);

            EditorGUI.EndChangeCheck();


            //������Ƶ㷢���仯����¼�仯���Ҹ��¿��Ƶ��λ��
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(WayPoints, "Change Waypoint Position");
                WayPoints.Points[i] = newWaypointPoint - WayPoints.CurrentPosition;
            }
        }
    }
}
