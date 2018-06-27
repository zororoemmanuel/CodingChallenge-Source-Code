using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodingChallenge
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string m_filename = string.Empty;
        private string m_string = string.Empty;

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //open file dialog
                OpenFileDialog ofd = new OpenFileDialog();
                //ofd.Filter = ".txt";
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if(!string.IsNullOrEmpty(ofd.FileName))
                    {
                        txtfilename.Text = ofd.FileName;
                        m_filename = ofd.FileName;
                    }
                }

            }
            catch (Exception ex)
                {
                    throw ex;
                }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtStringCode.Text) && !string.IsNullOrEmpty(m_filename))
                {
                    //read the file
                    m_string = txtStringCode.Text.Trim();
                    var content = System.IO.File.ReadAllText(m_filename).Split(',');
                    Dictionary<string, string> match = new Dictionary<string, string>();
                    //logic to match the strings
                    foreach (string code in content)
                    {
                        if (code.Length != m_string.Length)
                        {
                            break;
                        }

                        bool matchfound = false;
                        foreach (char chr in m_string)
                        {
                            if (code.ToUpper().Contains(chr.ToString().ToUpper()))
                                matchfound = true;
                            else
                            {
                                matchfound = false;
                                break;
                            }
                        }
                        if (matchfound)
                        {
                            match.Add(code, m_string);
                        }
                    }
                    if (match.Count() > 0)
                    {
                        string matchfound = "";
                        foreach (var item in match)
                        {
                            matchfound = matchfound + "," + item.Key;
                        }
                        MessageBox.Show("Congratulations The following strings are equivalent to what you entered: " + matchfound);
                    }
                    else
                    {
                        MessageBox.Show("Sorry there are no equivalent strings in this files: ");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                txtfilename.Text = "";
                txtStringCode.Text = "";
            }
        }
    }
}
