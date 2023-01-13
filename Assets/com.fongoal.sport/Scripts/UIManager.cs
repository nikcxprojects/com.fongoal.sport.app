using UnityEngine;
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

    [Space(10)]
    [SerializeField] Button chooseCountryBtn;
    [SerializeField] Button rulesBtn;
    [SerializeField] Button ratingBtn;

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

        GameManager.Instance.EndGame();
    }
}
