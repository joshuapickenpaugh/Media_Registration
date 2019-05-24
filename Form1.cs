//Joshua Pickenpaugh
//Media Registration File Maker
//052419

//Some code borrowed and pieced together from:
//https://www.dotnetperls.com/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace Media_Registration
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //Initialize Tape Type Combobox:
            cboTapeType.Items.Add("9840");
            cboTapeType.Items.Add("LTO3");
            cboTapeType.Items.Add("LTO4");
            cboTapeType.Items.Add("LTO5");
            cboTapeType.Items.Add("Optical Disk");
            cboTapeType.Items.Add("USB Drive");
            cboTapeType.Items.Add("3420 Reel Tape");

            //Initialize Tape Movement Combobox:
            cboMovementType.Items.Add("TIN");
            cboMovementType.Items.Add("VIN");
            cboMovementType.Items.Add("MIN");
            cboMovementType.Items.Add("NTP");
        }

        //Global var:
        string strFileContentsAndPathAndName;
        string strPathWithoutFilename;
        string strFileNameAfterREGEX;
        string strTapeTypeSelected;
        string strMovementTypeSelected;

        //Code for the "Browse" button (browse for local SCAN text file):
        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            // Show the Windows dialog box:
            DialogResult diagDialogBoxResult = openFileDialog1.ShowDialog();

            // Test user selection: 
            if (diagDialogBoxResult == DialogResult.OK)
            {
                strFileContentsAndPathAndName = openFileDialog1.FileName;

                strPathWithoutFilename = Path.GetDirectoryName(strFileContentsAndPathAndName);

                string strfileNameWithoutExtension = Path.GetFileNameWithoutExtension(strFileContentsAndPathAndName);

                //Applies a REGEX to get all characters from start to first space:
                strFileNameAfterREGEX = Regex.Match(strfileNameWithoutExtension, @"([^\s]+)").ToString();

                //Tests for correct ".txt" suffix:
                string strFileExtension = Path.GetExtension(strFileContentsAndPathAndName);
                if (strFileExtension == ".txt")
                {
                    //Displays the filepath and filename in textbox:
                    {
                        txtDisplay.Text = strFileContentsAndPathAndName;
                    }
                }
                //If not correct file type, display messagebox:
                else
                {
                    MessageBox.Show("NOT CORRECT FILE TYPE, PLEASE SELECT AN INBOUND SCAN.TXT FILE");
                }
            }
        }

        //Code for the "Create File" button:
        private void BtnCreate_Click(object sender, EventArgs e)
        {
            //Gets the user-selected types, 'returns' to top of button-click event if no selection made:
            if (cboTapeType.SelectedIndex == -1)
            {
                MessageBox.Show("You must select a Tape Type.");
                return;
            }
            else
            {
                strTapeTypeSelected = cboTapeType.GetItemText(cboTapeType.SelectedItem);
            }

            if (cboMovementType.SelectedIndex == -1)
            {
                MessageBox.Show("You must select a Movement Type.");
                return;
            }
            else
            {
                strMovementTypeSelected = cboMovementType.GetItemText(cboMovementType.SelectedItem);
            }

            //Reads the filecontents into an array:
            string[] aryFileContents = File.ReadAllLines(strFileContentsAndPathAndName);

            //Instantiated in order to append user selection to VOLSERS in the FOREACH:
            StringBuilder sbAppended = new StringBuilder();

            //Reads through the array, appends the user-selected type of tape to VOLSERS:
            foreach (string filecontent in aryFileContents)
            {
                sbAppended.Append(filecontent);
                sbAppended.Append(",");
                sbAppended.Append(strTapeTypeSelected);
                sbAppended.Append(Environment.NewLine);
            }

            string strAppendedFileContents = sbAppended.ToString();

            //Creates writer object, names file and path:            
            StreamWriter sW = new StreamWriter(strPathWithoutFilename + "\\" + strFileNameAfterREGEX +
                " " + strMovementTypeSelected + " Media Registration File " +
                DateTime.Now.ToString("MMddyy") + ".txt");

            //Writes entire, appended file with line breaks to a new file, then closes:
            sW.Write(strAppendedFileContents);
            sW.Close();

            //Display message to user:
            MessageBox.Show("Your new Media Registration file created and placed in " +
                "same folder as your selected SCAN file.");

            //Closes the app:
            this.Close();
        }
    }
}