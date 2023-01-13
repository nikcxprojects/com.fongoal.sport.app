using UnityEngine;
using UnityEngine.UI;

public class Versus : MonoBehaviour
{
    [SerializeField] Image leftTeam;
    [SerializeField] Image rightTeam;

    private void OnEnable()
    {
        Destroy(gameObject, 1.5f);
        GameManager.Instance.StartGame();
    }

    public void Init((Sprite, Sprite) set)
    {
        leftTeam.sprite = set.Item1;
        rightTeam.sprite = set.Item2;
    }
}
