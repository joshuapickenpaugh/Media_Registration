//Joshua Pickenpaugh
//Media Registration File Maker
//051519

//Some code borrowed and pieced together from:
//https://www.dotnetperls.com/
//...and...
//https://support.microsoft.com/en-us/help/816149/how-to-read-from-and-write-to-a-text-file-by-using-visual-c


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
            cboMovementType.Items.Add("Mail In");
        }        
        
        //Global var:
        string file;

        //Code for the "Browse" button (browse for local SCAN text file):
        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            // Show the Windows dialog box:
            DialogResult result = openFileDialog1.ShowDialog();

            // Test result:
            if (result == DialogResult.OK) 
            {
                file = openFileDialog1.FileName;
                              
                //Tests for correct ".txt" suffix:
                string filePath = Path.GetExtension(file);
                if (filePath == ".txt")
                {
                    //Displays the filepath and filename in textbox:
                    {
                        string text = File.ReadAllText(file);
                        txtDisplay.Text = file;
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
            //Gets the user-selected type of tape:
            string selected = cboTapeType.GetItemText(cboTapeType.SelectedItem);

            //Reads the filecontents into an array:
            string[] fileContents = File.ReadAllLines(file);

            StringBuilder appended = new StringBuilder();

            //Reads through the array, appends the user-selected type of tape:
            foreach (string filecontent in fileContents)
            {
                appended.Append(filecontent);
                appended.Append(",");
                appended.Append(selected);
                appended.Append(Environment.NewLine);
            }

            string appendedFileContents = appended.ToString();
            Console.WriteLine(appendedFileContents);

            //Creates writer object, names file and path (need to work on this...):
            //Need to save to same place in file as original.
            //Need to change name, and add user SELECTED TAPE MOVEMENT & DATE:
            StreamWriter sW = new StreamWriter("C:\\Users\\JoshPickenpaugh\\Desktop\\TEST.txt");

            //Writes entire, appended file with line breaks to a new file:
            sW.Write(appendedFileContents);

            sW.Close();

            MessageBox.Show("File Creation Complete!");

            //Closes the app:
            this.Close();

        }
    }
}
    

