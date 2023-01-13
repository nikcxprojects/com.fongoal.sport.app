using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get => FindObjectOfType<GameManager>(); }

    public static int score = 0;

    public static bool IsPause { get; set; }

    private GameObject LevelPrefab { get; set; }
    private GameObject LevelRef { get; set; }

    private Transform Parent { get; set; }

    private void Start()
    {
        LevelPrefab = Resources.Load<GameObject>("level");
        Parent = GameObject.Find("Environment").transform;
    }

    private void OnEnable()
    {
        Enemy.OnBallÑaught += OnBallÑaughtEventHandler;
    }

    private void OnDestroy()
    {
        Enemy.OnBallÑaught -= OnBallÑaughtEventHandler;
    }

    private void OnBallÑaughtEventHandler(bool IsCaught)
    {
        if(IsCaught)
        {
            score++;
        }
    }

    public void StartGame()
    {
        score = 0;

        Time.timeScale = 1;
        IsPause = false;

        if (LevelRef)
        {
            Destroy(LevelRef);
        }

        LevelRef = Instantiate(LevelPrefab, Parent);
    }

    public void EndGame()
    {
        Destroy(LevelRef);
    }
}
