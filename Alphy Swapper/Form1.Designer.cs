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
            this.btnSwap = new MaterialSkin.Controls.MaterialButton();
            this.tabConsole = new System.Windows.Forms.TabPage();
            this.txtConsole = new System.Windows.Forms.RichTextBox();
            this.materialTabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
            this.materialTabControl1.SuspendLayout();
            this.tabSwapper.SuspendLayout();
            this.materialCard1.SuspendLayout();
            this.tabConsole.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialTabControl1
            // 
            this.materialTabControl1.Controls.Add(this.tabSwapper);
            this.materialTabControl1.Controls.Add(this.tabConsole);
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
            this.tabSwapper.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.tabSwapper.Controls.Add(this.materialCard1);
            this.tabSwapper.Location = new System.Drawing.Point(4, 22);
            this.tabSwapper.Name = "tabSwapper";
            this.tabSwapper.Padding = new System.Windows.Forms.Padding(3);
            this.tabSwapper.Size = new System.Drawing.Size(786, 309);
            this.tabSwapper.TabIndex = 0;
            this.tabSwapper.Text = "SWAPPER";
            // 
            // materialCard1
            // 
            this.materialCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard1.Controls.Add(this.txtCustomFolderName);
            this.materialCard1.Controls.Add(this.cmbDonor);
            this.materialCard1.Controls.Add(this.cmbTarget);
            this.materialCard1.Controls.Add(this.cmbCategory);
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
            this.txtCustomFolderName.AnimateReadOnly = false;
            this.txtCustomFolderName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCustomFolderName.Depth = 0;
            this.txtCustomFolderName.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtCustomFolderName.Hint = "Custom Output Folder Name (Optional)";
            this.txtCustomFolderName.LeadingIcon = null;
            this.txtCustomFolderName.Location = new System.Drawing.Point(17, 203);
            this.txtCustomFolderName.MaxLength = 50;
            this.txtCustomFolderName.MouseState = MaterialSkin.MouseState.OUT;
            this.txtCustomFolderName.Multiline = false;
            this.txtCustomFolderName.Name = "txtCustomFolderName";
            this.txtCustomFolderName.Size = new System.Drawing.Size(434, 50);
            this.txtCustomFolderName.TabIndex = 5;
            this.txtCustomFolderName.Text = "";
            this.txtCustomFolderName.TrailingIcon = null;
            // 
            // cmbDonor
            // 
            this.cmbDonor.AutoResize = false;
            this.cmbDonor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbDonor.Depth = 0;
            this.cmbDonor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbDonor.DropDownHeight = 174;
            this.cmbDonor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDonor.DropDownWidth = 121;
            this.cmbDonor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cmbDonor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmbDonor.FormattingEnabled = true;
            this.cmbDonor.Hint = "Select Donor Item (Item you want)";
            this.cmbDonor.IntegralHeight = false;
            this.cmbDonor.ItemHeight = 43;
            this.cmbDonor.Location = new System.Drawing.Point(17, 137);
            this.cmbDonor.MaxDropDownItems = 4;
            this.cmbDonor.MouseState = MaterialSkin.MouseState.OUT;
            this.cmbDonor.Name = "cmbDonor";
            this.cmbDonor.Size = new System.Drawing.Size(434, 49);
            this.cmbDonor.StartIndex = 0;
            this.cmbDonor.TabIndex = 4;
            // 
            // cmbTarget
            // 
            this.cmbTarget.AutoResize = false;
            this.cmbTarget.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbTarget.Depth = 0;
            this.cmbTarget.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbTarget.DropDownHeight = 174;
            this.cmbTarget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTarget.DropDownWidth = 121;
            this.cmbTarget.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cmbTarget.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmbTarget.FormattingEnabled = true;
            this.cmbTarget.Hint = "Select Target Item (Item you equip)";
            this.cmbTarget.IntegralHeight = false;
            this.cmbTarget.ItemHeight = 43;
            this.cmbTarget.Location = new System.Drawing.Point(17, 72);
            this.cmbTarget.MaxDropDownItems = 4;
            this.cmbTarget.MouseState = MaterialSkin.MouseState.OUT;
            this.cmbTarget.Name = "cmbTarget";
            this.cmbTarget.Size = new System.Drawing.Size(434, 49);
            this.cmbTarget.StartIndex = 0;
            this.cmbTarget.TabIndex = 3;
            // 
            // cmbCategory
            // 
            this.cmbCategory.AutoResize = false;
            this.cmbCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbCategory.Depth = 0;
            this.cmbCategory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbCategory.DropDownHeight = 174;
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.DropDownWidth = 121;
            this.cmbCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cmbCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Hint = "Select Category";
            this.cmbCategory.IntegralHeight = false;
            this.cmbCategory.ItemHeight = 43;
            this.cmbCategory.Location = new System.Drawing.Point(17, 17);
            this.cmbCategory.MaxDropDownItems = 4;
            this.cmbCategory.MouseState = MaterialSkin.MouseState.OUT;
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(434, 49);
            this.cmbCategory.StartIndex = 0;
            this.cmbCategory.TabIndex = 2;
            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);
            // 
            // btnSwap
            // 
            this.btnSwap.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSwap.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnSwap.Depth = 0;
            this.btnSwap.HighEmphasis = true;
            this.btnSwap.Icon = null;
            this.btnSwap.Location = new System.Drawing.Point(594, 217);
            this.btnSwap.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSwap.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSwap.Name = "btnSwap";
            this.btnSwap.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnSwap.Size = new System.Drawing.Size(140, 36);
            this.btnSwap.TabIndex = 0;
            this.btnSwap.Text = "GENERATE SWAP";
            this.btnSwap.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSwap.UseAccentColor = true;
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
            this.tabConsole.Text = "CONSOLE";
            this.tabConsole.UseVisualStyleBackColor = true;
            // 
            // txtConsole
            // 
            this.txtConsole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtConsole.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtConsole.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConsole.ForeColor = System.Drawing.Color.LimeGreen;
            this.txtConsole.Location = new System.Drawing.Point(3, 3);
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.ReadOnly = true;
            this.txtConsole.Size = new System.Drawing.Size(780, 303);
            this.txtConsole.TabIndex = 0;
            this.txtConsole.Text = "";
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
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Sizable = false;
            this.Text = "Alphy Swapper Plugin";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.materialTabControl1.ResumeLayout(false);
            this.tabSwapper.ResumeLayout(false);
            this.materialCard1.ResumeLayout(false);
            this.materialCard1.PerformLayout();
            this.tabConsole.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private System.Windows.Forms.TabPage tabSwapper;
        private System.Windows.Forms.TabPage tabConsole;
        private MaterialSkin.Controls.MaterialTabSelector materialTabSelector1;
        private MaterialSkin.Controls.MaterialCard materialCard1;
        private MaterialSkin.Controls.MaterialButton btnSwap;
        private System.Windows.Forms.RichTextBox txtConsole;
        private MaterialSkin.Controls.MaterialComboBox cmbDonor;
        private MaterialSkin.Controls.MaterialComboBox cmbTarget;
        private MaterialSkin.Controls.MaterialComboBox cmbCategory;
        private MaterialSkin.Controls.MaterialTextBox txtCustomFolderName;
    }
}