using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class ValueText : MonoBehaviour
{
    [SerializeField] string _prefixText = "";
    //[SerializeField] float value = 0;
    [SerializeField] string _suffixText = "";
    private TMP_Text _TMP;

    private void Awake()
    {
        _TMP = GetComponent<TMP_Text>();
        UpdateText(0);
    }

    public void UpdateText(float value, Color color = default)
    {
        if (color == default)
            color = Color.white;
        _TMP.text = _prefixText + value.ToString() + _suffixText;
        _TMP.color = color;
    }
}
