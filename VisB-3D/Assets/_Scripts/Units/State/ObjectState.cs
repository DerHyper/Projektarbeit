using UnityEngine;

public abstract class ObjectState
{
    public string name;
    public Vector3 position;
    public Vector3 rotation;
    public Vector3 scale;
    public Material material;
    public bool is_active;

    public ObjectState(string name, Vector3 position, Vector3 rotation, Vector3 scale, Material material, bool is_active)
    {
        this.name = name;
        this.position = position;
        this.rotation = rotation;
        this.scale = scale;
        this.material = material;
        this.is_active = is_active;
    }
} 