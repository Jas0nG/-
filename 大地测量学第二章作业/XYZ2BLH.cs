using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace 大地测量学第二章作业
{
    class XYZ2BLH
    {
        static void Text(string src, double[] a)//文件读取并存入数组
        {
            StreamReader streamReader = new StreamReader(src);
            String[] fileLines = System.IO.File.ReadAllLines(src);
            for (int i = 0; i < 14435; i++)
            {
                a[i] = Convert.ToDouble(fileLines[i]);
            }
        }
        static void Trans2_BLH(double[] x, double[] y, double[] z,double[] b, double[] l, double[] h,int i,double n,int t)
        {
            
            for (int u = 0; u < t + 1; u++)
            {
                
                double a = 6378137;//WGS84长半径
                double f = 0.003352810664;//WGS84扁率
                double e2 = f * (2 - f);
                double p = Math.Sqrt((x[i] * x[i]) + (y[i] * y[i]));
                l[i] = Math.Atan((y[i]/x[i]));
                h[i] = (z[i] / Math.Sin(b[i]) - (n * (1 - e2)));
                b[i] = Math.Atan((z[i] / p) * (1 / (1 - (e2 * (n / (n + h[i]))))));
                n = a / Math.Sqrt(1 - (e2 * (Math.Sin(b[i]) * Math.Sin(b[i]))));
            }
        }
        
        static void Main(string[] args)
        {
            double[] XYZ_X = new double[14436];
            double[] XYZ_Y = new double[14436];
            double[] XYZ_Z = new double[14436];
            double[] BLH_B = new double[14436];
            double[] BLH_L = new double[14436];
            double[] BLH_H = new double[14436];
            StreamWriter sw = new StreamWriter(@"D:\DATA\XYZ2BLH\RES.txt");
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
               
                Console.Write(i+1);
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
}
