using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float force;

    [Space(10)]
    [SerializeField] Sprite middle;
    [SerializeField] Sprite left;
    [SerializeField] Sprite right;


    private static Rigidbody2D Rigidbody { get; set; }
    private SpriteRenderer Renderer { get; set; }


    private GameObject[] Targets { get; set; }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        Renderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        Ball.OnPressed += OnBallPressdEventHandler;
    }

    private void OnDestroy()
    {
        Ball.OnPressed -= OnBallPressdEventHandler;
    }

    private void OnBallPressdEventHandler(Transform target)
    {
        Transform rv = Random.Range(0, 100) > 70 ? target : Targets[Random.Range(0, Targets.Length)].transform;
        Vector2 direction = rv.transform.position - transform.position;

        if (rv != target)
        {
            //Instantiate(Resources.Load<Popup>("popup"), GameObject.Find("main canvas").transform);
        }

        Renderer.sprite = target.position.x > transform.position.x ? right : left;

        Rigidbody.AddForce(direction.normalized * force, ForceMode2D.Impulse);
        Invoke(nameof(ResetMe), 0.5f);
    }

    private void ResetMe()
    {
        Renderer.sprite = middle;

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

        Targets = GameObject.FindGameObjectsWithTag("target");
    }
}
