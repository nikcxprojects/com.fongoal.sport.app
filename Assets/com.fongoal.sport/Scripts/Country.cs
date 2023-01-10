using UnityEngine;
using UnityEngine.UI;

public class Country : MonoBehaviour
{
    [SerializeField] string _name;
    [SerializeField] Sprite sprite;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            UIManager.Instance.SetCountry(sprite, _name, transform.GetSiblingIndex());
        });
    }
}
