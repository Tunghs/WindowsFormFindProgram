using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace SearchProgram_for_List
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process[] pro = Process.GetProcesses();

            var searchValue = textBox1.Text;
            searchValue = searchValue.ToLower();
            // 검색할때마다 리스트박스 초기화
            listBox1.Items.Clear();
            string check = "false";

            for (int i = 0; i < pro.Length; i++)
            {
                if (pro[i].MainWindowHandle != IntPtr.Zero)
                {
                    if (searchValue != "")
                    {
                        string name = pro[i].MainWindowTitle.ToLower();
                        if (name.Contains(searchValue))
                        {
                            if (pro[i].MainWindowTitle == "")
                            {
                                continue;
                            }
                            listBox1.Items.Add(pro[i].MainWindowTitle);
                            check = "true";
                        }
                    }
                    else
                    {
                        if (pro[i].MainWindowTitle == "")
                        {
                            continue;
                        }
                        listBox1.Items.Add(pro[i].MainWindowTitle);
                        check = "true";
                    }
                    
                }
            }
            if (check == "false")
            {
                listBox1.Items.Add("일치하는 프로그램이 없습니다.");
            }
        }
    }
}
