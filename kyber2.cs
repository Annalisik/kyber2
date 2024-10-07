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
            private const string FilePath = "todolist.txt"; // Путь по умолчанию для сохранения задач

            public Form1()
            {
                InitializeComponent();
            }

            private void MainForm_Load(object sender, EventArgs e)
            {
                LoadTasks(); // На загрузке формы загружаем задачи
            }

            private void LoadTasks()
            {
                if (File.Exists(FilePath))
                {
                    string[] tasks = File.ReadAllLines(FilePath);
                    ListBox1.Items.AddRange(tasks); // Добавляем задачи в ListBox
                }
            }

            private void button1_Click(object sender, EventArgs e) // Кнопка "Добавить"
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
                    MessageBox.Show("Введите текст задачи для удаления.");
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

            private void SaveTasks()
            {
                File.WriteAllLines(FilePath, ListBox1.Items.Cast<string>());
            }

            private void textBox1_TextChanged(object sender, EventArgs e) // Событие изменения текста
            {
                // Здесь можно добавить код, если что-то должно произойти при изменении текста
            }

            private void listBox1_SelectedIndexChanged(object sender, EventArgs e) // Событие выбора элемента
            {
                // Можно добавить код, если нужно что-то сделать при изменении выбора в ListBox
            }


          

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
    }


