public class SpecialForm
{
    public static string prefix;
    public string name;
    public SpecialForm(string name)
    {
        this.name = name;
    }

    /// <summary>
    /// Called when the special form is created
    /// </summary>
    public virtual void OnCreate() { }

    /// <summary>
    /// Called at the start of each visualization update
    /// </summary>
    public virtual void OnStartVisualizationUpdate() { }

}