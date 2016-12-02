using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using XamDataGrid_IDataErrorInfo.Model;

namespace XamDataGrid_IDataErrorInfo.ViewModel
{
    class MainViewModel
    {
        public ObservableCollection<TaskItem> Tasks { get; set; }

        public List<OrderEntry> Orders { get; set; }

        public MainViewModel()
        {
            #region データ作成

            List<OrderEntry> orders = new List<OrderEntry>();
            
            orders.Add(new OrderEntry("Anti-Wrinkle Cream", 5, 2));
            orders.Add(new OrderEntry("Body Moisturizing Spray", 0, 1));
            orders.Add(new OrderEntry("Bronze Self-Tanning Kit", 9.99m, 1));
            orders.Add(new OrderEntry("Blusher Brush", 4, -1));
            orders.Add(new OrderEntry("Compact Refill", 5, 1));
            orders.Add(new OrderEntry("Day Cream with Vitamin E", 6, 3));
            orders.Add(new OrderEntry("Dermocleansing Lotion", 0, 0));
            orders.Add(new OrderEntry("Duo Eyeshadow Applicator", 3, -2));
            orders.Add(new OrderEntry("Eyelash Adhesive", 2, 1));
            orders.Add(new OrderEntry("Eyeshadow, waterproof", 7, 1));

            this.Orders = new List<OrderEntry>();
            this.Orders = orders;

            #endregion
        }
    }
}
