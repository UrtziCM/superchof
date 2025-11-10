using UnityEngine;
using UnityEngine.UI;

public class HPCanvasHelper : MonoBehaviour
{
    [SerializeField]
    private Image _maskedThermometer;
    [SerializeField]
    private Image _fillThermometer;

    [SerializeField]
    private Gradient _hotColdGradient;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void SetProgress(float progress)
    {
        _maskedThermometer.fillAmount = progress;
        UpdateTemperatureColor(progress);
    }

    private void UpdateTemperatureColor(float gradientPointValue)
    {
        _fillThermometer.color = _hotColdGradient.Evaluate(gradientPointValue);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
