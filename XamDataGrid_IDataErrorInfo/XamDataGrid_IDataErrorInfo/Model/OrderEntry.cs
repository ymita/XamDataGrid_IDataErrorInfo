using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamDataGrid_IDataErrorInfo.Infrastructure;

namespace XamDataGrid_IDataErrorInfo.Model
{
    public class OrderEntry : NotificationObject, IDataErrorInfo
    {
        #region Member Vars

        private string _productName;
        private decimal _price;
        private int _quantity;

        private string _dataError;
        private Dictionary<string, string> _dataErrors = new Dictionary<string, string>();

        #endregion

        #region Constructors

        public OrderEntry()
        {

        }

        public OrderEntry(string productName, decimal price, int quantity)
        {
            _productName = productName;
            _price = price;
            _quantity = quantity;

            this.ValidatePrice(false);
            this.ValidateProductName(false);
            this.ValidateQuantity(false);
        }

        #endregion // Constructors

        #region Public Properties

        #region Price

        public decimal Price
        {
            get
            {
                return _price;
            }
            set
            {
                if (_price != value)
                {
                    _price = value;

                    this.ValidatePrice(false);
                    OnPropertyChanged();
                }
            }
        }

        private void ValidatePrice(bool raiseNotification)
        {
            string error = null;
            if (_price <= 0)
                error = "価格は 0 以上にして下さい。";

            this.SetFieldDataError("Price", error, raiseNotification);
        }

        #endregion // Price

        #region ProductName

        public string ProductName
        {
            get
            {
                return _productName;
            }
            set
            {
                if (_productName != value)
                {
                    _productName = value;

                    this.ValidateProductName(false);
                    OnPropertyChanged();
                }
            }
        }

        private void ValidateProductName(bool raiseNotification)
        {
            string error = null;
            if (string.IsNullOrEmpty(_productName))
                error = "ProductName は空にはできません。";

            this.SetFieldDataError("ProductName", error, raiseNotification);
        }

        #endregion // ProductName

        #region Quantity

        public int Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                if (_quantity != value)
                {
                    _quantity = value;

                    this.ValidateQuantity(false);
                    OnPropertyChanged();
                }
            }
        }

        private void ValidateQuantity(bool raiseNotification)
        {
            string error = null;
            if (_quantity <= 0)
                error = "数量は 1 以上にして下さい。";

            this.SetFieldDataError("Quantity", error, raiseNotification);
        }

        #endregion // Quantity

        #endregion // Public Properties

        #region Public Methods

        #region GetFieldDataError

        public string GetFieldDataError(string fieldName)
        {
            string error;
            _dataErrors.TryGetValue(fieldName, out error);

            return error;
        }

        #endregion // GetFieldDataError

        #region GetRecordDataError

        public string GetRecordDataError()
        {
            return _dataError;
        }

        #endregion // GetRecordDataError

        #region HasDataError

        public bool HasDataError()
        {
            return !string.IsNullOrEmpty(_dataError)
                || null != _dataErrors && _dataErrors.Count > 0;
        }

        #endregion // HasDataError

        #region SetFieldDataError

        public void SetFieldDataError(string fieldName, string error, bool raiseNotification)
        {
            if (string.IsNullOrEmpty(error))
            {
                _dataErrors.Remove(fieldName);

                // If there are no field errors anymore, reset the record error as well.
                if (0 == _dataErrors.Count)
                    this.SetRecordDataError(null, true);
            }
            else
            {
                _dataErrors[fieldName] = error;

                this.SetRecordDataError("１つ以上のフィールドで無効な入力があります。", true);
            }

            if (raiseNotification)
                OnPropertyChanged();
        }

        #endregion // SetFieldDataError

        #region SetRecordDataError

        public void SetRecordDataError(string error, bool raiseNotification)
        {
            if (_dataError != error)
            {
                _dataError = error;

                if (raiseNotification)
                    OnPropertyChanged();
            }
        }

        #endregion // SetRecordDataError

        #endregion // Public Methods
        
        #region IDataErrorInfo Members

        string IDataErrorInfo.Error
        {
            get
            {
                return _dataError;
            }
        }

        string IDataErrorInfo.this[string fieldName]
        {
            get
            {
                return this.GetFieldDataError(fieldName);
            }
        }

        #endregion
    }
}
