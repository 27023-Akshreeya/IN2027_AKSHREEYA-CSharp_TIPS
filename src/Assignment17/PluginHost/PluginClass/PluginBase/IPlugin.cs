
namespace PluginBase;

/// <summary>
/// Plugin interface
/// </summary>
public interface IPlugin
{
    string Name { get; }

    void Execute();
}