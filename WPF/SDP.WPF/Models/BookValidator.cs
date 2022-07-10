using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP.WPF.Models
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(b => b.InventoryNumber)
                .NotEmpty().WithMessage("Inventory number can't be empty.")
                .GreaterThan(9999).WithMessage("Inventory number must have 5 digits.")
                .LessThan(100000).WithMessage("Inventory number must have 5 digits.");
            RuleFor(b => b.Title)
                .NotEmpty().WithMessage("Title can't be empty.");
            RuleFor(b => b.Author)
                .NotEmpty().WithMessage("Author can't be empty.");
            RuleFor(b => b.YearPublisher)
                .NotEmpty().WithMessage("Year / Publisher can't be empty.");
            RuleFor(b => b.Price)
                .NotEmpty().WithMessage("Price cannot be empty")
                .GreaterThan(0).WithMessage("A book must have a price");
        }
    }
}
