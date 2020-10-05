using System;
using UnityEditor;
using UnityEngine;

public class Segment : MonoBehaviour
{
    [SerializeField]private float angle;
    public float speedIncrease;
    
    public virtual Vector2 getDirection(Vector2 direction)
    {
        var invertedX = -direction.x;
        var returnAngle = angle;
        
        if ( invertedX < 0 )
            returnAngle += 180;

        return GetDirectionFromAngle( returnAngle  );
    }
    
    protected static Vector2 GetDirectionFromAngle( float degrees )
    {
        return new Vector2( Mathf.Sin( Mathf.Deg2Rad * degrees ), Mathf.Cos( Mathf.Deg2Rad * degrees ) );
    }
}