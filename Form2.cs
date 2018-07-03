using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Data.SqlClient;
using 车检器;

using Microsoft.Office.Core;
using Microsoft.Office.Interop.Excel;






namespace WindowsFormsApplication2
{

    public partial class Form2 : Form
    {
        SqlDataAdapter myda;
        DataSet myds;
        SqlConnection cn;
        public Form2()
        {
          InitializeComponent();
       
        }
        
        //连接导入
     

       //查询
        private void button1_Click(object sender, EventArgs e)
        {

            string con;
            con = "Data Source=127.0.0.1,1433;initial catalog=GSZ_KKDB;user id=sa;pwd=123456;";

            String strSQL = String.Format("select  EquipID as 设备 ,EquipAddress as '设备地址',LandId as '车道号',CurrentStatus as 当前工作状态 ,AvgSpd1 as '平均车速(小货车)',Forward1 as '正向流量(小货车)',Reverse1 as '逆向流量(小货车)', Occupancy1 as '占有率(小货车)', AvgSpd2 as '平均车速(中货车 )', Forward2 as '正向流量(中货车 )',Reverse2 as '逆向流量(中货车 )', Occupancy2 as '占有率(中货车 )',AvgSpd3 as '平均车速(大货车)',Forward3 as '正向流量(大货车)',Reverse3 as '逆向流量(大货车)', Occupancy3 as '占有率(大货车)',AvgSpd4 as '平均车速(小客车)',Forward4 as '正向流量(小客车)',Reverse4 as '逆向流量(小客车)', Occupancy4 as '占有率(小客车)',AvgSpd5 as '平均车速(大客车)',Forward5 as '正向流量( 大客车 )',Reverse5 as '逆向流量( 大客车 )', Occupancy5 as '占有率( 大客车 )',GatherDate as '数据采集日期',GatherTime as '数据采集时间',CreateDate as '创建日期' ,CreateTime as '创建时间' from T_VD_Data_Raw where GatherDate > '{0}-{1}-{2}' and GatherDate < '{3}-{4}-{5}'",
            dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day,
            dateTimePicker2.Value.Year, dateTimePicker2.Value.Month, dateTimePicker2.Value.Day);



            
            cn = db.Camcon(); //建立连接
            cn.Open();    // 打开数据库
            myda = new SqlDataAdapter(strSQL, con);
            myds = new DataSet();
            myda.Fill(myds, "T_VD_Data_Raw");
            dataGridView1.DataSource = myds.Tables["T_VD_Data_Raw"];//把容器放在列表
        }
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

     

        private void Form2_Load(object sender, EventArgs e)
        {

        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


            //MessageBox.Show("车道号");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {





        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        //Excel 写入调用写入函数
        private void button3_Click(object sender, EventArgs e)
        {

            DataSetToExcel(myds.Tables["T_VD_Data_Raw"], true);
            

        }

       //数据导入excel
        public bool DataSetToExcel(System.Data.DataTable dataTable, bool isShowExcle)
        {
            //datatble 
           // System.Data.DataTable dataTable = dataSet.Tables[0];
            int rowNumber = dataTable.Rows.Count;
            int columnNumber = dataTable.Columns.Count;

            if (rowNumber == 0)
            {
                MessageBox.Show("没有任何数据可以导入到Excel文件！");
                return false;
            }

            //建立Excel对象 
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Application.Workbooks.Add(true);
            excel.Visible = isShowExcle;//是否打开该Excel文件 


            if (excel != null)
            {
                MessageBox.Show("  EXCEL启动成功  )", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //return false;
            }

            if (excel == null)
            {
                MessageBox.Show("EXCEL无法启动！(可能您没有安装EXCEL，或者版本与本程序不符)", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            //填充数据 
            for (int c = 0; c < rowNumber; c++)
            {
                for (int j = 0; j < columnNumber-5; j++)
                {
                    excel.Cells[c + 1, j + 1] = dataTable.Rows[c].ItemArray[j];
                }
            }
            return true;
        }



        private void button2_Click(object sender, EventArgs e)
        {




        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void statusStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void statusStrip2_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void 金山大道AToolStripMenuItem_Click(object sender, EventArgs e)
        {
        //    string con;
        //    con = "Data Source=127.0.0.1,1433;initial catalog=GSZ_KKDB;user id=sa;pwd=123456;";

        //    String strSQL = String.Format("select  EquipID as 设备 ,EquipAddress as '设备地址',LandId as '车道号',CurrentStatus as 当前工作状态 ,AvgSpd1 as '平均车速(小货车)',Forward1 as '正向流量(小货车)',Reverse1 as '逆向流量(小货车)', Occupancy1 as '占有率(小货车)', AvgSpd2 as '平均车速(中货车 )', Forward2 as '正向流量(中货车 )',Reverse2 as '逆向流量(中货车 )', Occupancy2 as '占有率(中货车 )',AvgSpd3 as '平均车速(大货车)',Forward3 as '正向流量(大货车)',Reverse3 as '逆向流量(大货车)', Occupancy3 as '占有率(大货车)',AvgSpd4 as '平均车速(小客车)',Forward4 as '正向流量(小客车)',Reverse4 as '逆向流量(小客车)', Occupancy4 as '占有率(小客车)',AvgSpd5 as '平均车速(大客车)',Forward5 as '正向流量( 大客车 )',Reverse5 as '逆向流量( 大客车 )', Occupancy5 as '占有率( 大客车 )',GatherDate as '数据采集日期',GatherTime as '数据采集时间',CreateDate as '创建日期' ,CreateTime as '创建时间' from T_VD_Data_Raw where GatherDate > '{0}-{1}-{2}' and GatherDate < '{3}-{4}-{5}'",
        //    dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day,
        //    dateTimePicker2.Value.Year, dateTimePicker2.Value.Month, dateTimePicker2.Value.Day);
        //    // new SqlConnection(con);
        //    SqlConnection cn = db.Camcon(); //建立连接
        //    cn.Open();    // 打开数据库
        //    SqlDataAdapter myda = new SqlDataAdapter(strSQL, con);
        //    myds = new DataSet();
        //    myda.Fill(myds, "T_VD_Data_Raw");

        //   // dataGridView1.DataSource = myds.Tables["T_VD_Data_Raw"];//把容器放在列表
           
        //    DataRow[] drs2 = myds.Tables["T_VD_Data_Raw"].Select("EquipAddress='金山大道A' ");
        ////    myds = new DataSet();
        //    //    myda.Fill(drs2);
            
        //    dataGridView1.DataSource = drs2;//把容器放在列表

        }

        private void 以Excel格式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
         //   DataSetToExcel(myds.Tables["T_VD_Data_Raw"], true);
        }

        private void 日报表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }



    }
}
