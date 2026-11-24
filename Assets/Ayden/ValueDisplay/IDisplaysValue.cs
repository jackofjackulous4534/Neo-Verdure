using UnityEngine;

public interface IDisplaysValue
{
    void Setup(float newValue, float minValue, float maxValue);
    void SetValue(float newValue);
}
