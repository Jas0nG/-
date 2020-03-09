using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace XYZ2BLH
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
     


        public void button1_Click(object sender, EventArgs e)
        {
            Main();
            void Text(string src, double[] a)//文件读取并存入数组
            {
                StreamReader streamReader = new StreamReader(src);
                String[] fileLines = System.IO.File.ReadAllLines(src);
                for (int i = 0; i < 14435; i++)
                {
                    a[i] = Convert.ToDouble(fileLines[i]);
                }
            }
            void Trans2_BLH(double[] x, double[] y, double[] z, double[] b, double[] l, double[] h, int i, double n, int t)
            {

                for (int u = 0; u < t + 1; u++)
                {

                    double a = 6378137;//WGS84长半径
                    double f = 0.003352810664;//WGS84扁率
                    double e2 = f * (2 - f);
                    double p = Math.Sqrt((x[i] * x[i]) + (y[i] * y[i]));
                    l[i] = Math.Atan((y[i] / x[i]));
                    h[i] = (z[i] / Math.Sin(b[i]) - (n * (1 - e2)));
                    b[i] = Math.Atan((z[i] / p) * (1 / (1 - (e2 * (n / (n + h[i]))))));
                    n = a / Math.Sqrt(1 - (e2 * (Math.Sin(b[i]) * Math.Sin(b[i]))));
                }
            }

            void Main()
            {
                double[] XYZ_X = new double[14436];
                double[] XYZ_Y = new double[14436];
                double[] XYZ_Z = new double[14436];
                double[] BLH_B = new double[14436];
                double[] BLH_L = new double[14436];
                double[] BLH_H = new double[14436];
                StreamWriter sw = new StreamWriter(@"D:\DATA\XYZ2BLH\RES2.txt");
                Console.SetOut(sw);

                double a = 6378137;//WGS84长半径
                double f = 0.003352810664;//WGS84扁率

                string coor_X = @"D:\DATA\XYZ2BLH\XYZ_X.txt";
                string coor_Y = @"D:\DATA\XYZ2BLH\XYZ_Y.txt";
                string coor_Z = @"D:\DATA\XYZ2BLH\XYZ_Z.txt";
                double rad2deg = 180 / Math.PI;
                Text(coor_X, XYZ_X);
                Text(coor_Y, XYZ_Y);
                Text(coor_Z, XYZ_Z);
                /* for (int i = 0; i < 50; i++)
                 {
                     Console.WriteLine(XYZ_X[i]);
                         }*/
                //Console.WriteLine("数据读取成功！");
                //Console.WriteLine("按任意键继续！");
                //Console.ReadKey();
                for (int i = 0; i < 14435; i++)
                {
                    Trans2_BLH(XYZ_X, XYZ_Y, XYZ_Z, BLH_B, BLH_L, BLH_H, i, 0, 50);
                }

                for (int i = 0; i < 14435; i++)
                {
                    BLH_B[i] = BLH_B[i] * rad2deg;
                    BLH_L[i] = BLH_L[i] * rad2deg;

                    Console.Write(i + 1);
                    Console.Write(",");
                    //Console.Write("号点转换为BLH为：");
                    Console.Write(BLH_B[i]);
                    Console.Write(",");
                    Console.Write(BLH_L[i]);
                    Console.Write(",");
                    Console.Write(BLH_H[i]);
                    Console.WriteLine();


                }
                sw.Flush();
                sw.Close();
                // Console.ReadKey();
            }
        }

        public void button2_Click(object sender, EventArgs e)
        {
            Main();
            void Text(string src, double[] a)//文件读取并存入数组
            {
                StreamReader streamReader = new StreamReader(src);
                String[] fileLines = System.IO.File.ReadAllLines(src);
                for (int i = 0; i < 14435; i++)
                {
                    a[i] = Convert.ToDouble(fileLines[i]);
                }
            }
            void Trans2_BLH(double[] x, double[] y, double[] z, double[] b, double[] l, double[] h, int i, double n, int t)
            {

                for (int u = 0; u < t + 1; u++)
                {

                    double a = 6378137;//WGS84长半径
                    double f = 0.003352810664;//WGS84扁率
                    double e2 = f * (2 - f);
                    double p = Math.Sqrt((x[i] * x[i]) + (y[i] * y[i]));
                    l[i] = Math.Atan((y[i] / x[i]));
                    h[i] = (z[i] / Math.Sin(b[i]) - (n * (1 - e2)));
                    b[i] = Math.Atan((z[i] / p) * (1 / (1 - (e2 * (n / (n + h[i]))))));
                    n = a / Math.Sqrt(1 - (e2 * (Math.Sin(b[i]) * Math.Sin(b[i]))));
                }
            }

            void Main()
            {
                double[] XYZ_X = new double[14436];
                double[] XYZ_Y = new double[14436];
                double[] XYZ_Z = new double[14436];
                double[] BLH_B = new double[14436];
                double[] BLH_L = new double[14436];
                double[] BLH_H = new double[14436];
                string coor_X = @"D:\DATA\XYZ2BLH\XYZ_X.txt";
                string coor_Y = @"D:\DATA\XYZ2BLH\XYZ_Y.txt";
                string coor_Z = @"D:\DATA\XYZ2BLH\XYZ_Z.txt";
                double rad2deg = 180 / Math.PI;
                Text(coor_X, XYZ_X);
                Text(coor_Y, XYZ_Y);
                Text(coor_Z, XYZ_Z);
                for (int i = 0; i < 14435; i++)
                {
                    Trans2_BLH(XYZ_X, XYZ_Y, XYZ_Z, BLH_B, BLH_L, BLH_H, i, 0, 50);
                }

                for (int i = 0; i < 14435; i++)
                {
                    BLH_B[i] = BLH_B[i] * rad2deg;
                    BLH_L[i] = BLH_L[i] * rad2deg;       

                }
                Graphics g = CreateGraphics();
                Point[] pot = new Point[30000];
                Pen pen = new Pen(Color.Orchid,3);
                for (int i = 0; i < 14436; i++)
                
                {
                   
                    pot[i].X =(Convert.ToInt32(BLH_L[i]*18000)-1000);
                    pot[i].Y= (Convert.ToInt32(BLH_B[i] * 13000)-5000);
                    pot[i+14436].X= (Convert.ToInt32(BLH_L[i] * 18000)+0-1000);
                    pot[i+14436].Y = (Convert.ToInt32(BLH_B[i] * 13000)+1-5000);

                    g.DrawLine(pen,pot[i],pot[i+14436] );
                }

          
            }
            

            
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        /*private void button3_Click(object sender, EventArgs e)
        {
            Main();
            void Text(string src, double[] a)//文件读取并存入数组
            {
                StreamReader streamReader = new StreamReader(src);
                String[] fileLines = System.IO.File.ReadAllLines(src);
                for (int i = 0; i < 14435; i++)
                {
                    a[i] = Convert.ToDouble(fileLines[i]);
                }
            }
            void Trans2_BLH(double[] x, double[] y, double[] z, double[] b, double[] l, double[] h, int i, double n, int t)
            {

                for (int u = 0; u < t + 1; u++)
                {

                    double a = 6378137;//WGS84长半径
                    double f = 0.003352810664;//WGS84扁率
                    double e2 = f * (2 - f);
                    double p = Math.Sqrt((x[i] * x[i]) + (y[i] * y[i]));
                    l[i] = Math.Atan((y[i] / x[i]));
                    h[i] = (z[i] / Math.Sin(b[i]) - (n * (1 - e2)));
                    b[i] = Math.Atan((z[i] / p) * (1 / (1 - (e2 * (n / (n + h[i]))))));
                    n = a / Math.Sqrt(1 - (e2 * (Math.Sin(b[i]) * Math.Sin(b[i]))));
                }
            }

            void Main()
            {
                double[] XYZ_X = new double[14436];
                double[] XYZ_Y = new double[14436];
                double[] XYZ_Z = new double[14436];
                double[] BLH_B = new double[14436];
                double[] BLH_L = new double[14436];
                double[] BLH_H = new double[14436];
                StreamWriter sw = new StreamWriter(@"D:\DATA\XYZ2BLH\RES2.txt");
                Console.SetOut(sw);

                double a = 6378137;//WGS84长半径
                double f = 0.003352810664;//WGS84扁率

                string coor_X = @"D:\DATA\XYZ2BLH\XYZ_X.txt";
                string coor_Y = @"D:\DATA\XYZ2BLH\XYZ_Y.txt";
                string coor_Z = @"D:\DATA\XYZ2BLH\XYZ_Z.txt";
                double rad2deg = 180 / Math.PI;
                Text(coor_X, XYZ_X);
                Text(coor_Y, XYZ_Y);
                Text(coor_Z, XYZ_Z);
                /* for (int i = 0; i < 50; i++)
                 {
                     Console.WriteLine(XYZ_X[i]);
                         }*/
                //Console.WriteLine("数据读取成功！");
                //Console.WriteLine("按任意键继续！");
                //Console.ReadKey();
               /* for (int i = 0; i < 14435; i++)
                {
                    Trans2_BLH(XYZ_X, XYZ_Y, XYZ_Z, BLH_B, BLH_L, BLH_H, i, 0, 50);
                }

                for (int i = 0; i < 14435; i++)
                {
                    BLH_B[i] = BLH_B[i] * rad2deg;
                    BLH_L[i] = BLH_L[i] * rad2deg;

                    Console.Write(i + 1);
                    Console.Write(",");
                    //Console.Write("号点转换为BLH为：");
                    Console.Write(BLH_B[i]);
                    Console.Write(",");
                    Console.Write(BLH_L[i]);
                    Console.Write(",");
                    Console.Write(BLH_H[i]);
                    Console.WriteLine();


                }
                sw.Flush();
                sw.Close();
                // Console.ReadKey();
            }
        }*/

        public void button3_Click(object sender, EventArgs e)
        {
            Main();
            void Text(string src, double[] a)//文件读取并存入数组
            {
                StreamReader streamReader = new StreamReader(src);
                String[] fileLines = System.IO.File.ReadAllLines(src);
                for (int i = 0; i < 14435; i++)
                {
                    a[i] = Convert.ToDouble(fileLines[i]);
                }
            }
            void Trans2_BLH(double[] x, double[] y, double[] z, double[] b, double[] l, double[] h, int i, double n, int t)
            {

                for (int u = 0; u < t + 1; u++)
                {

                    double a = 6378137;//WGS84长半径
                    double f = 0.003352810664;//WGS84扁率
                    double e2 = f * (2 - f);
                    double p = Math.Sqrt((x[i] * x[i]) + (y[i] * y[i]));
                    l[i] = Math.Atan((y[i] / x[i]));
                    h[i] = (z[i] / Math.Sin(b[i]) - (n * (1 - e2)));
                    b[i] = Math.Atan((z[i] / p) * (1 / (1 - (e2 * (n / (n + h[i]))))));
                    n = a / Math.Sqrt(1 - (e2 * (Math.Sin(b[i]) * Math.Sin(b[i]))));
                }
            }

            void Main()
            {
                double[] XYZ_X = new double[14436];
                double[] XYZ_Y = new double[14436];
                double[] XYZ_Z = new double[14436];
                double[] BLH_B = new double[14436];
                double[] BLH_L = new double[14436];
                double[] BLH_H = new double[14436];
                string coor_X = @"D:\DATA\XYZ2BLH\XYZ_X.txt";
                string coor_Y = @"D:\DATA\XYZ2BLH\XYZ_Y.txt";
                string coor_Z = @"D:\DATA\XYZ2BLH\XYZ_Z.txt";
                double rad2deg = 180 / Math.PI;
                Text(coor_X, XYZ_X);
                Text(coor_Y, XYZ_Y);
                Text(coor_Z, XYZ_Z);
                for (int i = 0; i < 14435; i++)
                {
                    Trans2_BLH(XYZ_X, XYZ_Y, XYZ_Z, BLH_B, BLH_L, BLH_H, i, 0, 50);
                }

                for (int i = 0; i < 14435; i++)
                {
                    BLH_B[i] = BLH_B[i] * rad2deg;
                    BLH_L[i] = BLH_L[i] * rad2deg;

                }
                Graphics g = CreateGraphics();
                Point[] pot = new Point[30000];
                Pen pen = new Pen(Color.DarkKhaki, 1);
                for (int i = 0; i < 14436; i++)

                {

                    pot[i].X = (Convert.ToInt32(BLH_H[i] * 2.5)-600 );
                    pot[i].Y = 200;
                    pot[i + 14436].X = (Convert.ToInt32(BLH_H[i] * 2.5)-600 );
                    pot[i + 14436].Y = 700;

                    g.DrawLine(pen, pot[i], pot[i + 14436]);
                }


            }
        }
    }
}

