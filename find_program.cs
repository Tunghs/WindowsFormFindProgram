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
            // for문이 종료된 후 일치하는 프로그램이 있다면 check가 true로 변경되고
            // 일치하는 프로그램이 없다면 그대로 false로 유지됨.
            // 프로그램 유무 확인 변수
            string check = "false";

            for (int i = 0; i < pro.Length; i++)
            {
                // MainWindowHandle은 연결된 프로세스의 주 창에 대한 창 핸들을 가져온다.
                if (pro[i].MainWindowHandle != IntPtr.Zero)
                {
                    if (searchValue != "")
                    {
                        // Contains는 대소문자를 구분해서 비교를 하기 때문에
                        // 비교를 위해 모두 소문자로 변경했다.
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
