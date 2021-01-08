
namespace Macros
{
    partial class Settings
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
            this.comboBox_WindowTitle = new System.Windows.Forms.ComboBox();
            this.button_NewWindowTitle = new System.Windows.Forms.Button();
            this.textBox_WindowTitle = new System.Windows.Forms.TextBox();
            this.label_WindowTitle = new System.Windows.Forms.Label();
            this.label_Trigger = new System.Windows.Forms.Label();
            this.comboBox_Trigger = new System.Windows.Forms.ComboBox();
            this.richTextBox_Responses = new System.Windows.Forms.RichTextBox();
            this.label_Responses = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBox_WindowTitle
            // 
            this.comboBox_WindowTitle.FormattingEnabled = true;
            this.comboBox_WindowTitle.Location = new System.Drawing.Point(13, 13);
            this.comboBox_WindowTitle.Name = "comboBox_WindowTitle";
            this.comboBox_WindowTitle.Size = new System.Drawing.Size(604, 21);
            this.comboBox_WindowTitle.TabIndex = 0;
            this.comboBox_WindowTitle.SelectedIndexChanged += new System.EventHandler(this.LoadSetting);
            // 
            // button_NewWindowTitle
            // 
            this.button_NewWindowTitle.Location = new System.Drawing.Point(623, 13);
            this.button_NewWindowTitle.Name = "button_NewWindowTitle";
            this.button_NewWindowTitle.Size = new System.Drawing.Size(165, 23);
            this.button_NewWindowTitle.TabIndex = 1;
            this.button_NewWindowTitle.Text = "Save New Window Title";
            this.button_NewWindowTitle.UseVisualStyleBackColor = true;
            // 
            // textBox_WindowTitle
            // 
            this.textBox_WindowTitle.Location = new System.Drawing.Point(13, 55);
            this.textBox_WindowTitle.Name = "textBox_WindowTitle";
            this.textBox_WindowTitle.Size = new System.Drawing.Size(604, 20);
            this.textBox_WindowTitle.TabIndex = 2;
            // 
            // label_WindowTitle
            // 
            this.label_WindowTitle.AutoSize = true;
            this.label_WindowTitle.Location = new System.Drawing.Point(623, 58);
            this.label_WindowTitle.Name = "label_WindowTitle";
            this.label_WindowTitle.Size = new System.Drawing.Size(69, 13);
            this.label_WindowTitle.TabIndex = 3;
            this.label_WindowTitle.Text = "Window Title";
            // 
            // label_Trigger
            // 
            this.label_Trigger.AutoSize = true;
            this.label_Trigger.Location = new System.Drawing.Point(623, 96);
            this.label_Trigger.Name = "label_Trigger";
            this.label_Trigger.Size = new System.Drawing.Size(40, 13);
            this.label_Trigger.TabIndex = 5;
            this.label_Trigger.Text = "Trigger";
            // 
            // comboBox_Trigger
            // 
            this.comboBox_Trigger.FormattingEnabled = true;
            this.comboBox_Trigger.Location = new System.Drawing.Point(12, 96);
            this.comboBox_Trigger.Name = "comboBox_Trigger";
            this.comboBox_Trigger.Size = new System.Drawing.Size(604, 21);
            this.comboBox_Trigger.TabIndex = 6;
            this.comboBox_Trigger.SelectedIndexChanged += new System.EventHandler(this.UpdateResponses);
            // 
            // richTextBox_Responses
            // 
            this.richTextBox_Responses.Location = new System.Drawing.Point(13, 140);
            this.richTextBox_Responses.Name = "richTextBox_Responses";
            this.richTextBox_Responses.Size = new System.Drawing.Size(604, 298);
            this.richTextBox_Responses.TabIndex = 7;
            this.richTextBox_Responses.Text = "";
            // 
            // label_Responses
            // 
            this.label_Responses.AutoSize = true;
            this.label_Responses.Location = new System.Drawing.Point(623, 143);
            this.label_Responses.Name = "label_Responses";
            this.label_Responses.Size = new System.Drawing.Size(60, 13);
            this.label_Responses.TabIndex = 8;
            this.label_Responses.Text = "Responses";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label_Responses);
            this.Controls.Add(this.richTextBox_Responses);
            this.Controls.Add(this.comboBox_Trigger);
            this.Controls.Add(this.label_Trigger);
            this.Controls.Add(this.label_WindowTitle);
            this.Controls.Add(this.textBox_WindowTitle);
            this.Controls.Add(this.button_NewWindowTitle);
            this.Controls.Add(this.comboBox_WindowTitle);
            this.Name = "Settings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_WindowTitle;
        private System.Windows.Forms.Button button_NewWindowTitle;
        private System.Windows.Forms.TextBox textBox_WindowTitle;
        private System.Windows.Forms.Label label_WindowTitle;
        private System.Windows.Forms.Label label_Trigger;
        private System.Windows.Forms.ComboBox comboBox_Trigger;
        private System.Windows.Forms.RichTextBox richTextBox_Responses;
        private System.Windows.Forms.Label label_Responses;
    }
}