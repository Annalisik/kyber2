using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2


    {
        public partial class Form1 : Form
        {
            private const string FilePath = "tasks.txt"; 

            public Form1()
            {
                InitializeComponent();
            }

            private void MainForm_Load(object sender, EventArgs e)
            {
                LoadTasks(); // Load tasks from file
            }

            private void LoadTasks()
            {
                if (File.Exists(FilePath))
                {
                    string[] tasks = File.ReadAllLines(FilePath);
                    ListBox1.Items.AddRange(tasks); // Add tasks to ListBox
                }
            }

            private void button1_Click(object sender, EventArgs e) // Button "Add"
            {
                string task = TextBox1.Text.Trim();
                if (!string.IsNullOrEmpty(task))
                {
                    ListBox1.Items.Add(task);
                    SaveTasks();
                    TextBox1.Clear();
                }
                else
                {
                    MessageBox.Show("Введите задачу.");
                }
            }

            private void button2_Click(object sender, EventArgs e) // Кнопка "Удалить"
            {
                string taskToRemove = TextBox1.Text.Trim();
                if (!string.IsNullOrEmpty(taskToRemove))
                {
                    for (int i = ListBox1.Items.Count - 1; i >= 0; i--)
                    {
                        if (ListBox1.Items[i].ToString() == taskToRemove)
                        {
                            ListBox1.Items.RemoveAt(i);
                        }
                    }
                    SaveTasks();
                    TextBox1.Clear();
                }
                else
                {
                    MessageBox.Show("Add text to delete.");
                }
            }

            private void button3_Click(object sender, EventArgs e) // Кнопка "Открыть файл"
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                //using (StreamWriter writer = new StreamWriter("tasks.txt"))
                //{
               
                

                openFileDialog.InitialDirectory = "C:\\";
                   openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                  openFileDialog.FilterIndex = 1;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = openFileDialog.FileName;
                        // Читаем содержимое файла и добавляем в ListBox
                        string[] tasks = File.ReadAllLines(filePath);
                        ListBox1.Items.Clear(); // Очищаем существующий список
                        ListBox1.Items.AddRange(tasks); // Добавляем задачи из файла
                    }
                }
            }
    }
    }


