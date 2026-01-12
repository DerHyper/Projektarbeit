using System;
using System.Collections.Generic;
using System.Linq;

public static class SpecialFormManager
{
    // public static SpecialFormManager instance;
    // public static readonly List<string> SPECIAL_FORM_PREFIXES = new() { "cube_", "sphere_" };
    public static Dictionary<string, Type> specialForms = new();
    public static List<SpecialForm> specialFormInstances = new();
    // private void Awake()
    // {
    //     if (instance == null)
    //     {
    //         instance = this;
    //     }
    //     else
    //     {
    //         Destroy(gameObject);
    //     }

    //     InitSpecialForms();

    // }

    static SpecialFormManager()
    {
        // if (instance == null)
        // {
        //     instance = this;
        // }
        InitSpecialForms();
    }

    /// <summary>
    /// Initialize the Dict of special form prefixes by reflecting over all subclasses of SpecialFormBase
    /// and extracting their static prefix field.
    /// </summary>
    private static void InitSpecialForms()
    {
        typeof(SpecialForm).Assembly
            .GetTypes()
            .Where(t => t.IsSubclassOf(typeof(SpecialForm)) && !t.IsAbstract)
            .ToList()
            .ForEach(t => specialForms.Add(t.GetField("prefix").GetValue(null).ToString(), t));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dto"></param>
    public static bool TryAddSpecialForm(VisB3DObjectDto dto)
    {
        if (!TryGetSFTypeByDto(dto, out Type sfType))
        {
            return false;
        }

        // Create special form based on the prefix
        Type[] constructorParameterTypes = { typeof(string) };
        object[] constructorParameters = { dto.name };
        SpecialForm specialFormInstance = sfType.GetConstructor(constructorParameterTypes).Invoke(constructorParameters) as SpecialForm;
        specialFormInstances.Add(specialFormInstance);
        specialFormInstance.OnCreate();

        return true;
    }

    /// <summary>
    /// Called at the start of each visualization update
    /// </summary>
    public static void OnStartVisualizationUpdate()
    {
        specialFormInstances.ForEach(sf => sf.OnStartVisualizationUpdate());
    }

    private static bool TryGetSFTypeByDto(VisB3DObjectDto dto, out Type sfType)
    {
        foreach (string prefix in specialForms.Keys)
        {
            if (dto.name.StartsWith(prefix))
            {
                sfType = specialForms[prefix];
                return true;
            }
        }

        sfType = null;
        return false;
    }
}