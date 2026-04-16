using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(FieldOfView))]
public class FieldOfViewEditor : Editor
{
    // followed tutorial from Comp-3 Interactive [https://www.youtube.com/watch?v=j1-OyLo77ss]

    void OnSceneGUI()
    {

        FieldOfView fov = (FieldOfView)target;
        Handles.color = Color.white;
        
        // draw radius
        Handles.DrawWireArc(fov.transform.position, Vector3.up, Vector3.forward, 360, fov.viewRadius);

        Vector3 viewAngle01 = DirectionFromAngle(fov.transform.eulerAngles.y, -fov.viewAngle / 2);
        Vector3 viewAngle02 = DirectionFromAngle(fov.transform.eulerAngles.y, +fov.viewAngle / 2);

        Handles.color = Color.yellow;

        //draw angle to radius boundary
        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngle01 * fov.viewRadius);
        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngle02 * fov.viewRadius);

        //draw green line to player if seen
        if(fov.playerInSight)
        {
            Handles.color = Color.green;
            Handles.DrawLine(fov.transform.position, fov.playerReference.transform.position);
        }
    }

    private Vector3 DirectionFromAngle(float eulerY, float angleInDegrees)
    {
        angleInDegrees += eulerY;

        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
