namespace PlayfairCipher
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.decryptBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.output = new System.Windows.Forms.Label();
            this.deOutput = new System.Windows.Forms.Label();
            this.encryptBtn = new System.Windows.Forms.Button();
            this.keyTextInput = new System.Windows.Forms.TextBox();
            this.encryptionTextInput = new System.Windows.Forms.TextBox();
            this.decryptTextInput = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.editedTextOut = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.encryptedTextOut = new System.Windows.Forms.TextBox();
            this.decryptedTextOut = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // decryptBtn
            // 
            this.decryptBtn.BackColor = System.Drawing.Color.DarkSlateGray;
            resources.ApplyResources(this.decryptBtn, "decryptBtn");
            this.decryptBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.decryptBtn.Name = "decryptBtn";
            this.decryptBtn.UseVisualStyleBackColor = false;
            this.decryptBtn.Click += new System.EventHandler(this.decryptBtn_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // output
            // 
            resources.ApplyResources(this.output, "output");
            this.output.Name = "output";
            // 
            // deOutput
            // 
            resources.ApplyResources(this.deOutput, "deOutput");
            this.deOutput.Name = "deOutput";
            // 
            // encryptBtn
            // 
            this.encryptBtn.BackColor = System.Drawing.Color.DarkSlateGray;
            resources.ApplyResources(this.encryptBtn, "encryptBtn");
            this.encryptBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.encryptBtn.Name = "encryptBtn";
            this.encryptBtn.UseVisualStyleBackColor = false;
            this.encryptBtn.Click += new System.EventHandler(this.encryptBtn_Click);
            this.encryptBtn.Enter += new System.EventHandler(this.encryptBtn_Enter);
            // 
            // keyTextInput
            // 
            resources.ApplyResources(this.keyTextInput, "keyTextInput");
            this.keyTextInput.Name = "keyTextInput";
            this.keyTextInput.Validating += new System.ComponentModel.CancelEventHandler(this.keyTextInput_Validating);
            this.keyTextInput.Validated += new System.EventHandler(this.keyTextInput_Validated);
            // 
            // encryptionTextInput
            // 
            resources.ApplyResources(this.encryptionTextInput, "encryptionTextInput");
            this.encryptionTextInput.Name = "encryptionTextInput";
            // 
            // decryptTextInput
            // 
            resources.ApplyResources(this.decryptTextInput, "decryptTextInput");
            this.decryptTextInput.Name = "decryptTextInput";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dataGridView1, "dataGridView1");
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            // 
            // editedTextOut
            // 
            resources.ApplyResources(this.editedTextOut, "editedTextOut");
            this.editedTextOut.Name = "editedTextOut";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // encryptedTextOut
            // 
            resources.ApplyResources(this.encryptedTextOut, "encryptedTextOut");
            this.encryptedTextOut.Name = "encryptedTextOut";
            // 
            // decryptedTextOut
            // 
            resources.ApplyResources(this.decryptedTextOut, "decryptedTextOut");
            this.decryptedTextOut.Name = "decryptedTextOut";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.Controls.Add(this.decryptedTextOut);
            this.Controls.Add(this.encryptedTextOut);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.editedTextOut);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.decryptTextInput);
            this.Controls.Add(this.encryptionTextInput);
            this.Controls.Add(this.keyTextInput);
            this.Controls.Add(this.encryptBtn);
            this.Controls.Add(this.deOutput);
            this.Controls.Add(this.output);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.decryptBtn);
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button decryptBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label output;
        private System.Windows.Forms.Label deOutput;
        private System.Windows.Forms.Button encryptBtn;
        private System.Windows.Forms.TextBox keyTextInput;
        private System.Windows.Forms.TextBox encryptionTextInput;
        private System.Windows.Forms.TextBox decryptTextInput;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox editedTextOut;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox encryptedTextOut;
        private System.Windows.Forms.TextBox decryptedTextOut;
    }
}

