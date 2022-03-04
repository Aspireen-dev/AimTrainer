using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetPanel : MonoBehaviour
{
    [SerializeField]
    private SettingsPanel settingsPanel;
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Transform areaRange;

    [SerializeField]
    private Material targetMaterial;

    // --- SLIDERS ---
    [SerializeField]
    private Slider areaRangeSlider;
    [SerializeField]
    private Slider minDistanceSlider;
    [SerializeField]
    private Slider maxDistanceSlider;

    private void OnEnable()
    {
        target.gameObject.SetActive(true);
        areaRangeSlider.value = PlayerPrefs.GetFloat("areaRange", 5);
        minDistanceSlider.value = PlayerPrefs.GetFloat("minDistance", 50);
        maxDistanceSlider.value = PlayerPrefs.GetFloat("maxDistance", 50);
    }

    private void OnDisable()
    {
        if (target)
            target.gameObject.SetActive(false);
    }

    public void OnAreaRangeValueChanged(Slider slider)
    {
        print("Area Range : " + slider.value);
        areaRange.localScale = new Vector3(slider.value * 4, slider.value * 2, 1);
        PlayerPrefs.SetFloat("areaRange", slider.value);
    }

    public void OnMinDistanceValueChanged(Slider slider)
    {
        /*print("Min Distance : " + slider.value);
        if (slider.value > maxDistanceSlider.value)
        {
            maxDistanceSlider.value = slider.value;
        }
        target.position = new Vector3(target.position.x, target.position.y, slider.value);
        PlayerPrefs.SetFloat("minDistance", slider.value);*/
    }

    public void OnMaxDistanceValueChanged(Slider slider)
    {
        /*print("Max Distance : " + slider.value);
        if (slider.value < minDistanceSlider.value)
        {
            minDistanceSlider.value = slider.value;
        }
        PlayerPrefs.SetFloat("maxDistance", slider.value);*/
    }

    public void SetColor(string value)
    {
        switch (value)
        {
            case "green":
                // color = "green";
                targetMaterial.SetColor("_EmissionColor", Color.green);
                break;

            case "yellow":
                // color = "yellow";
                targetMaterial.SetColor("_EmissionColor", Color.yellow);
                break;

            case "red":
                // color = "red";
                targetMaterial.SetColor("_EmissionColor", Color.red);
                break;

            case "magenta":
                // color = "magenta";
                targetMaterial.SetColor("_EmissionColor", Color.magenta);
                break;

            case "cyan":
                // color = "cyan";
                targetMaterial.SetColor("_EmissionColor", Color.cyan);
                break;

            case "blue":
                // color = "blue";
                targetMaterial.SetColor("_EmissionColor", Color.blue);
                break;

            case "white":
                // color = "white";
                targetMaterial.SetColor("_EmissionColor", Color.white);
                break;

            case "black":
                // color = "black";
                targetMaterial.SetColor("_EmissionColor", Color.black);
                break;

            default:
                // color = "magenta";
                targetMaterial.SetColor("_EmissionColor", Color.magenta);
                print("default color");
                break;
        }
        //PlayerPrefs.SetString("color", color);
    }
    public void OnBackBtnClick()
    {
        settingsPanel.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
