using UnityEngine;
using UnityEngine.UI;

public class SoundSlider : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] AudioSource source;

    private void Start()
    {
        slider.onValueChanged.AddListener((value) =>
        {
            source.volume = value;
        });

        slider.value = 1;
        source.volume = 1;
    }
}
