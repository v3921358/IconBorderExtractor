namespace ExtractIconBorder
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            selectImageButton = new Button();
            batchConvertButton = new Button();
            sourcePictureBox = new PictureBox();
            convertButton = new Button();
            samplePictureBox = new PictureBox();
            label1 = new Label();
            sourceSizeLabel = new Label();
            sampleSizeLabel = new Label();
            label2 = new Label();
            blackToleranceTextBox = new TextBox();
            label4 = new Label();
            ignoreBorderTextBox = new TextBox();
            saveButton = new Button();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)sourcePictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)samplePictureBox).BeginInit();
            SuspendLayout();
            // 
            // selectImageButton
            // 
            selectImageButton.Image = Resource.plus;
            resources.ApplyResources(selectImageButton, "selectImageButton");
            selectImageButton.Name = "selectImageButton";
            selectImageButton.UseVisualStyleBackColor = true;
            selectImageButton.Click += selectImageButton_Click;
            // 
            // batchConvertButton
            // 
            resources.ApplyResources(batchConvertButton, "batchConvertButton");
            batchConvertButton.Name = "batchConvertButton";
            batchConvertButton.UseVisualStyleBackColor = true;
            batchConvertButton.Click += batchConvertButton_Click;
            // 
            // sourcePictureBox
            // 
            sourcePictureBox.BorderStyle = BorderStyle.FixedSingle;
            sourcePictureBox.Cursor = Cursors.Hand;
            resources.ApplyResources(sourcePictureBox, "sourcePictureBox");
            sourcePictureBox.Name = "sourcePictureBox";
            sourcePictureBox.TabStop = false;
            sourcePictureBox.Click += sourcePictureBox_Click;
            sourcePictureBox.DragDrop += sourcePictureBox_DragDrop;
            sourcePictureBox.DragEnter += sourcePictureBox_DragEnter;
            // 
            // convertButton
            // 
            convertButton.Image = Resource.arrow;
            resources.ApplyResources(convertButton, "convertButton");
            convertButton.Name = "convertButton";
            convertButton.UseVisualStyleBackColor = true;
            convertButton.Click += convertButton_Click;
            // 
            // samplePictureBox
            // 
            samplePictureBox.BorderStyle = BorderStyle.FixedSingle;
            samplePictureBox.Cursor = Cursors.Hand;
            resources.ApplyResources(samplePictureBox, "samplePictureBox");
            samplePictureBox.Name = "samplePictureBox";
            samplePictureBox.TabStop = false;
            samplePictureBox.Click += samplePictureBox_Click;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // sourceSizeLabel
            // 
            resources.ApplyResources(sourceSizeLabel, "sourceSizeLabel");
            sourceSizeLabel.Name = "sourceSizeLabel";
            // 
            // sampleSizeLabel
            // 
            resources.ApplyResources(sampleSizeLabel, "sampleSizeLabel");
            sampleSizeLabel.Name = "sampleSizeLabel";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // blackToleranceTextBox
            // 
            resources.ApplyResources(blackToleranceTextBox, "blackToleranceTextBox");
            blackToleranceTextBox.Name = "blackToleranceTextBox";
            blackToleranceTextBox.KeyDown += blackToleranceTextBox_KeyDown;
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.Name = "label4";
            // 
            // ignoreBorderTextBox
            // 
            resources.ApplyResources(ignoreBorderTextBox, "ignoreBorderTextBox");
            ignoreBorderTextBox.Name = "ignoreBorderTextBox";
            ignoreBorderTextBox.KeyDown += ignoreBorderTextBox_KeyDown;
            // 
            // saveButton
            // 
            saveButton.Image = Resource.disk;
            resources.ApplyResources(saveButton, "saveButton");
            saveButton.Name = "saveButton";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // MainForm
            // 
            AllowDrop = true;
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label3);
            Controls.Add(saveButton);
            Controls.Add(ignoreBorderTextBox);
            Controls.Add(label4);
            Controls.Add(blackToleranceTextBox);
            Controls.Add(label2);
            Controls.Add(sampleSizeLabel);
            Controls.Add(sourceSizeLabel);
            Controls.Add(label1);
            Controls.Add(samplePictureBox);
            Controls.Add(convertButton);
            Controls.Add(sourcePictureBox);
            Controls.Add(batchConvertButton);
            Controls.Add(selectImageButton);
            Name = "MainForm";
            DragDrop += sourcePictureBox_DragDrop;
            DragEnter += sourcePictureBox_DragEnter;
            ((System.ComponentModel.ISupportInitialize)sourcePictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)samplePictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button selectImageButton;
        private Button batchConvertButton;
        private PictureBox sourcePictureBox;
        private Button convertButton;
        private PictureBox samplePictureBox;
        private Label label1;
        private Label sourceSizeLabel;
        private Label sampleSizeLabel;
        private Label label2;
        private TextBox blackToleranceTextBox;
        private Label label4;
        private TextBox ignoreBorderTextBox;
        private Button saveButton;
        private Label label3;
    }
}