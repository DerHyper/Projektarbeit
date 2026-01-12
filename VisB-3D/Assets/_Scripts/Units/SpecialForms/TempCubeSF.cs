using UnityEngine;

public class TempCubeSF : SpecialForm
{
    public static new string prefix = "temp_cube_";

    public TempCubeSF(string name) : base(name)
    {
    }

    public override void OnCreate()
    {
        // Create a cube GameObject and register it with the ObjectManager
        base.OnCreate();
        GameObject instance = GameObject.CreatePrimitive(PrimitiveType.Cube);
        instance.name = name;
        instance.transform.parent = ObjectManager.instance.stateObjectParent.transform;
        ObjectManager.instance.managedObjects.Add(name, instance.AddComponent<StateUpdater>());
    }

    public override void OnStartVisualizationUpdate()
    {
        ObjectManager.instance.DestroyObject(name);
    }
}