using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
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

    public float waterFriction = .3f;

    [Header("Debug display only")]
    public float length = 5;
    public int sections = 5;

    private Rigidbody rb;
    private Gravity grav;

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
        rb = GetComponent<Rigidbody>();
        grav = GetComponent<Gravity>();
    }

    // Update is called once per frame
    void Update()
    {
        float area = Integrate(height) * crossSectionalArea * crossSectionalArea;
        //print(area);
        //print(area * area * Mathf.PI);
    }

    private void FixedUpdate()
    {
        float radius = 25f;
        float submergedVolume = 0;
        Vector3 normal = rb.position;
        if(normal.magnitude < radius)
        {
            submergedVolume = Volume(radius - normal.magnitude);
            rb.AddForce(-normal.normalized * submergedVolume *
                GravityWell.GravityAtPoint(rb.position).magnitude * (density - 1));
        }
        rb.velocity *= 1 - waterFriction * (submergedVolume / Volume(height));
    }

    /// <summary>
    /// calculate approximate integral of curve up to
    /// </summary>
    private float Integrate(float end, int steps = 10)
    {
        if (end > 1)
            end = 1;
        float step = end / steps;
        float res = (areaCurve.Evaluate(0) + areaCurve.Evaluate(end)) / 2;
        for (int i = 0; i < steps; i++)
        {
            res += areaCurve.Evaluate(i * step);
        }
        return step * res;
    }

    public float Volume(float depth = 1f)
    {
        return Integrate(depth / height) * crossSectionalArea;
    }
}