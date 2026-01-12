using UnityEngine;

public class SphereSF : SpecialForm
{
    public static new string prefix = "sphere_";

    public SphereSF(string name) : base(name)
    {
    }

    public override void OnCreate()
    {
        // Create a sphere GameObject and register it with the ObjectManager
        base.OnCreate();
        GameObject instance = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        instance.name = name;
        instance.transform.parent = ObjectManager.instance.stateObjectParent.transform;
        ObjectManager.instance.managedObjects.Add(name, instance.AddComponent<StateUpdater>());
    }
}