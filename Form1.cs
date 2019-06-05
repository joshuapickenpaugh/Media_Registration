//Joshua Pickenpaugh
//Media Registration File Maker
//060519

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

            //Initialize Tape Type Combobox with content:
            cboTapeType.Items.Add("9840");
            cboTapeType.Items.Add("LTO3");
            cboTapeType.Items.Add("LTO4");
            cboTapeType.Items.Add("LTO5");
            cboTapeType.Items.Add("Optical Disk");
            cboTapeType.Items.Add("USB Drive");
            cboTapeType.Items.Add("3420 Reel Tape");

            //Initialize Tape Movement Combobox with content:
            cboMovementType.Items.Add("TIN");
            cboMovementType.Items.Add("VIN");
            cboMovementType.Items.Add("MIN");
            cboMovementType.Items.Add("NTP");
        }

        //Global vars:
        DialogResult diagDialogBoxResult;
        string strFileContentsAndPathAndName;
        string strPathWithoutFilename;
        string strFileNameAfterREGEX;
        string strTapeTypeSelected;
        string strMovementTypeSelected;
        string strFirstLetterOfTapeType;

        //"BROWSE" button (browse for local SCAN text file):
        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                //Shows the Windows dialog box, assigns user selection:
                diagDialogBoxResult = openFileDialog1.ShowDialog();

                //Test user selection for correct ".txt" suffix: 
                TestUserSelection();

                //Gets file name without the suffix:
                string strfileNameWithoutExtension = Path.GetFileNameWithoutExtension(strFileContentsAndPathAndName);

                //Applies a REGEX to get all characters from start to first space:
                strFileNameAfterREGEX = Regex.Match(strfileNameWithoutExtension, @"([^\s]+)").ToString();
            }
            //If user doesn't select a file:
            catch (ArgumentNullException)
            {
                MessageBox.Show("You must select a file, or close this app manually.");
            }

        }

        //"CREATE FILE" button:
        private void BtnCreate_Click(object sender, EventArgs e)
        {
            //Check to see if user selected an original SCAN file by looking to see if anything is in the textbox:
            string textBox;
            textBox = txtDisplay.Text;
            if (String.IsNullOrEmpty(textBox))
            {
                MessageBox.Show("You must select a FILE.");
                return;
            }

            //After user selects a file:
            else
            {                
                //Gets the user-selected types, 'returns' to the top of this "IF" if nothing selected:
                if (cboTapeType.SelectedIndex == -1)
                {
                    MessageBox.Show("You must select a TAPE TYPE.");
                    return;
                }
                else
                {
                    strTapeTypeSelected = cboTapeType.GetItemText(cboTapeType.SelectedItem);
                    strFirstLetterOfTapeType = Regex.Match(strTapeTypeSelected, @"^[a-zA-Z]").ToString();
                }

                //Gets the user-selected type, 'returns' to the top of the this "IF" if nothing selected:
                if (cboMovementType.SelectedIndex == -1)
                {
                    MessageBox.Show("You must select a MOVEMENT TYPE.");
                    return;
                }
                else
                {
                    strMovementTypeSelected = cboMovementType.GetItemText(cboMovementType.SelectedItem);
                }

                //Appends Volsers with user-selected tape type.
                string strAppendedFileContents = GetAppendedVolserList();

                //Creates the file and saves it:
                CreateFileWithVolsersOnly(strAppendedFileContents);                

                //Display message to user:
                MessageBox.Show("Your new MEDIA REGISTRATION FILE has been created and placed in " +
                    "same folder as your selected SCAN file.");

                //Closes the app:
                this.Close();
            }
        }

        //Test user selection (function from "BROWSE" button): 
        public void TestUserSelection()
        {
            if (diagDialogBoxResult == DialogResult.OK)
            {
                strFileContentsAndPathAndName = openFileDialog1.FileName;

                strPathWithoutFilename = Path.GetDirectoryName(strFileContentsAndPathAndName);

                //Tests for correct ".txt" suffix:
                string strFileExtension = Path.GetExtension(strFileContentsAndPathAndName);
                if (strFileExtension == ".txt")
                {
                    //Displays only the filepath and filename in textbox:                    
                    txtDisplay.Text = strFileContentsAndPathAndName;
                }
                //If not correct file type, display messagebox:
                else
                {
                    MessageBox.Show("NOT CORRECT FILE TYPE, PLEASE SELECT YOUR INBOUND SCAN.TXT FILE");
                }
            }
        }

        //Appends Volsers with user-selected tape type (function from "CREATE FILE" button): 
        public string GetAppendedVolserList()
        {
            //Reads the filecontents into an array:
            string[] aryFileContents = File.ReadAllLines(strFileContentsAndPathAndName);

            //Used to append user-selected tape type to VOLSERS in the FOREACH:
            StringBuilder sbAppended = new StringBuilder();

            //Reads through the array, appends the user-selected type of tape to VOLSERS:
            foreach (string filecontent in aryFileContents)
            {
                sbAppended.Append(filecontent);
                sbAppended.Append(",");
                sbAppended.Append(strTapeTypeSelected);
                sbAppended.Append(Environment.NewLine);
            }

            //Finished, appended VOLSERS with user-selected tape type to each tape:
            string strAppendedFileContents = sbAppended.ToString();

            return strAppendedFileContents;
        }

        //Creates the file and saves it (function from "CREATE FILE" button):
        public void CreateFileWithVolsersOnly(string strAppendedFileContents)
        {
            if (strFirstLetterOfTapeType == "L")
            {
                //...for Bombardier site...if tape is an "LTO", there will be a "1" appended to the filename:
                StreamWriter sW = new StreamWriter(strPathWithoutFilename + "\\" + strFileNameAfterREGEX +
                " " + strMovementTypeSelected + " Media Registration File 1 " +
                DateTime.Now.ToString("MMddyy") + ".txt");

                //Writes entire, appended file with line breaks to a new file, then closes:
                sW.Write(strAppendedFileContents);
                sW.Close();
            }
            else
            {
                StreamWriter sW = new StreamWriter(strPathWithoutFilename + "\\" + strFileNameAfterREGEX +
                " " + strMovementTypeSelected + " Media Registration File " +
                DateTime.Now.ToString("MMddyy") + ".txt");

                //Writes entire, appended file with line breaks to a new file, then closes:
                sW.Write(strAppendedFileContents);
                sW.Close();
            }
        }
    }
}