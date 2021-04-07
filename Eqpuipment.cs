using System;
using Npoi.Mapper.Attributes;

namespace Import_Eqp
{
    /// <summary>
    /// Класс отвечает за импорт данных из Excel файла
    /// </summary>
    class Eqpuipment
    {

        /// <summary> Наименование оборудования </summary>
        [Column(0)]
        public string FullName { get; set; }

        /// <summary> Код </summary>
        /*[Column(1)]
        public int Code { get; set; }*/

        /// <summary> Наименование типа оборудования </summary> 
        [Column(2)]
        public string EqpTypeName { get; set; }

        /// <summary> Вид </summary>
        [Column(6)]
        public string EqpKindName { get; set; }

        /// <summary> Лаборатория владелец </summary>
        [Column(27)]
        public string EqpSubDivisions { get; set; }

        /// <summary> Состояние </summary>
        [Column(10)]
        public string EqpStateName { get; set; }

        /// <summary> Производитель </summary>
        [Column(4)]
        public string Mnf { get; set; }

        /// <summary> Заводской номер </summary>
        [Column(5)]
        public string MnfNum { get; set; }

        /// <summary> Дата выпуска </summary>
        [Column(7)]
        public DateTime MnfDateStr { get; set; }

        /// <summary> Технические характеристики </summary>
        /*[Column(25)]
        public string TechnicalProps { get; set; }*/

        /// <summary> Право собственности </summary>
        [Column(10)]
        public string LegalBasis { get; set; }

        /// <summary> Инвентарный номер </summary>
        [Column(5)]
        public string InvNum { get; set; }

        /// <summary> Дата ввода в эксплуатацию </summary>
        [Column(8)]
        public DateTime StartUpDateStr { get; set; }

        /// <summary> Место установки </summary>
        [Column(29)]
        public string Location { get; set; }

        /// <summary> Ответственный </summary>
        [Column(27)]
        public string UserId { get; set; }

        /// <summary> Назначение </summary>
        //[Column(18)]
        //public string Purpose { get; set; }

        /// <summary> Входит в область аккредитации </summary>
        [Column(30)]
        public byte InScopeAccreditation { get; set; }

        /// <summary> Примечание </summary>
        /*[Column(15)]
        public string Note { get; set; }*/

        /// <summary> Тип регламентных работ </summary>
        [Column(16)]
        public string EqpCheckTypeName { get; set; }

        /// <summary> Дата проведения </summary>
        [Column(9)]
        public DateTime CheckDateStr { get; set; }

        /// <summary> Периодичность (значение) </summary>
        [Column(18)]
        public int IntervalLenStr { get; set; }

        /// <summary> Периодичность (тип интервала) </summary>
        [Column(17)]
        public string IntervalTypeName { get; set; }

        /// <summary> Дата следующего проведения </summary>
        [Column(11)]
        public DateTime NextDateStr { get; set; }

        /// <summary> Место проведения проверки </summary>
        [Column(28)]
        public string ECLPlace { get; set; }

        /// <summary> Примечание проверки </summary>
        /*[Column(14)]
        public string ECLComment { get; set; }*/

        /// <summary> Документ </summary>
        [Column(19)]
        public string ECLDoc { get; set; }

        /// <summary> Определяемые характеристики </summary>
        [Column(20)]
        public string PropValueStr { get; set; }

        /// <summary> Диапазон измерений </summary>
        [Column(22)]
        public string EqpTestLimitName { get; set; }

        /// <summary> Класс точности </summary>
        /*[Column(30)]
        public string AccuracyClass { get; set; }*/

        /// <summary> Погрешность </summary>
        /*[Column(24)]
        public string Accuracy { get; set; }*/

        /// <summary> Единица измерения </summary>
        /*[Column(23)]
        public string EngUnitName { get; set; }*/

        /// <summary> Цена деления </summary>
        /*[Column(21)]
        public string ScaleInterval { get; set; }*/

        /// <summary> Проводить оперативный контроль после регламентных работ </summary>
        /*[Column(20)]
        public byte UseOperationControl { get; set; }*/

        /// <summary> Ответ службы </summary>
        [Ignore]
        public string Service_Response { get; set; } 

    }
}
