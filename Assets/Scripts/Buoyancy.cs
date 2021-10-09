using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// F = - (Object density - fluid density) (gravitational acceleration) (Displaced Volume)
public class Buoyancy : MonoBehaviour
{
    [Header("Physical Attributes")]
    [Tooltip("density of the object in kg/m^3")]
    public float density = .2f;
    [Tooltip("maximum cross sectional area in m^2")]
    public float crossSectionalArea = 3;
    [Tooltip("Curve representing change in area over height")]
    public AnimationCurve areaCurve;
    [Tooltip("height of the object in m")]
    public float height;

    [Header("Debug display only")]
    public float length = 5;
    public int sections = 5;

    //private void OnDrawGizmosSelected()
    //{
    //    Gizmos.matrix = transform.localToWorldMatrix;
    //    for(int i = 0; i < sections; i++)
    //    {
    //        Gizmos.dr
    //    }
    //}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}