using UnityEngine;
using UnityEngine.UI;

public class Country : MonoBehaviour
{
    private Sprite Sprite { get; set; }

    private void Start()
    {
        Sprite = GetComponent<Image>().sprite;
        GetComponent<Button>().onClick.AddListener(() =>
        {
            //UIManager.Instance.SetCountry(sprite, _name, transform.GetSiblingIndex());
        });
    }
}
