using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrosshairPanel : MonoBehaviour
{
    [SerializeField]
    private SettingsPanel settingsPanel;
    [SerializeField]
    private Crosshair crosshair;

    // --- SLIDERS ---
    [SerializeField]
    private Slider thicknessSlider;
    [SerializeField]
    private Slider lengthSlider;
    [SerializeField]
    private Slider centerGapSlider;
    [SerializeField]
    private Slider opacitySlider;

    void Start()
    {
        thicknessSlider.value = crosshair.thickness;
        lengthSlider.value = crosshair.length;
        centerGapSlider.value = crosshair.centerGap;
        opacitySlider.value = crosshair.opacity;
    }

    private void OnEnable()
    {
        crosshair.Show();
    }

    private void OnDisable()
    {
        crosshair.Hide();
    }

    public void OnThicknessValueChanged(Slider slider)
    {
        print("thickness : " + slider.value);
        crosshair.SetThickness(slider.value);
    }

    public void OnLengthValueChanged(Slider slider)
    {
        print("length : " + slider.value);
        crosshair.SetLength(slider.value);
    }

    public void OnCenterGapValueChanged(Slider slider)
    {
        print("center gap : " + slider.value);
        crosshair.SetCenterGap(slider.value);
    }

    public void OnOpacityValueChanged(Slider slider)
    {
        print("opacity : " + slider.value);
        crosshair.SetOpacity(slider.value);
    }

    public void OnColorBtnClick(string color)
    {
        crosshair.SetColor(color);
    }

    public void OnBackBtnClick()
    {
        settingsPanel.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
