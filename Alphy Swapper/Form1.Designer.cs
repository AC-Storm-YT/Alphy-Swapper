namespace Alphy2
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            this.tabSwapper = new System.Windows.Forms.TabPage();
            this.materialCard1 = new MaterialSkin.Controls.MaterialCard();
            this.txtCustomFolderName = new MaterialSkin.Controls.MaterialTextBox();
            this.cmbDonor = new MaterialSkin.Controls.MaterialComboBox();
            this.cmbTarget = new MaterialSkin.Controls.MaterialComboBox();
            this.cmbCategory = new MaterialSkin.Controls.MaterialComboBox();
            this.btnRevert = new MaterialSkin.Controls.MaterialButton();
            this.btnSwap = new MaterialSkin.Controls.MaterialButton();
            this.tabConsole = new System.Windows.Forms.TabPage();
            this.txtConsole = new System.Windows.Forms.RichTextBox();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.materialCard2 = new MaterialSkin.Controls.MaterialCard();
            this.btnClearAlphyMods = new MaterialSkin.Controls.MaterialButton();
            this.btnBrowseAlphyMods = new MaterialSkin.Controls.MaterialButton();
            this.txtAlphyModsDir = new MaterialSkin.Controls.MaterialTextBox();
            this.btnBrowseDonor = new MaterialSkin.Controls.MaterialButton();
            this.txtDonorDir = new MaterialSkin.Controls.MaterialTextBox();
            this.btnBrowseOutput = new MaterialSkin.Controls.MaterialButton();
            this.txtOutputDir = new MaterialSkin.Controls.MaterialTextBox();
            this.lblSettingsTitle = new MaterialSkin.Controls.MaterialLabel();
            this.materialTabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
            this.materialTabControl1.SuspendLayout();
            this.tabSwapper.SuspendLayout();
            this.materialCard1.SuspendLayout();
            this.tabConsole.SuspendLayout();
            this.tabSettings.SuspendLayout();
            this.materialCard2.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialTabControl1
            // 
            this.materialTabControl1.Controls.Add(this.tabSwapper);
            this.materialTabControl1.Controls.Add(this.tabConsole);
            this.materialTabControl1.Controls.Add(this.tabSettings);
            this.materialTabControl1.Depth = 0;
            this.materialTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialTabControl1.Location = new System.Drawing.Point(3, 112);
            this.materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl1.Multiline = true;
            this.materialTabControl1.Name = "materialTabControl1";
            this.materialTabControl1.SelectedIndex = 0;
            this.materialTabControl1.Size = new System.Drawing.Size(794, 335);
            this.materialTabControl1.TabIndex = 0;
            // 
            // tabSwapper
            // 
            this.tabSwapper.Controls.Add(this.materialCard1);
            this.tabSwapper.Location = new System.Drawing.Point(4, 22);
            this.tabSwapper.Name = "tabSwapper";
            this.tabSwapper.Padding = new System.Windows.Forms.Padding(3);
            this.tabSwapper.Size = new System.Drawing.Size(786, 309);
            this.tabSwapper.TabIndex = 0;
            this.tabSwapper.Text = "Asset Swapper";
            this.tabSwapper.UseVisualStyleBackColor = true;
            // 
            // materialCard1
            // 
            this.materialCard1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard1.Controls.Add(this.txtCustomFolderName);
            this.materialCard1.Controls.Add(this.cmbDonor);
            this.materialCard1.Controls.Add(this.cmbTarget);
            this.materialCard1.Controls.Add(this.cmbCategory);
            this.materialCard1.Controls.Add(this.btnRevert);
            this.materialCard1.Controls.Add(this.btnSwap);
            this.materialCard1.Depth = 0;
            this.materialCard1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard1.Location = new System.Drawing.Point(17, 17);
            this.materialCard1.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard1.Name = "materialCard1";
            this.materialCard1.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard1.Size = new System.Drawing.Size(752, 275);
            this.materialCard1.TabIndex = 0;
            // 
            // txtCustomFolderName
            // 
            this.txtCustomFolderName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCustomFolderName.AnimateReadOnly = false;
            this.txtCustomFolderName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCustomFolderName.Depth = 0;
            this.txtCustomFolderName.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtCustomFolderName.Hint = "Optional: Custom Name (e.g. My Custom Fennec)";
            this.txtCustomFolderName.LeadingIcon = null;
            this.txtCustomFolderName.Location = new System.Drawing.Point(17, 153);
            this.txtCustomFolderName.MaxLength = 100;
            this.txtCustomFolderName.MouseState = MaterialSkin.MouseState.OUT;
            this.txtCustomFolderName.Multiline = false;
            this.txtCustomFolderName.Name = "txtCustomFolderName";
            this.txtCustomFolderName.Size = new System.Drawing.Size(718, 50);
            this.txtCustomFolderName.TabIndex = 9;
            this.txtCustomFolderName.Text = "";
            this.txtCustomFolderName.TrailingIcon = null;
            // 
            // cmbDonor
            // 
            this.cmbDonor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDonor.AutoResize = false;
            this.cmbDonor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbDonor.Depth = 0;
            this.cmbDonor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbDonor.DropDownHeight = 432;
            this.cmbDonor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDonor.DropDownWidth = 121;
            this.cmbDonor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cmbDonor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmbDonor.FormattingEnabled = true;
            this.cmbDonor.Hint = "3. Replace With (e.g. Fennec)";
            this.cmbDonor.IntegralHeight = false;
            this.cmbDonor.ItemHeight = 43;
            this.cmbDonor.Location = new System.Drawing.Point(435, 85);
            this.cmbDonor.MaxDropDownItems = 10;
            this.cmbDonor.MouseState = MaterialSkin.MouseState.OUT;
            this.cmbDonor.Name = "cmbDonor";
            this.cmbDonor.Size = new System.Drawing.Size(300, 49);
            this.cmbDonor.StartIndex = 0;
            this.cmbDonor.TabIndex = 8;
            // 
            // cmbTarget
            // 
            this.cmbTarget.AutoResize = false;
            this.cmbTarget.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbTarget.Depth = 0;
            this.cmbTarget.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbTarget.DropDownHeight = 432;
            this.cmbTarget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTarget.DropDownWidth = 121;
            this.cmbTarget.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cmbTarget.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmbTarget.FormattingEnabled = true;
            this.cmbTarget.Hint = "2. Item to Replace (e.g. Octane)";
            this.cmbTarget.IntegralHeight = false;
            this.cmbTarget.ItemHeight = 43;
            this.cmbTarget.Location = new System.Drawing.Point(17, 85);
            this.cmbTarget.MaxDropDownItems = 10;
            this.cmbTarget.MouseState = MaterialSkin.MouseState.OUT;
            this.cmbTarget.Name = "cmbTarget";
            this.cmbTarget.Size = new System.Drawing.Size(300, 49);
            this.cmbTarget.StartIndex = 0;
            this.cmbTarget.TabIndex = 7;
            // 
            // cmbCategory
            // 
            this.cmbCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCategory.AutoResize = false;
            this.cmbCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbCategory.Depth = 0;
            this.cmbCategory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbCategory.DropDownHeight = 432;
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.DropDownWidth = 121;
            this.cmbCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cmbCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Hint = "1. Select Category (e.g. Body)";
            this.cmbCategory.IntegralHeight = false;
            this.cmbCategory.ItemHeight = 43;
            this.cmbCategory.Location = new System.Drawing.Point(17, 17);
            this.cmbCategory.MaxDropDownItems = 10;
            this.cmbCategory.MouseState = MaterialSkin.MouseState.OUT;
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(718, 49);
            this.cmbCategory.StartIndex = 0;
            this.cmbCategory.TabIndex = 6;
            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);
            // 
            // btnRevert
            // 
            this.btnRevert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRevert.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRevert.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnRevert.Depth = 0;
            this.btnRevert.HighEmphasis = false;
            this.btnRevert.Icon = null;
            this.btnRevert.Location = new System.Drawing.Point(660, 219);
            this.btnRevert.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnRevert.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRevert.Name = "btnRevert";
            this.btnRevert.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnRevert.Size = new System.Drawing.Size(75, 36);
            this.btnRevert.TabIndex = 3;
            this.btnRevert.Text = "REVERT";
            this.btnRevert.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnRevert.UseAccentColor = true;
            this.btnRevert.UseVisualStyleBackColor = true;
            this.btnRevert.Click += new System.EventHandler(this.btnRevert_Click);
            // 
            // btnSwap
            // 
            this.btnSwap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSwap.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSwap.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnSwap.Depth = 0;
            this.btnSwap.HighEmphasis = true;
            this.btnSwap.Icon = null;
            this.btnSwap.Location = new System.Drawing.Point(466, 219);
            this.btnSwap.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSwap.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSwap.Name = "btnSwap";
            this.btnSwap.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnSwap.Size = new System.Drawing.Size(177, 36);
            this.btnSwap.TabIndex = 2;
            this.btnSwap.Text = "Execute Asset Swap";
            this.btnSwap.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSwap.UseAccentColor = false;
            this.btnSwap.UseVisualStyleBackColor = true;
            this.btnSwap.Click += new System.EventHandler(this.btnSwap_Click);
            // 
            // tabConsole
            // 
            this.tabConsole.Controls.Add(this.txtConsole);
            this.tabConsole.Location = new System.Drawing.Point(4, 22);
            this.tabConsole.Name = "tabConsole";
            this.tabConsole.Padding = new System.Windows.Forms.Padding(3);
            this.tabConsole.Size = new System.Drawing.Size(786, 309);
            this.tabConsole.TabIndex = 1;
            this.tabConsole.Text = "Console output";
            this.tabConsole.UseVisualStyleBackColor = true;
            // 
            // txtConsole
            // 
            this.txtConsole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtConsole.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtConsole.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConsole.ForeColor = System.Drawing.Color.LightGreen;
            this.txtConsole.Location = new System.Drawing.Point(3, 3);
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.ReadOnly = true;
            this.txtConsole.Size = new System.Drawing.Size(780, 303);
            this.txtConsole.TabIndex = 0;
            this.txtConsole.Text = "";
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.materialCard2);
            this.tabSettings.Location = new System.Drawing.Point(4, 22);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Size = new System.Drawing.Size(786, 309);
            this.tabSettings.TabIndex = 2;
            this.tabSettings.Text = "Settings";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // materialCard2
            // 
            this.materialCard2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialCard2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard2.Controls.Add(this.btnClearAlphyMods);
            this.materialCard2.Controls.Add(this.btnBrowseAlphyMods);
            this.materialCard2.Controls.Add(this.txtAlphyModsDir);
            this.materialCard2.Controls.Add(this.btnBrowseDonor);
            this.materialCard2.Controls.Add(this.txtDonorDir);
            this.materialCard2.Controls.Add(this.btnBrowseOutput);
            this.materialCard2.Controls.Add(this.txtOutputDir);
            this.materialCard2.Controls.Add(this.lblSettingsTitle);
            this.materialCard2.Depth = 0;
            this.materialCard2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard2.Location = new System.Drawing.Point(14, 14);
            this.materialCard2.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard2.Name = "materialCard2";
            this.materialCard2.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard2.Size = new System.Drawing.Size(756, 266);
            this.materialCard2.TabIndex = 0;
            // 
            // btnClearAlphyMods
            // 
            this.btnClearAlphyMods.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearAlphyMods.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClearAlphyMods.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnClearAlphyMods.Depth = 0;
            this.btnClearAlphyMods.HighEmphasis = false;
            this.btnClearAlphyMods.Icon = null;
            this.btnClearAlphyMods.Location = new System.Drawing.Point(575, 198);
            this.btnClearAlphyMods.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnClearAlphyMods.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnClearAlphyMods.Name = "btnClearAlphyMods";
            this.btnClearAlphyMods.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnClearAlphyMods.Size = new System.Drawing.Size(66, 36);
            this.btnClearAlphyMods.TabIndex = 7;
            this.btnClearAlphyMods.Text = "CLEAR";
            this.btnClearAlphyMods.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnClearAlphyMods.UseAccentColor = true;
            this.btnClearAlphyMods.UseVisualStyleBackColor = true;
            this.btnClearAlphyMods.Click += new System.EventHandler(this.btnClearAlphyMods_Click);
            // 
            // btnBrowseAlphyMods
            // 
            this.btnBrowseAlphyMods.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseAlphyMods.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBrowseAlphyMods.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnBrowseAlphyMods.Depth = 0;
            this.btnBrowseAlphyMods.HighEmphasis = true;
            this.btnBrowseAlphyMods.Icon = null;
            this.btnBrowseAlphyMods.Location = new System.Drawing.Point(659, 198);
            this.btnBrowseAlphyMods.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnBrowseAlphyMods.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnBrowseAlphyMods.Name = "btnBrowseAlphyMods";
            this.btnBrowseAlphyMods.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnBrowseAlphyMods.Size = new System.Drawing.Size(80, 36);
            this.btnBrowseAlphyMods.TabIndex = 6;
            this.btnBrowseAlphyMods.Text = "BROWSE";
            this.btnBrowseAlphyMods.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnBrowseAlphyMods.UseAccentColor = false;
            this.btnBrowseAlphyMods.UseVisualStyleBackColor = true;
            this.btnBrowseAlphyMods.Click += new System.EventHandler(this.btnBrowseAlphyMods_Click);
            // 
            // txtAlphyModsDir
            // 
            this.txtAlphyModsDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAlphyModsDir.AnimateReadOnly = false;
            this.txtAlphyModsDir.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAlphyModsDir.Depth = 0;
            this.txtAlphyModsDir.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtAlphyModsDir.Hint = "Alphy Mods Directory (Optional - Auto structures exports)";
            this.txtAlphyModsDir.LeadingIcon = null;
            this.txtAlphyModsDir.Location = new System.Drawing.Point(17, 198);
            this.txtAlphyModsDir.MaxLength = 300;
            this.txtAlphyModsDir.MouseState = MaterialSkin.MouseState.OUT;
            this.txtAlphyModsDir.Multiline = false;
            this.txtAlphyModsDir.Name = "txtAlphyModsDir";
            this.txtAlphyModsDir.ReadOnly = true;
            this.txtAlphyModsDir.Size = new System.Drawing.Size(540, 36);
            this.txtAlphyModsDir.TabIndex = 5;
            this.txtAlphyModsDir.Text = "";
            this.txtAlphyModsDir.TrailingIcon = null;
            this.txtAlphyModsDir.UseTallSize = false;
            // 
            // btnBrowseDonor
            // 
            this.btnBrowseDonor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseDonor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBrowseDonor.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnBrowseDonor.Depth = 0;
            this.btnBrowseDonor.HighEmphasis = true;
            this.btnBrowseDonor.Icon = null;
            this.btnBrowseDonor.Location = new System.Drawing.Point(659, 128);
            this.btnBrowseDonor.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnBrowseDonor.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnBrowseDonor.Name = "btnBrowseDonor";
            this.btnBrowseDonor.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnBrowseDonor.Size = new System.Drawing.Size(80, 36);
            this.btnBrowseDonor.TabIndex = 4;
            this.btnBrowseDonor.Text = "BROWSE";
            this.btnBrowseDonor.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnBrowseDonor.UseAccentColor = false;
            this.btnBrowseDonor.UseVisualStyleBackColor = true;
            this.btnBrowseDonor.Click += new System.EventHandler(this.btnBrowseDonor_Click);
            // 
            // txtDonorDir
            // 
            this.txtDonorDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDonorDir.AnimateReadOnly = false;
            this.txtDonorDir.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDonorDir.Depth = 0;
            this.txtDonorDir.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtDonorDir.Hint = "Game Files Directory (e.g. C:\\Games\\RocketLeague\\TAGame\\CookedPCConsole)";
            this.txtDonorDir.LeadingIcon = null;
            this.txtDonorDir.Location = new System.Drawing.Point(17, 128);
            this.txtDonorDir.MaxLength = 300;
            this.txtDonorDir.MouseState = MaterialSkin.MouseState.OUT;
            this.txtDonorDir.Multiline = false;
            this.txtDonorDir.Name = "txtDonorDir";
            this.txtDonorDir.ReadOnly = true;
            this.txtDonorDir.Size = new System.Drawing.Size(620, 36);
            this.txtDonorDir.TabIndex = 3;
            this.txtDonorDir.Text = "";
            this.txtDonorDir.TrailingIcon = null;
            this.txtDonorDir.UseTallSize = false;
            // 
            // btnBrowseOutput
            // 
            this.btnBrowseOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseOutput.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBrowseOutput.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnBrowseOutput.Depth = 0;
            this.btnBrowseOutput.HighEmphasis = true;
            this.btnBrowseOutput.Icon = null;
            this.btnBrowseOutput.Location = new System.Drawing.Point(659, 58);
            this.btnBrowseOutput.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnBrowseOutput.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnBrowseOutput.Name = "btnBrowseOutput";
            this.btnBrowseOutput.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnBrowseOutput.Size = new System.Drawing.Size(80, 36);
            this.btnBrowseOutput.TabIndex = 2;
            this.btnBrowseOutput.Text = "BROWSE";
            this.btnBrowseOutput.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnBrowseOutput.UseAccentColor = false;
            this.btnBrowseOutput.UseVisualStyleBackColor = true;
            this.btnBrowseOutput.Click += new System.EventHandler(this.btnBrowseOutput_Click);
            // 
            // txtOutputDir
            // 
            this.txtOutputDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutputDir.AnimateReadOnly = false;
            this.txtOutputDir.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtOutputDir.Depth = 0;
            this.txtOutputDir.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtOutputDir.Hint = "Fallback Output Directory (Used if Alphy Mods directory is cleared)";
            this.txtOutputDir.LeadingIcon = null;
            this.txtOutputDir.Location = new System.Drawing.Point(17, 58);
            this.txtOutputDir.MaxLength = 300;
            this.txtOutputDir.MouseState = MaterialSkin.MouseState.OUT;
            this.txtOutputDir.Multiline = false;
            this.txtOutputDir.Name = "txtOutputDir";
            this.txtOutputDir.ReadOnly = true;
            this.txtOutputDir.Size = new System.Drawing.Size(620, 36);
            this.txtOutputDir.TabIndex = 1;
            this.txtOutputDir.Text = "";
            this.txtOutputDir.TrailingIcon = null;
            this.txtOutputDir.UseTallSize = false;
            // 
            // lblSettingsTitle
            // 
            this.lblSettingsTitle.AutoSize = true;
            this.lblSettingsTitle.Depth = 0;
            this.lblSettingsTitle.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblSettingsTitle.Location = new System.Drawing.Point(17, 14);
            this.lblSettingsTitle.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblSettingsTitle.Name = "lblSettingsTitle";
            this.lblSettingsTitle.Size = new System.Drawing.Size(183, 19);
            this.lblSettingsTitle.TabIndex = 0;
            this.lblSettingsTitle.Text = "Mod Export Configuration";
            // 
            // materialTabSelector1
            // 
            this.materialTabSelector1.BaseTabControl = this.materialTabControl1;
            this.materialTabSelector1.CharacterCasing = MaterialSkin.Controls.MaterialTabSelector.CustomCharacterCasing.Normal;
            this.materialTabSelector1.Depth = 0;
            this.materialTabSelector1.Dock = System.Windows.Forms.DockStyle.Top;
            this.materialTabSelector1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialTabSelector1.Location = new System.Drawing.Point(3, 64);
            this.materialTabSelector1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabSelector1.Name = "materialTabSelector1";
            this.materialTabSelector1.Size = new System.Drawing.Size(794, 48);
            this.materialTabSelector1.TabIndex = 1;
            this.materialTabSelector1.Text = "materialTabSelector1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.materialTabControl1);
            this.Controls.Add(this.materialTabSelector1);
            this.MinimumSize = new System.Drawing.Size(800, 450);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alphy Swapper";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.materialTabControl1.ResumeLayout(false);
            this.tabSwapper.ResumeLayout(false);
            this.materialCard1.ResumeLayout(false);
            this.materialCard1.PerformLayout();
            this.tabConsole.ResumeLayout(false);
            this.tabSettings.ResumeLayout(false);
            this.materialCard2.ResumeLayout(false);
            this.materialCard2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private System.Windows.Forms.TabPage tabSwapper;
        private System.Windows.Forms.TabPage tabConsole;
        private System.Windows.Forms.TabPage tabSettings;
        private MaterialSkin.Controls.MaterialTabSelector materialTabSelector1;
        private MaterialSkin.Controls.MaterialCard materialCard1;
        private MaterialSkin.Controls.MaterialButton btnRevert;
        private MaterialSkin.Controls.MaterialButton btnSwap;
        private System.Windows.Forms.RichTextBox txtConsole;
        private MaterialSkin.Controls.MaterialComboBox cmbDonor;
        private MaterialSkin.Controls.MaterialComboBox cmbTarget;
        private MaterialSkin.Controls.MaterialComboBox cmbCategory;
        private MaterialSkin.Controls.MaterialCard materialCard2;
        private MaterialSkin.Controls.MaterialButton btnBrowseOutput;
        private MaterialSkin.Controls.MaterialTextBox txtOutputDir;
        private MaterialSkin.Controls.MaterialLabel lblSettingsTitle;
        private MaterialSkin.Controls.MaterialButton btnBrowseDonor;
        private MaterialSkin.Controls.MaterialTextBox txtDonorDir;
        private MaterialSkin.Controls.MaterialButton btnClearAlphyMods;
        private MaterialSkin.Controls.MaterialButton btnBrowseAlphyMods;
        private MaterialSkin.Controls.MaterialTextBox txtAlphyModsDir;
        private MaterialSkin.Controls.MaterialTextBox txtCustomFolderName;
    }
}