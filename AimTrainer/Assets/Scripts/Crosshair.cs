using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{
    // --- CROSSHAIR ELEMENTS ---
    [SerializeField]
    private RectTransform topRT;
    [SerializeField]
    private RectTransform bottomRT;
    [SerializeField]
    private RectTransform leftRT;
    [SerializeField]
    private RectTransform rightRT;

    private Image topI;
    private Image bottomI;
    private Image leftI;
    private Image rightI;

    [HideInInspector]
    public float thickness;
    [HideInInspector]
    public float length;
    [HideInInspector]
    public float centerGap;
    [HideInInspector]
    public float opacity;
    [HideInInspector]
    public string color;

    // Start is called before the first frame update
    void Awake()
    {
        topI = topRT.GetComponent<Image>();
        bottomI = bottomRT.GetComponent<Image>();
        leftI = leftRT.GetComponent<Image>();
        rightI = rightRT.GetComponent<Image>();

        SetSavedParameters();
    }

    private void SetSavedParameters()
    {
        SetThickness(PlayerPrefs.GetFloat("thickness", 5f));
        SetLength(PlayerPrefs.GetFloat("length", 10f));
        SetCenterGap(PlayerPrefs.GetFloat("centerGap", 2f));
        SetOpacity(PlayerPrefs.GetFloat("opacity", 1f));
        SetColor(PlayerPrefs.GetString("color", "green"));
    }

    public void SetThickness(float value)
    {
        thickness = value;

        topRT.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, thickness);
        bottomRT.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, thickness);
        leftRT.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, thickness);
        rightRT.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, thickness);

        PlayerPrefs.SetFloat("thickness", thickness);
    }

    public void SetLength(float value)
    {
        length = value;

        topRT.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, value);
        bottomRT.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, value);
        leftRT.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, value);
        rightRT.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, value);

        PlayerPrefs.SetFloat("length", length);
    }

    public void SetCenterGap(float value)
    {
        centerGap = value;

        topRT.anchoredPosition = new Vector2(0f, value);
        bottomRT.anchoredPosition = new Vector2(0f, -value);
        leftRT.anchoredPosition = new Vector2(-value, 0f);
        rightRT.anchoredPosition = new Vector2(value, 0f);

        PlayerPrefs.SetFloat("centerGap", centerGap);
    }

    public void SetOpacity(float value)
    {
        opacity = value;

        SetColorAlpha(topI, value);
        SetColorAlpha(bottomI, value);
        SetColorAlpha(leftI, value);
        SetColorAlpha(rightI, value);

        PlayerPrefs.SetFloat("opacity", opacity);
    }

    public void SetColor(string value)
    {
        switch (value)
        {
            case "green":
                color = "green";
                SetColor(Color.green);
                break;

            case "yellow":
                color = "yellow";
                SetColor(Color.yellow);
                break;

            case "red":
                color = "red";
                SetColor(Color.red);
                break;

            case "magenta":
                color = "magenta";
                SetColor(Color.magenta);
                break;

            case "cyan":
                color = "cyan";
                SetColor(Color.cyan);
                break;

            case "blue":
                color = "blue";
                SetColor(Color.blue);
                break;

            case "white":
                color = "white";
                SetColor(Color.white);
                break;

            case "black":
                color = "black";
                SetColor(Color.black);
                break;

            default:
                color = "green";
                SetColor(Color.green);
                print("default color");
                break;
        }
        PlayerPrefs.SetString("color", color);
    }

    public void Show()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
    }

    public void Hide()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    private void SetColor(Color col)
    {
        col.a = opacity;

        topI.color = col;
        bottomI.color = col;
        leftI.color = col;
        rightI.color = col;
    }

    private void SetColorAlpha(Image image, float alpha)
    {
        Color col = image.color;
        col.a = alpha;
        image.color = col;
    }
}
