using SimpleBinder.Services;

namespace SimpleBinder;

public partial class SimpleBinder
{
    private async void Binder_FormClosing(object sender, FormClosingEventArgs e)
    {
        await BinderService.TurnOffBinder(this);
        settings.Save();
        keyboardHookManager.Stop();
        if (!saveButton.Enabled) return;
        var result = MessageBox.Show(exitToolStripMenuItem_Click_Text,
            exitToolStripMenuItem_Click_Warning,
            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
        switch (result)
        {
            case DialogResult.Yes:
                saveButton_Click(null, null);
                break;
            case DialogResult.Cancel:
                e.Cancel = true;
                break;
        }
    }
}