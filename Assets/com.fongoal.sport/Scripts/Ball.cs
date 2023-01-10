using System;
using UnityEngine;

using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    private Vector2 InitScale { get; set; } = Vector3.one;
    private Vector2 TargetScale { get; set; } = Vector3.one * 0.5f;

    private Transform Center { get; set; }

    public float totalDistance = 4.0f;
    private const float force = 60;

    private static Rigidbody2D Rigidbody { get; set; }
    private static Vector2 Velocity { get; set; }

    private bool EndTravel { get; set; }
    public static Action OnTravelled { get; set; }
    public static Action OnPressed { get; set; }

    private void Awake()
    {
        Target.OnPressed += (target) =>
        {
            Rigidbody.WakeUp();
            OnPressed?.Invoke();

            Vector2 direction = target.transform.position - transform.position;

            Rigidbody.AddForce(direction.normalized * force, ForceMode2D.Impulse);
            Invoke(nameof(ResetMe), 2.5f);

            Target[] targets = FindObjectsOfType<Target>();
            foreach (Target t in targets)
            {
                t.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                t.gameObject.GetComponent<CircleCollider2D>().enabled = false;
            }

            FindObjectOfType<Mark>().GetComponent<SpriteRenderer>().enabled = false;
        };
    }

    private void OnDestroy()
    {
        Target.OnPressed = null;
    }

    private void Start()
    {
        Center = GameObject.Find("center").transform;
        Rigidbody = GetComponent<Rigidbody2D>();

        ResetMe();
    }

    private void Update()
    {
        float distanceToGoal = Mathf.Abs(Center.position.y - transform.position.y);
        if(distanceToGoal <= 1 && !EndTravel)
        {
            EndTravel = true;
            OnTravelled?.Invoke();
        }

        transform.localScale = Vector2.Lerp(TargetScale, InitScale, distanceToGoal / totalDistance);
    }

    private void ResetMe()
    {
        EndTravel = false;

        Rigidbody.velocity = Vector2.zero;
        Rigidbody.angularVelocity = 0;

        transform.position = new Vector2(-4.81f, -2.79f);
        Rigidbody.Sleep();

        Target[] targets = FindObjectsOfType<Target>();
        foreach (Target t in targets)
        {
            t.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            t.gameObject.GetComponent<CircleCollider2D>().enabled = true;
        }

        FindObjectOfType<Mark>().transform.position = new Vector2(0, 1000);
        FindObjectOfType<Mark>().GetComponent<SpriteRenderer>().enabled = true;
    }
}
