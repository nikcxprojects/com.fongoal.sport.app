using System;
using UnityEngine;

public class Target : MonoBehaviour
{
    public static Action<Target> OnPressed { get; set; }

    private void OnMouseDown()
    {
        OnPressed?.Invoke(this);
    }
}
