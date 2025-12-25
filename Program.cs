using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Function_lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            Console.WriteLine("กรอกตัวเลขที่ต้องการ (พิมพ์ 'q' เพื่อตกลง):");

            while (true)
            {
                string inputA = Console.ReadLine();
                if (inputA.ToLower() == "q") break;

                if (int.TryParse(inputA, out int a))
                {
                    numbers.Add(a);
                }
                else
                {
                    Console.WriteLine("กรุณากรอกเฉพาะตัวเลขครับ");
                }
            }

            if (numbers.Count > 0)
            {
                DisplayStatistics(numbers);
            }
            else
            {
                Console.WriteLine("ไม่มีข้อมูลในการคำนวณ");
            }
        }

        static void DisplayStatistics(List<int> data)
        {
            // คำนวณค่าต่างๆ ค่าเฉลี่ย ค่าสูงสุด ค่าต่ำสุด ค่ากลางข้อมูล
            double mean = data.Average();
            int max = data.Max();
            int min = data.Min();
            double median = GetMedian(data);

            // เรียงลำดับข้อมูล
            var descOrder = data.OrderByDescending(n => n).ToList();
            var ascOrder = data.OrderBy(n => n).ToList();

            // แสดงผล
            Console.WriteLine("\n--- ผลลัพธ์การคำนวณ ---");
            Console.WriteLine($"1. ค่าเฉลี่ย (Mean): {mean:F2}");
            Console.WriteLine($"2. ค่าสูงสุด (Max): {max}");
            Console.WriteLine($"3. ค่าต่ำสุด (Min): {min}");
            Console.WriteLine($"4. ค่ากลาง (Median): {median}");
            Console.WriteLine($"5. เรียงจากมากไปน้อย: {string.Join(", ", descOrder)}");
            Console.WriteLine($"6. เรียงจากน้อยไปมาก: {string.Join(", ", ascOrder)}");
        }

        static double GetMedian(List<int> data)
        {
            var sorted = data.OrderBy(n => n).ToList();
            int count = sorted.Count;
            if (count % 2 == 0)
            {
                return (sorted[(count / 2) - 1] + sorted[count / 2]) / 2.0;
            }
            return sorted[count / 2];
        }
    }
    
}
