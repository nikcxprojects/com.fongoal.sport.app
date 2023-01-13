using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    private Vector2 InitScale { get; set; } = Vector3.one * 0.08922569f;
    private Vector2 TargetScale { get; set; } = Vector3.one * 0.05888896f;

    private Transform Center { get; set; }

    public float totalDistance = 4.0f;
    private const float force = 60;

    private static Rigidbody2D Rigidbody { get; set; }
    private static Vector2 Velocity { get; set; }

    private bool EndTravel { get; set; }
    public static Action OnTravelled { get; set; }

    private void OnMouseDown()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("target");
        Rigidbody.WakeUp();

        Transform target = targets[Random.Range(0, targets.Length)].transform;
        Vector2 direction = target.transform.position - transform.position;

        Rigidbody.AddForce(direction.normalized * force, ForceMode2D.Impulse);
        Invoke(nameof(ResetMe), 2.5f);
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

        transform.position = new Vector2(-1.4f, -3.68f);
        Rigidbody.Sleep();
    }
}
