using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Circle
{
    public float radius;
    public Vector2 center;

    public Circle (Vector2 center, float radius)
    {
        this.radius = radius;
        this.center = center;
    }

    public bool Contains(Circle circle)
    {
        Vector2 direction = center - circle.center;
        float sqrDistance = direction.sqrMagnitude;
        float sqrRadius = ((radius + circle.radius) * (radius + circle.radius));

        return (sqrDistance <= sqrRadius);
    }
}
