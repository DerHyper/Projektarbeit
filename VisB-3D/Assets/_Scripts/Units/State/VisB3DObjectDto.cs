using System;
using UnityEngine;

[Serializable]
public class VisB3DObjectDto
{
    public string name;
    public string material;
    public bool isActive;
    public Vector3 position;
    public Vector3 rotation;
    public Vector3 scale;

    public VisB3DObjectDto(string name, string material, bool isActive, Vector3 position, Vector3 rotation, Vector3 scale)
    {
        this.name = name;
        this.material = material;
        this.isActive = isActive;
        this.position = position;
        this.rotation = rotation;
        this.scale = scale;
    }
} 