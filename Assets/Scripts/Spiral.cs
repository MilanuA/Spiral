using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Spiral : MonoBehaviour
{
    [SerializeField] private LineRenderer line;

    private float xPoint, yPoint = 0;
    private Vector2 nextPoint = new();
    private int stopPoint = 0;

    private void OnEnable()
    {
        Input.OnShowSpiral += CreateSpiral;
    }

    private void OnDisable()
    {
        Input.OnShowSpiral -= CreateSpiral;
    }

    private void CreateSpiral(int spiralSize, int spiralWidth, int spiralDelta)
    {
        Reset();

        // If the spiral delta is 0, exit the method
        if (spiralDelta == 0) return;

        // Calculate the stopping point based on spiral size and delta
        stopPoint = (Mathf.FloorToInt((spiralSize / spiralDelta)) * 2) - 2;

        int a = -1; // Variable to alternate between positive and negative direction
        int deltaMultiplier = 0; // Multiplier for spiral delta
        int linePosition = 0; // Current position in the line renderer

        line.positionCount = 3; // Set initial position count for the line renderer

        // Loop to create the spiral
        while (true)
        {
            // Update x position
            xPoint -= (spiralSize - (spiralDelta * deltaMultiplier)) * a;
            nextPoint.x = xPoint;
            nextPoint.y = yPoint;
            line.SetPosition(linePosition + 1, nextPoint); // Set position for the next point

            // Update y position
            yPoint -= (spiralSize - (spiralDelta * deltaMultiplier)) * a;
            nextPoint.x = xPoint;
            nextPoint.y = yPoint;
            line.SetPosition(linePosition + 2, nextPoint); // Set position for the next point

            // Check if reached the stopping point
            if (linePosition == stopPoint) break;

            // Update variables for the next iteration
            a *= -1; // Alternate direction
            deltaMultiplier++; // Increment delta multiplier
            linePosition += 2; // Move to the next position in the line
            line.positionCount += 2; // Increment position count for the line renderer
        }

        CameraSettings.OnSetCamera?.Invoke(spiralWidth);
    }

    private void Reset()
    {
        xPoint = 0;
        yPoint = 0;
        line.positionCount = 0;
    }
}
