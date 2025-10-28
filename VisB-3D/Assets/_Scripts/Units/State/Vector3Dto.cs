using System;

[Serializable]
public class Vector3Dto
{
    public float? x;
    public float? y;
    public float? z;

    public Vector3Dto()
    {
        this.x = null;
        this.y = null;
        this.z = null;
    }

    public Vector3Dto(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
}