using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RichTextBoxDemo
{
    public partial class Form1 : Form
    {
        string fileName = "";
        public Form1()
        {
            InitializeComponent();
            richTextBox1.ContextMenuStrip = contextMenuStrip1;
            richTextBox1.Text = "我们为何用它？无可否认，当读者在浏览一个页面的排版时，难免会被可阅读的内容所分散注意力。Lorem Ipsum的目的就是为了保持字母多多少少标准及平均的分配，而不是“此处有文本，此处有文本”，从而让内容更像可读的英语。如今，很多桌面排版软件以及网页编辑用Lorem Ipsum作为默认的示范文本，搜一搜“Lorem Ipsum”就能找到这些网站的雏形。这些年来Lorem Ipsum演变出了各式各样的版本，有些出于偶然，有些则是故意的（刻意的幽默之类的）";
            richTextBox1.TextChanged += RichTextBox1_TextChanged;
            undoToolStripMenuItem.Enabled = false;
            redoToolStripMenuItem.Enabled = false;
            richTextBox1.LinkClicked += RichTextBox1_LinkClicked;
            
        }

        private void RichTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            if (MessageBox.Show("Do You...") == DialogResult.OK)
            {
                Process.Start(e.LinkText);
            }
            
        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {
            undoToolStripMenuItem.Enabled = richTextBox1.CanUndo;
            redoToolStripMenuItem.Enabled = richTextBox1.CanRedo;
        }

        //Выбор шрифта и цвета
        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog dlg = new FontDialog();
            dlg.Font = richTextBox1.SelectionFont;
            dlg.Color = richTextBox1.SelectionColor;
            dlg.ShowColor = true;
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionColor = dlg.Color;
                richTextBox1.SelectionFont = dlg.Font;
            }

            
        }


        //Отступы
        private void indentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionIndent = 15;
        }

        //маркерованый список 
        private void markerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionBullet = true;
        }

        //Отмена
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        //Отмена отмененого действия
        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        //Открытие файла
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Text Files|*.txt|Rich Text Document|*.rtf|All Files|*.*";
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                fileName = dlg.FileName; 
                if (!string.IsNullOrWhiteSpace(fileName))
                {
                    if (fileName.EndsWith("rtf"))
                    {
                        richTextBox1.LoadFile(fileName, RichTextBoxStreamType.RichText);
                    }
                    else
                    {
                        richTextBox1.LoadFile(fileName, RichTextBoxStreamType.PlainText);
                    }
                }
            }
        }

        //сохранение файла
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine(fileName);
            if (!string.IsNullOrWhiteSpace(fileName))
            {
                if (fileName.EndsWith("rtf"))
                {
                    
                    richTextBox1.SaveFile(fileName, RichTextBoxStreamType.RichText);
                }
                else
                {
                    richTextBox1.SaveFile(fileName, RichTextBoxStreamType.PlainText);
                }
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Text Files|*.txt|Rich Text Document|*.rtf|All Files|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (dlg.FileName.EndsWith("rtf"))
                {
                    richTextBox1.SaveFile(dlg.FileName, RichTextBoxStreamType.RichText);
                }
                else
                {
                    richTextBox1.SaveFile(dlg.FileName, RichTextBoxStreamType.PlainText);
                }
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }





        //Нажатие на ссылку
    }
}
