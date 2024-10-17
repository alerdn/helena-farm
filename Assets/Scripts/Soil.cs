using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public enum SoilState
{
    Empty,
    Planted,
    Growing,
    ReadyToHarvest
}

[Serializable]
public class SoilConfig
{
    public SoilState State;
    public Sprite Sprite;
}

public class Soil : MonoBehaviour
{
    [SerializeField] private List<SoilConfig> _soilConfigs;
    [SerializeField] private SoilState _currentState;
    private SpriteRenderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _currentState = SoilState.Empty;

        UpdateSprite(_currentState);
    }

    public void Interact()
    {
        switch (_currentState)
        {
            case SoilState.Empty:
                if (Player.Instance.SeedsSO.Value <= 0) return;

                Player.Instance.SeedsSO.Value--;

                _currentState++;
                UpdateSprite(_currentState);
                break;
            case SoilState.Planted:

                _currentState++;
                UpdateSprite(_currentState);
                break;
            case SoilState.Growing:

                _currentState++;
                UpdateSprite(_currentState);
                break;
            case SoilState.ReadyToHarvest:

                Player.Instance.CarrotsSO.Value += 3;
                Player.Instance.SeedsSO.Value += Random.Range(1, 3);

                _currentState = SoilState.Empty;
                UpdateSprite(_currentState);
                break;
        }
    }

    private void UpdateSprite(SoilState state)
    {
        SoilConfig config = _soilConfigs.Find(s => s.State == state);
        _renderer.sprite = config.Sprite;
    }
}
