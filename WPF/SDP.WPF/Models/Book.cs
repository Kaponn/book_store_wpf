using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP.WPF.Models
{
    public class Book : BindableBase, IDataErrorInfo
    {
        private int _inventoryNumber;
        private string _author;
        private string _title;
        private string _yearPublisher;
        private decimal _price;
        public int InventoryNumber
        {
            get => _inventoryNumber;
            set
            {
                _inventoryNumber = value;
                OnPropertyChanged();
            }
        }
        public string Author
        {
            get => _author;
            set
            {
                _author = value;
                OnPropertyChanged();
            }
        }
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }
        public string YearPublisher
        {
            get => _yearPublisher;
            set
            {
                _yearPublisher = value;
                OnPropertyChanged();
            }
        }
        public decimal Price
        {
            get => _price;
            set
            {
                _price = value;
                OnPropertyChanged();
            }
        }
        public void Clear()
        {
            InventoryNumber = 0;
            Author = string.Empty;
            Title = string.Empty;
            YearPublisher = string.Empty;
            Price = 0;
        }
        public Book(Book book) : this()
        {
            InventoryNumber = book.InventoryNumber;
            Author = book.Author;
            Title = book.Title;
            YearPublisher = book.YearPublisher;
            Price = book.Price;
        }
        public Book()
        {
            _bookValidator = new BookValidator();
        }


        private readonly BookValidator _bookValidator;
        public bool IsValid
        {
            get => _bookValidator.Validate(this).IsValid;
        }
        ////////////////////////////////////
        public string Error
        {
            get
            {
                if (_bookValidator != null)
                {
                    var results = _bookValidator.Validate(this);
                    if (results != null && results.Errors.Any())
                    {
                        var errors =
                        String.Join(Environment.NewLine, results.Errors.Select(x => x.ErrorMessage).ToArray());
                        return errors;
                    }
                }

                return String.Empty;
            }
        }
        ////////////////////////////////////
        public string this[string columnName]
        {
            get
            {
                var firstOrDefault = _bookValidator.Validate(this)
                .Errors.FirstOrDefault(lol => lol.PropertyName == columnName);
                if (firstOrDefault != null)
                    return _bookValidator != null ? firstOrDefault.ErrorMessage : String.Empty;
                return String.Empty;
            }
        }
    }
}
