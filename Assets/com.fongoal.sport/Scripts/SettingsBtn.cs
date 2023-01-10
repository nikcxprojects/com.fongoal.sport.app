using UnityEngine;
using UnityEngine.UI;

public class SettingsBtn : MonoBehaviour
{
    [SerializeField] GameObject root;

    private void Start()
    {
        root.SetActive(false);

        GetComponent<Button>().onClick.AddListener(() =>
        {
            root.SetActive(true);
        });

        root.GetComponent<Button>().onClick.AddListener(() =>
        {
            root.SetActive(false);
        });
    }
}
