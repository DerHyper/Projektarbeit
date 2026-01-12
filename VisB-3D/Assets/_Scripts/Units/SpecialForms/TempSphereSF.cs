using UnityEngine;

public class TempSphereSF : SpecialForm
{
    public static new string prefix = "temp_sphere_";

    public TempSphereSF(string name) : base(name)
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
    
    public override void OnStartVisualizationUpdate()
    {
        ObjectManager.instance.DestroyObject(name);
    }
}