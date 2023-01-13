using UnityEngine.UI;
using UnityEngine;

public class ChooseCountry : MonoBehaviour
{
    [SerializeField] Button backBtn;
    [SerializeField] Button confirm;

    [Space(10)]
    [SerializeField] Button[] countries;

    private void Start()
    {
        confirm.interactable = false;

        transform.GetChild(0).GetComponent<Button>().onClick.AddListener(() =>
        {
            for (int i = 0; i < countries.Length; i++)
            {
                countries[i].interactable = true;
            }

            confirm.interactable = false;
        });

        backBtn.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });

        confirm.onClick.AddListener(() =>
        {
            //UIManager.Instance.OpenMenu();
        });

        foreach(Button b in countries)
        {
            b.onClick.AddListener(() =>
            {
                SetCountry(b.transform.GetSiblingIndex());
            });
        }
    }

    private void SetCountry(int id)
    {
        for(int i = 0; i < countries.Length; i++)
        {
            countries[i].interactable = id == i;
        }

        confirm.interactable = true;
    }
}
