using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get => FindObjectOfType<GameManager>(); }

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
        LevelRef = Instantiate(LevelPrefab, Parent);
    }

    public void EndGame()
    {
        Destroy(LevelRef);
    }
}
