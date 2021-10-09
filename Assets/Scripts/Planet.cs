using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : GravityWell
{
    /// fluid density in kg/m^3
    public float fluidDensity = 1;
    public float radius = 250;

    // Start is called before the first frame update
    void Start()
    {
        wells.Add(this);
        OnMove();
        radius *= transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
