using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleShape : Shape
{
    public float radius { get => transform.localScale.x * .5f; set => transform.localScale = Vector2.one * value; }
    public override eType type => eType.Circle;
    public override float mass => (Mathf.PI * radius * radius) * density;
}