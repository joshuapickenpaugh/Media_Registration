//Joshua Pickenpaugh
//Media Registration File Maker
//051519

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

            //Initialize Tape Movement Combobox:
            cboMovementType.Items.Add("TIN");
            cboMovementType.Items.Add("VIN");
            cboMovementType.Items.Add("MAIL IN");
        }        
        
        //Global var:
        string fileContentsAndPathAndName;
        string pathWithoutFilename;

        //Code for the "Browse" button (browse for local SCAN text file):
        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            // Show the Windows dialog box:
            DialogResult dialogBoxResult = openFileDialog1.ShowDialog();

            // Test result:
            if (dialogBoxResult == DialogResult.OK) 
            {
                fileContentsAndPathAndName = openFileDialog1.FileName;

                //Gets original file path minus the original file name:
                pathWithoutFilename = Path.GetDirectoryName(fileContentsAndPathAndName);

                //Tests for correct ".txt" suffix:
                string fileExtension = Path.GetExtension(fileContentsAndPathAndName);
                if (fileExtension == ".txt")
                {
                    //Displays the filepath and filename in textbox:
                    {
                        txtDisplay.Text = fileContentsAndPathAndName;
                    }
                }
                //If not correct file type, display messagebox:
                else
                {
                    MessageBox.Show("NOT CORRECT FILE TYPE");
                }
            }
        }

        //Code for the "Create File" button:
        private void BtnCreate_Click(object sender, EventArgs e)
        {
            //Gets the user-selected selections:
            string tapeTypeSelected = cboTapeType.GetItemText(cboTapeType.SelectedItem);
            string movementTypeSelected = cboMovementType.GetItemText(cboMovementType.SelectedItem);

            //Reads the filecontents into an array:
            string[] fileContents = File.ReadAllLines(fileContentsAndPathAndName);

            //Instantiated in order to append user selection to VOLSERS in the FOREACH:
            StringBuilder appended = new StringBuilder();

            //Reads through the array, appends the user-selected type of tape to VOLSERS:
            foreach (string filecontent in fileContents)
            {
                appended.Append(filecontent);
                appended.Append(",");
                appended.Append(tapeTypeSelected);
                appended.Append(Environment.NewLine);
            }

            string appendedFileContents = appended.ToString();

            //Creates writer object, names file and path:           
            //Needs to use the original title, up to the first white space.
            StreamWriter sW = new StreamWriter(pathWithoutFilename + "\\" +
                movementTypeSelected + " Media Registration File " + 
                DateTime.Now.ToString("MMddyy") + ".txt");

            //Writes entire, appended file with line breaks to a new file, then closes:
            sW.Write(appendedFileContents);
            sW.Close();

            //Display message to user:
            MessageBox.Show("File Creation Complete!");

            Console.WriteLine("TEST = " + pathWithoutFilename);

            //Closes the app:
            this.Close();

        }
    }
}
    

