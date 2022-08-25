namespace InstagramAdBlocker.Properties
{

    // This allows you to handle setting value when changed.
    // The SettingChanging event is raised before a setting's value is changed.
    // The PropertyChanged event is raised after a setting's value is changed.
    // The SettingLoaded event is raised after a setting's value is loaded.
    // The settingSaved event is raised after the setting value is reseted.
    internal sealed partial class Settings
    {
        
        public Settings()
        {
            // // To add event handlers for saving and changing settings, uncomment the lines below.
            //
            // this.SettingChanging += this.SettingChangingEventHandler;
            //
            // this.SettingsSaving += this.SettingsSavingEventHandler;
            //
        }

        private void SettingChangingEventHandler(object sender, System.Configuration.SettingChangingEventArgs())
        {
            // Code required to add this feature.
        }
        private void SettingSavingEventHandler(object sender, System.ComponentModel.CancelEventArgs())
        {
            // Code required to add this feature.
        }
    }

}