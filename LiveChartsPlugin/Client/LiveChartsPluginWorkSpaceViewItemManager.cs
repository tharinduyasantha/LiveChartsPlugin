using VideoOS.Platform.Client;

namespace LiveChartsPlugin.Client
{
    public class LiveChartsPluginWorkSpaceViewItemManager : ViewItemManager
    {
        public LiveChartsPluginWorkSpaceViewItemManager() : base("LiveChartsPluginWorkSpaceViewItemManager")
        {
        }

        public override ViewItemWpfUserControl GenerateViewItemWpfUserControl()
        {
            return new LiveChartsPluginWorkSpaceViewItemWpfUserControl();
        }
    }
}
