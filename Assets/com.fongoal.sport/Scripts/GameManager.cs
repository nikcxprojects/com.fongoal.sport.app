using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get => FindObjectOfType<GameManager>(); }

    public static bool IsPause { get; set; }

    private GameObject LevelPrefab { get; set; }
    private GameObject LevelRef { get; set; }

    private Transform Parent { get; set; }

    private void Start()
    {
        LevelPrefab = Resources.Load<GameObject>("level");
        Parent = GameObject.Find("Environment").transform;
    }

    public void StartGame()
    {
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
