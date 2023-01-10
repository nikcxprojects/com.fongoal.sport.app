using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using System;

public class Loading : MonoBehaviour
{
    [SerializeField] Button getStarted;

    public static Action OnLoadingStarted { get; set; }
    public static Action OnLoadingFinished { get; set; }

    private void Awake()
    {
        getStarted.onClick.AddListener(() =>
        {
            OnLoadingFinished?.Invoke();
            Destroy(gameObject);
        });
    }

    private IEnumerator Start()
    {
        OnLoadingStarted?.Invoke();
        getStarted.gameObject.SetActive(false);

        float loadingTime = 1.5f;
        yield return new WaitForSeconds(loadingTime);

        getStarted.gameObject.SetActive(true);
    }
}
