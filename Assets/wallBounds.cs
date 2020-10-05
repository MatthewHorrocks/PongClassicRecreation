using UnityEngine;

public class wallBounds : Segment
{
    public override Vector2 getDirection(Vector2 direction)
    {
        var returnAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90;
        return GetDirectionFromAngle(returnAngle);
    }
}