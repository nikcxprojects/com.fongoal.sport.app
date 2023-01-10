using UnityEngine;

public class Mark : MonoBehaviour
{
    private void Awake()
    {
        Target.OnPressed += (target) =>
        {
            GameObject.Find("sfx sound").GetComponent<AudioSource>().Play();
            transform.position = target.transform.position;
        };
    }
}
