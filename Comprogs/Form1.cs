using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Comprogs
{
    public partial class Form1 : Form
    {

        List<Person> vault = new List<Person>();
        public Form1()
        {
            InitializeComponent();
        }

        public class Person
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
            public string Gender { get; set; }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "ID";
            dataGridView1.Columns[1].Name = "Name";
            dataGridView1.Columns[2].Name = "Gender";
            dataGridView1.Columns[3].Name = "Age";
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            object cellValue = dataGridView1.Rows[e.RowIndex].Cells[0].Value;
            txtID.Text = Convert.ToString(cellValue);

            object cellValue2 = dataGridView1.Rows[e.RowIndex].Cells[1].Value;
            txtNames.Text = Convert.ToString(cellValue2);

            object cellValue3 = dataGridView1.Rows[e.RowIndex].Cells[2].Value;
            txtGender.Text = Convert.ToString(cellValue3);

            object cellValue4 = dataGridView1.Rows[e.RowIndex].Cells[3].Value;
            txtAge.Text = Convert.ToString(cellValue4);

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            int id = Convert.ToInt32(txtID.Text); 

            Person existingPerson = vault.Find(p => p.ID == id);

            if (existingPerson != null)
            {
                existingPerson.Name = txtNames.Text;
                existingPerson.Gender = txtGender.Text; 
                existingPerson.Age = Convert.ToUInt16(txtAge.Text);
                listBox1.Items[listBox1.SelectedIndex] = existingPerson.Name;
            } 
            else 
            { 
                Person newPerson = new Person() 
                { 
                    ID = id, 
                    Name = txtNames.Text,
                    Gender = txtGender.Text,
                    Age = Convert.ToUInt16(txtAge.Text) 
                }; 
                vault.Add(newPerson); 
                listBox1.Items.Add(newPerson.Name);
            } 
            dataGridView1.Rows.Clear();

            foreach (Person person in vault) 
            { 
                dataGridView1.Rows.Add( 
                    person.ID,
                    person.Name,
                    person.Gender,
                    person.Age); 
            } 
            txtID.Text = "";
            txtNames.Text = ""; 
            txtGender.Text = ""; 
            txtAge.Text = "";

            }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            { 
                string selectedName = listBox1.SelectedItem.ToString(); 
                Person selectedPerson = vault.Find(p => p.Name == selectedName);
                if (selectedPerson != null) 
                { 
                    txtID.Text = selectedPerson.ID.ToString(); 
                    txtNames.Text = selectedPerson.Name;
                    txtGender.Text = selectedPerson.Gender;
                    txtAge.Text = selectedPerson.Age.ToString();
                } 
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                string selectedName = listBox1.SelectedItem.ToString();
                Person personToDelete = vault.Find(p => p.Name == selectedName);
                if (personToDelete != null)
                {
                    vault.Remove(personToDelete);
                    listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                    dataGridView1.Rows.Clear();
                    foreach (Person person in vault)
                    {
                        dataGridView1.Rows.Add(
                            person.ID,
                            person.Name,
                            person.Gender,
                            person.Age);
                    }
                    txtID.Text = "";
                    txtNames.Text = "";
                    txtGender.Text = "";
                    txtAge.Text = "";
                }
            }
        }
    }
}
