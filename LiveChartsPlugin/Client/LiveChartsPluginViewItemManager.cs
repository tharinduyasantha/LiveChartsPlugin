
using LiveChartsPlugin.Models;
using LiveChartsPlugin.ChartServices;
using System;
using System.Collections.Generic;
using VideoOS.Platform;
using VideoOS.Platform.Client;

namespace LiveChartsPlugin.Client
{
    /// <summary>
    /// The ViewItemManager contains the configuration for the ViewItem. <br/>
    /// When the class is initiated it will automatically recreate relevant ViewItem configuration saved in the properties collection from earlier.
    /// Also, when the viewlayout is saved the ViewItemManager will supply current configuration to the SmartClient to be saved on the server.<br/>
    /// This class is only relevant when executing in the Smart Client.
    /// </summary>
    public class LiveChartsPluginViewItemManager : ViewItemManager
    {
        private Guid _someid;
        private string _someName;
        private List<Item> _configItems;
        private bool _isInitialized = false;
        public ChartsViewModel ViewModel { get; private set; }
        private ChartService _chartService;

        public LiveChartsPluginViewItemManager() : base("LiveChartsPluginViewItemManager")
        {
            ViewModel = new ChartsViewModel();
            _chartService = new ChartService();
        }

        #region Methods overridden 
        /// <summary>
        /// The properties for this ViewItem is now loaded into the base class and can be accessed via 
        /// GetProperty(key) and SetProperty(key,value) methods
        /// </summary>
        public override void PropertiesLoaded()
        {
            _chartService.InitializeChartsViewModel(ViewModel);
            _isInitialized = true;

        }

        ///// <summary>
        ///// Generate the UserControl containing the actual ViewItem Content.
        ///// 
        ///// For new plugins it is recommended to use GenerateViewItemWpfUserControl() instead. Only implement this one if support for Smart Clients older than 2017 R3 is needed.
        ///// </summary>
        ///// <returns></returns>
        //public override ViewItemUserControl GenerateViewItemUserControl()
        //{
        //	return new LiveChartsPluginViewItemUserControl(this);
        //}

        /// <summary>
        /// Generate the UserControl containing the actual ViewItem Content.
        /// </summary>
        /// <returns></returns>
        public override ViewItemWpfUserControl GenerateViewItemWpfUserControl()
        {
            var control = new LiveChartsPluginViewItemWpfUserControl(this);
            control.DataContext = ViewModel;
            return control;
        }

        ///// <summary>
        ///// Generate the UserControl containing the property configuration.
        ///// 
        ///// For new plugins it is recommended to use GeneratePropertiesWpfUserControl() instead. Only implement this one if support for Smart Clients older than 2017 R3 is needed.
        ///// </summary>
        ///// <returns></returns>
        //public override PropertiesUserControl GeneratePropertiesUserControl()
        //{
        //	return new LiveChartsPluginPropertiesUserControl(this);
        //}

        /// <summary>
        /// Generate the UserControl containing the property configuration.
        /// </summary>
        /// <returns></returns>
        public override PropertiesWpfUserControl GeneratePropertiesWpfUserControl()
        {
            var control = new LiveChartsPluginPropertiesWpfUserControl(this);
            control.DataContext = ViewModel;
            return control;
        }

        #endregion



    }
}
