using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get => FindObjectOfType<UIManager>(); }

    [SerializeField] GameObject loading;
    [SerializeField] GameObject menu;
    [SerializeField] GameObject game;
    [SerializeField] GameObject rules;
    [SerializeField] GameObject rating;
    [SerializeField] GameObject country;
    [SerializeField] GameObject pause;

    [Space(10)]
    [SerializeField] Text scoreText;

    [Space(10)]
    [SerializeField] Button chooseCountryBtn;
    [SerializeField] Button rulesBtn;
    [SerializeField] Button ratingBtn;

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
        if (IsCaught)
        {
            scoreText.text = $"{GameManager.score}";
        }
    }

    private void Awake()
    {
        Loading.OnLoadingStarted += () =>
        {
            menu.SetActive(false);
            game.SetActive(false);
            rules.SetActive(false);
            rating.SetActive(false);
            country.SetActive(false);
        };

        Loading.OnLoadingFinished += () =>
        {
            menu.SetActive(true);
        };

        chooseCountryBtn.onClick.AddListener(() =>
        {
            country.SetActive(true);
        });

        rulesBtn.onClick.AddListener(() =>
        {
            rules.SetActive(true);
        });

        ratingBtn.onClick.AddListener(() =>
        {
            rating.SetActive(true);
        });
    }

    private void Start()
    {
        loading.SetActive(true);
    }

    public void OpenMenu()
    {
        game.SetActive(false);
        menu.SetActive(true);
        pause.SetActive(false);

        GameManager.Instance.EndGame();
    }

    public void StartGameOnClick()
    {
        menu.SetActive(false);
        game.SetActive(true);
        pause.SetActive(false);

        GameManager.Instance.StartGame();
    }

    public void IsPauseGame(bool IsPause)
    {
        GameManager.IsPause = IsPause;

        Time.timeScale = IsPause ? 0 : 1;
        pause.SetActive(IsPause);
    }
}
