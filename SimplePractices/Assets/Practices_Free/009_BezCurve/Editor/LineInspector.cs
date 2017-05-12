using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Line))]
public class LineInspector : Editor {

    private void OnSceneGUI()
    {
        Line line = target as Line;

        //convert the point from the local position to world positon
        Transform handleTransform = line.transform;
        Quaternion handleRotation = Tools.pivotRotation == PivotRotation.Local ? handleTransform.rotation : Quaternion.identity;
        Vector3 p0 = handleTransform.TransformPoint(line.p0);
        Vector3 p1 = handleTransform.TransformPoint(line.p1);

        Handles.color = Color.white;
        Handles.DrawLine(p0, p1);
        Handles.DoPositionHandle(p0, handleRotation);
        Handles.DoPositionHandle(p1, handleRotation);

        EditorGUI.BeginChangeCheck();
        //block of code with controls that may set GUI.changed to true
        p0 = Handles.DoPositionHandle(p0, handleRotation);
        if (EditorGUI.EndChangeCheck())
        {
            //code to execute if GUI.changed,was set to true inside the block of code above
            Undo.RecordObject(line, "move point");
            EditorUtility.SetDirty(line);
            line.p0 = handleTransform.InverseTransformPoint(p0); 
        }

        EditorGUI.BeginChangeCheck();
         p1 = Handles.DoPositionHandle(p1, handleRotation);
        if(EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(line, "move point");
            EditorUtility.SetDirty(line);
            line.p1 = handleTransform.InverseTransformPoint(p1);
        }


    }

    
       

}
