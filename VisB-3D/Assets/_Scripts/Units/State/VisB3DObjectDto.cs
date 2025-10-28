using System;
using UnityEngine;

[Serializable]
public class VisB3DObjectDto
{
    public string name;
    public string material;
    public bool? isActive;
    public Vector3Dto position;
    public Vector3Dto rotation;
    public Vector3Dto scale;

    public VisB3DObjectDto(string name, string material, bool? isActive, Vector3Dto position, Vector3Dto rotation, Vector3Dto scale)
    {
        this.name = name;
        this.material = material;
        this.isActive = isActive;
        this.position = position;
        this.rotation = rotation;
        this.scale = scale;
    }
} 