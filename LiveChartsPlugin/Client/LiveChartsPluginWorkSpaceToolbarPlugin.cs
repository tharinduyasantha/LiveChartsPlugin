using System;
using System.Collections.Generic;
using VideoOS.Platform;
using VideoOS.Platform.Client;

namespace LiveChartsPlugin.Client
{
    internal class LiveChartsPluginWorkSpaceToolbarPluginInstance : WorkSpaceToolbarPluginInstance
    {
        private Item _window;

        public LiveChartsPluginWorkSpaceToolbarPluginInstance()
        {
        }

        public override void Init(Item window)
        {
            _window = window;

            Title = "LiveChartsPlugin";
        }

        public override void Activate()
        {
            // Here you should put whatever action that should be executed when the toolbar button is pressed
        }

        public override void Close()
        {
        }

    }

    internal class LiveChartsPluginWorkSpaceToolbarPlugin : WorkSpaceToolbarPlugin
    {
        public LiveChartsPluginWorkSpaceToolbarPlugin()
        {
        }

        public override Guid Id
        {
            get { return LiveChartsPluginDefinition.LiveChartsPluginWorkSpaceToolbarPluginId; }
        }

        public override string Name
        {
            get { return "LiveChartsPlugin"; }
        }

        public override void Init()
        {
            // TODO: remove below check when LiveChartsPluginDefinition.LiveChartsPluginWorkSpaceToolbarPluginId has been replaced with proper GUID
            if (Id == new Guid("22222222-2222-2222-2222-222222222222"))
            {
                System.Windows.MessageBox.Show("Default GUID has not been replaced for LiveChartsPluginWorkSpaceToolbarPluginId!");
            }

            WorkSpaceToolbarPlaceDefinition.WorkSpaceIds = new List<Guid>() { ClientControl.LiveBuildInWorkSpaceId, ClientControl.PlaybackBuildInWorkSpaceId, LiveChartsPluginDefinition.LiveChartsPluginWorkSpacePluginId };
            WorkSpaceToolbarPlaceDefinition.WorkSpaceStates = new List<WorkSpaceState>() { WorkSpaceState.Normal };
        }

        public override void Close()
        {
        }

        public override WorkSpaceToolbarPluginInstance GenerateWorkSpaceToolbarPluginInstance()
        {
            return new LiveChartsPluginWorkSpaceToolbarPluginInstance();
        }
    }
}
