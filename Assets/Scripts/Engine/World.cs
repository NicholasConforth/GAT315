using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    public BoolData simulate;
    public BoolData collision;
    public BoolData wrap;
    public FloatData gravity;
    public FloatData fixedFPS;
    public FloatData gravitation;
    public StringData fpsText;
    public float fixedDeltaTime { get => 1.0f / fixedFPS.value; }


    public float timeAccumulator;
    float fps = 0;
    float fpsAverage = 0;
    float smoothing = .975f;
    Vector2 size;

    static World instance;
    static public World Instance { get { return instance; } }
    public Vector2 Gravity { get { return new Vector2(0, gravity.value); } }
    public List<Body> bodies { get; set; } = new List<Body>();

    private void Awake()
    {
        instance = this;
        size = Camera.main.ViewportToWorldPoint(Vector2.one);
    }

    void Update()
    {
        float dt = Time.deltaTime;
        fps = 1.0f / dt;
        fpsAverage = (fpsAverage * smoothing) + (fps * 1.0f - smoothing);
        fpsText.value = "FPS: " + fps.ToString("F1");
        timeAccumulator += dt;

        if (!simulate.value) return;

        GravitationalForce.ApplyForce(bodies, gravitation.value);

        while (timeAccumulator >= fixedDeltaTime)
        {
            bodies.ForEach(body => body.Step(fixedDeltaTime));
            bodies.ForEach(body => Integrator.ImplicitEuler(body, fixedDeltaTime));

            bodies.ForEach(body => body.shape._Color = Color.yellow);

            if(collision == true)
            {
                Collision.CreateContacts(bodies, out List<Contact> contacts);
                contacts.ForEach(contact => { contact.bodyA.shape._Color = Color.blue; contact.bodyB.shape._Color = Color.blue; } );
                ContactSolver.Resolve(contacts);
            }

            timeAccumulator -= fixedDeltaTime;
        }

        if (wrap) { bodies.ForEach(body => body.position = Utilities.Wrap(body.position, -size, size)); }

        bodies.ForEach(body => body.force = Vector2.zero);
        bodies.ForEach(body => body.acceleration = Vector2.zero);

    }
}
