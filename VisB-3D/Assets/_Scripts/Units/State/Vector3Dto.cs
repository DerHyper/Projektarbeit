using System;
using UnityEngine;

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

    /// <summary>
    /// Overrides the components of the provided Vector3 with the non-null values from this DTO.
    /// </summary>
    /// <param name="original"></param>
    /// <returns></returns>
    public Vector3 OverrideVector3(Vector3 original)
    {
        Vector3 overwritten = new(
                    this.x ?? original.x,
                    this.y ?? original.y,
                    this.z ?? original.z
                );
        return overwritten;
    }
}