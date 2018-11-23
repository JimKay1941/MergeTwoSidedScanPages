// This program depends on the Windows 10 (and later?) builtin "Windows Fax and Scan" program which creates files with these names:
// Image (n).jpg
// The length of n varies with the value AND the very first image has NO Number
// This program assumes the user will update the name of the first page image to insert "(1)" because the Windows program starts with the second image.

using System;using System.IO;
using System.Windows.Forms;

namespace MergeTwoSidedScanPages
{
    public partial class Form1 : Form
    {
        private readonly FolderBrowserDialog _chooseSide1FolderDialog = new FolderBrowserDialog();
        private readonly FolderBrowserDialog _chooseSide2FolderDialog = new FolderBrowserDialog();
        private readonly FolderBrowserDialog _chooseOutputFolderDialog = new FolderBrowserDialog();

        // The output files will be named "PageNNN.jpg" and the number of digits (Ns) can be set in the source code.
        //  This setting MUST be sufficient for the total number of output pages or name collisions will occur.
        //  The first collision will halt the program.
        private const int FileNameDigits = 3;

        public Form1()
        {
            InitializeComponent();
        }

        private void Side1Path_Click(object sender, EventArgs e)
        {
            _chooseSide1FolderDialog.ShowDialog();
            textSide1.Text = _chooseSide1FolderDialog.SelectedPath;
        }

        private void Side2Path_Click(object sender, EventArgs e)
        {
            _chooseSide2FolderDialog.ShowDialog();
            textSide2.Text = _chooseSide2FolderDialog.SelectedPath;
        }

        private void OutputPath_Click(object sender, EventArgs e)
        {
            _chooseOutputFolderDialog.ShowDialog();
            textOutput.Text = _chooseOutputFolderDialog.SelectedPath;
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnInterleave_Click(object sender, EventArgs e)
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

            CopyMoveDirectory(new DirectoryInfo(textSide1.Text), new DirectoryInfo(textSide2.Text), textOutput.Text, FileNameDigits);
        }

        /// <summary>
        ///     Procedure to copy or move folder to another volume
        /// </summary>
        /// <param name="side1">DirectoryInfo structure of origin which should contain the side 1 (odd numbered pages) of scanned documents</param>
        /// <param name="side2">DirectoryInfo structure of origin which should contain the side 2 (even numbered pages) of scanned documents</param>
        /// <param name="destination">Destination path, including folder</param>
        /// <param name="fileDigits">this number, set in the calling routine, defines the number of digits in the output name form PageNNN.jpg the number of Ns</param>
        private void CopyMoveDirectory(DirectoryInfo side1, DirectoryInfo side2, string destination, int fileDigits)
        {
            // Get files lists.
            var filesS1 = side1.GetFiles();
            var filesS2 = side2.GetFiles();

            // Get file counts
            var fileNumberS1 = filesS1.Length;
            var fileNumberS2 = filesS2.Length;

            if (fileNumberS1 != fileNumberS2)
            {
                textStatus.Text = @"The Side1 and Side2 directories MUST have the same number of files! Aborting!";
                return;
            }

            try
            {
                for (var i = 0; i < filesS1.Length; i++)
                {
                    char[] delimiter = { '(', ')' };

                    // Algorithm for output page numbers:
                    //  Side1 = (input * 2) - 1 (yields: 1, 3, 5, etc
                    //  Side2 = input * 2       (yields: 2, 4, 6, etc
                    var inputName = filesS1[i].ToString();
                    var substrings = inputName.Split(delimiter);
                    var inputValueSide1 = Convert.ToInt32(substrings[1]);
                    inputValueSide1 = 2 * inputValueSide1 - 1;
                    var working = "000000" + inputValueSide1;
                    var finalS1 = working.Substring(working.Length - fileDigits, fileDigits);
                    var outputFileName1 = "Page" + finalS1 + ".jpg";

                    inputName = filesS2[i].ToString();
                    substrings = inputName.Split(delimiter);
                    var inputValueSide2 = Convert.ToInt32(substrings[1]);
                    inputValueSide2 = 2 * inputValueSide2;
                    working = "000000" + inputValueSide2;
                    var finalS2 = working.Substring(working.Length - fileDigits, fileDigits);
                    var outputFileName2 = "Page" + finalS2 + ".jpg";


                    // Just in case we make no changes
                    var finalOutput1 = destination + "\\" + outputFileName1;
                    var finalOutput2 = destination + "\\" + outputFileName2;

                    filesS1[i].CopyTo(finalOutput1);
                    filesS2[i].CopyTo(finalOutput2);
                }
            }
            catch (PathTooLongException e)
            {
                textStatus.Text = e.Message;
            }
        }
    }
}
