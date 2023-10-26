using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABA8
{



    class CommunalPayments
    {
        // Массив для хранения базовых тарифов
        private double[] utilityRates = new double[4];

        public CommunalPayments()
        {
            // Инициализация базовых тарифов (по умолчанию)
            HeatingRate = 5.0;  // Тариф на отопление (1 м2)
            WaterRate = 2.0;    // Тариф на воду (1 чел)
            GasRate = 1.0;      // Тариф на газ (1 чел)
            RepairRate = 3.0;   // Тариф на текущий ремонт (1 м2)
        }

        // Индексатор для доступа к базовым тарифам
        public double this[int index]
        {
            get
            {
                if (index >= 0 && index < utilityRates.Length)
                {
                    return utilityRates[index];
                }
                else
                {
                    Console.WriteLine("Недопустимый индекс.");
                    return 0;
                }
            }
            set
            {
                if (index >= 0 && index < utilityRates.Length)
                {
                    utilityRates[index] = value * value; // Возводим в квадрат
                }
                else
                {
                    Console.WriteLine("Недопустимый индекс.");
                }
            }
        }

        // Свойства для базовых тарифов
        public double HeatingRate { get; set; }
        public double WaterRate { get; set; }
        public double GasRate { get; set; }
        public double RepairRate { get; set; }

        // Метод для расчета коммунальных платежей
        public void CalculatePayments(double area, int residents, bool isWinter, bool hasBenefits)
        {
            Console.WriteLine("Вид платежа\tНачислено\tЛьготная скидка\tИтого");

            // Расчет стоимости отопления
            double heatingCost = HeatingRate * area * (isWinter ? 1.5 : 1);
            double heatingDiscount = hasBenefits ? 0.3 : 0; // 30% скидка при наличии льгот
            double totalHeatingCost = heatingCost * (1 - heatingDiscount);

            // Расчет стоимости водоснабжения
            double waterCost = WaterRate * residents;
            double waterDiscount = hasBenefits ? 0.3 : 0;
            double totalWaterCost = waterCost * (1 - waterDiscount);

            // Расчет стоимости газа
            double gasCost = GasRate * residents;
            double gasDiscount = hasBenefits ? 0.3 : 0;
            double totalGasCost = gasCost * (1 - gasDiscount);

            // Расчет стоимости текущего ремонта
            double repairCost = RepairRate * area;
            double repairDiscount = hasBenefits ? 0.3 : 0;
            double totalRepairCost = repairCost * (1 - repairDiscount);

            // Итоговая стоимость
            double totalPayment = totalHeatingCost + totalWaterCost + totalGasCost + totalRepairCost;

            // Вывод результатов
            Console.WriteLine($"Отопление\t{heatingCost}\t{(hasBenefits ? "30%" : "0%")}\t{totalHeatingCost}");
            Console.WriteLine($"Вода\t{waterCost}\t{(hasBenefits ? "30%" : "0%")}\t{totalWaterCost}");
            Console.WriteLine($"Газ\t{gasCost}\t{(hasBenefits ? "30%" : "0%")}\t{totalGasCost}");
            Console.WriteLine($"Ремонт\t{repairCost}\t{(hasBenefits ? "30%" : "0%")}\t{totalRepairCost}");
            Console.WriteLine($"Итого:\t{totalPayment}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CommunalPayments communal = new CommunalPayments();

            // Устанавливаем базовые тарифы через индексаторы
            communal[0] = 5.0; // Отопление
            communal[1] = 2.0; // Вода
            communal[2] = 1.0; // Газ
            communal[3] = 3.0; // Ремонт

            // Ввод данных
            Console.WriteLine("Введите площадь помещения (кв. м):");
            double area = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите количество проживающих:");
            int residents = int.Parse(Console.ReadLine());

            Console.WriteLine("Зимний сезон (да/нет):");
            bool isWinter = Console.ReadLine().ToLower() == "да";

            Console.WriteLine("Есть ли льготы (да/нет):");
            bool hasBenefits = Console.ReadLine().ToLower() == "да";

            // Расчет коммунальных платежей и вывод результатов
            communal.CalculatePayments(area, residents, isWinter, hasBenefits);

            Console.ReadLine();
        }
    }
}