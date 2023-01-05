using System.ComponentModel;

namespace SimpleBinder
{
    public partial class SimpleBinder
    {
        private void ChangerCurrentCulture(string lang)
        {
            if (lang == settings.CurrentLanguage) return;
            settings.CurrentLanguage = lang;
            var newLangCultureInfo = new CultureInfo(lang);
            Thread.CurrentThread.CurrentCulture = newLangCultureInfo;
            Thread.CurrentThread.CurrentUICulture = newLangCultureInfo;
        }

        private void ChangeLanguage(string lang)
        {
            if (lang == settings.CurrentLanguage) return;
            ChangerCurrentCulture(lang);
            var newLangCultureInfo = new CultureInfo(lang);

            #region ApplyingResources
            {
                var resources = new ComponentResourceManager(typeof(SimpleBinder));
                foreach (Control control in Controls)
                {
                    resources.ApplyResources(control, control.Name, newLangCultureInfo);
                }


                foreach (ToolStripMenuItem item in menuStrip1.Items)
                {
                    resources.ApplyResources(item, item.Name, newLangCultureInfo);
                    foreach (var dropItem in item.DropDownItems)
                    {
                        if (dropItem is ToolStripMenuItem Item)
                            resources.ApplyResources(Item, Item.Name, newLangCultureInfo);
                    }
                }

                resources.ApplyResources(this, "$this", newLangCultureInfo);
            }
            #endregion
        }
    }

    #region LanguageToolStripItems

    #endregion
}