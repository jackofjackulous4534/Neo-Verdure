using UnityEngine;
using UnityEngine.UI;

public class ValueBar : MonoBehaviour, IDisplaysValue
{
    //[SerializeField] Image barBase;
    [SerializeField] Image barDisplay;

    [SerializeField] float currentValue, maxValue, minValue;
    [SerializeField] bool hideIfMax = true;
    [SerializeField] bool hideIfMin = true;
    private void HideBar()
    {
        //barBase.enabled = false;
        barDisplay.enabled = false;
    }
    private void ShowBar()
    {
        //barBase.enabled = true;
        barDisplay.enabled = true;
    }
    public void Setup(float newCurrent, float newMax, float newMin = 0)
    {
        currentValue = newCurrent;
        maxValue = newMax;
        minValue = newMin;

        if (barDisplay == null)
        {
            Debug.LogError("VALUE BAR INCORRECTLY SET UP");
            return;
        }
        SetValue(currentValue);
    }

    public void SetValue(float newValue)
    {
        currentValue = Mathf.Clamp(newValue, minValue, maxValue);

        if (barDisplay == null)
        {
            Debug.LogError("VALUE BAR INCORRECTLY SET UP");
            return;
        }
        barDisplay.fillAmount = Mathf.Clamp((currentValue - minValue) / (maxValue - minValue), 0f, 1f);
        //barDisplay.rectTransform.sizeDelta = new Vector2(barBase.rectTransform.sizeDelta.x * (currentValue - minValue) / (maxValue - minValue), 0);
        if ((hideIfMax && currentValue == maxValue) || (hideIfMin && currentValue == minValue))
            HideBar();
        else
            ShowBar();
    }

    private void Awake()
    {
        SetValue(currentValue);
    }
    private void Update()
    {
        SetValue(currentValue);
    }
}
