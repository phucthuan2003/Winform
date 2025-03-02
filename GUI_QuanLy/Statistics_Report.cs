using BUS_QuanLy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
//using Utilities.BunifuGradientPanel.Transitions;
using System.Windows.Forms.DataVisualization.Charting;
using DTO_QuanLy;
using OfficeOpenXml;
using System.IO;
using LicenseContext = System.ComponentModel.LicenseContext;

namespace GUI_QuanLy
{
    public partial class Statistics_Report : Form
    {

        private BUS_SalesData salesDataBUS;
        private TabControl tabControl;
        public Statistics_Report()
        {
            InitializeComponent();

            salesDataBUS = new BUS_SalesData();

            // Đăng kí sự kiện ValueChanged cho BunifuDatePicker
            // bunifuDatePicker1.ValueChanged += new EventHandler(bunifuDatePicker1_ValueChanged);

            bunifuDatePicker1.ValueChanged += new EventHandler(DateRangeChanged);
            bunifuDatePicker2.ValueChanged += new EventHandler(DateRangeChanged);

            PannelShow1.Visible = false;

            chart1.Visible = false;

            ConfigureChart();

            btnThongKe.Click += new EventHandler(btnThongKe_Click);
        }

        private void DateRangeChanged(object sender, EventArgs e)
        {
            DateTime startDate = bunifuDatePicker1.Value.Date;
            DateTime endDate = bunifuDatePicker2.Value.Date;

            if (startDate <= endDate)
            {
                ShowOverView(startDate, endDate);
            }
            else
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc.");
            }
        }


        private void ShowOverView(DateTime startDate, DateTime endDate)
        {
            var data = salesDataBUS.GetSalesDataForPeriod(startDate, endDate);

            txtDoanhSo.Text = data.DoanhThu.ToString("N0") + " VNĐ";
            txtSoSanPham.Text = data.SoSanPham.ToString();

            if (data.DoanhThu > 0 || data.SoSanPham > 0)
            {
                PannelShow1.Visible = true;

                var salesDataList = salesDataBUS.GetProductSalesDataForPeriod(startDate, endDate);
                UpdateChart(salesDataList);

                chart1.Visible = true;
                Dvg_Products.Visible = true;
                LoadProductRankingData(startDate, endDate);
            }
            else
            {
                PannelShow1.Visible = true;
                chart1.Visible = false;
                Dvg_Products.Visible = false;
            }
        }

        private void LoadProductRankingData(DateTime startDate, DateTime endDate)
        {
            var products = salesDataBUS.GetProductSalesDataForPeriod(startDate, endDate);
            Dvg_Products.Rows.Clear();

            foreach (var product in products)
            {
                Dvg_Products.Rows.Add(product.Rank, product.ProductInfo, product.Revenue.ToString("C0") + " VNĐ", product.Quantity);
            }
        }


        //private void button1_Click(object sender, EventArgs e)
        //{
        //    DateTime selectDate= bunifuDatePicker1.Value.Date;
        //    GetSalesData(selectDate);
        //}
        //private void GetSalesData(DateTime date)
        //{
        //    string connectionString = "Data Source=DESKTOP-R4RPQKD;Initial Catalog=BTL_6;Integrated Security=True;Encrypt=True";
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();

        //        string query = @"
        //                        SELECT 
        //                            SUM(hb.TongTien) AS DoanhThu, 
        //                            SUM(ct.SoLuong) AS SoSanPham
        //                        FROM HoaDonBan hb
        //                        JOIN ChiTietHoaDonBan ct ON hb.SoHDB = ct.SoHDB
        //                        WHERE hb.NgayBan = @NgayBan";

        //        using (SqlCommand command = new SqlCommand(query, connection))
        //        {
        //            command.Parameters.AddWithValue("@NgayBan", date);

        //            using (SqlDataReader reader = command.ExecuteReader())
        //            {
        //                if (reader.Read())
        //                {
        //                    // Hiển thị kết quả lên TextBox
        //                    txtDoanhSo.Text = reader["DoanhThu"] != DBNull.Value ? reader["DoanhThu"].ToString() : "0";
        //                    txtSoSanPham.Text = reader["SoSanPham"] != DBNull.Value ? reader["SoSanPham"].ToString() : "0";
        //                }
        //                else
        //                {
        //                    txtDoanhSo.Text = "0";
        //                    txtSoSanPham.Text = "0";
        //                }
        //            }
        //        }
        //    }
        //}


        //  private void bunifuDatePicker1_ValueChanged(object sender, EventArgs e)
        // {
        //  DateTime selectDate = bunifuDatePicker1.Value.Date;
        //var result = salesDataBUS.GetSalesData(selectDate);
        //txtDoanhSo.Text = result.DoanhThu.ToString();
        //txtSoSanPham.Text = result.SoSanPham.ToString();

        //PannelShow1.Visible = true;
        //GetSalesData(selectDate);   
        // ShowOverView(selectDate);   

        // DateTime selectDate = bunifuDatePicker1.Value.Date;

        // Hiển thị dữ liệu tổng quan và cập nhật biểu đồ
        //ShowOverView(selectDate);
        //  }

        //private void ShowOverView(DateTime date)
        //{
        //    var data = salesDataBUS.GetSalesData(date);

        //    txtDoanhSo.Text = data.DoanhThu.ToString();
        //    txtSoSanPham.Text = data.SoSanPham.ToString();
        //    PannelShow1.Visible=true;

        //    //UpdateChart(data.DoanhThu , data.SoSanPham , date);
        //    DateTime selectDate = bunifuDatePicker1.Value.Date;    
        //    ShowOverView(selectDate);   
        //}

        //private void ShowOverView(DateTime date)
        //{
        //    // Lấy dữ liệu tổng quan cho ngày được chọn
        //    var data = salesDataBUS.GetSalesData(date);

        //    // Cập nhật các TextBox với dữ liệu tổng quan
        //    txtDoanhSo.Text = data.DoanhThu.ToString();
        //    txtSoSanPham.Text = data.SoSanPham.ToString();

        //    // Hiển thị tổng quan
        //    PannelShow1.Visible = true;

        //    // Lấy dữ liệu 7 ngày gần nhất (bao gồm cả ngày chọn)
        //    var salesDataList = salesDataBUS.GetSalesDataForPeriod(date, 7);

        //    // Cập nhật biểu đồ với dữ liệu 7 ngày
        //    UpdateChart(salesDataList);
        //}

        //private void ShowOverView(DateTime date)
        //{
        //    // Lấy dữ liệu tổng quan cho ngày được chọn
        //    var data = salesDataBUS.GetSalesData(date);

        //    // Cập nhật các TextBox với dữ liệu tổng quan
        //    txtDoanhSo.Text = data.DoanhThu.ToString("N0") + " VNĐ"; // Hiển thị doanh thu
        //    txtSoSanPham.Text = data.SoSanPham.ToString(); // Hiển thị số sản phẩm

        //    // Kiểm tra xem có dữ liệu không
        //    if (data.DoanhThu > 0 || data.SoSanPham > 0)
        //    {
        //        // Hiển thị tổng quan
        //        PannelShow1.Visible = true;

        //        // Lấy dữ liệu 7 ngày gần nhất (bao gồm cả ngày chọn)
        //        var salesDataList = salesDataBUS.GetSalesDataForPeriod(date, 7);

        //        // Cập nhật biểu đồ với dữ liệu 7 ngày
        //        UpdateChart(salesDataList);

        //        // Hiện bảng biểu đồ
        //        chart1.Visible = true; // Đảm bảo bảng biểu đồ được hiển thị
        //        Dvg_Products.Visible = true;
        //    }
        //    else
        //    {
        //        // Nếu không có dữ liệu, ẩn bảng biểu đồ
        //        PannelShow1.Visible = true; // Vẫn hiển thị tổng quan
        //        chart1.Visible = false; // Ẩn bảng biểu đồ nếu không có dữ liệu
        //        Dvg_Products.Visible= false;
        //    }

        //    LoadProductRankingData();
        //}






        //private void ConfiureChart()
        //{
        //    chart1.Series.Clear();

        //    var seriesDoanhThhu = chart1.Series.Add("DoanhThu");
        //    seriesDoanhThhu.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
        //    seriesDoanhThhu.Color = Color.Blue;
        //    seriesDoanhThhu.BorderWidth = 3;

        //    seriesDoanhThhu.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
        //    seriesDoanhThhu.MarkerSize = 5;
        //    seriesDoanhThhu.MarkerColor = Color.Blue;   

        //    var seriesSoSanPham = chart1.Series.Add("SoSanPham");
        //    seriesSoSanPham.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
        //    seriesSoSanPham.Color = Color.Red;
        //    seriesSoSanPham.BorderWidth = 3;   

        //    seriesSoSanPham.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
        //    seriesSoSanPham.MarkerSize = 5; 
        //    seriesSoSanPham.MarkerColor = Color.Red;


        //    // Tùy chỉnh trục X
        //    chart1.ChartAreas[0].AxisX.Title = "Ngày";
        //    chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
        //    chart1.ChartAreas[0].AxisX.Interval = 1;

        //    // Tùy chỉnh trục Y
        //    chart1.ChartAreas[0].AxisY.Title = "Giá trị";
        //    chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
        //}
        //private void UpdateChart(decimal doanhThu , int soSanPham , DateTime date)
        //{
        //    //chart1.Series["DoanhThu"].Points.Clear();
        //    //chart1.Series["SoSanPham"].Points.Clear();

        //    chart1.Series["DoanhThu"].Points.AddXY(date.ToShortDateString(), doanhThu);
        //    chart1.Series["SoSanPham"].Points.AddXY(date.ToShortDateString() , soSanPham);

        //    chart1.Invalidate();
        //}
        //private void UpdateChart(List<BUS_SalesData> salesDataList)
        //{
        //    // Xóa các điểm cũ trên biểu đồ
        //    chart1.Series["DoanhThu"].Points.Clear();
        //    chart1.Series["SoSanPham"].Points.Clear();

        //    // Thêm dữ liệu mới vào biểu đồ
        //    foreach (var data in salesDataList)
        //    {
        //        chart1.Series["DoanhThu"].Points.AddXY(data.Date.ToShortDateString(), data.DoanhThu);
        //        chart1.Series["SoSanPham"].Points.AddXY(data.Date.ToShortDateString(), data.SoSanPham);
        //    }

        //    // Vẽ lại biểu đồ sau khi thêm dữ liệu
        //    chart1.Invalidate();
        //}

        //private void ConfiureChart()
        //{
        //    chart1.Series.Clear();

        //    // Thiết lập series DoanhThu
        //    var seriesDoanhThu = chart1.Series.Add("DoanhThu");
        //    seriesDoanhThu.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
        //    seriesDoanhThu.Color = Color.Blue; // Màu xanh cho doanh thu
        //    seriesDoanhThu.BorderWidth = 2; // Độ dày đường

        //    // Thiết lập marker cho DoanhThu
        //    seriesDoanhThu.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
        //    seriesDoanhThu.MarkerSize = 6; // Kích thước marker
        //    seriesDoanhThu.MarkerColor = Color.Blue;

        //    // Thiết lập series SoSanPham
        //    var seriesSoSanPham = chart1.Series.Add("SoSanPham");
        //    seriesSoSanPham.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
        //    seriesSoSanPham.Color = Color.Red; // Màu đỏ cho số sản phẩm
        //    seriesSoSanPham.BorderWidth = 2; // Độ dày đường

        //    // Thiết lập marker cho SoSanPham
        //    seriesSoSanPham.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
        //    seriesSoSanPham.MarkerSize = 6; // Kích thước marker
        //    seriesSoSanPham.MarkerColor = Color.Red;

        //    // Tùy chỉnh trục X
        //    chart1.ChartAreas[0].AxisX.Title = "Ngày";
        //    chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray; // Màu lưới
        //    chart1.ChartAreas[0].AxisX.Interval = 1; // Khoảng cách giữa các điểm

        //    // Tùy chỉnh trục Y
        //    chart1.ChartAreas[0].AxisY.Title = "Giá trị";
        //    chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray; // Màu lưới

        //    // Thiết lập font cho tiêu đề và trục
        //    chart1.Titles.Add("Biểu đồ Doanh Thu và Số Sản Phẩm");
        //    chart1.Titles[0].Font = new Font("Arial", 14, FontStyle.Bold);
        //    chart1.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Arial", 10);
        //    chart1.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Arial", 10);
        //}

        //private void ConfiureChart()
        //{
        //    chart1.Series.Clear();

        //    // Thiết lập trục Y thứ hai
        //    chart1.ChartAreas[0].AxisY2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;

        //    // Thiết lập series DoanhThu
        //    var seriesDoanhThu = chart1.Series.Add("DoanhThu");
        //    seriesDoanhThu.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine; // Đường
        //    seriesDoanhThu.Color = Color.Blue; // Màu xanh cho doanh thu
        //    seriesDoanhThu.BorderWidth = 2; // Độ dày đường
        //    seriesDoanhThu.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
        //    seriesDoanhThu.MarkerSize = 6; // Kích thước marker
        //    seriesDoanhThu.MarkerColor = Color.Blue;

        //    // Thiết lập series SoSanPham
        //    var seriesSoSanPham = chart1.Series.Add("SoSanPham");
        //    seriesSoSanPham.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine; // Đường
        //    seriesSoSanPham.Color = Color.Red; // Màu đỏ cho số sản phẩm
        //    seriesSoSanPham.BorderWidth = 2; // Độ dày đường
        //    seriesSoSanPham.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
        //    seriesSoSanPham.MarkerSize = 6; // Kích thước marker
        //    seriesSoSanPham.MarkerColor = Color.Red;

        //    // Tùy chỉnh trục X
        //    chart1.ChartAreas[0].AxisX.Title = "Ngày";
        //    chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray; // Màu lưới
        //    chart1.ChartAreas[0].AxisX.Interval = 1; // Khoảng cách giữa các điểm

        //    // Tùy chỉnh trục Y cho DoanhThu
        //    chart1.ChartAreas[0].AxisY.Title = "Doanh Thu";
        //    chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray; // Màu lưới

        //    // Tùy chỉnh trục Y cho SoSanPham
        //    chart1.ChartAreas[0].AxisY2.Title = "Số Sản Phẩm";
        //    chart1.ChartAreas[0].AxisY2.MajorGrid.LineColor = Color.LightGray; // Màu lưới
        //    seriesSoSanPham.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary; // Gán series vào trục Y thứ hai

        //    // Thiết lập khoảng cách của trục Y cho số sản phẩm
        //    chart1.ChartAreas[0].AxisY2.Interval = 2; // Hiển thị theo số nguyên 0, 2, 4,...
        //    chart1.ChartAreas[0].AxisY2.Minimum = 0; // Bắt đầu từ 0
        //    chart1.ChartAreas[0].AxisY2.Maximum = 10; // Thiết lập giá trị tối đa (thay đổi theo nhu cầu)

        //    // Thiết lập label style cho trục Y số sản phẩm
        //    chart1.ChartAreas[0].AxisY2.LabelStyle.IsEndLabelVisible = false; // Ẩn nhãn cuối cùng nếu không cần thiết
        //    chart1.ChartAreas[0].AxisY2.LabelStyle.Font = new Font("Arial", 10); // Font chữ cho nhãn

        //    // Thiết lập font cho tiêu đề và trục
        //    chart1.Titles.Add("Biểu đồ Doanh Thu và Số Sản Phẩm");
        //    chart1.Titles[0].Font = new Font("Arial", 14, FontStyle.Bold);
        //    chart1.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Arial", 10);
        //    chart1.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Arial", 10);
        //    chart1.ChartAreas[0].AxisY2.LabelStyle.Font = new Font("Arial", 10); // Font cho trục Y thứ hai
        //}

        //private void ConfigureChart()
        //{
        //    chart1.Series.Clear();

        //    var seriesDoanhThu = chart1.Series.Add("DoanhThu");
        //    seriesDoanhThu.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
        //    seriesDoanhThu.Color = Color.Blue;
        //    seriesDoanhThu.BorderWidth = 2;
        //    seriesDoanhThu.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
        //    seriesDoanhThu.MarkerSize = 6;
        //    seriesDoanhThu.IsValueShownAsLabel = true;

        //    var seriesSoSanPham = chart1.Series.Add("SoSanPham");
        //    seriesSoSanPham.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
        //    seriesSoSanPham.Color = Color.Red;
        //    seriesSoSanPham.BorderWidth = 2;
        //    seriesSoSanPham.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
        //    seriesSoSanPham.MarkerSize = 6;
        //    seriesSoSanPham.IsValueShownAsLabel = true;
        //    seriesSoSanPham.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
        //    // Tùy chỉnh trục X
        //    chart1.ChartAreas[0].AxisX.Title = "Ngày";
        //    chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
        //    chart1.ChartAreas[0].AxisX.Interval = 1;
        //    chart1.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Arial", 10, FontStyle.Bold);
        //    chart1.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.Black;

        //    // Tùy chỉnh trục Y cho DoanhThu
        //    chart1.ChartAreas[0].AxisY.Title = "Doanh Thu";
        //    chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
        //    chart1.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Arial", 10, FontStyle.Bold);
        //    chart1.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.Blue;

        //    // Tùy chỉnh trục Y cho SoSanPham
        //    chart1.ChartAreas[0].AxisY2.Title = "Số Sản Phẩm";
        //    chart1.ChartAreas[0].AxisY2.MajorGrid.LineColor = Color.LightGray;
        //    chart1.ChartAreas[0].AxisY2.LabelStyle.Font = new Font("Arial", 10, FontStyle.Bold);
        //    chart1.ChartAreas[0].AxisY2.LabelStyle.ForeColor = Color.Red;

        //    // Thiết lập tiêu đề biểu đồ
        //    chart1.Titles.Clear(); // Xóa tiêu đề cũ
        //    chart1.Titles.Add("Biểu đồ Doanh Thu và Số Sản Phẩm");
        //    chart1.Titles[0].Font = new Font("Arial", 16, FontStyle.Bold);
        //    chart1.Titles[0].ForeColor = Color.Black;
        //    chart1.Titles[0].Alignment = ContentAlignment.TopCenter; // Căn giữa tiêu đề

        //    // Thiết lập nền biểu đồ cho phù hợp với giao diện tổng thể
        //    chart1.BackColor = Color.White;
        //    chart1.ChartAreas[0].BackColor = Color.WhiteSmoke; // Màu nền nhẹ hơn cho biểu đồ

        //    // Tùy chỉnh chú thích (Legend)
        //    chart1.Legends[0].BackColor = Color.White; // Màu nền chú thích
        //    chart1.Legends[0].Font = new Font("Arial", 10, FontStyle.Regular);
        //    chart1.Legends[0].ForeColor = Color.Black;

        //    // Tắt các đường lưới không cần thiết nếu muốn tối giản biểu đồ
        //    chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
        //    chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
        //    chart1.ChartAreas[0].AxisY2.MajorGrid.Enabled = true;
        //}

        private void ConfigureChart()
        {
            chart1.Series.Clear();

            var seriesDoanhThu = chart1.Series.Add("DoanhThu");
            seriesDoanhThu.ChartType = SeriesChartType.Line;
            seriesDoanhThu.Color = Color.Blue;
            seriesDoanhThu.BorderWidth = 2;
            seriesDoanhThu.MarkerStyle = MarkerStyle.Circle;
            seriesDoanhThu.MarkerSize = 6;
            seriesDoanhThu.IsValueShownAsLabel = true;

            var seriesSoSanPham = chart1.Series.Add("SoSanPham");
            seriesSoSanPham.ChartType = SeriesChartType.Line;
            seriesSoSanPham.Color = Color.Red;
            seriesSoSanPham.BorderWidth = 2;
            seriesSoSanPham.MarkerStyle = MarkerStyle.Circle;
            seriesSoSanPham.MarkerSize = 6;
            seriesSoSanPham.IsValueShownAsLabel = true;
            seriesSoSanPham.YAxisType = AxisType.Secondary;

            chart1.ChartAreas[0].AxisX.Title = "Ngày";
            chart1.ChartAreas[0].AxisY.Title = "Doanh Thu";
            chart1.ChartAreas[0].AxisY2.Title = "Số Sản Phẩm";
            chart1.Titles.Add("Biểu đồ Doanh Thu và Số Sản Phẩm");
        }

        private void UpdateChart(List<DTO_Product> salesDataList)
        {
            chart1.Series["DoanhThu"].Points.Clear();
            chart1.Series["SoSanPham"].Points.Clear();

            foreach (var data in salesDataList)
            {
                chart1.Series["DoanhThu"].Points.AddXY(data.ProductInfo, data.Revenue);
                chart1.Series["SoSanPham"].Points.AddXY(data.ProductInfo, data.Quantity);
            }

            chart1.Invalidate();
        }

        //private void UpdateChart(List<(DateTime Date, decimal DoanhThu, int SoSanPham)> salesDataList)
        //{
        //    // Xóa các điểm cũ trên biểu đồ
        //    chart1.Series["DoanhThu"].Points.Clear();
        //    chart1.Series["SoSanPham"].Points.Clear();

        //    // Thêm dữ liệu mới vào biểu đồ
        //    foreach (var data in salesDataList)
        //    {
        //        // Thêm điểm doanh thu và lấy điểm dữ liệu
        //        var doanhThuPoint = chart1.Series["DoanhThu"].Points.AddXY(data.Date.ToShortDateString(), data.DoanhThu);
        //        chart1.Series["DoanhThu"].Points[doanhThuPoint].Label = $"{data.DoanhThu:N0}"; // Định dạng với ký hiệu VNĐ

        //        // Thêm điểm số sản phẩm và lấy điểm dữ liệu
        //        var soSanPhamPoint = chart1.Series["SoSanPham"].Points.AddXY(data.Date.ToShortDateString(), data.SoSanPham);
        //        chart1.Series["SoSanPham"].Points[soSanPhamPoint].Label = data.SoSanPham.ToString(); // Hiển thị số sản phẩm (số nguyên)
        //    }

        //    // Vẽ lại biểu đồ sau khi thêm dữ liệu
        //    chart1.Invalidate();
        //}

        //private void UpdateChart(List<(DateTime Date, decimal DoanhThu, int SoSanPham)> salesDataList)
        //{
        //    // Xóa các điểm cũ trên biểu đồ
        //    chart1.Series["DoanhThu"].Points.Clear();
        //    chart1.Series["SoSanPham"].Points.Clear();

        //    // Thêm dữ liệu mới vào biểu đồ
        //    foreach (var data in salesDataList)
        //    {
        //        // Thêm điểm doanh thu và lấy điểm dữ liệu
        //        chart1.Series["DoanhThu"].Points.AddXY(data.Date.ToShortDateString(), data.DoanhThu);

        //        // Thêm điểm số sản phẩm
        //        chart1.Series["SoSanPham"].Points.AddXY(data.Date.ToShortDateString(), data.SoSanPham);
        //    }

        //    // Vẽ lại biểu đồ sau khi thêm dữ liệu
        //    chart1.Invalidate();
        //}






        private void chart1_Validated(object sender, EventArgs e)
        {

        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //private void LoadProductRankingData()
        //{
        //    // Lấy dữ liệu từ BUS
        //    var products = salesDataBUS.GetProductRankingData();

        //    // Làm sạch DataGridView trước khi nạp dữ liệu mới
        //    Dvg_Products.Rows.Clear();

        //    foreach (var product in products)
        //    {
        //        Dvg_Products.Rows.Add(product.Rank, product.ProductInfo, product.Revenue.ToString("C0") + " VNĐ", product.Quantity);
        //    }
        //}

        private void Statistics_Report_Load(object sender, EventArgs e)
        {

            Dvg_Products.Visible = false;
            // Tạo một TabControl mới
           // TabControl tabControl = new TabControl();
            //tabControl.Dock = DockStyle.Fill; // Căn chỉnh full form

            //tabControl.BackColor = No;

            // Tạo TabPage1 - Tổng quan và Thống kê
            TabPage tabPage1 = new TabPage("Tổng quan và Thống kê");


            // Tạo TabPage2 - Biểu đồ
            TabPage tabPage2 = new TabPage("Biểu đồ");


            // Thêm các thành phần vào TabPage1
            Label labelTongQuan = new Label() { Text = "Tổng quan và Thống kê", AutoSize = true, Location = new Point(20, 20) };
            tabPage1.Controls.Add(labelTongQuan);
            //tabPage1.Controls.Add(Dvg_Products);

            // Thêm biểu đồ vào TabPage2
            Chart chart1 = new Chart();
            chart1.Dock = DockStyle.Fill;
            tabPage2.Controls.Add(chart1);

            // Thêm các TabPage vào TabControl
            //tabControl.TabPages.Add(tabPage1);
            //tabControl.TabPages.Add(tabPage2);

            tabControl1.Visible = false;


            // Thêm TabControl vào form
            this.Controls.Add(tabControl);
            //this.tabControl = tabControl;


        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            tabControl1.Visible = true;
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            FormReport report = new FormReport();
            report.Show();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Thiết lập giấy phép phi thương mại cho EPPlus
                        ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                        // Tạo file Excel mới
                        using (ExcelPackage excelPackage = new ExcelPackage())
                        {
                            // Tạo worksheet
                            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Báo Cáo");

                            // Ghi dữ liệu vào các ô
                            worksheet.Cells["A1"].Value = "Thứ hạng";
                            worksheet.Cells["B1"].Value = "Thông tin sản phẩm";
                            worksheet.Cells["C1"].Value = "Doanh thu";
                            worksheet.Cells["D1"].Value = "Số lượng";

                            // Giả sử dữ liệu trong DataGridView Dvg_Products
                            int row = 2; // Bắt đầu từ hàng thứ 2 (hàng 1 là tiêu đề)
                            foreach (DataGridViewRow dataRow in Dvg_Products.Rows)
                            {
                                if (dataRow.IsNewRow) continue;

                                worksheet.Cells[row, 1].Value = dataRow.Cells[0].Value; // Thứ hạng
                                worksheet.Cells[row, 2].Value = dataRow.Cells[1].Value; // Thông tin sản phẩm
                                worksheet.Cells[row, 3].Value = dataRow.Cells[2].Value; // Doanh thu
                                worksheet.Cells[row, 4].Value = dataRow.Cells[3].Value; // Số lượng
                                row++;
                            }

                            // Lưu file Excel
                            FileInfo fi = new FileInfo(sfd.FileName);
                            excelPackage.SaveAs(fi);

                            MessageBox.Show("Xuất báo cáo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Đã xảy ra lỗi khi xuất báo cáo: " + ex.Message);
                    }
                }
            }
        }
    }
}
