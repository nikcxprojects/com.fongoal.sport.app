using UnityEngine;
using UnityEngine.UI;

public class SoundOption : MonoBehaviour
{
    private Image Image { get; set; }

    [SerializeField] Sprite on;
    [SerializeField] Sprite off;

    private void Start()
    {
        Image = GetComponent<Image>();

        GetComponent<Button>().onClick.AddListener(() =>
        {
            AudioListener.pause = !AudioListener.pause;
            Image.sprite = AudioListener.pause ? off : on;
        });
    }
}
