using UnityEngine.UI;
using UnityEngine;

public class Progress : MonoBehaviour
{
    private static float Current { get; set; }
    private static Image FillAmount { get; set; }

    private void Awake()
    {
        FillAmount = transform.GetChild(0).GetComponent<Image>();
    }

    private void Start()
    {
        FillAmount.fillAmount = 0;
    }

    public static void UpdateProgress()
    {
        FillAmount.fillAmount = ++Current / 10.0f;
    }
}
