using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using VideoOS.Platform;
using VideoOS.Platform.Client;
using VideoOS.Platform.Messaging;

namespace LiveChartsPlugin.Client
{
    public class LiveChartsPluginWorkSpacePlugin : WorkSpacePlugin
    {

        private List<object> _messageRegistrationObjects = new List<object>();

        private bool _workSpaceSelected = false;
        private bool _workSpaceViewSelected = false;

        /// <summary>
        /// The Id.
        /// </summary>
        public override Guid Id
        {
            get { return LiveChartsPluginDefinition.LiveChartsPluginWorkSpacePluginId; }
        }

        /// <summary>
        /// The name displayed on top
        /// </summary>
        public override string Name
        {
            get { return "LiveChartsPlugin"; }
        }

        /// <summary>
        /// We support setup mode
        /// </summary>
        public override bool IsSetupStateSupported
        {
            get { return true; }
        }

        /// <summary>
        /// Initializa the plugin
        /// </summary>
        public override void Init()
        {
            LoadProperties(true);

            List<Rectangle> rectangles = new List<Rectangle>();
            rectangles.Add(new Rectangle(000, 000, 1000, 800));
            ViewAndLayoutItem.Layout = rectangles.ToArray();
            ViewAndLayoutItem.Name = Name;

            //add viewitems to view layout
            Dictionary<String, String> properties2 = new Dictionary<string, string>();
            var newCustom = new LiveChartsPluginViewItemPlugin();

            ViewAndLayoutItem.InsertViewItemPlugin(0, newCustom, properties2);

        }

        /// <summary>
        /// Close workspace and clean up
        /// </summary>
        public override void Close()
        {
            foreach (object messageRegistrationObject in _messageRegistrationObjects)
            {
                EnvironmentManager.Instance.UnRegisterReceiver(messageRegistrationObject);
            }
            _messageRegistrationObjects.Clear();
        }

        /// <summary>
        /// User modified something in setup mode
        /// </summary>
        /// <param name="index"></param>
        public override void ViewItemConfigurationModified(int index)
        {
            base.ViewItemConfigurationModified(index);

            if (ViewAndLayoutItem.ViewItemId(index) == ViewAndLayoutItem.CameraBuiltinId)
            {
                SetProperty("Camera" + index, ViewAndLayoutItem.ViewItemConfigurationString(index));
                SaveProperties(true);
            }
        }

        /// <summary>
        /// Keep track of what workspace is selected, if this is selected the _workSpaceViewSelected is true.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="sender"></param>
        /// <param name="related"></param>
        /// <returns></returns>
        private object ShownWorkSpaceChangedReceiver(Message message, FQID sender, FQID related)
        {
            if (message.Data is Item && ((Item)message.Data).FQID.ObjectId == Id)
            {
                _workSpaceSelected = true;
                Notification = null;
            }
            else
            {
                _workSpaceSelected = false;
            }
            return null;
        }

        /// <summary>
        /// Keep track of current state: in setup or normal
        /// </summary>
        /// <param name="message"></param>
        /// <param name="sender"></param>
        /// <param name="related"></param>
        /// <returns></returns>
        private object WorkSpaceStateChangedReceiver(Message message, FQID sender, FQID related)
        {
            if (_workSpaceSelected && ((WorkSpaceState)message.Data) == WorkSpaceState.Normal)
            {
                // Went in or out of Setup state
            }
            return null;
        }


        /// <summary>
        /// Keep track of what workspace is selected, if this is selected the _workSpaceViewSelected is true.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="sender"></param>
        /// <param name="related"></param>
        /// <returns></returns>
        private object SelectedViewChangedReceiver(Message message, FQID sender, FQID related)
        {
            if (message.Data is Item && ((Item)message.Data).FQID.ObjectId == ViewAndLayoutItem.FQID.ObjectId)
            {
                _workSpaceViewSelected = true;
            }
            else
            {
                _workSpaceViewSelected = false;
            }
            return null;
        }

        /// <summary>
        /// A simple loop to find any camera - replace with something usefull...
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        private Item FindAnyCamera(List<Item> top)
        {
            if (top != null)
                foreach (Item item in top)
                {
                    if (item.FQID.FolderType == FolderType.No && item.FQID.Kind == Kind.Camera)
                        return item;

                    if (item.FQID.FolderType != FolderType.No)
                    {
                        Item check = FindAnyCamera(item.GetChildren());
                        if (check != null)
                            return check;
                    }
                }
            return null;
        }
    }
}
