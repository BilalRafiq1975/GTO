
using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.OpenApi.MicrosoftExtensions;

namespace TaskMangmentSystem.Models;

public class Task{
    public int Id {get; set;}

    [Required(ErrorMessage = "Title is required.")]
    [MinLength(3, ErrorMessage = "Title must be atleast 3 characters long.")]
    [MaxLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
    public string Title {get; set;}

    [MaxLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
    public string Description {get; set;}

    [Required(ErrorMessage = "Due date is required")]
    [DataType(DataType.DateTime, ErrorMessage = "Invalid date format.")]
    [FutureDate(ErrorMessage = "Due date must be in the future." )]
    public DateTime DueDate {get; set;}

    [Required(ErrorMessage = "User ID is required.")]
    public int UserId {get; set;}
    public User User {get; set;}    
}


public class FutureDateAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is DateTime dateTime)
        {
            if (dateTime < DateTime.Now)
            {
                return new ValidationResult(ErrorMessage ?? "The date must be in the future.");
            }
        }
        return ValidationResult.Success;
    }
}

