using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shape : MonoBehaviour
{
    public enum eType
    {
        Circle,
        Box
    }

    public abstract eType type { get; }
    public abstract float mass { get; }
    public abstract float size { get; set; }
    public float density { get; set; } = 1;

    SpriteRenderer spriteRenderer;
    public Color _Color { set => spriteRenderer.material.color = value; }

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
