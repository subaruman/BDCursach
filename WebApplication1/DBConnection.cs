﻿using System.Data.Entity;
using WebApplication1.Models;

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

    public DbSet<Спортсмен> Спортсмен { get; set; }

    public DbSet<Спортивный_клуб> Спортивный_клуб { get; set; }

    public DbSet<Соревнования> Соревнования { get; set; }

    public DbSet<Сотрудники> Сотрудники { get; set; }
}
