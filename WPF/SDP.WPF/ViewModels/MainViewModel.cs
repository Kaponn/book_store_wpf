using SDP.WPF.Commands;
using SDP.WPF.DataAccess.Implementation;
using SDP.WPF.DataAccess.Interface;
using SDP.WPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SDP.WPF.ViewModels
{
    class MainViewModel
    {
        private readonly IDialogService _dialogService;
        private readonly JsonBookReader _jsonBookReader;
        private readonly ISourceOperationStrategy _sourceOperations;
        public ObservableCollection<Book> Books
        {
            get;
            set;
        }
        public MainViewModel(IDialogService dialogService, ISourceOperationStrategy sourceOperations)
        {
            _dialogService = dialogService;
            _sourceOperations = sourceOperations;
            Books = new ObservableCollection<Book>();
            NewBook = new Book();
            AddBook = new RelayCommand(param => AddNewBook());
            OpenFile = new RelayCommand(param => LoadDataFromFile());
            SaveFile = new RelayCommand(param => WriteDataToFile());
        }

        public Book NewBook
        {
            get;
            set;
        }
        public ICommand AddBook
        {
            get;
            private set;
        }
        private void AddNewBook()
        {
            if (NewBook.IsValid)
            {
                Books.Add(new Book(NewBook));
            }
        }
        public ICommand OpenFile
        {
            get;
            private set;
        }
        private void LoadDataFromFile()
        {
            var fileName = _dialogService.OpenFileDialog();
            if (fileName != null)
            {
                List<Book> bookList = _sourceOperations.GetReader(fileName).ReadBooks(fileName);
                Books.Clear();
                foreach (Book book in bookList)
                {
                    Books.Add(book);
                }
            }
        }

        private void WriteDataToFile()
        {
            var fileName = _dialogService.SaveFileDialog();


            if (fileName != null)
            {
                _sourceOperations.GetWriter(fileName).WriteBooks(fileName, Books.ToList());
            }

        }

        public ICommand SaveFile
        {
            get;
            private set;
        }
    }
}