using UnityEngine;

public abstract class VisB3DObjectDto
{
    public enum MaterialDto {
        standard,
        red,
        orange,
        yellow,
        green,
        cyan,
        blue,
        purple,
        black,
        grey,
        metallic,
        glassy,
        transparent
    }
    public string name;
    public MaterialDto material;
    public bool isActive;
    public Vector3 position;
    public Vector3 rotation;
    public Vector3 scale;

    protected VisB3DObjectDto(string name, MaterialDto material, bool isActive, Vector3 position, Vector3 rotation, Vector3 scale)
    {
        this.name = name;
        this.material = material;
        this.isActive = isActive;
        this.position = position;
        this.rotation = rotation;
        this.scale = scale;
    }
} 