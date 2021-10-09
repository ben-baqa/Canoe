using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityWell : MonoBehaviour
{
    public static List<GravityWell> wells = new List<GravityWell>();

    public float mass;
    public Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        wells.Add(this);
        OnMove();
    }

    protected void OnMove(){
        pos = transform.position;
    }

    public static Vector3 GravityAtPoint(Vector3 pos, float mass = 1)
    {
        Vector3 force = Vector3.zero, diff = Vector3.zero;
        foreach(GravityWell well in wells)
        {
            diff = well.pos - pos;
            force += diff.normalized * (mass * well.mass / diff.sqrMagnitude);
        }
        return force;
    }
}
