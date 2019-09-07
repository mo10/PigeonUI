public interface IPlugin
{
    string Name { get; }
    string Description { get; }
    string Author { get; }
    string Version { get; }
    string Url { get; }

    void OnLoad();
    void OnDestroy();
    object OnFrameUpdate();
    void OnShowSettingUI();
    void OnKeyDown();
    void OnKeyUp();
}
