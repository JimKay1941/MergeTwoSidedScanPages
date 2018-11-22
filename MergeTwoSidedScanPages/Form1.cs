using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MergeTwoSidedScanPages
{
    public partial class Form1 : Form
    {
        private readonly FolderBrowserDialog _chooseSide1FolderDialog = new FolderBrowserDialog();
        private readonly FolderBrowserDialog _chooseSide2FolderDialog = new FolderBrowserDialog();
        private readonly FolderBrowserDialog _chooseOutputFolderDialog = new FolderBrowserDialog();

        public Form1()
        {
            InitializeComponent();
        }

        private void side1Path_Click(object sender, EventArgs e)
        {
            _chooseSide1FolderDialog.ShowDialog();
            textSide1.Text = _chooseSide1FolderDialog.SelectedPath;
        }

        private void side2Path_Click(object sender, EventArgs e)
        {
            _chooseSide2FolderDialog.ShowDialog();
            textSide2.Text = _chooseSide2FolderDialog.SelectedPath;
        }

        private void outputPath_Click(object sender, EventArgs e)
        {
            _chooseOutputFolderDialog.ShowDialog();
            textOutput.Text = _chooseOutputFolderDialog.SelectedPath;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInterleave_Click(object sender, EventArgs e)
        {
            if (textSide1.Text == "")
            {
                textStatus.Text = @"Side1 Path is missing!";
                return;
            }

            if (textSide2.Text == "")
            {
                textStatus.Text = @"Side2 Path is missing!";
                return;
            }

            if (textOutput.Text == "")
            {
                textStatus.Text = @"Output Path is missing!";
                return;
            }

            CopyMoveDirectory(new DirectoryInfo(textSide1.Text), (new DirectoryInfo(textSide2.Text)), textOutput.Text);
        }

        /// <summary>
        ///     Recursive procedure to copy or move folder to another volume
        /// </summary>
        /// <param name="d">DirectoryInfo structure of origin</param>
        /// <param name="destination">Destiny path, including folder</param>
        private void CopyMoveDirectory(DirectoryInfo side1, DirectoryInfo side2, string destination)
        {
            var nameHold = "";

            // Get files.
            var filesS1 = side1.GetFiles();
            var filesS2 = side2.GetFiles();

            int fileNumberS1 = filesS1.Length;
            int fileNumberS2 = filesS2.Length;

            if (fileNumberS1 != fileNumberS2)
            {
                textStatus.Text = @"The Side1 and Side2 directories MUST have the same number of files! Aborting!";
                return;
            }

            try
            {
                int inFileNumber = 0;
                int outFileNumber = 1;
                string strFileNumber1;
                string strFileNumber2;
                string outputFileName1 = "";
                string outputFileName2 = "";

                for (int i = 0; i < filesS1.Length; i++)
                {
                    strFileNumber1 = outFileNumber.ToString();
                    strFileNumber2 = (outFileNumber + 1).ToString();

                    if (strFileNumber1.Length == 1)
                    {
                        outputFileName1 = "Page00" + strFileNumber1.Substring(strFileNumber1.Length - 1, 1) + ".jpg";
                    }

                    else if (strFileNumber1.Length == 2)
                    {
                        outputFileName1 = "Page0" + strFileNumber1.Substring(strFileNumber1.Length - 2, 2) + ".jpg";
                    }

                    else if (strFileNumber1.Length == 3)
                    {
                        outputFileName1 = "Page" + strFileNumber1.Substring(strFileNumber1.Length - 3, 3) + ".jpg";
                    }

                    else
                    {
                        textStatus.Text = @"Output file numbering File1 has an overflow! " + strFileNumber1;
                        return;
                    }

                    if (strFileNumber2.Length == 1)
                    {
                        outputFileName2 = "Page00" + strFileNumber2.Substring(strFileNumber2.Length - 1, 1) + ".jpg";
                    }

                    else if (strFileNumber2.Length == 2)
                    {
                        outputFileName2 = "Page0" + strFileNumber2.Substring(strFileNumber2.Length - 2, 2) + ".jpg";
                    }

                    else if (strFileNumber2.Length == 3)
                    {
                        outputFileName2 = "Page" + strFileNumber2.Substring(strFileNumber2.Length - 3, 3) + ".jpg";
                    }

                    else
                    {
                        textStatus.Text = @"Output file numbering File2 has an overflow! " + strFileNumber2;
                        return;
                    }

                    // Just in case we make no changes
                    var finalOutput1 = destination + "\\" + outputFileName1;
                    var finalOutput2 = destination + "\\" + outputFileName2;

                    filesS1[inFileNumber].CopyTo(finalOutput1);
                    filesS2[inFileNumber].CopyTo(finalOutput2);

                    inFileNumber += 1;
                    outFileNumber += 2;
                }
            }
            catch (PathTooLongException e)
            {
                textStatus.Text = e.Message;
                return;
            }
        }
    }
}
