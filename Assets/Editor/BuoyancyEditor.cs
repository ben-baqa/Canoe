using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(Buoyancy))]
public class BuoyancyEditor : Editor
{
    private Buoyancy b;

    public void OnSceneGUI()
    {
        b = this.target as Buoyancy;
        Handles.color = new Color(.5f, .3f, .35f, .8f);
        Handles.matrix = b.transform.localToWorldMatrix;
        for(int i = 0; i <= b.sections; i++)
        {
            DrawCrossSection((b.height * i) / b.sections, b.length,
                b.crossSectionalArea * b.areaCurve.Evaluate(i / (float)b.sections));
        }
        GUIStyle style = new GUIStyle();
        style.alignment = TextAnchor.MiddleCenter;
        style.fontStyle = FontStyle.Bold;
        style.fontSize = 24;
        Handles.Label(Vector3.zero + b.transform.up * b.height,
            "Total Volume: " + b.Volume(), style);
        Handles.Slider(Vector3.zero, b.transform.up);
    }

    private void DrawCrossSection(float height, float length, float area)
    {
        float squish = area / (Mathf.PI * length * length);
        Matrix4x4 squishMatrix = Matrix4x4.Scale(new Vector3(squish, 1, 1));
        Handles.matrix = squishMatrix * b.transform.localToWorldMatrix;
        //Handles.matrix = Matrix4x4.TRS(b.transform.position, b.transform.rotation,
        //    new Vector3(squish, 1, 1));
        Handles.DrawWireDisc(Vector3.up * height, Vector3.up, length);
        //Handles.matrix *= squishMatrix.inverse;
    }
}
