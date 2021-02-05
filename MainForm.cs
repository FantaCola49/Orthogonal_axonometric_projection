using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace ModelDesigner
{
    public partial class MainForm : Form
    {
        List<Point3D> _points = new List<Point3D>();
        List<Line> _lines = new List<Line>();

        bool IsBuild = false;

        static double kSize = 0.82f;
        static double scale = 3.0f;
        static double rad = 30 / 180f * (float)Math.PI;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            dtgPoints.RowsAdded += DataGridView_RowsAdded;
            dtgLines.RowsAdded += DataGridView_RowsAdded;

            dtgPoints.RowsRemoved += DataGridView_RowsRemoved;
            dtgLines.RowsRemoved += DataGridView_RowsRemoved;

            btnBuildAxonom.Click += BuildOrthogonalProjection;
            btnBuildAxonom.Click += BuildAxonometry;

            picOrhtog.MouseWheel += PicOnMouseWheel;
            picAxon.MouseWheel += PicOnMouseWheel;

            dtgPoints.DataError += delegate { };
            dtgLines.DataError += delegate { };

            tabControl1.SelectedIndexChanged += MainForm_Resize;
        }

        private void PicOnMouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                scale += 0.04f;
            }
            else
            {
                if (Math.Round(scale, 1) == 0) return;

                scale = Math.Abs(scale - 0.04f);
            }
            if (scale < 0)
                scale = 0;
            MainForm_Resize(sender, e);
            lblScale.Text = lblScale.Text.Substring(0, 6) + " " + Math.Round(scale, 2);
        }

        // Sort table counter for points
        private void DataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {

            if (sender is DataGridView)
            {
                var dtg = sender as DataGridView;
                if (dtg.Rows.Count > 0)
                {
                    var numVal = 0;
                    for (int i = 0; i < dtg.Rows.Count - 1; i++)
                    {
                        var row = dtg.Rows[i].Cells[0].Value = numVal++;
                    }
                }
            }
        }

        // Update first column counter in table
        private void DataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (e.RowCount > 0)
            {
                if (sender is DataGridView)
                {
                    var dtg = sender as DataGridView;
                    int maxCount = 0;
                    int result = 0;
                    for (int i = 0; i < dtg.Rows.Count - 1; i++)
                    {
                        var row = dtg.Rows[i];
                        if (int.TryParse(row.Cells[0].FormattedValue.ToString(), out result) && i != e.RowIndex - 1)
                        {
                            if (result >= maxCount) maxCount = ++result;
                        }
                    }
                    dtg.Rows[dtg.Rows.Count - 1].Cells[0].Value = maxCount;
                }
            }
        }

        #region DataGridView Points
        // Clear structs
        private void btnClearPoints_Click(object sender, EventArgs e)
        {
            _points.Clear();
            _lines.Clear();

            dtgPoints.Rows.Clear();
            dtgLines.Rows.Clear();

            IsBuild = false;
        }

        // Set list pf Points
        private void btnSetPoints_Click(object sender, EventArgs e)
        {
            if (!(sender is UserControl))
                _points.Clear();

            if (dtgPoints.Rows.Count > 1)
            {
                for (int i = 0; i < dtgPoints.Rows.Count - 1; i++)
                {
                    var currentRow = dtgPoints.Rows[i];

                    float X, Y, Z;

                    if (HasCorrectIntCell(currentRow.Cells[1], out X) &&
                        HasCorrectIntCell(currentRow.Cells[2], out Y) &&
                        HasCorrectIntCell(currentRow.Cells[3], out Z))
                    {
                        int index = Convert.ToInt32(currentRow.Cells[0].Value);
                        if (!(sender is UserControl)) _points.Add(new Point3D(index: index, x: X, y: Y, z: Z));
                    }
                    else
                    {
                        _points.Clear();
                        return;
                    }
                }
                SetDataSourcePoint();
                MessageBox.Show("Точки добавлены!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                _points.Clear();
                MessageBox.Show("Добавьте точки!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Set data source for comboboxs
        private void SetDataSourcePoint()
        {
            if (_points.Count > 1)
            {
                var cmbPoints = (DataGridViewComboBoxColumn)dtgLines.Columns[1];
                cmbPoints.DataSource = _points.Select(x => x.Index.ToString()).ToArray().ToList();

                cmbPoints = (DataGridViewComboBoxColumn)dtgLines.Columns[2];
                cmbPoints.DataSource = _points.Select(x => x.Index.ToString()).ToArray().ToList();
            }
        }

        // Cheack cells format
        private bool HasCorrectIntCell(DataGridViewCell cell, out float result)
        {
            result = 0;
            var _temp = 0;
            try
            {
                if (int.TryParse(cell.Value.ToString(), out _temp))
                {
                    result = _temp;
                    return true;
                }
                else
                {
                    MessageBox.Show("Ошибка формата координат точек!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Ошибка формата координат точек!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }
        #endregion

        #region DataGridView Lines
        // Clear structs
        private void btnClearLines_Click(object sender, EventArgs e)
        {
            _lines.Clear();
            dtgLines.Rows.Clear();
            IsBuild = false;
        }

        private void btnSetLines_Click(object sender, EventArgs e)
        {
            _lines.Clear();
            try
            {
                if (dtgLines.Rows.Count > 1)
                {
                    for (int i = 0; i < dtgLines.Rows.Count - 1; i++)
                    {
                        var currentRow = dtgLines.Rows[i];

                        if (string.IsNullOrEmpty(currentRow.Cells[1].FormattedValue.ToString()) ||
                            string.IsNullOrEmpty(currentRow.Cells[2].FormattedValue.ToString()))
                        {
                            MessageBox.Show("Ошибка формата выбранных точек!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        var point1Index = _points.First(x => x.Index == Convert.ToInt32(currentRow.Cells[1].Value));
                        var point2Index = _points.First(x => x.Index == Convert.ToInt32(currentRow.Cells[2].Value));

                        if (point1Index == point2Index)
                        {
                            MessageBox.Show("Некоторые линии образуют точку!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        if (Convert.ToInt32(currentRow.Cells[1].Value) >= 0 && Convert.ToInt32(currentRow.Cells[2].Value) >= 0)
                        {
                            int index = Convert.ToInt32(currentRow.Cells[0].Value);

                            var point1 = _points.First(x => x.Index == Convert.ToInt32(currentRow.Cells[1].Value));
                            var point2 = _points.First(x => x.Index == Convert.ToInt32(currentRow.Cells[2].Value));

                            _lines.Add(new Line(point1, point2));
                        }
                        else
                        {
                            return;
                        }
                    }
                    MessageBox.Show("Линии добавлены!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Добавьте линии!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch { }
        }
        #endregion

        #region Other
        private void BuildAxonometry(object sender, EventArgs e)
        {
            try
            {
                IsBuild = true;

                int cX = (picAxon.Width > picAxon.Height) ? picAxon.Width : picAxon.Height;
                int cY = (picAxon.Width < picAxon.Height) ? picAxon.Width : picAxon.Height;

                int x0 = cX / 2;
                int y0 = cY / 2;

                Bitmap image = new Bitmap(picAxon.Width, picAxon.Height);
                Graphics g = Graphics.FromImage(image);
                Pen pen = new Pen(Color.Black);

                // xyz
                g.DrawString("X", new Font("Arial", 12.0f), new SolidBrush(Color.ForestGreen), new PointF(0, cY - 200));
                g.DrawString("Z", new Font("Arial", 12.0f), new SolidBrush(Color.ForestGreen), new PointF(cX / 2 + 10, 0));
                g.DrawString("Y", new Font("Arial", 12.0f), new SolidBrush(Color.ForestGreen), new PointF((float)(x0 * 2 - 30),
                    (float)(y0 - 175 + Math.Sin(rad) * cY)));

                // axis
                g.DrawLine(pen, x0, y0,
                  (float)(x0 - Math.Cos(rad) * 2000 * kSize),
                   (float)(y0 + Math.Sin(rad) * 2000 * kSize));
                g.DrawLine(pen, x0, y0, (float)cX / 2, 0);
                g.DrawLine(pen, x0, y0,
                    (float)(x0 + Math.Cos(rad) * 2000 * kSize),
                    (float)(y0 + Math.Sin(rad) * 2000 * kSize));

                pen = new Pen(Color.DarkBlue, 3);

                for (int i = 0; i < _lines.Count; i++)
                {
                    var point1 = _lines[i].point1;
                    var point2 = _lines[i].point2;

                    g.DrawLine(pen,
                        (float)(x0 - (Math.Cos(rad) * point1.X - Math.Cos(rad) * point1.Y) * scale),
                        (float)(y0 + (Math.Sin(rad) * point1.X + Math.Sin(rad) * point1.Y - point1.Z) * scale),
                        (float)(x0 - (Math.Cos(rad) * point2.X - Math.Cos(rad) * point2.Y) * scale),
                        (float)(y0 + (Math.Sin(rad) * point2.X + Math.Sin(rad) * point2.Y - point2.Z) * scale));
                }

                lblScale.Text = lblScale.Text.Substring(0, 6) + " " + Math.Round(scale, 2);

                picAxon.Image = image;
            }
            catch (Exception)
            { }
        }

        // Build orthogonal projections
        private void BuildOrthogonalProjection(object sender, EventArgs e)
        {
            try
            {
                IsBuild = true;

                int cX = picOrhtog.Width;
                int cY = picOrhtog.Height;

                Bitmap image = new Bitmap(picOrhtog.Width, picOrhtog.Height);
                Graphics g = Graphics.FromImage(image);
                Pen pen = new Pen(Color.Black);

                // xyyz
                g.DrawString("X", new Font("Arial", 12.0f), new SolidBrush(Color.ForestGreen), new PointF(0, cY / 2));
                g.DrawString("Z", new Font("Arial", 12.0f), new SolidBrush(Color.ForestGreen), new PointF(cX / 2, 0));
                g.DrawString("Y", new Font("Arial", 12.0f), new SolidBrush(Color.ForestGreen), new PointF(cX - 20, cY / 2));
                g.DrawString("Y", new Font("Arial", 12.0f), new SolidBrush(Color.ForestGreen), new PointF(cX / 2, cY - 20));

                // axis
                g.DrawLine(pen, 0, cY / 2, cX, cY / 2);
                g.DrawLine(pen, cX / 2, 0, cX / 2, cY);

                pen = new Pen(Color.DarkBlue, 3);
                int x0 = cX / 2;
                int y0 = cY / 2;

                for (int i = 0; i < _lines.Count; i++)
                {
                    var point1 = _lines[i].point1;
                    var point2 = _lines[i].point2;

                    Point pointAxon1 = new Point(x0 - (int)(point1.X * scale), y0 + (int)(point1.Y * scale));
                    Point pointAxon2 = new Point(x0 - (int)(point2.X * scale), y0 + (int)(point2.Y * scale));
                    g.DrawLine(pen, pointAxon1, pointAxon2);

                    pointAxon1 = new Point(x0 - (int)(point1.X * scale), y0 - (int)(point1.Z * scale));
                    pointAxon2 = new Point(x0 - (int)(point2.X * scale), y0 - (int)(point2.Z * scale));
                    g.DrawLine(pen, pointAxon1, pointAxon2);

                    pointAxon1 = new Point(x0 + (int)(point1.Y * scale), y0 - (int)(point1.Z * scale));
                    pointAxon2 = new Point(x0 + (int)(point2.Y * scale), y0 - (int)(point2.Z * scale));
                    g.DrawLine(pen, pointAxon1, pointAxon2);

                }

                lblScale.Text = lblScale.Text.Substring(0, 6) + " " + Math.Round(scale, 2);

                picOrhtog.Image = image;
            }
            catch (Exception)
            { }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (IsBuild)
            {
                btnBuildAxonom.Invoke(new Action(() => BuildOrthogonalProjection(sender, e)));
                btnBuildAxonom.Invoke(new Action(() => BuildAxonometry(sender, e)));

                GC.Collect();
            }
        }
        #endregion

        #region ImportFromExcel
        private void ImportExcelData()
        {
            try
            {
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(path);
                Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                Excel.Range xlRange = xlWorksheet.UsedRange;

                int i, j = 0;
                for (i = 2; xlRange.Cells[i, 1].Value2 != null && xlRange.Cells[i, 1].Value2.ToString() != "&index&"; i++)
                {
                    var point = new Point3D();

                    for (j = 1; j <= 4; j++)
                    {
                        if (xlRange.Cells[i, j] != null && xlRange.Cells[i, j].Value2 != null)
                        {
                            var result = 0d;
                            var t = xlRange.Cells[i, j].Value2;
                            if (t.ToString() == "&index&") break;
                            if (double.TryParse(t.ToString(), out result))
                            {
                                switch (j)
                                {
                                    case 1: point.Index = (int)result; break;
                                    case 2: point.X = result; break;
                                    case 3: point.Y = result; break;
                                    case 4: point.Z = result; break;
                                }
                            }
                            else
                            {
                                throw new Exception("Ошибка чтения формата");
                            }
                        }
                        else
                        {
                            throw new Exception("Ошибка чтения формата");
                        }
                    }
                    _points.Add(point);
                    dtgPoints.Rows.Add(point.Index, point.X, point.Y, point.Z);
                }

                btnSetPoints_Click(new UserControl(), new EventArgs());
                int count = 0;
                var x = xlRange.Find("&index&");
                for (i = 1 + x.Row; xlRange.Cells[i, 1].Value2 != null; i++)
                {
                    var line = new Line();

                    for (j = x.Column; j < x.Column + 3; j++)
                    {
                        if (xlRange.Cells[i, j] != null && xlRange.Cells[i, j].Value2 != null)
                        {
                            var result = 0d;
                            var t = xlRange.Cells[i, j].Value2;
                            if (double.TryParse(t.ToString(), out result))
                            {
                                switch (j)
                                {
                                    case 2: line.point1 = _points.First(p => p.Index == result); break;
                                    case 3: line.point2 = _points.First(p => p.Index == result); break;
                                }
                            }
                            else
                            {
                                throw new Exception("Ошибка чтения формата");
                            }
                        }
                        else
                        {
                            throw new Exception("Ошибка чтения формата");
                        }
                    }
                    _lines.Add(line);
                    dtgLines.Rows.Add(count++, line.point1.Index.ToString(), line.point2.Index.ToString());
                }
                IsBuild = true;
                btnSetLines_Click(new UserControl(), new EventArgs());
                MainForm_Resize(this, new EventArgs());


                GC.Collect();
                GC.WaitForPendingFinalizers();
                xlWorkbook.Close();
                Marshal.ReleaseComObject(xlWorkbook);
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);
            }
            catch (COMException exc)
            {
                MessageBox.Show(exc.Message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                foreach (var p1 in Process.GetProcessesByName("Excel")) p1.Kill();
            }
        }
        #endregion

        #region Menu Buttons

        private string path;
        private void excelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var t = new OpenFileDialog();
            t.Multiselect = false;
            t.DefaultExt = ".xlsx";
            t.Filter = "*.xlsx|*.xlsx";
            t.InitialDirectory = Environment.CurrentDirectory;
            t.ShowDialog();
            if (t.SafeFileName == String.Empty) return;
            if (t.FileName.EndsWith("xlsx"))
            {
                clearBtn_Click(sender, e);
                path = t.FileName;

                ImportExcelData();
            }
            else
                MessageBox.Show("Выбранный формат не поддерживается программой", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void сПРАВКАToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Приложение для построения каркасных моделей и их ортогональных проекций.\n" +
                "Построение происходит по заданным точкам и линиям. Для загрузки данных из Excel'я необходимо " +
                "задать точки в файле data.xlsx, который должен быть расположен в директории программы.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnResetScale_Click(object sender, EventArgs e)
        {
            scale = 3f;
            MainForm_Resize(sender, e);
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            picAxon.Image = null;
            picOrhtog.Image = null;
            dtgLines.Rows.Clear();
            dtgPoints.Rows.Clear();
            _points.Clear();
            _lines.Clear();
        }

        private void btnBuildAxonom_Click(object sender, EventArgs e)
        {
            lblScale.Text = lblScale.Text.Substring(0, 6) + " " + Math.Round(scale, 2);
        }
        #endregion
    }
}