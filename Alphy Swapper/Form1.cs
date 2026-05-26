using Alphy;
using MaterialSkin;
using MaterialSkin.Controls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alphy2
{
    public partial class Form1 : MaterialForm
    {
        private readonly Alphy.Form1.IAlphyHost _host;

        private readonly MaterialSkinManager materialSkinManager;
        private List<RlItem> allItems = new List<RlItem>();

        private readonly string baseFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "AlphySwapper");
        private readonly string backendFolder;

        private readonly string pythonScriptPath;
        private readonly string pythonUpkEditorPath;
        private readonly string itemsJsonPath;
        private readonly string keysTxtPath;

        public Form1(Alphy.Form1.IAlphyHost host)
        {
            InitializeComponent();
            _host = host;

            backendFolder = Path.Combine(baseFolder, "Backend");

            pythonScriptPath = Path.Combine(backendFolder, "rl_asset_swapper.py");
            pythonUpkEditorPath = Path.Combine(backendFolder, "rl_upk_editor.py");
            itemsJsonPath = Path.Combine(backendFolder, "items.json");
            keysTxtPath = Path.Combine(backendFolder, "keys.txt");

            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LogToConsole("System: Alphy Swapper Plugin Initializing...");
            Directory.CreateDirectory(baseFolder);
            Directory.CreateDirectory(backendFolder);

            ExtractEmbeddedFiles();
            LoadItemsData();
        }

        private void ExtractEmbeddedFiles()
        {
            try
            {
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
                if (resUpk != null) ExtractResource(resUpk, pythonUpkEditorPath);
                if (resItems != null) ExtractResource(resItems, itemsJsonPath);
                if (resKeys != null) ExtractResource(resKeys, keysTxtPath);
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

        private string GetGamePathFromHost()
        {
            try
            {
                var settingsType = typeof(Alphy.Form1).Assembly.GetType("Alphy.Properties.Settings");
                if (settingsType != null)
                {
                    var defaultProp = settingsType.GetProperty("Default", BindingFlags.Public | BindingFlags.Static);
                    var defaultInstance = defaultProp?.GetValue(null);
                    if (defaultInstance != null)
                    {
                        var gamePathProp = settingsType.GetProperty("GamePath", BindingFlags.Public | BindingFlags.Instance);
                        return gamePathProp?.GetValue(defaultInstance) as string ?? "";
                    }
                }
            }
            catch { }
            return "";
        }

        private void LoadItemsData()
        {
            if (!File.Exists(itemsJsonPath)) return;

            try
            {
                string json = File.ReadAllText(itemsJsonPath);
                var root = JsonConvert.DeserializeObject<RlItemRoot>(json);
                if (root?.Items != null)
                {
                    allItems = root.Items;
                    var categories = allItems.Select(x => x.Slot).Where(s => !string.IsNullOrEmpty(s)).Distinct().OrderBy(s => s).ToList();

                    cmbCategory.Items.Clear();
                    foreach (var category in categories) cmbCategory.Items.Add(category);

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
            foreach (char c in invalidChars) name = name.Replace(c.ToString(), "");
            return name.Trim();
        }

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

            return char.ToUpper(rawSlot[0]) + rawSlot.Substring(1);
        }

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

            string rawCategory = cmbCategory.SelectedItem?.ToString() ?? "Unknown";
            string alphyCategory = MapSlotToAlphyCategory(rawCategory);

            string folderName;
            if (!string.IsNullOrWhiteSpace(txtCustomFolderName.Text))
                folderName = MakeValidFileName(txtCustomFolderName.Text);
            else
            {
                string cleanTargetName = MakeValidFileName(targetSelection.DisplayName);
                string cleanDonorName = MakeValidFileName(donorSelection.DisplayName);
                folderName = $"{cleanDonorName} (Replaces {cleanTargetName})";
            }

            string baseModsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "mods");
            string finalOutDir = Path.Combine(baseModsPath, alphyCategory, folderName);

            Directory.CreateDirectory(finalOutDir);
            LogToConsole($"System: Auto-routing export to -> {alphyCategory}\\{folderName}");

            await Task.Run(() => RunAssetSwapper(targetSelection.Id.ToString(), donorSelection.Id.ToString(), finalOutDir));

            btnSwap.Enabled = true;
            txtCustomFolderName.Text = "";

            _host?.LogToConsole("System: Alphy Swapper generated new mods. Triggering UI refresh...");
            _host?.RefreshModList();
        }

        private void RunAssetSwapper(string targetId, string donorId, string finalOutputDir)
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

                string donorDir = GetGamePathFromHost();
                if (!string.IsNullOrEmpty(donorDir))
                {
                    psi.Arguments += $" --donor-dir \"{donorDir}\"";
                }
                else
                {
                    LogToConsole("WARNING: Alphy GamePath is missing! Swaps may fail.", true);
                }

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
}