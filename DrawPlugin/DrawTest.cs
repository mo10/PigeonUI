namespace DrawPlugin
{
    public class PluginEntity : IPlugin
    {
        public string Name => "Draw Example";
        public string Description => "Draw Plugin";
        public string Author => "mo10";
        public string Version => "0.0.1";
        public string Url => "https://github.com/mo10";

        public void OnLoad()
        {
            throw new System.NotImplementedException();
        }

        public void OnDestroy()
        {
            throw new System.NotImplementedException();
        }

        public object OnFrameUpdate()
        {
            throw new System.NotImplementedException();
        }

        public void OnShowSettingUI()
        {
            throw new System.NotImplementedException();
        }

        public void OnKeyDown()
        {
            throw new System.NotImplementedException();
        }

        public void OnKeyUp()
        {
            throw new System.NotImplementedException();
        }
    }
}
