using System;
using UnityEngine;

[Serializable]
public class MaterialDto
{
    /// <summary>
    /// Can either be a Hex color string (e.g., "#RRGGBB" or "#RRGGBBAA")
    /// or a name with a matching unity material located at "\Assets\Resources\Materials".
    /// </summary>
    public string color;
    public float? metallic;
    public float? smoothness;
}