using Alphy;
using MaterialSkin;
using MaterialSkin.Controls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;

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

        private async void Form1_Load(object sender, EventArgs e)
        {
            LogToConsole("System: Alphy Swapper Plugin Initializing...");

            ToggleUI(false);

            Directory.CreateDirectory(baseFolder);
            Directory.CreateDirectory(backendFolder);

            ExtractEmbeddedFiles();
            LoadItemsData();

            await VerifyPythonDependenciesAsync();

            ToggleUI(true);
        }

        private void ToggleUI(bool isEnabled)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => ToggleUI(isEnabled)));
                return;
            }
            cmbCategory.Enabled = isEnabled;
            cmbTarget.Enabled = isEnabled;
            cmbDonor.Enabled = isEnabled;
            txtCustomFolderName.Enabled = isEnabled;
            btnSwap.Enabled = isEnabled;
        }

        private async Task VerifyPythonDependenciesAsync()
        {
            LogToConsole("System: Verifying Python dependencies...");

            List<string> pythonCommands = new List<string> { "py", "python" };
            string portableExe = Path.Combine(backendFolder, @"python\python.exe");

            if (File.Exists(portableExe))
            {
                pythonCommands.Insert(0, portableExe);
            }

            bool pipSuccess = await RunPythonCommandAsync("-m pip install --upgrade pip", "Checking for pip updates...", pythonCommands);

            if (!pipSuccess)
            {
                LogToConsole("System WARNING: Python not found. Initializing Alphy Portable Python installation...");
                bool portableInstalled = await InstallPortablePythonAsync();

                if (portableInstalled)
                {
                    pythonCommands.Clear();
                    pythonCommands.Add(portableExe);

                    pipSuccess = await RunPythonCommandAsync("-m pip install --upgrade pip", "Checking portable pip...", pythonCommands);
                }
            }

            if (!pipSuccess)
            {
                LogToConsole("System FATAL: Could not install or locate Python. Please report this in the Discord.", true);
                return;
            }
            bool cryptoSuccess = await RunPythonCommandAsync("-m pip install cryptography", "Verifying cryptography package...", pythonCommands);

            if (cryptoSuccess)
                LogToConsole("System: Dependency verification complete. Ready!");
            else
                LogToConsole("System WARNING: Failed to install cryptography package.", true);
        }

        private async Task<bool> InstallPortablePythonAsync()
        {
            string pythonDir = Path.Combine(backendFolder, "python");
            string zipPath = Path.Combine(backendFolder, "python.zip");
            string getPipPath = Path.Combine(backendFolder, "get-pip.py");
            string pythonExe = Path.Combine(pythonDir, "python.exe");

            try
            {
                if (Directory.Exists(pythonDir)) Directory.Delete(pythonDir, true);
                Directory.CreateDirectory(pythonDir);

                using (HttpClient client = new HttpClient())
                {
                    LogToConsole("Downloader: Fetching Portable Python (64-bit, ~8MB)... Please wait.");
                    byte[] pythonBytes = await client.GetByteArrayAsync("https://www.python.org/ftp/python/3.11.9/python-3.11.9-embed-amd64.zip");
                    File.WriteAllBytes(zipPath, pythonBytes);

                    LogToConsole("Downloader: Extracting Python engine...");
                    ZipFile.ExtractToDirectory(zipPath, pythonDir);
                    File.Delete(zipPath);

                    string pthFile = Path.Combine(pythonDir, "python311._pth");
                    string pthContent = File.ReadAllText(pthFile);
                    pthContent = pthContent.Replace("#import site", "import site");
                    File.WriteAllText(pthFile, pthContent);

                    LogToConsole("Downloader: Fetching pip installer script...");
                    byte[] pipBytes = await client.GetByteArrayAsync("https://bootstrap.pypa.io/get-pip.py");
                    File.WriteAllBytes(getPipPath, pipBytes);

                    LogToConsole("Downloader: Installing pip locally... Almost done.");
                    await RunPythonCommandAsync($"\"{getPipPath}\"", "Configuring local environment...", new List<string> { pythonExe });
                    File.Delete(getPipPath);

                    LogToConsole("System: Portable Python successfully installed and isolated!");
                    return true;
                }
            }
            catch (Exception ex)
            {
                LogToConsole($"Downloader Error: {ex.Message}", true);
                return false;
            }
        }

        private async Task<bool> RunPythonCommandAsync(string arguments, string statusMessage, List<string> pythonCommands)
        {
            LogToConsole($"System: {statusMessage}");

            foreach (string cmd in pythonCommands)
            {
                try
                {
                    ProcessStartInfo psi = new ProcessStartInfo
                    {
                        FileName = cmd,
                        Arguments = arguments,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    };

                    using (Process process = new Process { StartInfo = psi })
                    {
                        process.OutputDataReceived += (sender, args) =>
                        {
                            if (string.IsNullOrWhiteSpace(args.Data)) return;
                            if (!args.Data.Contains("Requirement already satisfied"))
                                LogToConsole($"Updater: {args.Data}");
                        };

                        process.ErrorDataReceived += (sender, args) =>
                        {
                            if (string.IsNullOrWhiteSpace(args.Data)) return;
                            if (!args.Data.Contains("WARNING: You are using pip version"))
                                LogToConsole($"Updater Log: {args.Data}");
                        };

                        process.Start();
                        process.BeginOutputReadLine();
                        process.BeginErrorReadLine();

                        await Task.Run(() => process.WaitForExit());

                        if (process.ExitCode == 0) return true;
                    }
                }
                catch (Exception)
                {

                }
            }
            return false;
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

                    var supportedRawSlots = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
                    {
                        "Body", "Decal", "Wheels", "Rocket Boost", "Goal Explosion",
                        "Trail", "Paint Finish", "Player Banner", "Antenna", "Topper", "Boost Audio",
                        "Engine Audio", "Avatar Border"
                    };

                    var categories = allItems.Select(x => x.Slot)
                                             .Where(s => !string.IsNullOrEmpty(s))
                                             .Distinct()
                                             .OrderBy(s => s)
                                             .ToList();

                    cmbCategory.Items.Clear();

                    foreach (var category in categories)
                    {
                        if (supportedRawSlots.Contains(category))
                            cmbCategory.Items.Add(category);
                        else
                            cmbCategory.Items.Add($"{category} ⚠️ (Unsupported)");
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
            string selectedCategory = cmbCategory.SelectedItem?.ToString().Replace(" ⚠️ (Unsupported)", "");
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
            string s = rawSlot.ToLower().Trim();

            if (s == "player banner" || s == "banner") return "Banner";
            if (s.Contains("boost audio") || s.Contains("engineaudio")) return "Boost Audio";
            if (s == "skin" || s == "decal") return "Decal";
            if (s.Contains("goalexplosion") || s.Contains("goal explosion")) return "Goal Explosion";
            if (s == "topper" || s == "hat") return "Hat";
            if (s.Contains("paint")) return "Paint";
            if (s.Contains("boost") && !s.Contains("audio")) return "Boost";
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

            string rawCategory = cmbCategory.SelectedItem?.ToString().Replace(" ⚠️ (Unsupported)", "") ?? "Unknown";
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

            if (message.Contains("UserWarning: You are using cryptography on a 32-bit Python")) return;
            if (message.Contains("from cryptography.hazmat.bindings.openssl import binding")) return;

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