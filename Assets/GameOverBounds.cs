using UnityEngine;

public class GameOverBounds : Segment
{
    public override Vector2 getDirection(Vector2 direction)
    {
        BallControl.instance.reset();
        return new Vector3(Random.value > 0.5 ? 1 : -1, 0, 0);
    }
}