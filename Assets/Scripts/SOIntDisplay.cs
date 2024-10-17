using TMPro;
using UnityEngine;

public class SOIntDisplay : MonoBehaviour
{
    [SerializeField] private SOInt _so;
    [SerializeField] private TMP_Text _text;

    private void Start()
    {
        _so.OnUpdated += UpdateUI;
        UpdateUI(_so.Value);
    }

    private void UpdateUI(int value)
    {
        _text.text = value.ToString();
    }

}