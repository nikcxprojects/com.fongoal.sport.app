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
    [SerializeField] GameObject progress;

    [Space(10)]
    [SerializeField] Button startBtn;
    [SerializeField] Button chooseCountryBtn;

    [Space(10)]
    [SerializeField] Image countryIcon;
    [SerializeField] Text countryName;

    [Space(10)]
    [SerializeField] GameObject canvasLandscape;

    private void Awake()
    {
        Loading.OnLoadingStarted += () =>
        {
            menu.SetActive(false);
            progress.SetActive(false);
            game.SetActive(false);

            chooseCountry.gameObject.SetActive(false);
        };

        Loading.OnLoadingFinished += () =>
        {
            menu.SetActive(true);
            progress.SetActive(true);
        };

        startBtn.onClick.AddListener(() =>
        {
            canvasLandscape.SetActive(false);

            menu.SetActive(false);
            game.SetActive(true);

            GameManager.Instance.StartGame();
        });

        chooseCountryBtn.onClick.AddListener(() =>
        {
            menu.SetActive(false);
            chooseCountry.gameObject.SetActive(true);
        });
    }

    private void Start()
    {
        loading.SetActive(true);
    }

    public void SetCountry(Sprite icon, string name, int id)
    {
        countryIcon.sprite = icon;
        countryName.text = name;

        chooseCountry.SetCountry(id);
    }

    public void OpenMenu()
    {
        canvasLandscape.SetActive(true);
        chooseCountry.gameObject.SetActive(false);

        game.SetActive(false);
        menu.SetActive(true);

        GameManager.Instance.EndGame();
    }
}
