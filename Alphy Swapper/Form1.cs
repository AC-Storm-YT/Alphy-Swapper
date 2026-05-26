using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using Newtonsoft.Json;

namespace Alphy2
{
    public partial class Form1 : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;
        private List<RlItem> allItems = new List<RlItem>();
        private AppSettings appSettings = new AppSettings();

        private readonly string baseFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "AlphySwapper");
        private readonly string backendFolder;
        private readonly string settingsJsonPath;

        private readonly string pythonScriptPath;
        private readonly string pythonUpkEditorPath;
        private readonly string itemsJsonPath;
        private readonly string keysTxtPath;

        public Form1()
        {
            InitializeComponent();

            backendFolder = Path.Combine(baseFolder, "Backend");
            settingsJsonPath = Path.Combine(baseFolder, "settings.json");

            pythonScriptPath = Path.Combine(backendFolder, "rl_asset_swapper.py");
            pythonUpkEditorPath = Path.Combine(backendFolder, "rl_upk_editor.py");
            itemsJsonPath = Path.Combine(backendFolder, "items.json");
            keysTxtPath = Path.Combine(backendFolder, "keys.txt");

            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE
            );

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LogToConsole("System: Alphy Swapper UI Initializing...");
            Directory.CreateDirectory(baseFolder);
            Directory.CreateDirectory(backendFolder);

            ExtractEmbeddedFiles();

            LoadSettings();
            LoadItemsData();
        }

        // --- EMBEDDED RESOURCE EXTRACTION ---
        private void ExtractEmbeddedFiles()
        {
            try
            {
                LogToConsole("System: Verifying integrated engine files...");

                string[] allResources = Assembly.GetExecutingAssembly().GetManifestResourceNames();

                string GetFullResourceName(string targetFileName)
                {
                    return allResources.FirstOrDefault(r => r.EndsWith(targetFileName, StringComparison.OrdinalIgnoreCase));
                }

                string resSwapper = GetFullResourceName("rl_asset_swapper.py");
                string resUpk = GetFullResourceName("rl_upk_editor.py");
                string resItems = GetFullResourceName("items.json");
                string resKeys = GetFullResourceName("keys.txt");

                if (resSwapper != null) ExtractResource(resSwapper, pythonScriptPath);
                else LogToConsole("FATAL: rl_asset_swapper.py is not embedded in the .exe!", true);

                if (resUpk != null) ExtractResource(resUpk, pythonUpkEditorPath);
                else LogToConsole("FATAL: rl_upk_editor.py is not embedded in the .exe!", true);

                if (resItems != null) ExtractResource(resItems, itemsJsonPath);
                else LogToConsole("FATAL: items.json is not embedded in the .exe!", true);

                if (resKeys != null) ExtractResource(resKeys, keysTxtPath);
                else LogToConsole("FATAL: keys.txt is not embedded in the .exe!", true);
            }
            catch (Exception ex)
            {
                LogToConsole($"Error extracting engine files: {ex.Message}", true);
            }
        }

        private void ExtractResource(string resourceName, string outPath)
        {
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            {
                if (stream == null) return;

                using (FileStream fileStream = new FileStream(outPath, FileMode.Create))
                {
                    stream.CopyTo(fileStream);
                }
            }
        }

        // --- SETTINGS MANAGEMENT ---
        private void LoadSettings()
        {
            try
            {
                if (File.Exists(settingsJsonPath))
                {
                    string json = File.ReadAllText(settingsJsonPath);
                    appSettings = JsonConvert.DeserializeObject<AppSettings>(json) ?? new AppSettings();
                }

                txtOutputDir.Text = appSettings.OutputDirectory;
                txtDonorDir.Text = appSettings.DonorDirectory;
                txtAlphyModsDir.Text = appSettings.AlphyModsDirectory;
            }
            catch (Exception ex)
            {
                LogToConsole($"Warning: Failed to load settings. {ex.Message}", true);
            }
        }

        private void SaveSettings()
        {
            try
            {
                string json = JsonConvert.SerializeObject(appSettings, Formatting.Indented);
                File.WriteAllText(settingsJsonPath, json);
            }
            catch (Exception ex)
            {
                LogToConsole($"Error saving settings: {ex.Message}", true);
            }
        }

        private void btnBrowseOutput_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Select the fallback folder where Alphy should save your converted mods.";

                if (!string.IsNullOrEmpty(appSettings.OutputDirectory) && Directory.Exists(appSettings.OutputDirectory))
                {
                    fbd.SelectedPath = appSettings.OutputDirectory;
                }

                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    appSettings.OutputDirectory = fbd.SelectedPath;
                    txtOutputDir.Text = appSettings.OutputDirectory;
                    SaveSettings();
                    LogToConsole($"System: Fallback output directory updated to -> {appSettings.OutputDirectory}");
                }
            }
        }

        private void btnBrowseDonor_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Select your Rocket League CookedPCConsole folder (Game Files).";

                if (!string.IsNullOrEmpty(appSettings.DonorDirectory) && Directory.Exists(appSettings.DonorDirectory))
                {
                    fbd.SelectedPath = appSettings.DonorDirectory;
                }

                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    appSettings.DonorDirectory = fbd.SelectedPath;
                    txtDonorDir.Text = appSettings.DonorDirectory;
                    SaveSettings();
                    LogToConsole($"System: Game files directory updated to -> {appSettings.DonorDirectory}");
                }
            }
        }

        private void btnBrowseAlphyMods_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Select your Alphy Mods folder (Where you want structured exports).";

                if (!string.IsNullOrEmpty(appSettings.AlphyModsDirectory) && Directory.Exists(appSettings.AlphyModsDirectory))
                {
                    fbd.SelectedPath = appSettings.AlphyModsDirectory;
                }

                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    appSettings.AlphyModsDirectory = fbd.SelectedPath;
                    txtAlphyModsDir.Text = appSettings.AlphyModsDirectory;
                    SaveSettings();
                    LogToConsole($"System: Alphy Mods directory linked -> {appSettings.AlphyModsDirectory}");
                }
            }
        }

        private void btnClearAlphyMods_Click(object sender, EventArgs e)
        {
            appSettings.AlphyModsDirectory = "";
            txtAlphyModsDir.Text = "";
            SaveSettings();
            LogToConsole("System: Alphy Mods directory link cleared.");
        }

        // --- ITEM DATA HANDLING ---
        private void LoadItemsData()
        {
            if (!File.Exists(itemsJsonPath))
            {
                LogToConsole("Error: Engine file items.json was not unpacked correctly.");
                return;
            }

            try
            {
                string json = File.ReadAllText(itemsJsonPath);
                var root = JsonConvert.DeserializeObject<RlItemRoot>(json);
                if (root?.Items != null)
                {
                    allItems = root.Items;
                    var categories = allItems.Select(x => x.Slot).Where(s => !string.IsNullOrEmpty(s)).Distinct().OrderBy(s => s).ToList();

                    cmbCategory.Items.Clear();
                    foreach (var category in categories)
                    {
                        cmbCategory.Items.Add(category);
                    }
                    LogToConsole($"System: Loaded {allItems.Count} items across {categories.Count} categories.");
                }
            }
            catch (Exception ex)
            {
                LogToConsole($"Error parsing items.json: {ex.Message}", true);
            }
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCategory = cmbCategory.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedCategory)) return;

            var filteredItems = allItems.Where(x => x.Slot == selectedCategory).OrderBy(x => x.Product).ToList();

            cmbTarget.Items.Clear();
            cmbDonor.Items.Clear();

            foreach (var item in filteredItems)
            {
                string cleanName = CleanItemName(item.Product);
                var option = new ItemComboBoxOption { DisplayName = cleanName, Id = item.ID };

                cmbTarget.Items.Add(option);
                cmbDonor.Items.Add(option);
            }
        }

        private string CleanItemName(string rawName)
        {
            if (string.IsNullOrEmpty(rawName)) return "Unknown";
            string cleaned = rawName.Replace("?INT?Products.", "").Replace(".Label?", "");
            if (cleaned.Contains(":")) cleaned = cleaned.Substring(cleaned.LastIndexOf(":") + 1).Trim();
            return cleaned.Replace("_", " ");
        }

        private string MakeValidFileName(string name)
        {
            string invalidChars = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            foreach (char c in invalidChars)
            {
                name = name.Replace(c.ToString(), "");
            }
            return name.Trim();
        }

        // Maps raw Rocket League item slots to Alphy's exact folder structure
        private string MapSlotToAlphyCategory(string rawSlot)
        {
            if (string.IsNullOrEmpty(rawSlot)) return "Unknown";

            string s = rawSlot.ToLower();

            if (s == "player banner" || s == "banner") return "Banner";
            if (s == "engineaudio" || s == "boost audio") return "Boost Audio";
            if (s == "skin" || s == "decal") return "Decal";
            if (s == "goalexplosion" || s == "goal explosion") return "Goal Explosion";
            if (s == "topper" || s == "hat") return "Hat";
            if (s == "paintfinish" || s == "paint") return "Paint";
            if (s == "rocketboost" || s == "boost") return "Boost";
            if (s == "wheels" || s == "wheel") return "Wheels";
            if (s == "body") return "Body";
            if (s == "antenna") return "Antenna";
            if (s == "trail") return "Trail";

            // Fallback (capitalizes first letter)
            return char.ToUpper(rawSlot[0]) + rawSlot.Substring(1);
        }

        // --- EXECUTION LOGIC ---
        private async void btnSwap_Click(object sender, EventArgs e)
        {
            var targetSelection = cmbTarget.SelectedItem as ItemComboBoxOption;
            var donorSelection = cmbDonor.SelectedItem as ItemComboBoxOption;

            if (targetSelection == null || donorSelection == null)
            {
                MaterialMessageBox.Show("Please select both a Target item and a Donor item.");
                return;
            }

            btnSwap.Enabled = false;
            LogToConsole($"System: Swapping [{targetSelection.DisplayName}] -> [{donorSelection.DisplayName}]...");

            string finalOutDir = appSettings.OutputDirectory;

            if (!string.IsNullOrEmpty(appSettings.AlphyModsDirectory))
            {
                string rawCategory = cmbCategory.SelectedItem?.ToString() ?? "Unknown";
                string alphyCategory = MapSlotToAlphyCategory(rawCategory); // Use translated folder name

                string folderName;

                // Check if user provided a custom name, if not, use the default formatting
                if (!string.IsNullOrWhiteSpace(txtCustomFolderName.Text))
                {
                    folderName = MakeValidFileName(txtCustomFolderName.Text);
                }
                else
                {
                    string cleanTargetName = MakeValidFileName(targetSelection.DisplayName);
                    string cleanDonorName = MakeValidFileName(donorSelection.DisplayName);
                    folderName = $"{cleanDonorName} (Replaces {cleanTargetName})";
                }

                finalOutDir = Path.Combine(appSettings.AlphyModsDirectory, alphyCategory, folderName);

                Directory.CreateDirectory(finalOutDir);
                LogToConsole($"System: Auto-routing export to -> {alphyCategory}\\{folderName}");
            }

            await Task.Run(() => RunAssetSwapper(targetSelection.Id.ToString(), donorSelection.Id.ToString(), false, finalOutDir));

            btnSwap.Enabled = true;

            txtCustomFolderName.Text = "";
        }

        private async void btnRevert_Click(object sender, EventArgs e)
        {
            var targetSelection = cmbTarget.SelectedItem as ItemComboBoxOption;
            if (targetSelection == null)
            {
                MaterialMessageBox.Show("Please select a Target item to revert.");
                return;
            }

            btnRevert.Enabled = false;
            LogToConsole($"System: Reverting [{targetSelection.DisplayName}] to vanilla state...");

            await Task.Run(() => RunAssetSwapper(targetSelection.Id.ToString(), "", true, appSettings.OutputDirectory));

            btnRevert.Enabled = true;
        }

        private void RunAssetSwapper(string targetId, string donorId, bool revert, string finalOutputDir)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "python",
                    Arguments = $"\"{pythonScriptPath}\" --no-gui --items \"{itemsJsonPath}\" --keys \"{keysTxtPath}\"",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                if (!string.IsNullOrEmpty(finalOutputDir))
                {
                    psi.Arguments += $" --output-dir \"{finalOutputDir}\"";
                }

                if (!string.IsNullOrEmpty(appSettings.DonorDirectory))
                {
                    psi.Arguments += $" --donor-dir \"{appSettings.DonorDirectory}\"";
                }

                if (revert)
                    psi.Arguments += $" --target {targetId} --revert";
                else
                    psi.Arguments += $" --target {targetId} --donor {donorId}";

                using (Process process = new Process { StartInfo = psi })
                {
                    process.OutputDataReceived += (sender, args) => LogToConsole(args.Data);
                    process.ErrorDataReceived += (sender, args) => LogToConsole(args.Data, true);

                    process.Start();
                    process.BeginOutputReadLine();
                    process.BeginErrorReadLine();
                    process.WaitForExit();
                }
            }
            catch (Exception ex)
            {
                LogToConsole($"FATAL: {ex.Message}", true);
            }
        }

        private void LogToConsole(string message, bool isError = false)
        {
            if (string.IsNullOrEmpty(message)) return;

            if (txtConsole.InvokeRequired)
            {
                txtConsole.Invoke(new Action(() => LogToConsole(message, isError)));
                return;
            }

            string timestamp = DateTime.Now.ToString("HH:mm:ss");
            txtConsole.SelectionStart = txtConsole.TextLength;
            txtConsole.SelectionLength = 0;
            txtConsole.SelectionColor = isError ? Color.Salmon : Color.LightGreen;
            txtConsole.AppendText($"[{timestamp}] {message}{Environment.NewLine}");
            txtConsole.ScrollToCaret();
        }
    }

    public class AppSettings
    {
        public string OutputDirectory { get; set; } = "";
        public string DonorDirectory { get; set; } = "";
        public string AlphyModsDirectory { get; set; } = "";
    }
}