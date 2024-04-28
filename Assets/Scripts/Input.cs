using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Input : MonoBehaviour
{
    /// <summary>
    /// first int - size
    /// second int - width
    /// third int - delta
    /// </summary>
    public static Action<int, int, int> OnShowSpiral;

    [SerializeField] private TMP_InputField deltaInput;
    [SerializeField] private TMP_InputField widthInput;
    [SerializeField] private Button btn;

    private int spiralWidth, spiralSize, spiralDelta;

    private void Update()
    {
        btn.interactable = deltaInput.text != "" && widthInput.text != "";
    }

    private void GetInput()
    {
        spiralWidth = int.Parse(widthInput.text);

        if (spiralWidth < 0)
        {
            spiralWidth *= -1;
            widthInput.text = spiralWidth.ToString();
        }

        spiralSize = spiralWidth;

        spiralDelta = int.Parse(deltaInput.text);

        if (spiralDelta < 0)
        {
            spiralDelta *= -1;
            deltaInput.text = spiralDelta.ToString();
        }

        if (spiralDelta > spiralWidth)
        {
            deltaInput.text = "0";
            widthInput.text = "0";

            spiralDelta = 0;
            spiralWidth = 0;
        }
    }

    public void GenerateSpiral()
    {
        GetInput();
        OnShowSpiral?.Invoke(spiralSize, spiralWidth, spiralDelta);
    }
}
