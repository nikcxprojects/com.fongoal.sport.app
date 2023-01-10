using UnityEngine.UI;
using UnityEngine;

public class ChooseCountry : MonoBehaviour
{
    [SerializeField] Button confirm;
    [SerializeField] Sprite ready;
    [SerializeField] Sprite hold;

    [Space(10)]
    [SerializeField] Button[] countries;

    private void Start()
    {
        confirm.GetComponent<Image>().sprite = hold;
        confirm.interactable = false;

        transform.GetChild(0).GetComponent<Button>().onClick.AddListener(() =>
        {
            for (int i = 0; i < countries.Length; i++)
            {
                countries[i].interactable = true;
            }

            confirm.GetComponent<Image>().sprite = hold;
            confirm.interactable = false;
        });

        confirm.onClick.AddListener(() =>
        {
            UIManager.Instance.OpenMenu();
        });
    }

    public void SetCountry(int id)
    {
        for(int i = 0; i < countries.Length; i++)
        {
            countries[i].interactable = id == i;
        }

        confirm.GetComponent<Image>().sprite = ready;
        confirm.interactable = true;
    }
}
