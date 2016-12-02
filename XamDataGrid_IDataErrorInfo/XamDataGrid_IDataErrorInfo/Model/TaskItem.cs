using System;
using XamDataGrid_IDataErrorInfo.Infrastructure;

namespace XamDataGrid_IDataErrorInfo.Model
{
    class TaskItem : NotificationObject
    {
        private int _id;
        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }
        private string _title;
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }
        private DateTime _due;
        public DateTime Due
        {
            get
            {
                return _due;
            }
            set
            {
                _due = value;
                OnPropertyChanged();
            }
        }
        private bool _isCompleted;
        public bool IsCompleted
        {
            get
            {
                return _isCompleted;
            }
            set
            {
                _isCompleted = value;
                OnPropertyChanged();
            }
        }
    }
}
