using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// F = - (Object density - fluid density) (gravitational acceleration) (Displaced Volume)
public class Buoyancy : MonoBehaviour
{
    /// density of the object in kg/m^3
    public float density = .2f;
    /// maximum cross sectional area
    public float crossSectionalArea = 1;
    /// Curve representing change in area over height
    public AnimationCurve areaCurve;
    /// height of the object
    public float height

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
