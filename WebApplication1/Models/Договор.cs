//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Договор
    {
        [Key, ForeignKey("Спортсмен")]
        public int Номер_договора { get; set; }
        public Nullable<System.DateTime> Дата_заключения { get; set; }
        public Nullable<decimal> Стоимость { get; set; }
        public Nullable<long> Серия_и_номер_паспорта { get; set; }
        public Nullable<System.DateTime> Дата_выдачи_паспорта { get; set; }
        public string Кем_выдан_паспорт { get; set; }
        public Nullable<System.DateTime> Срок_действия_договора { get; set; }
        public Nullable<int> ID_Группы { get; set; }
    
        public virtual Секция Секция { get; set; }
        public virtual Спортсмен Спортсмен { get; set; }
    }
}
