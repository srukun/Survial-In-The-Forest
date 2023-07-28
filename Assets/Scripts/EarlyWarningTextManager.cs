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
        if(timer < 2.1 && gameObject.activeInHierarchy)
        {
            timer += Time.deltaTime;
            AddToText();
            GetComponentInChildren<TextMeshProUGUI>().SetText(text);
        }
        if(timer > 2.1f && text.Length > 18)
        {
            text = "";
        }

    }
    #region "Add To Text"
    public void AddToText()
    {
        if (timer > 0.12 && text.Length < 1)
        {
            text = "E";
        }
        if (timer > 0.24 && text.Length < 2)
        {
            text = "En";
        }
        if (timer > (0.36) && text.Length < 3)
        {
            text = "Ene";
        }
        if (timer > (0.48) && text.Length < 4)
        {
            text = "Enem";
        }
        if (timer > (0.6) && text.Length < 5)
        {
            text = "Enemi";
        }
        if (timer > (0.72) && text.Length < 6)
        {
            text = "Enemie";
        }
        if (timer > (0.84) && text.Length < 7)
        {
            text = "Enemies";
        }
        if (timer > (0.96) && text.Length < 8)
        {
            text = "Enemies ";
        }
        if (timer > (1.08) && text.Length < 9)
        {
            text = "Enemies I";
        }
        if (timer > (1.2) && text.Length < 10)
        {
            text = "Enemies In";
        }
        if (timer > (1.34) && text.Length < 11)
        {
            text = "Enemies Inc";
        }
        if (timer > (1.46) && text.Length < 12)
        {
            text = "Enemies Inco";
        }
        if (timer > (1.58) && text.Length < 13)
        {
            text = "Enemies Incom";
        }
        if (timer > (1.7) && text.Length < 14)
        {
            text = "Enemies Incomi";
        }
        if (timer > (1.82) && text.Length < 15)
        {
            text = "Enemies Incomin";
        }
        if (timer > (1.94) && text.Length < 16)
        {
            text = "Enemies Incoming";
        }
        if (timer > (2.06) && text.Length < 17)
        {
            text = "Enemies Incoming!";
        }
    }
    #endregion
}
