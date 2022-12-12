using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResultController : MonoBehaviour
{
    private TMP_Text ResultText;

    private void Start()
    {
        ResultText = GetComponent<TMP_Text>();
    }
    public void WinCondition()
    {
        ResultText.color = Color.green;
        ResultText.text = "Mission Accomplished";
    }

    public void failedCondition()
    {
        ResultText.color = Color.red;
        ResultText.text = "Mission Failed";
    }
}
