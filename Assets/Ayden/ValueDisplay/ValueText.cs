using System.Drawing;
using TMPro;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

[RequireComponent(typeof(TMP_Text))]
public class ValueText : MonoBehaviour, IDisplaysValue
{
    [SerializeField] string _prefixText = "";
    [SerializeField] string _suffixText = "";
    private TMP_Text _TMP;

    private void Awake()
    {
        _TMP = GetComponent<TMP_Text>();
        SetValue(0);
    }
    public void Setup(float value, float _1, float _2)
    {
        SetValue(value);
    }
    public void SetValue(float value)
    {
        _TMP.text = _prefixText + value.ToString() + _suffixText;
    }
}
