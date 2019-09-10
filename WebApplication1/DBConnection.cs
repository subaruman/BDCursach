using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

public class DBConnection : DbContext
{
    // You can add custom code to this file. Changes will not be overwritten.
    // 
    // If you want Entity Framework to drop and regenerate your database
    // automatically whenever you change your model schema, please use data migrations.
    // For more information refer to the documentation:
    // http://msdn.microsoft.com/en-us/data/jj591621.aspx

    public DBConnection() : base("name=DBConnection")
    {
    }

    public System.Data.Entity.DbSet<WebApplication1.Models.Договор> Договор { get; set; }

    public System.Data.Entity.DbSet<WebApplication1.Models.Секция> Секция { get; set; }

    public System.Data.Entity.DbSet<WebApplication1.Models.Спортсмен> Спортсмен { get; set; }

    public System.Data.Entity.DbSet<WebApplication1.Models.Владелец> Владелец { get; set; }

    public System.Data.Entity.DbSet<WebApplication1.Models.Спортивный_клуб> Спортивный_клуб { get; set; }

    public System.Data.Entity.DbSet<WebApplication1.Models.Подготовка_к_соревнованиям> Подготовка_к_соревнованиям { get; set; }

    public System.Data.Entity.DbSet<WebApplication1.Models.Тренер> Тренер { get; set; }

    public System.Data.Entity.DbSet<WebApplication1.Models.Результат> Результат { get; set; }

    public System.Data.Entity.DbSet<WebApplication1.Models.Соревнования> Соревнования { get; set; }

    public System.Data.Entity.DbSet<WebApplication1.Models.Сотрудники> Сотрудники { get; set; }
}
