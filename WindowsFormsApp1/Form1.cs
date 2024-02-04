using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {


        //グリッドタイトルの色
        public Color G_GRID_TITLE_COLOR = Color.FromKnownColor(KnownColor.Gainsboro);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //InitGridNoDataSource(fg1);
            //InitGridNoDataSourceSort(fg1);
            InitGridDataSource(fg1);
        }

        private void InitGridNoDataSource(System.Windows.Forms.DataGridView dataGrid)
        {
            if (dataGrid != null)
            {

                dataGrid.SuspendLayout();
                // 初期化
                dataGrid.AllowUserToOrderColumns = false;
                dataGrid.AllowUserToDeleteRows = false;
                dataGrid.AllowUserToAddRows = false;
                dataGrid.AllowUserToResizeColumns = false;
                dataGrid.AllowUserToResizeRows = false;
                dataGrid.RowHeadersVisible = false;
                dataGrid.ColumnHeadersVisible = false;
                dataGrid.RowTemplate.Height = 285 / 10;



                dataGrid.RowCount = 4;
                dataGrid.ColumnCount = 3;


                // 第一列の設定
                dataGrid.Columns[0].Width = 50;
                dataGrid.Columns[0].ReadOnly = true;
                dataGrid.Columns[0].DefaultCellStyle.BackColor = G_GRID_TITLE_COLOR;

                // 第二列の設定
                dataGrid.Columns[1].Width = 80;

                // 第三列の設定
                dataGrid.Columns[2].Width = 80;

                // 第一行の設定
                dataGrid.Rows[0].ReadOnly = true;
                dataGrid.Rows[0].DefaultCellStyle.BackColor = G_GRID_TITLE_COLOR;

                // 第一行第一列の設定
                dataGrid.Rows[0].Cells[0].ReadOnly = false;
                dataGrid.Rows[0].Cells[0].Style.BackColor = Color.White;
                dataGrid.Rows[0].Cells[0].Value = "名前";


                dataGrid.Rows[0].Cells[1].Value = "点数";
                dataGrid.Rows[0].Cells[2].Value = "偏差値";

                // 第二行の設定
                dataGrid.Rows[1].Cells[0].Value = "英語";
                dataGrid.Rows[1].Cells[1].Value = "";
                dataGrid.Rows[1].Cells[2].Value = "";

                dataGrid.Rows[2].Cells[0].Value = "物理";
                dataGrid.Rows[2].Cells[1].Value = "";
                dataGrid.Rows[2].Cells[2].Value = "";

                dataGrid.Rows[3].Cells[0].Value = "化学";
                dataGrid.Rows[3].Cells[1].Value = "";
                dataGrid.Rows[3].Cells[2].Value = "";

                dataGrid.ResumeLayout();
            }
        }


        private void InitGridNoDataSourceSort(System.Windows.Forms.DataGridView dataGrid)
        {
            dataGrid.SuspendLayout();
            // 初期化
            dataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGrid.ColumnHeadersHeight = 285 / 10;
            dataGrid.ColumnHeadersDefaultCellStyle.BackColor = G_GRID_TITLE_COLOR;


            dataGrid.AllowUserToOrderColumns = true;
            dataGrid.AllowUserToDeleteRows = true;
            dataGrid.AllowUserToAddRows = false;
            dataGrid.AllowUserToResizeColumns = false;
            dataGrid.AllowUserToResizeRows = false;
            dataGrid.RowHeadersVisible = false;
            dataGrid.ColumnHeadersVisible = true;
            // dataGrid.ColumnHeadersHeight = 20;
            dataGrid.RowTemplate.Height = 285 / 10;



            // AddHandler dataGrid.ColumnHeaderMouseClick, AddressOf DataGridViewCellMouseEventHandler;


            dataGrid.ResumeLayout();


            dataGrid.RowCount = 2;
            dataGrid.ColumnCount = 2;



            dataGrid.Columns[0].Name = "日付";
            dataGrid.Columns[0].SortMode = DataGridViewColumnSortMode.Automatic;
            dataGrid.Columns[0].HeaderCell.Style.BackColor = G_GRID_TITLE_COLOR;
            dataGrid.Columns[0].DefaultCellStyle.BackColor = G_GRID_TITLE_COLOR;


            dataGrid.Columns[1].Name = "イベント";
            // dataGrid.Columns[1].SortMode = DataGridViewColumnSortMode.Automatic;

            dataGrid.Rows[0].Cells[0].Value = 20200101L;
            dataGrid.Rows[0].Cells[1].Value = 1L;
            dataGrid.Rows[1].Cells[0].Value = 20200102L;
            dataGrid.Rows[1].Cells[1].Value = 2L;
        }

        private void InitGridDataSource(System.Windows.Forms.DataGridView dataGrid)
        {
            if(dataGrid!=null)
            {
                string csvFilePath;
                csvFilePath = System.IO.Path.Combine(Application.StartupPath, "TestData.Csv");

                if (System.IO.File.Exists(csvFilePath))
                {
                    // 接続文字列
                    string conString;
                    conString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="
                    + Application.StartupPath + ";Extended Properties=\"text;HDR=Yes;FMT=Delimited\"";

                    System.Data.OleDb.OleDbConnection oleDb;
                    oleDb = new System.Data.OleDb.OleDbConnection(conString);

                    string commText;
                    commText = "SELECT * FROM [" + "TestData.Csv" + "]";

                    System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter;
                    oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(commText, oleDb);

                    DataTable dataTable = new DataTable();
                    oleDbDataAdapter.Fill(dataTable);

                    dataGrid.SuspendLayout();
                    dataGrid.DataSource = dataTable;
                    dataGrid.ResumeLayout();


                }

            }
           
        }
    }
}
