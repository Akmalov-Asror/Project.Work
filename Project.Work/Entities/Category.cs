﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Work.Entities;

public class Category
{
    public Guid Id { get; set; }
    public string? CategoryName { get; set; }
}