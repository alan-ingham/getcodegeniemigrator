using System;
using System.IO;
using System.Windows.Forms;

namespace GetCodeGenieMigrator
{
    public partial class GetCodeGenieMigrator : Form
    {
        public GetCodeGenieMigrator()
        {
            InitializeComponent();
            this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            buttonChooseDirectory.Click += buttonChooseDirectory_Click;
            buttonConvert.Click         += buttonConvert_Click;
        }

        // ── Choose directory ────────────────────────────────────────────────────

        private void buttonChooseDirectory_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dlg = new FolderBrowserDialog())
            {
                dlg.Description         = "Select the folder containing .gcg2p snapshot files";
                dlg.ShowNewFolderButton = false;

                if (!string.IsNullOrEmpty(textBoxWorkingDirectory.Text))
                    dlg.SelectedPath = textBoxWorkingDirectory.Text;

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    textBoxWorkingDirectory.Text = dlg.SelectedPath;
                    SetStatus("Ready.");
                }
            }
        }

        // ── Convert ─────────────────────────────────────────────────────────────

        private void buttonConvert_Click(object sender, EventArgs e)
        {
            string dir = textBoxWorkingDirectory.Text.Trim();

            if (string.IsNullOrEmpty(dir) || !Directory.Exists(dir))
            {
                SetStatus("Please choose a valid directory first.");
                return;
            }

            // Find all snapshot files — both active (.gcg2p) and historical (.gcg2)
            string[] files = Directory.GetFiles(dir, "*.gcg2p");

            if (files.Length == 0)
            {
                SetStatus("No .gcg2p files found in that directory.");
                return;
            }

            int converted = 0;
            int skipped   = 0;
            int failed    = 0;

            buttonConvert.Enabled = false;

            foreach (string path in files)
            {
                // Skip files that already have a JSON counterpart
                if (File.Exists(path + Migrator.JsonExtension))
                {
                    skipped++;
                    continue;
                }

                SetStatus(string.Format("Converting {0} of {1}: {2}",
                    converted + skipped + failed + 1, files.Length, Path.GetFileName(path)));

                Application.DoEvents(); // Keep the UI responsive

                try
                {
                    Migrator.MigrateFile(path);
                    converted++;
                }
                catch (Exception ex)
                {
                    failed++;
                    MessageBox.Show(
                        string.Format("Failed to convert:\n{0}\n\n{1}", path, ex.Message),
                        "Conversion error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }

            buttonConvert.Enabled = true;

            SetStatus(string.Format("Done. {0} converted, {1} skipped (already done), {2} failed.",
                converted, skipped, failed));
        }

        // ── Helpers ─────────────────────────────────────────────────────────────

        private void SetStatus(string message)
        {
            labelStatus.Text = "Status: " + message;
        }
    }
}
