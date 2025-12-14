using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Лабораторная1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            words_comboBox();

            button1.Click += wordOfSentence;
            button2.Click += addWordInlistBox1;
            button3.Click += editWordInlistBox1;
            button4.Click += deleteWordInlistBox1;
            button5.Click += addRadioToStart;
            button6.Click += addRadioToEnd;
            button7.Click += (s, e) => AddItem();
            button8.Click += (s, e) => EditItem();
            button9.Click += (s, e) => DeleteItem();

            comboBox1.DropDownStyle = ComboBoxStyle.DropDown; 
            comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;

            comboBox1.DropDown += comboBox1_DropDown;



        }

        private void words_comboBox()
        {
            comboBox1.BeginUpdate();
            comboBox1.Items.Add("император");
            comboBox1.Items.Add("полководец");
            comboBox1.Items.Add("воин");
            comboBox1.EndUpdate();

            comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private string GetAdv_For()
        {
           foreach (Control control in groupBox1.Controls)
            {
                if (control is RadioButton radiobutton && radiobutton.Checked)
                {
                    return radiobutton.Text; 
                }
            }
            return "";
        }

        private void wordOfSentence(object sender, EventArgs e)
        {
            string adj = listBox1.SelectedItem?.ToString();
            string noun = comboBox1.SelectedItem?.ToString();
            string adv = GetAdv_For();

            if (adj != null && noun != null && adv != null && adv != "")
            {
                label1.Text = adj + " " + noun + " " + adv;
            }
            else
            {
                MessageBox.Show("Выберите все элементы");
            }
        }

        private void addWordInlistBox1(object sender, EventArgs e)
        {
            string newWord = capitalizeIfChecked(textBox1.Text);
            if (newWord.Length > 0)
            {
                listBox1.Items.Add(newWord);
                textBox1.Clear();
            }
        }

        private void editWordInlistBox1(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            string newWord = textBox1.Text;

            if (index >= 0 && index < listBox1.Items.Count && newWord.Length > 0)
            {
                newWord = capitalizeIfChecked(newWord);
                listBox1.Items[index] = newWord;
                textBox1.Clear();
            }
        }

        private void deleteWordInlistBox1(Object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            if (index >= 0)
            {
                listBox1.Items.RemoveAt(index);
                textBox1.Clear();
            }
        }

        private string capitalizeIfChecked(string word)
        {
            if (checkBox1.Checked && word.Length > 0)
            {
                word = char.ToUpper(word[0]) + word.Substring(1); 
            }
            return word;
        }

        private void addRadioToEnd(object sender, EventArgs e)
        {
            string word = textBox2.Text.Trim();
            if (word.Length == 0) return;

            RadioButton rb = new RadioButton();
            rb.Text = word;
            rb.AutoSize = true;

            
            int y = 10 + groupBox1.Controls.Count * 25; 
            rb.Location = new Point(10, y);

            groupBox1.Controls.Add(rb);

            textBox2.Clear();

        }

        private void addRadioToStart(object sender, EventArgs e)
        {
            string word = textBox2.Text.Trim();
            if (word.Length == 0) return;

            RadioButton rb = new RadioButton();
            rb.Text = word;
            rb.AutoSize = true;

            foreach (Control ctrl in groupBox1.Controls)
            {
                ctrl.Top += 25; 
            }

            rb.Location = new Point(10, 10);

            groupBox1.Controls.Add(rb);

            groupBox1.Controls.SetChildIndex(rb, 0);

            textBox2.Clear();
        }
        private void AddItem()
        {
            string text = comboBox1.Text.Trim();
            if (!string.IsNullOrEmpty(text) && !comboBox1.Items.Contains(text))
            {
                comboBox1.Items.Add(text);
                comboBox1.Text = ""; 
            }
        }

        private void EditItem()
        {
            int index = comboBox1.SelectedIndex;
            string text = comboBox1.Text;
            if (index >= 0 && !string.IsNullOrEmpty(text))
            {
                comboBox1.Items[index] = text;
            }
        }

        private void DeleteItem()
        {
            int index = comboBox1.SelectedIndex;
            if (index >= 0)
            {
                comboBox1.Items.RemoveAt(index);
                comboBox1.Text = "";
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.I | Keys.Alt | Keys.Shift))
            {
                AddItem();
                return true; 
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            MessageBox.Show($"Список содержит {comboBox1.Items.Count} элементов");
        }

    }

}
