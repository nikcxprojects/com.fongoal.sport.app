using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get => FindObjectOfType<UIManager>(); }

    [SerializeField] GameObject loading;
    [SerializeField] GameObject menu;
    [SerializeField] GameObject game;
    [SerializeField] ChooseCountry chooseCountry;

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

            chooseCountry.gameObject.SetActive(false);
        };

        Loading.OnLoadingFinished += () =>
        {
            menu.SetActive(true);
        };

        chooseCountryBtn.onClick.AddListener(() =>
        {
            menu.SetActive(false);
            chooseCountry.gameObject.SetActive(true);
        });

        rulesBtn.onClick.AddListener(() =>
        {
            
        });

        ratingBtn.onClick.AddListener(() =>
        {

        });
    }

    private void Start()
    {
        loading.SetActive(true);
    }

    public void OpenMenu()
    {
        chooseCountry.gameObject.SetActive(false);

        game.SetActive(false);
        menu.SetActive(true);

        GameManager.Instance.EndGame();
    }
}
