using VideoOS.Platform.Admin;

namespace LiveChartsPlugin.Admin
{
    public partial class LiveChartsPluginToolsOptionDialogUserControl : ToolsOptionsDialogUserControl
    {
        public LiveChartsPluginToolsOptionDialogUserControl()
        {
            InitializeComponent();
        }

        public override void Init()
        {
        }

        public override void Close()
        {
        }

        public string MyPropValue
        {
            set { textBoxPropValue.Text = value ?? ""; }
            get { return textBoxPropValue.Text; }
        }
    }
}
