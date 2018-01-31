using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Text textMessage;
    public GameObject panel;

    private void Awake()
    {
        panel.SetActive(false);
    }

    public void ShowInstrumentPanel(string message, bool active)
    {
        textMessage.text = message;

        if (active)
        {
            panel.SetActive(true);
        }
        else
        {
            panel.SetActive(false);
        }

    }
}
