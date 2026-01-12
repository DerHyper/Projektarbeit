using UnityEngine;

public class CubeSF : SpecialForm
{
    public static new string prefix = "cube_";

    public CubeSF(string name) : base(name)
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
}