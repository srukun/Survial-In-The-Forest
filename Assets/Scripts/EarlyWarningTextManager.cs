using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EarlyWarningTextManager : MonoBehaviour
{
    public float timer;
    public string text;
    public bool warningSwitch;
    void Start()
    {
    }

    
    void Update()
    {
        if(timer < 2.2 && gameObject.activeInHierarchy)
        {
            timer += Time.deltaTime;
            AddToText();
            GetComponentInChildren<TextMeshProUGUI>().SetText(text);
        }
        if(timer > 2.2f && text.Length > 18)
        {
            text = "";
        }


    }
    #region "Add To Text"
    public void AddToText()
    {
        if (timer > 0.12 && text.Length < 1)
        {
            text = "N";
        }
        if (timer > 0.24 && text.Length < 2)
        {
            text = "Ne";
        }
        if (timer > (0.36) && text.Length < 3)
        {
            text = "New";
        }
        if (timer > (0.48) && text.Length < 4)
        {
            text = "New ";
        }
        if (timer > (0.6) && text.Length < 5)
        {
            text = "New W";
        }
        if (timer > (0.72) && text.Length < 6)
        {
            text = "New Wa";
        }
        if (timer > (0.84) && text.Length < 7)
        {
            text = "New Wav";
        }
        if (timer > (0.96) && text.Length < 8)
        {
            text = "New Wave";
        }
        if (timer > (1.08) && text.Length < 9)
        {
            text = "New Wave ";
        }
        if (timer > (1.2) && text.Length < 10)
        {
            text = "New Wave I";
        }
        if (timer > (1.34) && text.Length < 11)
        {
            text = "New Wave In";
        }
        if (timer > (1.46) && text.Length < 12)
        {
            text = "New Wave Inc";
        }
        if (timer > (1.58) && text.Length < 13)
        {
            text = "New Wave Inco";
        }
        if (timer > (1.7) && text.Length < 14)
        {
            text = "New Wave Incom";
        }
        if (timer > (1.82) && text.Length < 15)
        {
            text = "New Wave Incomi";
        }
        if (timer > (1.94) && text.Length < 16)
        {
            text = "New Wave Incomin";
        }
        if (timer > (2.06) && text.Length < 17)
        {
            text = "New Wave Incoming";
        }
        if (timer > (2.18) && text.Length < 18)
        {
            text = "New Wave Incoming!";
        }
    }
    #endregion
}
