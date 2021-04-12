using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    public BoolData simulate;
    public FloatData gravity;
    public FloatData fixedFPS;
    public StringData fpsText;
    public float fixedDeltaTime { get => 1.0f / fixedFPS.value; }


    public float timeAccumulator;
    float fps = 0;
    float fpsAverage = 0;
    float smoothing = .975f;

    static World instance;
    static public World Instance { get { return instance; } }
    public Vector2 Gravity { get { return new Vector2(0, gravity.value); } }
    public List<Body> bodies { get; set; } = new List<Body>();

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        float dt = Time.deltaTime;
        fps = 1.0f / dt;
        fpsAverage = (fpsAverage * smoothing) + (fps * 1.0f - smoothing);
        fpsText.value = "FPS: " + fps.ToString("F1");
        timeAccumulator += dt;
        

        if(!simulate.value) return;

        while (timeAccumulator >= fixedDeltaTime)
        {
            bodies.ForEach(body => body.Step(dt));
            bodies.ForEach(body => Integrator.ImplicitEuler(body, dt));


            timeAccumulator -= fixedDeltaTime;
        }

        bodies.ForEach(body => body.force = Vector2.zero);
        bodies.ForEach(body => body.acceleration = Vector2.zero);

    }
}
