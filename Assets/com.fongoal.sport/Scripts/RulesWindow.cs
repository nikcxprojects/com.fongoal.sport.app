using UnityEngine;
using UnityEngine.UI;

public class RulesWindow : MonoBehaviour
{
    [SerializeField] Button backBtn;
    [SerializeField] Button continueBtn;

    private void Start()
    {
        Button.ButtonClickedEvent eventBtn = new Button.ButtonClickedEvent();
        eventBtn.AddListener(() =>
        {
            gameObject.SetActive(false);
        });

        backBtn.onClick = continueBtn.onClick = eventBtn;
    }
}
