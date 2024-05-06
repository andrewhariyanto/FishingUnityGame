using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Singleton class to handle all UI functions
public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField]
    private Slider _castMeter;
    [SerializeField]
    private Image _castMeterFill;
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private GameObject _fishCaughtIcon;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    // Casting meeter functions
    public void ShowMeter()
    {
        _castMeter.gameObject.SetActive(true);
    }

    public void HideMeter()
    {
        _castMeter.gameObject.SetActive(false);
    }

    public void UpdateMeter(float power)
    {
        _castMeter.value = power;
        _castMeterFill.color = Color.Lerp(Color.green, Color.red, _castMeter.value / 4);
    }

    // Score text function
    public void UpdateScore(float score)
    {
        _scoreText.text = "Score: " + score.ToString();
    }

    // Fish caught icon functions
    public void ShowIcon()
    {
        _fishCaughtIcon.SetActive(true);
    }

    public void HideIcon()
    {
        _fishCaughtIcon.SetActive(false);
    }
}
