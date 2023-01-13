using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private int Count { get; set; }

    [SerializeField] Sprite normal;
    [SerializeField] Sprite empty;

    private void Awake()
    {
        Enemy.OnBallGaught += OnBallGaughtEventHandler;
    }

    private void OnBallGaughtEventHandler(bool IsCaught)
    {
        if (IsCaught)
        {
            bool IsHaveHealth = TakeDamage();
            if(!IsHaveHealth)
            {
                UIManager.Instance.StartGameOnClick();
            }
        }
    }

    public bool TakeDamage()
    {
        Count--;

        if (Count <= 0)
        {
            return false;
        }

        transform.GetChild(Count).GetComponent<Image>().sprite = empty;
        return true;
    }

    public void ResetMe()
    {
        Count = transform.childCount;
        for (int i = transform.childCount - 1; i > 0; i--)
        {
            transform.GetChild(i).GetComponent<Image>().sprite = normal;
        }
    }
}
