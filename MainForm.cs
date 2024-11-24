using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExtractIconBorder
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            selectImageButton.AllowDrop = true;
        }

        private void blackToleranceTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && sourcePictureBox.Image != null)
            {
                convertButton_Click(sender, e);
            }
        }

        private void ignoreBorderTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            blackToleranceTextBox_KeyDown(sender, e);
        }
        private void selectImageButton_Click(object sender, EventArgs e)
        {
            var success = false;
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = Resource.OpenPNGFileFilter;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    sourcePictureBox.Text = Path.GetFileName(openFileDialog.FileName);
                    sourcePictureBox.Image = new Bitmap(openFileDialog.FileName);
                    sourceSizeLabel.Text = sourcePictureBox.Image.Width + @", " + sourcePictureBox.Image.Height;
                    success = true;
                }
            }

            if (success)
            {
                convertButton_Click(sender, e);
            }
        }

        private void sourcePictureBox_Click(object sender, EventArgs e)
        {
            selectImageButton_Click(sender, e);
        }

        private void sourcePictureBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data != null && e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var files = (string[])e.Data.GetData(DataFormats.FileDrop)!;
                if (files.Length > 0 && ImageHelper.IsImageFile(files[0]))
                {
                    e.Effect = DragDropEffects.Copy;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void sourcePictureBox_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data != null)
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop)!;
                if (files.Length > 0)
                {
                    try
                    {

                        sourcePictureBox.Text = Path.GetFileName(files[0]);
                        sourcePictureBox.Image = Image.FromFile(files[0]);
                        sourceSizeLabel.Text = sourcePictureBox.Image.Width + @", " + sourcePictureBox.Image.Height;
                        convertButton_Click(sender, e);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(string.Format(Resource.CanNotLoadImage, ex.Message));
                    }
                }
            }
        }

        private void convertButton_Click(object sender, EventArgs e)
        {
            if (sourcePictureBox.Image == null)
            {
                MessageBox.Show(Resource.ChooseImageFirst);
                return;
            }
            if (GetSetting(out var blackTolerance, out var ignoreBorder))
            {
                var originalBitmap = new Bitmap(sourcePictureBox.Image);
                samplePictureBox.Image = ImageProcessor.ProcessImage(originalBitmap, blackTolerance, ignoreBorder);
                sampleSizeLabel.Text = samplePictureBox.Image.Width + @", " + samplePictureBox.Image.Height;
            }
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (samplePictureBox.Image != null)
            {
                using var saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = Resource.SavePNGFileFilter;
                saveFileDialog.Title = Resource.SaveImage;
                saveFileDialog.FileName = sourcePictureBox.Text;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        samplePictureBox.Image.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                        MessageBox.Show(Resource.SaveImageSuccessWithPath + saveFileDialog.FileName, Resource.SaveSuccessed, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(Resource.SaveImageFailed + ex.Message, Resource.SaveFailed, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show(Resource.NoImageForSave, Resource.SaveFailed, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void samplePictureBox_Click(object sender, EventArgs e)
        {
            saveButton_Click(sender, e);
        }

        private void batchConvertButton_Click(object sender, EventArgs e)
        {
            if (GetSetting(out var blackTolerance, out var ignoreBorder))
            {
                using var openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = Resource.OpenPNGFileFilter;
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using var folderDialog = new FolderBrowserDialog();
                    if (folderDialog.ShowDialog() == DialogResult.OK)
                    {
                        var outputFolder = folderDialog.SelectedPath;
                        var processedFiles = new List<string>();

                        foreach (var filePath in openFileDialog.FileNames)
                        {
                            var originalBitmap = new Bitmap(filePath);
                            var resultBitmap = ImageProcessor.ProcessImage(originalBitmap, blackTolerance, ignoreBorder);

                            var outputFilePath = Path.Combine(outputFolder, Path.GetFileName(filePath));
                            resultBitmap.Save(outputFilePath);
                            processedFiles.Add(outputFilePath);
                        }

                        MessageBox.Show(string.Format(Resource.BatchConvertSuccessed, processedFiles.Count, outputFolder));
                    }
                }
            }
        }

        private bool GetSetting(out int blackTolerance, out int ignoreBorder)
        {
            blackTolerance = 0;
            ignoreBorder = 0;

            if (!int.TryParse(blackToleranceTextBox.Text, out blackTolerance))
            {
                MessageBox.Show(Resource.BlackToleranceMustBeNumber);
                return false;
            }
            else if (!int.TryParse(ignoreBorderTextBox.Text, out ignoreBorder))
            {
                MessageBox.Show(Resource.IgnoreBorderMustBeNumber);
                return false;
            }
            return true;
        }
    }
}