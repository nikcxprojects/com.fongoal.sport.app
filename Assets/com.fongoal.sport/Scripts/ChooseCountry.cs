using UnityEngine.UI;
using UnityEngine;

public class ChooseCountry : MonoBehaviour
{
    private Sprite spriteRef;
    private (Sprite, Sprite) set;

    [SerializeField] Button backBtn;
    [SerializeField] Button confirm;
    [SerializeField] Button playBtn;

    [Space(10)]
    [SerializeField] Button[] countries;

    private void Start()
    {
        confirm.interactable = false;

        transform.GetChild(0).GetComponent<Button>().onClick.AddListener(ResetClick);

        backBtn.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });

        confirm.onClick.AddListener(() =>
        {
            if (!set.Item1)
            {
                ResetClick();
                set.Item1 = spriteRef;
            }
            else if (!set.Item2)
            {
                set.Item2 = spriteRef;
            }

            if (set.Item1 && set.Item2)
            {
                confirm.gameObject.SetActive(false);
                playBtn.gameObject.SetActive(true);
            }
        });

        playBtn.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
            Instantiate(Resources.Load<Versus>("versus"), GameObject.Find("main canvas").transform).Init(set);
        });

        foreach(Button b in countries)
        {
            b.onClick.AddListener(() =>
            {
                SetCountry(b.transform.GetSiblingIndex());
            });
        }
    }

    private void ResetClick()
    {
        for (int i = 0; i < countries.Length; i++)
        {
            countries[i].interactable = true;
        }

        confirm.interactable = false;
    }

    private void SetCountry(int id)
    {
        SFXManager.PlayOnClick();
        spriteRef = countries[id].GetComponent<Image>().sprite;

        for(int i = 0; i < countries.Length; i++)
        {
            countries[i].interactable = id == i;
        }

        confirm.interactable = true;
    }

    private void OnEnable()
    {
        spriteRef = null;
        set = (null, null);

        confirm.gameObject.SetActive(true);
        playBtn.gameObject.SetActive(false);

        ResetClick();
    }
}
