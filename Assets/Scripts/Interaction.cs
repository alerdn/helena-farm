using System;
using UnityEngine;
using UnityEngine.Events;

public class Interaction : MonoBehaviour
{
    [SerializeField] private UnityEvent _onInteract;
    private SpriteRenderer _renderer;

    private void Awake()
    {
        _renderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public void Interact()
    {
        _onInteract.Invoke();
    }

    public void SetHighlight(bool active)
    {
        Color color = Color.white;
        if (active)
        {
            color = new Color(.87f, .81f, .51f);
        }
        else
        {
            color = Color.white;
        }

        _renderer.material.SetColor("_Color", color);
    }
}