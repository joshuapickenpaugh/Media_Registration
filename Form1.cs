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

            //Reads through the array, appends the user-selected type of tape:
            foreach (string filecontent in fileContents)
            {
                Console.WriteLine(filecontent + "," + selected);
            }

            //Function to make file and make its name to:
            //Bombardier-WichitaKS-500732TIO TIN Media Registration File 010219.txt
            //...get filename, use REGEX to find:
            //first whitespace, then SPACE, then add user-selected tape movement type, then "Media Registration File", 
            //                  then current date in correct format, and correct file type (".txt"), then put in same
            //                  directory as original file. 

            //Test to see if file was created, somehow?
            MessageBox.Show("File Creation Complete!");

        }
    }
}
    

