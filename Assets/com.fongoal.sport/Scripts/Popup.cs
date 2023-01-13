using UnityEngine;
using UnityEngine.UI;

public class Popup : MonoBehaviour
{
    private Image Image { get; set; }

    [SerializeField] Sprite lose;
    [SerializeField] Sprite success;
    [SerializeField] Sprite levelUp;

    private void Awake()
    {
        Image = GetComponent<Image>();
    }

    private void Start()
    {
        Destroy(gameObject, 1.0f);
    }

    public void Init(string status)
    {
        Image.sprite = status switch
        {
            "lose" => lose,
            "sucess" => success,
            "level up" => levelUp
        };

        Image.SetNativeSize();
    }
}
