using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float force;
    private static Rigidbody2D Rigidbody { get; set; }
    private Target[] Targets { get; set; }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();

        Target.OnPressed += (target) =>
        {
            Target rv = Random.Range(0,100) > 70 ? target : Targets[Random.Range(0, Targets.Length)];
            Vector2 direction = rv.transform.position - transform.position;

            if(rv != target)
            {
                Progress.UpdateProgress();
                Instantiate(Resources.Load<Popup>("popup"), GameObject.Find("main canvas").transform);
            }

            Rigidbody.AddForce(direction.normalized * force, ForceMode2D.Impulse);
            Invoke(nameof(ResetMe), 2.5f);
        };
    }

    private void ResetMe()
    {
        Rigidbody.velocity = Vector2.zero;
        Rigidbody.angularVelocity = 0;

        transform.position = new Vector2(0, -0.52f);
        Rigidbody.Sleep();
    }

    private void Update()
    {
        if(Targets != null && Targets.Length > 0)
        {
            return;
        }

        Targets = FindObjectsOfType<Target>();
    }
}
